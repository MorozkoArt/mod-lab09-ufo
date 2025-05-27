namespace Lab09;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        accuracyField = new NumericUpDown();
        radiusField = new NumericUpDown();
        label1 = new Label();
        label2 = new Label();
        run = new Button();
        analysis = new Button();
        ((System.ComponentModel.ISupportInitialize)accuracyField).BeginInit();
        ((System.ComponentModel.ISupportInitialize)radiusField).BeginInit();
        SuspendLayout();
        
        accuracyField.Location = new Point(400, 40);
        accuracyField.Name = "accuracyField";
        accuracyField.Size = new Size(120, 27);
        accuracyField.TabIndex = 0;
        
        radiusField.Location = new Point(550, 40);
        radiusField.Name = "radiusField";
        radiusField.Size = new Size(120, 27);
        radiusField.TabIndex = 1;
        
        label1.AutoSize = true;
        label1.Location = new Point(400, 0);
        label1.Name = "label1";
        label1.Size = new Size(67, 20);
        label1.TabIndex = 2;
        label1.Text = "Accuracy";
        
        label2.AutoSize = true;
        label2.Location = new Point(550, 0);
        label2.Name = "label2";
        label2.Size = new Size(53, 20);
        label2.TabIndex = 3;
        label2.Text = "Radius";
        
        run.BackColor = Color.SteelBlue;
        run.FlatStyle = FlatStyle.Flat;
        run.ForeColor = Color.White;
        run.Location = new Point(400, 80);
        run.Name = "run";
        run.Size = new Size(120, 35);
        run.TabIndex = 4;
        run.Text = "Run";
        run.UseVisualStyleBackColor = false;
        run.Click += Run_Click;
        run.FlatAppearance.BorderSize = 0;
        
        analysis.BackColor = Color.Teal;
        analysis.FlatStyle = FlatStyle.Flat;
        analysis.ForeColor = Color.White;
        analysis.Location = new Point(550, 80);
        analysis.Name = "analysis";
        analysis.Size = new Size(120, 35);
        analysis.TabIndex = 5;
        analysis.Text = "Analysis";
        analysis.UseVisualStyleBackColor = false;
        analysis.Click += Analysis_Click;
        analysis.FlatAppearance.BorderSize = 0;
        
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 600);
        Controls.Add(analysis);
        Controls.Add(run);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(radiusField);
        Controls.Add(accuracyField);
        Name = "Form1";
        Text = "Trigonometric Approximation Visualizer";
        Paint += Form1_Paint;
        ((System.ComponentModel.ISupportInitialize)accuracyField).EndInit();
        ((System.ComponentModel.ISupportInitialize)radiusField).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private NumericUpDown accuracyField;
    private NumericUpDown radiusField;
    private Label label1;
    private Label label2;
    private Button run;
    private Button analysis;
}