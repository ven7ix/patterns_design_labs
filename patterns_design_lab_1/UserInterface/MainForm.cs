using patterns_design_lab_1.Geometry;
using patterns_design_lab_1.UserInterface;
using patterns_design_lab_1.Visual;
using patterns_design_lab_1.Visual.Shemes;
using Point = patterns_design_lab_1.Geometry.Point;

namespace patterns_design_lab_1
{
    public partial class MainForm : Form, IGetGraphics
    {
        List<VisualCurve> visualCurves = [];
        readonly Random random = new();
        double angle = 0, scale = 1;
        Point delta = new(0, 0);
        readonly List<Func<ICurveVisualizationScheme, ICurveVisualizationScheme>> scheme_decorators = [];
        readonly ICurveVisualizationScheme dashed_scheme;

        public MainForm()
        {
            InitializeComponent();

            dashed_scheme = Decorate(new ShadowScheme(new DashedScheme(this, new Pen(Color.Black, 2)), new DashedScheme(this, new Pen(Color.Gray, 2)), new Point(3, 3)));
        }

        void PanelGreenScheme_Paint(object sender, PaintEventArgs e)
        {
            var scheme = Decorate(new GreenScheme(e.Graphics));

            foreach (VisualCurve curve in visualCurves)
            {
                curve.Draw(scheme);
            }
        }

        void PanelDashedScheme_Paint(object sender, PaintEventArgs e)
        {
            var scheme = Decorate(dashed_scheme);

            foreach (VisualCurve curve in visualCurves)
            {
                curve.Draw(scheme);
            }
        }

        void ButtonGenerate_Click(object sender, EventArgs e)
        {
            ButtonGreenSchemeSave.Enabled = true;
            ButtonDashedSchemeSave.Enabled = true;

            visualCurves = GenerateCurves();

            UpdateCurveChainComboBoxes();

            PanelGreenScheme.Invalidate();
            PanelDashedScheme.Invalidate();
        }

        List<VisualCurve> GenerateCurves()
        {
            int line_curves_count = random.Next(1, 4);
            int bezier_curves_count = random.Next(1, 4);
            var curves = new List<VisualCurve>(line_curves_count + bezier_curves_count);

            for (int i = 0; i < line_curves_count; i++)
            {
                curves.Add(new VisualCurve(new Line(
                    GenerateRandomPoint(600, 600),
                    GenerateRandomPoint(600, 600)
                    ), 2));
            }

            for (int i = 0; i < bezier_curves_count; i++)
            {
                curves.Add(new VisualCurve(new Bezier(
                    GenerateRandomPoint(600, 600),
                    GenerateRandomPoint(600, 600),
                    GenerateRandomPoint(600, 600),
                    GenerateRandomPoint(600, 600)
                    ), 100));
            }

            return curves;
        }

        Point GenerateRandomPoint(int width, int height)
        {
            double x = random.NextDouble() * width;
            double y = random.NextDouble() * height;

            return new Geometry.Point(x, y);
        }

        void SchemeSave_Click(SVGScheme scheme)
        {
            if (visualCurves.Count == 0)
            {
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "SVG file (*.svg)|*.svg"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            foreach (VisualCurve curve in visualCurves)
            {
                curve.Draw(scheme);
            }

            scheme.Save(dialog.FileName);
        }

        void ButtonGreenSchemeSave_Click(object sender, EventArgs e)
        {
            SchemeSave_Click(new SVGScheme(PanelGreenScheme.Width, PanelGreenScheme.Height, Color.Green, "stoke-width=\"2\" stroke-solid=\"6 3\" stroke-linecap=\"round\""));
        }

        void ButtonDashedSchemeSave_Click(object sender, EventArgs e)
        {
            SchemeSave_Click(new SVGScheme(PanelGreenScheme.Width, PanelGreenScheme.Height, Color.Black, "stoke-width=\"2\" stroke-dasharray=\"6 3\" stroke-linecap=\"round\""));
        }

        ICurveVisualizationScheme Decorate(ICurveVisualizationScheme scheme)
        {
            foreach (var decorate in scheme_decorators)
            {
                scheme = decorate(scheme);
            }

            return scheme;
        }

        void RebuildDecortors()
        {
            scheme_decorators.Clear();

            var center = new Point(PanelGreenScheme.Width / 2.0, PanelGreenScheme.Height / 2.0);

            if (angle != 0)
            {
                scheme_decorators.Add(scheme => new RotateScheme(scheme, center, angle));
            }
            if (scale > 0 && scale != 1)
            {
                scheme_decorators.Add(scheme => new ScaleScheme(scheme, center, scale));
            }
            if (delta.X != 0 || delta.Y != 0)
            {
                scheme_decorators.Add(scheme => new MoveBySceme(scheme, delta));
            }

            PanelGreenScheme.Invalidate();
            PanelDashedScheme.Invalidate();
        }

        void TextBoxRotationAngle_TextChanged(object sender, EventArgs e)
        {
            angle = 0;

            if (TextBoxRotationAngle.Text != string.Empty)
            {
                if (!double.TryParse(TextBoxRotationAngle.Text, out angle))
                {
                    return;
                }
            }

            RebuildDecortors();
        }

        void TextBoxScale_TextChanged(object sender, EventArgs e)
        {
            scale = 1;

            if (TextBoxScale.Text != string.Empty)
            {
                if (!(double.TryParse(TextBoxScale.Text, out scale) && scale > 0.1))
                {
                    return;
                }
            }

            RebuildDecortors();
        }

        private void TextBoxMoveBy_TextChanged(object sender, EventArgs e)
        {
            delta = new Point(0, 0);

            string[] coords = TextBoxMoveBy.Text.Split(";");

            if (coords.Length == 2)
            {
                if (!(double.TryParse(coords[0], out double x)))
                {
                    return;
                }

                if (!(double.TryParse(coords[1], out double y)))
                {
                    return;
                }

                delta = new Point(x, y);
            }

            RebuildDecortors();
        }

        void UpdateCurveChainComboBoxes()
        {
            int[] curve_indices_first = new int[visualCurves.Count];
            int[] curve_indices_second = new int[visualCurves.Count];
            for (int i = 0; i < visualCurves.Count; i++)
            {
                curve_indices_first[i] = i;
                curve_indices_second[i] = i;
            }

            ComboBoxCurveChainFirst.DataSource = curve_indices_first;
            ComboBoxCurveChainSecond.DataSource = curve_indices_second;
        }

        private void ButtonApplyCurveChain_Click(object sender, EventArgs e)
        {
            var first_curve = visualCurves[ComboBoxCurveChainFirst.SelectedIndex];
            var second_curve = visualCurves[ComboBoxCurveChainSecond.SelectedIndex];

            var chained_curve = new VisualCurve(new Chain(first_curve, second_curve), first_curve.point_count);

            visualCurves[ComboBoxCurveChainFirst.SelectedIndex] = chained_curve;
            //visualCurves.RemoveAt(ComboBoxCurveChainFirst.SelectedIndex);

            UpdateCurveChainComboBoxes();

            PanelGreenScheme.Invalidate();
            PanelDashedScheme.Invalidate();
        }

        public Graphics Get()
        {
            Graphics graphics = Graphics.FromHwnd(PanelDashedScheme.Handle);
            return graphics;
        }
    }
}
