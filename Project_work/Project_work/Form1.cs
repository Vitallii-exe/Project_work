using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Project_work
{
    public partial class Form1 : Form
    {
        enum instruments { Перемещение, Выделение, Обрезка, Кисть, Пипетка, Ластик };
        enum states { Ждуприменения };
        //Layer work_layer = new Layer();
        List<Layer> work_layer_list = new List<Layer>();
        int CurrentLayerIndex = 0;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private Bitmap DrawLayersList(List<Layer> _work_layer_list, bool tmp = false)
        {
            Bitmap result = new Bitmap(Work_space.Width, Work_space.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                for (int i = 0; i < _work_layer_list.Count; i++)
                {
                    Bitmap to_draw = null;
                    if (!tmp)
                    {
                        to_draw = _work_layer_list[i].ResizeBitmap(_work_layer_list[i].original, Work_space.Width, Work_space.Height,
                                                               _work_layer_list[i].original.Width * _work_layer_list[i].scale / 100,
                                                               _work_layer_list[i].original.Height * _work_layer_list[i].scale / 100,
                                                               _work_layer_list[i].shift.X, _work_layer_list[i].shift.Y);
                    }
                    else
                    {
                        to_draw = _work_layer_list[i].ResizeBitmap(_work_layer_list[i].original, Work_space.Width, Work_space.Height,
                                                               _work_layer_list[i].original.Width * _work_layer_list[i].scale / 100,
                                                               _work_layer_list[i].original.Height * _work_layer_list[i].scale / 100,
                                                               _work_layer_list[i].shift_tmp.X, _work_layer_list[i].shift_tmp.Y);
                    }

                    g.DrawImage(to_draw, 0, 0, to_draw.Width, to_draw.Height);
                }
            }
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
                    Layer fromfilelayer = new Layer();
                    Bitmap orig = new Bitmap(FD.FileName);
                    Bitmap clone = new Bitmap(orig.Width, orig.Height,
                                              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                    using (Graphics gr = Graphics.FromImage(clone))
                    {
                        gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                    }
                    //Work_space.Image = new Bitmap(FD.FileName);
                    // work_layer_list[CurrentLayerIndex].original = new Bitmap(FD.FileName);
                    Work_space.Image = clone;
                    fromfilelayer.original = clone;
                    work_layer_list.Add(fromfilelayer);
                    Work_space.Image = DrawLayersList(work_layer_list);
                    Work_space.Refresh();
                    pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
                    pictureBox_preview.Refresh();
                }
                catch
                {
                    MessageBox.Show("Выбранный файл невозможно открыть. Данный тип файла не поддерживается!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void moving_instr_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeAll;
            work_layer_list[CurrentLayerIndex].Active_instr = (int)instruments.Перемещение;
        }

        private void brush_Click(object sender, EventArgs e)
        {
            work_layer_list[CurrentLayerIndex].Active_instr = (int)instruments.Кисть;
            work_layer_list[CurrentLayerIndex].layer_pen.Color = choose_color_button.BackColor;
        }

        private void create_area_Click(object sender, EventArgs e)
        {
            work_layer_list[CurrentLayerIndex].Active_instr = (int)instruments.Выделение;
        }

        private void Eraser_button_Click(object sender, EventArgs e)
        {
            work_layer_list[CurrentLayerIndex].Active_instr = (int)instruments.Ластик;
        }

        private void cropping_Click(object sender, EventArgs e)
        {
            work_layer_list[CurrentLayerIndex].Active_instr = (int)instruments.Обрезка;
        }

        private void Work_space_MouseDown(object sender, MouseEventArgs e)
        {
            Point relative_current_position = new Point((e.Location.X - work_layer_list[CurrentLayerIndex].shift.X) * 100 / work_layer_list[CurrentLayerIndex].scale,
                                                            (e.Location.Y - work_layer_list[CurrentLayerIndex].shift.Y) * 100 / work_layer_list[CurrentLayerIndex].scale);
            if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Выделение
                | work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Обрезка)
            {
                work_layer_list[CurrentLayerIndex].start_position_selection = e.Location;
                return;
            }


            else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Кисть)
            {
                work_layer_list[CurrentLayerIndex].last_position = relative_current_position;
                return;
            }

            else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Перемещение)
            {
                work_layer_list[CurrentLayerIndex].start_position = Cursor.Position;
                return;
            }
        }

        private void Work_space_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextPicBox.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Выделение
                     | work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Обрезка)
            {
                work_layer_list[CurrentLayerIndex].Current_state = (int)states.Ждуприменения;

                Pen finished_selection_pen = work_layer_list[CurrentLayerIndex].selection_pen;
                switch (work_layer_list[CurrentLayerIndex].Active_instr) {
                    case (int)instruments.Обрезка:
                        finished_selection_pen.Brush = Brushes.Red;
                        break;
                    case (int)instruments.Выделение:
                        finished_selection_pen.Brush = Brushes.Lime;
                        break;
                }
                using (Graphics g = Graphics.FromImage(Work_space.Image))
                    g.DrawRectangle(finished_selection_pen, work_layer_list[CurrentLayerIndex].selection);
                //Work_space.Image = work_layer_list[CurrentLayerIndex].CropBitmap((Bitmap)Work_space.Image, work_layer_list[CurrentLayerIndex].selection);
                
                Work_space.Refresh();
                pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
                pictureBox_preview.Refresh();

            }

            else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Перемещение)
            {
                work_layer_list[CurrentLayerIndex].shift = work_layer_list[CurrentLayerIndex].shift_tmp;
            }

        }

        private void Work_space_MouseMove(object sender, MouseEventArgs e)
        {   if (CurrentLayerIndex < work_layer_list.Count)
            {
                Point relative_current_position = new Point((e.Location.X - work_layer_list[CurrentLayerIndex].shift.X) * 100 / work_layer_list[CurrentLayerIndex].scale, (e.Location.Y - work_layer_list[CurrentLayerIndex].shift.Y) * 100 / work_layer_list[CurrentLayerIndex].scale);
                if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Ластик)
                {
                    for (int i = relative_current_position.X - 5; i < relative_current_position.X + 5; i++)
                    {
                        for (int j = relative_current_position.Y - 5; j < relative_current_position.Y + 5; j++)
                        {
                            work_layer_list[CurrentLayerIndex].original.SetPixel(i, j, Color.Transparent);
                        }
                    }
                    Work_space.Image = DrawLayersList(work_layer_list);
                    Work_space.Refresh();
                    pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
                    pictureBox_preview.Refresh();
                    return;
                }

                if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Кисть)
                {
                    work_layer_list[CurrentLayerIndex].original = Layer.BrushDraw(work_layer_list[CurrentLayerIndex].original, work_layer_list[CurrentLayerIndex].layer_pen, work_layer_list[CurrentLayerIndex].last_position, relative_current_position);
                    Work_space.Image = DrawLayersList(work_layer_list);
                    work_layer_list[CurrentLayerIndex].last_position = relative_current_position;
                    Work_space.Refresh();
                    pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
                    pictureBox_preview.Refresh();
                    return;
                }

                else if ((work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Выделение
                         | work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Обрезка) & e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (work_layer_list[CurrentLayerIndex].original != null)
                        Work_space.Image = DrawLayersList(work_layer_list);

                    work_layer_list[CurrentLayerIndex].selection = work_layer_list[CurrentLayerIndex].GetSelRectangle(work_layer_list[CurrentLayerIndex].start_position_selection, e.Location);
                    using (Graphics g = Graphics.FromImage(Work_space.Image))
                        g.DrawRectangle(work_layer_list[CurrentLayerIndex].selection_pen, work_layer_list[CurrentLayerIndex].selection);
                    Work_space.Refresh();
                    pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
                    pictureBox_preview.Refresh();
                    return;
                }

                else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Перемещение)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer_list[CurrentLayerIndex].original != null)
                    {
                        work_layer_list[CurrentLayerIndex].shift_tmp.X = Cursor.Position.X - work_layer_list[CurrentLayerIndex].start_position.X + work_layer_list[CurrentLayerIndex].shift.X;
                        work_layer_list[CurrentLayerIndex].shift_tmp.Y = Cursor.Position.Y - work_layer_list[CurrentLayerIndex].start_position.Y + work_layer_list[CurrentLayerIndex].shift.Y;
                        Work_space.Image = DrawLayersList(work_layer_list, true);

                        Work_space.Refresh();
                        pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
                        pictureBox_preview.Refresh();

                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                    }
                    return;
                }
            }
        }

        private void Scale_Scroll(object sender, EventArgs e)
        {
            Scale_label.Text = String.Format("{0} %", Scale.Value);
            work_layer_list[CurrentLayerIndex].scale = Scale.Value + 1;
            if (work_layer_list[CurrentLayerIndex].original != null)
                Work_space.Image = DrawLayersList(work_layer_list);

            Work_space.Refresh();
            pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
            pictureBox_preview.Refresh();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void WidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.Work_space.Size = new System.Drawing.Size((int)WidthUpDown.Value, (int)HeightUpDown.Value);
            Work_space.Refresh();
            pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
            pictureBox_preview.Refresh();
        }

        private void HeightUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.Work_space.Size = new System.Drawing.Size((int)WidthUpDown.Value, (int)HeightUpDown.Value);
            Work_space.Refresh();
            pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
            pictureBox_preview.Refresh();
        }

        private void opacity_UpDown_ValueChanged(object sender, EventArgs e)
        {
            work_layer_list[CurrentLayerIndex].layer_pen.Width = (float)opacity_UpDown.Value;
        }

        private void choose_color_button_Click(object sender, EventArgs e)
        {
            if (Choose_color.ShowDialog() == DialogResult.OK)
            {
                work_layer_list[CurrentLayerIndex].layer_pen.Color = Choose_color.Color;
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
                    work_layer_list[CurrentLayerIndex].original.Save(saveBitmapToFile.FileName);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка записи. Возможно, вы пытаетесь сохранить картинку, не содержащую ни одного пикселя.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LayerUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((int)LayerUpDown.Value - 1 < work_layer_list.Count)
            {
                CurrentLayerIndex = (int)LayerUpDown.Value - 1;
                pictureBox_preview.BackgroundImage = work_layer_list[CurrentLayerIndex].original;
                pictureBox_preview.Refresh();
            }
            else LayerUpDown.Value = work_layer_list.Count;
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Обрезка
                & work_layer_list[CurrentLayerIndex].Current_state == (int)states.Ждуприменения) {
                Bitmap to_draw = work_layer_list[CurrentLayerIndex].ResizeBitmap(work_layer_list[CurrentLayerIndex].original, Work_space.Width, Work_space.Height,
                                                               work_layer_list[CurrentLayerIndex].original.Width * work_layer_list[CurrentLayerIndex].scale / 100,
                                                               work_layer_list[CurrentLayerIndex].original.Height * work_layer_list[CurrentLayerIndex].scale / 100,
                                                               work_layer_list[CurrentLayerIndex].shift.X, work_layer_list[CurrentLayerIndex].shift.Y);

                work_layer_list[CurrentLayerIndex].original = work_layer_list[CurrentLayerIndex].CropBitmap(to_draw, work_layer_list[CurrentLayerIndex].selection);
                work_layer_list[CurrentLayerIndex].shift = new Point(0, 0);
                work_layer_list[CurrentLayerIndex].scale = 100;
                Scale.Value = 100;

                Work_space.Image = DrawLayersList(work_layer_list);
                Work_space.Refresh();
            }
        }
    }
}
