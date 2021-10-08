using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_work
{
    public partial class Form1 : Form
    {
        Rectangle selRect;
        Point orig;
        Pen pen = new Pen(Brushes.Black, 0.8f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        Pen pen_finished = new Pen(Brushes.Red, 0.9f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        string ActiveInst = "Перемещение";
        Bitmap original;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private static Bitmap ResizeBitmap(Bitmap source_bitmap, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(source_bitmap, 0, 0, width, height);
            return result;
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.ICO)|*.BMP;*.JPG;*.PNG;*.ICO|All files(*.*)|*.*";
            
            if (FD.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    Work_space.Image = new Bitmap(FD.FileName);
                    original = new Bitmap(FD.FileName);
                }
                catch {
                    MessageBox.Show("Выбранный файл невозможно открыть. Данный тип файла не поддерживается!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void moving_instr_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeAll;
            ActiveInst = "Перемещение";
        }

        private void Selection_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, selRect);
        }

        void Work_space_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen_finished, selRect);
        }

        Rectangle GetSelRectangle(Point orig, Point location)
        {
            int deltaX = location.X - orig.X, deltaY = location.Y - orig.Y;
            Size s = new Size(Math.Abs(deltaX), Math.Abs(deltaY));
            Rectangle rect = new Rectangle();
            if (deltaX >= 0 & deltaY >= 0)
                rect = new Rectangle(orig, s);
            if (deltaX < 0 & deltaY > 0)
                rect = new Rectangle(location.X, orig.Y, s.Width, s.Height);
            if (deltaX < 0 & deltaY < 0)
                rect = new Rectangle(location, s);
            if (deltaX > 0 & deltaY < 0)
                rect = new Rectangle(orig.X, location.Y, s.Width, s.Height);
            return rect;
        }

        private void Work_space_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveInst == "Создать прямоугольную область")
            {
                Work_space.Paint -= Work_space_Paint;
                Work_space.Paint += Selection_Paint;
                orig = e.Location;
            }
        }

        private void Work_space_MouseUp(object sender, MouseEventArgs e)
        {
            if (ActiveInst == "Создать прямоугольную область")
            {
                Work_space.Paint -= Selection_Paint;
                Work_space.Paint += Work_space_Paint;
                Work_space.Invalidate();
            }
        }

        private void Work_space_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActiveInst == "Создать прямоугольную область")
            {
                selRect = GetSelRectangle(orig, e.Location);
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    (sender as PictureBox).Refresh();
            }
        }

        private void create_area_Click(object sender, EventArgs e)
        {
            ActiveInst = "Создать прямоугольную область";
        }

        private void Scale_Scroll(object sender, EventArgs e)
        {
            Scale_label.Text = String.Format("{0} %", Scale.Value);
            Work_space.Image = ResizeBitmap(original, original.Width * Scale.Value / 100 + 1, original.Height * Scale.Value / 100 + 1);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
    }
}
