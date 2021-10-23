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
        enum instruments {Перемещение, Выделение, Обрезка, Кисть, Пипетка, Ластик};
        Layer work_layer = new Layer();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.ICO)|*.BMP;*.JPG;*.PNG;*.ICO|All files(*.*)|*.*";
            
            if (FD.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    work_layer = new Layer();
                    Bitmap orig = new Bitmap(FD.FileName);
                    Bitmap clone = new Bitmap(orig.Width, orig.Height,
                                              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                    using (Graphics gr = Graphics.FromImage(clone))
                    {
                        gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                    }
                    //Work_space.Image = new Bitmap(FD.FileName);
                    // work_layer.original = new Bitmap(FD.FileName);
                    Work_space.Image = clone;
                    work_layer.original = clone;
                }
                catch {
                    MessageBox.Show("Выбранный файл невозможно открыть. Данный тип файла не поддерживается!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void moving_instr_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeAll;
            work_layer.Active_instr = (int)instruments.Перемещение;
        }

        private void brush_Click(object sender, EventArgs e)
        {
            work_layer.Active_instr = (int)instruments.Кисть;
        }

        private void create_area_Click(object sender, EventArgs e)
        {
            work_layer.Active_instr = (int)instruments.Выделение;
        }

        private void Eraser_button_Click(object sender, EventArgs e)
        {
            work_layer.Active_instr = (int)instruments.Ластик;
        }

        private void Work_space_MouseDown(object sender, MouseEventArgs e)
        {
            if (work_layer.Active_instr == (int)instruments.Выделение)
            {
                work_layer.start_position_selection = e.Location;
            }

            if (work_layer.Active_instr == (int)instruments.Кисть)
            {
                Point relative_current_position = new Point(e.Location.X * 100 / work_layer.scale - work_layer.shift.X, 
                                                            e.Location.Y * 100 / work_layer.scale - work_layer.shift.Y);
                work_layer.last_position = relative_current_position;
            }

            else if (work_layer.Active_instr == (int)instruments.Перемещение) 
            {
                work_layer.start_position = Cursor.Position;
            }
        }

        private void Work_space_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextPicBox.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            else if (work_layer.Active_instr == (int)instruments.Выделение)
            {
                Pen finished_selection_pen = work_layer.selection_pen;
                finished_selection_pen.Brush = Brushes.Lime;
                using (Graphics g = Graphics.FromImage(Work_space.Image))
                    g.DrawRectangle(finished_selection_pen, work_layer.selection);
                Work_space.Image = work_layer.CropBitmap((Bitmap)Work_space.Image, work_layer.selection);
                Work_space.Refresh();

            }

            else if (work_layer.Active_instr == (int)instruments.Перемещение)
            {
                work_layer.shift = work_layer.shift_tmp;
            }

            }

        private void Work_space_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer.Active_instr == (int)instruments.Ластик) {
                Point relative_current_position = new Point((e.Location.X - work_layer.shift.X) * 100 / work_layer.scale, 
                                                            (e.Location.Y - work_layer.shift.Y) * 100 / work_layer.scale);

                for (int i = relative_current_position.X - 5; i < relative_current_position.X + 5; i++)
                {
                    for (int j = relative_current_position.Y - 5; j < relative_current_position.Y + 5; j++)
                    {
                        work_layer.original.SetPixel(i, j, Color.Transparent);
                    }
                }
                //work_layer.original.MakeTransparent(Color.Transparent);
                Work_space.Image = work_layer.ResizeBitmap(work_layer.original, Work_space.Width, Work_space.Height,
                                                           work_layer.original.Width * work_layer.scale / 100,
                                                           work_layer.original.Height * work_layer.scale / 100,
                                                           work_layer.shift.X, work_layer.shift.Y);
                Work_space.Refresh();
                return;
            }

                if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer.Active_instr == (int)instruments.Кисть)
            {
                Point relative_current_position = new Point((e.Location.X - work_layer.shift.X) * 100 / work_layer.scale, (e.Location.Y - work_layer.shift.Y) * 100 / work_layer.scale);

                work_layer.original = Layer.BrushDraw(work_layer.original, work_layer.layer_pen, work_layer.last_position, relative_current_position);
                Work_space.Image = work_layer.ResizeBitmap(work_layer.original, Work_space.Width, Work_space.Height,
                                                           work_layer.original.Width * work_layer.scale / 100,
                                                           work_layer.original.Height * work_layer.scale / 100,
                                                           work_layer.shift.X, work_layer.shift.Y);
                work_layer.last_position = relative_current_position;
                Work_space.Refresh();
                return;
            }

            else if (work_layer.Active_instr == (int)instruments.Выделение & e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (work_layer.original != null)
                    Work_space.Image = work_layer.ResizeBitmap(work_layer.original, Work_space.Width, Work_space.Height, 
                                                               work_layer.original.Width * work_layer.scale / 100, 
                                                               work_layer.original.Height * work_layer.scale / 100, 
                                                               work_layer.shift.X, work_layer.shift.Y);

                work_layer.selection = work_layer.GetSelRectangle(work_layer.start_position_selection, e.Location);
                using (Graphics g = Graphics.FromImage(Work_space.Image))
                    g.DrawRectangle(work_layer.selection_pen, work_layer.selection);
                Work_space.Refresh();
                return;
            }

            else if (work_layer.Active_instr == (int)instruments.Перемещение)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer.original != null)
                {
                    work_layer.shift_tmp.X = Cursor.Position.X - work_layer.start_position.X + work_layer.shift.X;
                    work_layer.shift_tmp.Y = Cursor.Position.Y - work_layer.start_position.Y + work_layer.shift.Y;
                    int PicBox_Width = Work_space.Width;
                    int PicBox_Height = Work_space.Height;
                    Work_space.Image = work_layer.ResizeBitmap(work_layer.original, PicBox_Width, PicBox_Height,
                                                               work_layer.original.Width * work_layer.scale / 100,
                                                               work_layer.original.Height * work_layer.scale / 100,
                                                               work_layer.shift_tmp.X, work_layer.shift_tmp.Y);
                    Work_space.Refresh();
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                }
                return;
            }
        }

        private void Scale_Scroll(object sender, EventArgs e)
        {
            Scale_label.Text = String.Format("{0} %", Scale.Value);
            work_layer.scale = Scale.Value + 1;
            int PicBox_Width = Work_space.Width;
            int PicBox_Height = Work_space.Height;
            if (work_layer.original != null)
                Work_space.Image = work_layer.ResizeBitmap(work_layer.original, 
                                                           PicBox_Width, PicBox_Height, 
                                                           work_layer.original.Width * work_layer.scale / 100, 
                                                           work_layer.original.Height * work_layer.scale / 100, 
                                                           work_layer.shift.X, work_layer.shift.Y);
            Work_space.Refresh();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void WidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.Work_space.Size = new System.Drawing.Size((int)WidthUpDown.Value, (int)HeightUpDown.Value);
            Work_space.Refresh();
        }

        private void HeightUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.Work_space.Size = new System.Drawing.Size((int)WidthUpDown.Value, (int)HeightUpDown.Value);
            Work_space.Refresh();
        }

        private void opacity_UpDown_ValueChanged(object sender, EventArgs e)
        {
            work_layer.layer_pen.Width = (float)opacity_UpDown.Value;
        }

        private void choose_color_button_Click(object sender, EventArgs e)
        {
            if (Choose_color.ShowDialog() == DialogResult.OK) {
                work_layer.layer_pen.Color = Choose_color.Color;
                choose_color_button.BackColor = Choose_color.Color;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveBitmapToFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.ICO)|*.BMP;*.JPG;*.PNG;*.ICO|All files(*.*)|*.*";
            if (saveBitmapToFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    work_layer.original.Save(saveBitmapToFile.FileName);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка записи. Возможно, вы пытаетесь сохранить картинку, не содержащую ни одного пикселя.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
