using patterns_design_lab_1.Geometry;
using patterns_design_lab_1.Visual;
using patterns_design_lab_1.Visual.Shemes;
using Point = patterns_design_lab_1.Geometry.Point;

namespace patterns_design_lab_1
{
    public partial class MainForm : Form
    {
        List<VisualCurve> visualCurves = [];
        readonly Random random = new();
        ICurveVisualizationScheme? transform_scheme = null;

        public MainForm()
        {
            InitializeComponent();
        }

        void PanelGreenScheme_Paint(object sender, PaintEventArgs e)
        {
            var scheme = new GreenScheme(e.Graphics);

            foreach (VisualCurve curve in visualCurves)
            {
                curve.Draw(scheme);
            }
        }

        void PanelDashedScheme_Paint(object sender, PaintEventArgs e)
        {
            var scheme = new DashedScheme(e.Graphics);

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

        void TextBoxRotationAngle_TextChanged(object sender, EventArgs e)
        {
            double angle = 0;

            if (TextBoxRotationAngle.Text != string.Empty)
            {
                if (!double.TryParse(TextBoxRotationAngle.Text, out angle))
                {
                    return;
                }
            }

            var center = new Point(PanelGreenScheme.Width / 2.0, PanelGreenScheme.Height / 2.0);

            PanelGreenScheme.Invalidate();
            PanelDashedScheme.Invalidate();
        }

        void TextBoxScale_TextChanged(object sender, EventArgs e)
        {
            double scale = 0;

            if (TextBoxScale.Text != string.Empty)
            {
                if (!(double.TryParse(TextBoxScale.Text, out scale) && scale > 0.1))
                {
                    return;
                }
            }

            var center = new Point(PanelGreenScheme.Width / 2.0, PanelGreenScheme.Height / 2.0);

            PanelGreenScheme.Invalidate();
            PanelDashedScheme.Invalidate();
        }
    }
}
