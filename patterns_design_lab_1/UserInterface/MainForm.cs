using patterns_design_lab_1.Geometry;
using patterns_design_lab_1.Visual;
using patterns_design_lab_1.Visual.CustomGraphics;
using patterns_design_lab_1.Visual.Schemes;
using Point = patterns_design_lab_1.Geometry.Point;

namespace patterns_design_lab_1
{
    public partial class MainForm : Form
    {
        List<VisualCurve> visual_curves = [];
        readonly Random random = new();
        double angle = 0, scale = 1;
        Point delta = new(0, 0);
        readonly List<Func<ICurveVisualizationScheme, ICurveVisualizationScheme>> scheme_decorators = [];

        public MainForm()
        {
            InitializeComponent();
        }

        static ICurveVisualizationScheme CreateGreen(IGraphics graphics) => new GreenScheme(graphics);

        static ICurveVisualizationScheme CreateDashed(IGraphics graphics) => new ShadowScheme(
            new DashedScheme(graphics, new Pen(Color.Black, 2)),
            new DashedScheme(graphics, new Pen(Color.Gray, 2)),
            new Point(3, 3));

        void DrawCurves(Func<IGraphics, ICurveVisualizationScheme> create_scheme, IGraphics graphics)
        {
            var scheme = Decorate(create_scheme(graphics));

            foreach (VisualCurve curve in visual_curves)
            {
                curve.Draw(scheme);
            }
        }

        void DrawLabeledCurves(Func<IGraphics, ICurveVisualizationScheme> create_scheme, IGraphics graphics)
        {
            for (int i = 0; i < visual_curves.Count; i++)
            {
                var scheme = Decorate(new LabelScheme(create_scheme(graphics), $"{i}", graphics));
                visual_curves[i].Draw(scheme);
            }
        }

        void PanelGreenScheme_Paint(object sender, PaintEventArgs e) => DrawLabeledCurves(CreateGreen, new GDIGraphics(e.Graphics));

        void PanelDashedScheme_Paint(object sender, PaintEventArgs e) => DrawLabeledCurves(CreateDashed, new GDIGraphics(e.Graphics));

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

        void ButtonGenerate_Click(object sender, EventArgs e)
        {
            ButtonGreenSchemeSave.Enabled = true;
            ButtonDashedSchemeSave.Enabled = true;

            visual_curves = GenerateCurves();

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

            Point GenerateRandomPoint(int width, int height)
            {
                double x = random.NextDouble() * width;
                double y = random.NextDouble() * height;

                return new Geometry.Point(x, y);
            }
        }

        void SaveSvg(Func<IGraphics, ICurveVisualizationScheme> create_scheme)
        {
            if (visual_curves.Count == 0)
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

            var svg_graphics = new SVGGraphics(PanelGreenScheme.Width, PanelGreenScheme.Height);
            DrawCurves(create_scheme, svg_graphics);
            svg_graphics.Save(dialog.FileName);
        }

        void ButtonGreenSchemeSave_Click(object sender, EventArgs e) => SaveSvg(CreateGreen);

        void ButtonDashedSchemeSave_Click(object sender, EventArgs e) => SaveSvg(CreateDashed);

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
            int[] curve_indices_first = new int[visual_curves.Count];
            int[] curve_indices_second = new int[visual_curves.Count];
            for (int i = 0; i < visual_curves.Count; i++)
            {
                curve_indices_first[i] = i;
                curve_indices_second[i] = i;
            }

            ComboBoxCurveChainFirst.DataSource = curve_indices_first;
            ComboBoxCurveChainSecond.DataSource = curve_indices_second;
        }

        private void ButtonApplyCurveChain_Click(object sender, EventArgs e)
        {
            if (ComboBoxCurveChainFirst.SelectedIndex == ComboBoxCurveChainSecond.SelectedIndex)
            {
                return;
            }

            VisualCurve first_curve = visual_curves[ComboBoxCurveChainFirst.SelectedIndex];
            VisualCurve second_curve = visual_curves[ComboBoxCurveChainSecond.SelectedIndex];

            first_curve.GetPoint(1, out IPoint end);
            ICurve moved_second_curve = new MoveTo(second_curve, end);

            int point_count = 2 * (first_curve.point_count + second_curve.point_count);
            var chained_curve = new VisualCurve(new Chain(first_curve, moved_second_curve), point_count);

            visual_curves[ComboBoxCurveChainFirst.SelectedIndex] = chained_curve;
            visual_curves.RemoveAt(ComboBoxCurveChainSecond.SelectedIndex);

            UpdateCurveChainComboBoxes();
            PanelGreenScheme.Invalidate();
            PanelDashedScheme.Invalidate();
        }
    }
}
