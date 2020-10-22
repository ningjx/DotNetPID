using DotNetPID;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        PID pid;
        Graphics graphics;
        Pen pen = new Pen(Color.Black);
        Pen pen1 = new Pen(Color.Blue);
        Font font = new Font("宋体", 12);
        Brush black_brush = new SolidBrush(Color.Black);
        Brush blue_brush = new SolidBrush(Color.Blue);

        int x = 0;
        int midY = 0;
        PointF lastPoint = new PointF(0, 0);
        PointF lastIncPoint = new PointF(0, 0);
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            midY = pictureBox1.Height / 2;
            label1.Text = (trackBar1.Value / 10f).ToString();
        }

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            x = 0;
            graphics.Clear(Color.White);
            pid = PID.Create(Convert.ToDouble(domainUpDown1.Text), Convert.ToDouble(domainUpDown2.Text), Convert.ToDouble(domainUpDown3.Text), domainUpDown4.Text == "无限制" ? 0 : Convert.ToDouble(domainUpDown4.Text), comboBox1.Text == "增量型" ? PIDType.Increment : PIDType.Positional, Convert.ToInt32(textBox1.Text));
            pid.StepEvent += Pid_StepEvent;
            pid.TargetAttachEvent += Pid_TargetAttachEvent;
            lastPoint = lastIncPoint = new PointF(0, 0);
            pid.Start(Convert.ToDouble(trackBar1.Value / 10d), 0);
        }

        private float Pid_TargetAttachEvent(float value, float inc_per)
        {
            pid.Stop();
            return 0;
        }

        private float Pid_StepEvent(float value, float inc_per)
        {
            float trcV = trackBar1.Value / 10f;
            var newPoint = new PointF(x, trcV + value + midY);
            var incPoint = new PointF(x, -value + midY);
            if (lastPoint.X != 0)
            {
                graphics.DrawLine(pen, lastPoint, newPoint);
                graphics.DrawLine(pen1, lastIncPoint, incPoint);
            }
            else if (lastPoint.Y != 0)
            {
                graphics.DrawString("值", Font, black_brush, lastPoint);
                graphics.DrawString("增量", Font, blue_brush, lastIncPoint);
            }
            lastPoint = newPoint;
            lastIncPoint = incPoint;
            trcV += value;
            if (comboBox1.Text == "位置型")
                trackBar1.Value = (int)(value * 10);
            else
                trackBar1.Value = (int)(trcV * 10);
            x += 20;
            return trackBar1.Value / 10f;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = (trackBar1.Value / 10f).ToString();
        }
    }
}
