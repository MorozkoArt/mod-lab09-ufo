using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace Lab09;

public partial class Form1 : Form
{
    private const float DefaultStep = 1f;
    private const float DefaultDotSize = 15f;
    private const int DefaultAccuracy = 2;
    private const float DefaultRadius = 2f;

    private readonly Point _point1 = new(50, 50);
    private readonly Point _point2 = new(700, 1950);
    private float _radius = DefaultRadius;
    private int _accuracy = DefaultAccuracy;
    private bool _isAnalysisMode = false;

    public Form1()
    {
        InitializeComponent();
        InitializeControls();
        SetupFormAppearance();
    }

    private void InitializeControls()
    {
        accuracyField.Value = _accuracy;
        radiusField.Value = (decimal)_radius;
    }

    private void SetupFormAppearance()
    {
        this.Text = "Trigonometric Approximation Visualizer";
        this.BackColor = Color.WhiteSmoke;
        this.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.ScaleTransform(0.5f, 0.5f);
        g.FillEllipse(Brushes.Red, _point1.X, _point1.Y, DefaultDotSize, DefaultDotSize);
        g.FillEllipse(Brushes.Blue, _point2.X, _point2.Y, DefaultDotSize, DefaultDotSize);
        g.DrawEllipse(new Pen(Color.Black, 1),
                    _point2.X + DefaultDotSize / 2 - _radius / 2,
                    _point2.Y + DefaultDotSize / 2 - _radius / 2,
                    _radius, _radius);
        DrawLine(g);
        if (_isAnalysisMode)
        {
            _accuracy = 1;
            accuracyField.Value = _accuracy;
            bool result = DrawAnglePath(g, _accuracy);
            while (!result)
            {
                _accuracy++;
                accuracyField.Value = _accuracy;
                result = DrawAnglePath(g, _accuracy);
            }
            _isAnalysisMode = false;
        }
        else
        {
            DrawAnglePath(g, _accuracy);
        }
    }

    private void DrawLine(Graphics g)
    {
        double k = ((double)(_point2.Y - _point1.Y)) / (_point2.X - _point1.X);
        double b = _point1.Y - k * _point1.X;

        using (var pen = new Pen(Color.Goldenrod, 3))
        {
            g.DrawLine(pen, _point1.X, (float)(k * _point1.X + b),
                                _point2.X, (float)(k * _point2.X + b));
        }
    }

    private double CalculateDistance(float x, float y) => Math.Sqrt(Math.Pow(_point2.X  - x , 2) + Math.Pow(_point2.Y - y , 2));

    private bool DrawAnglePath(Graphics g, int n)
    {
        double angle = Atn((double)Math.Abs(_point2.Y - _point1.Y) / Math.Abs(_point2.X - _point1.X), n);
        float x = _point1.X;
        float y = _point1.Y;
        double distance = CalculateDistance(x, y);
        const int maxIterations = 10000;
        int iterations = 0;

        using (var brush = new SolidBrush(Color.FromArgb(80, Color.Black)))
        {
            while (distance > _radius && iterations < maxIterations)
            {
                x += DefaultStep * (float)Cos(angle, n);
                y += DefaultStep * (float)Sin(angle, n);
                g.FillEllipse(brush, x, y, 5, 5);
                distance = CalculateDistance(x, y);
                iterations++;
            }
        }

        return iterations < maxIterations;
    }

    private void Run_Click(object sender, EventArgs e)
    {
        _accuracy = (int)accuracyField.Value;
        _radius = (int)radiusField.Value;
        this.Invalidate();
    }

    private void Analysis_Click(object sender, EventArgs e)
    {
        string basePath = AppContext.BaseDirectory;
        string projectPath = Path.GetFullPath(Path.Combine(basePath, "../../../.."));
        string resultsPath = Path.Combine(projectPath, "result/data.txt");
        var sb = new StringBuilder();

        for (int r = 2; r < 30; r += 2)
        {
            _radius = r;
            radiusField.Value = (decimal)_radius;
            _isAnalysisMode = true;
            this.Invalidate();
            this.Update();
            Application.DoEvents();
            sb.AppendLine($"{_radius} {_accuracy}");
        }

        File.AppendAllText(resultsPath, sb.ToString());
    }

    private static double Factorial(int x)
    {
        long result = 1;
        for (int i = 2; i <= x; i++)
            result *= i;
        return result;
    }

        private static double Sin(double x, int n)
    {
        double answer = 0;
        for (int i = 0; i < n; i++)
            answer += Math.Pow(-1, i) * Math.Pow(x, 2 * i+1) / Factorial(2 * i+1);
        return answer;
    }

    private static double Cos(double x, int n)
    {
        double answer = 0;
        for (int i = 0; i < n; i++)
            answer += Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorial(2 * i);
        return answer;
    }

    public static double Atn(double x, int n)
    {
        if (Math.Abs(x) > 1)
            return Math.Sign(x) * Math.PI / 2 - Atn(1 / x, n);

        double result = 0;
        for (int i = 0; i < n; i++)
            result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
        return result;
    }
}