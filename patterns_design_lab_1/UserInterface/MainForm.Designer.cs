namespace patterns_design_lab_1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PanelGreenScheme = new Panel();
            PanelDashedScheme = new Panel();
            ButtonGenerate = new Button();
            ButtonGreenSchemeSave = new Button();
            ButtonDashedSchemeSave = new Button();
            TextBoxScale = new TextBox();
            TextBoxRotationAngle = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // PanelGreenScheme
            // 
            PanelGreenScheme.Location = new Point(87, 155);
            PanelGreenScheme.Name = "PanelGreenScheme";
            PanelGreenScheme.Size = new Size(600, 600);
            PanelGreenScheme.TabIndex = 0;
            PanelGreenScheme.Paint += PanelGreenScheme_Paint;
            // 
            // PanelDashedScheme
            // 
            PanelDashedScheme.Location = new Point(862, 155);
            PanelDashedScheme.Name = "PanelDashedScheme";
            PanelDashedScheme.Size = new Size(600, 600);
            PanelDashedScheme.TabIndex = 1;
            PanelDashedScheme.Paint += PanelDashedScheme_Paint;
            // 
            // ButtonGenerate
            // 
            ButtonGenerate.Location = new Point(474, 12);
            ButtonGenerate.Name = "ButtonGenerate";
            ButtonGenerate.Size = new Size(595, 99);
            ButtonGenerate.TabIndex = 2;
            ButtonGenerate.Text = "Generate";
            ButtonGenerate.UseVisualStyleBackColor = true;
            ButtonGenerate.Click += ButtonGenerate_Click;
            // 
            // ButtonGreenSchemeSave
            // 
            ButtonGreenSchemeSave.Enabled = false;
            ButtonGreenSchemeSave.Location = new Point(90, 778);
            ButtonGreenSchemeSave.Name = "ButtonGreenSchemeSave";
            ButtonGreenSchemeSave.Size = new Size(595, 55);
            ButtonGreenSchemeSave.TabIndex = 3;
            ButtonGreenSchemeSave.Text = "Save to SVG";
            ButtonGreenSchemeSave.UseVisualStyleBackColor = true;
            ButtonGreenSchemeSave.Click += ButtonGreenSchemeSave_Click;
            // 
            // ButtonDashedSchemeSave
            // 
            ButtonDashedSchemeSave.Enabled = false;
            ButtonDashedSchemeSave.Location = new Point(862, 779);
            ButtonDashedSchemeSave.Name = "ButtonDashedSchemeSave";
            ButtonDashedSchemeSave.Size = new Size(601, 54);
            ButtonDashedSchemeSave.TabIndex = 4;
            ButtonDashedSchemeSave.Text = "Save to SVG";
            ButtonDashedSchemeSave.UseVisualStyleBackColor = true;
            ButtonDashedSchemeSave.Click += ButtonDashedSchemeSave_Click;
            // 
            // TextBoxScale
            // 
            TextBoxScale.Location = new Point(723, 480);
            TextBoxScale.Name = "TextBoxScale";
            TextBoxScale.Size = new Size(111, 23);
            TextBoxScale.TabIndex = 7;
            TextBoxScale.TextChanged += TextBoxScale_TextChanged;
            // 
            // TextBoxRotationAngle
            // 
            TextBoxRotationAngle.Location = new Point(723, 282);
            TextBoxRotationAngle.Name = "TextBoxRotationAngle";
            TextBoxRotationAngle.Size = new Size(111, 23);
            TextBoxRotationAngle.TabIndex = 8;
            TextBoxRotationAngle.TextChanged += TextBoxRotationAngle_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(736, 252);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 9;
            label1.Text = "rotation angle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(759, 452);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 10;
            label2.Text = "scale";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TextBoxRotationAngle);
            Controls.Add(TextBoxScale);
            Controls.Add(ButtonDashedSchemeSave);
            Controls.Add(ButtonGreenSchemeSave);
            Controls.Add(ButtonGenerate);
            Controls.Add(PanelDashedScheme);
            Controls.Add(PanelGreenScheme);
            DoubleBuffered = true;
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelGreenScheme;
        private Panel PanelDashedScheme;
        private Button ButtonGenerate;
        private Button ButtonGreenSchemeSave;
        private Button ButtonDashedSchemeSave;
        private TextBox TextBoxScale;
        private TextBox TextBoxRotationAngle;
        private Label label1;
        private Label label2;
    }
}
