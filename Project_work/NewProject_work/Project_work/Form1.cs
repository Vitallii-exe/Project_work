using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace Project_work
{
    public partial class Form1 : Form
    {
        enum instruments { Перемещение, Выделение, Обрезка, Кисть, Пипетка, Ластик };
        enum states { Ждуприменения };
        List<Layer> work_layer_list = new List<Layer>();
        int CurrentLayerIndex = 0;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            new LayerVisualiser();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import_Export.ImportFromFile(ref work_layer_list, ref Work_space);
            CurrentLayerIndex = work_layer_list.Count - 1;
            for (int i = 0; i < work_layer_list.Count; i++) {
                work_layer_list[i].visible_checkbox.Click += new System.EventHandler(UpdateVisualLayers);
                work_layer_list[i].preview.Tag = i;
                work_layer_list[i].preview.Click += new System.EventHandler(UpdateActiveLayer);
                LayerVisualiser.AddVisualLayer(ref work_layer_list, ref CurrentLayerIndex, ref Layer_panel, ref Work_space);
            }
        }

        private void UpdateVisualLayers(object sender, EventArgs e)
        {
            for (int i = 0; i < work_layer_list.Count; i++)
            {
                if (work_layer_list[i].visible != work_layer_list[i].visible_checkbox.Checked)
                {
                    work_layer_list[i].visible = work_layer_list[i].visible_checkbox.Checked;
                }
            }
            Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
            Work_space.Refresh();
        }

        private void UpdateActiveLayer(object sender, EventArgs e) {
            Button from_sender = sender as Button;
            CurrentLayerIndex = (int)from_sender.Tag;
            //LayerVisualiser.AddVisualLayer(ref work_layer_list, ref CurrentLayerIndex, ref Layer_panel, ref Work_space);
            LayerVisualiser.UpdateLayersPreviews(ref work_layer_list, ref Layer_panel, ref CurrentLayerIndex);
            Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
            Work_space.Refresh();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import_Export.ExportToFile(ref work_layer_list, ref CurrentLayerIndex);
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

        private void pipette_Click(object sender, EventArgs e)
        {
            work_layer_list[CurrentLayerIndex].Active_instr = (int)instruments.Пипетка;
        }

        private void LayerUpButton_Click(object sender, EventArgs e)
        {
            if (CurrentLayerIndex + 1 < work_layer_list.Count)
            {
                Layer Buff = work_layer_list[CurrentLayerIndex + 1];
                work_layer_list[CurrentLayerIndex + 1] = work_layer_list[CurrentLayerIndex];
                work_layer_list[CurrentLayerIndex] = Buff;
                CurrentLayerIndex++;
                LayerVisualiser.AddVisualLayer(ref work_layer_list, ref CurrentLayerIndex, ref Layer_panel, ref Work_space);
                for (int i = 0; i < work_layer_list.Count; i++)  work_layer_list[i].preview.Tag = i;
                Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
                Work_space.Refresh();
            }

        }

        private void LayerDownButton_Click(object sender, EventArgs e)
        {
            if (CurrentLayerIndex - 1 > -1)
            {
                Layer Buff = work_layer_list[CurrentLayerIndex - 1];
                work_layer_list[CurrentLayerIndex - 1] = work_layer_list[CurrentLayerIndex];
                work_layer_list[CurrentLayerIndex] = Buff;
                CurrentLayerIndex -= 1;
                LayerVisualiser.AddVisualLayer(ref work_layer_list, ref CurrentLayerIndex, ref Layer_panel, ref Work_space);
                for (int i = 0; i < work_layer_list.Count; i++) work_layer_list[i].preview.Tag = i;
                Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
                Work_space.Refresh();
            }
        }

        private void choose_color_button_Click(object sender, EventArgs e)
        {
            if (Choose_color.ShowDialog() == DialogResult.OK)
            {
                work_layer_list[CurrentLayerIndex].layer_pen.Color = Choose_color.Color;
                choose_color_button.BackColor = Choose_color.Color;
            }
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Обрезка
                & work_layer_list[CurrentLayerIndex].Current_state == (int)states.Ждуприменения)
            {
                Bitmap to_draw = work_layer_list[CurrentLayerIndex].ResizeBitmap(work_layer_list[CurrentLayerIndex].original, Work_space.Width, Work_space.Height,
                                                               work_layer_list[CurrentLayerIndex].original.Width * work_layer_list[CurrentLayerIndex].scale / 100,
                                                               work_layer_list[CurrentLayerIndex].original.Height * work_layer_list[CurrentLayerIndex].scale / 100,
                                                               work_layer_list[CurrentLayerIndex].shift.X, work_layer_list[CurrentLayerIndex].shift.Y);

                work_layer_list[CurrentLayerIndex].original = work_layer_list[CurrentLayerIndex].CropBitmap(to_draw, work_layer_list[CurrentLayerIndex].selection);
                work_layer_list[CurrentLayerIndex].shift = new Point(0, 0);
                work_layer_list[CurrentLayerIndex].scale = 100;
                Scale.Value = 100;

                Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
                Work_space.Refresh();
                //Layer.AddVisualLayer(ref work_layer_list, ref CurrentLayerIndex, ref Layer_panel, ref Work_space);
            }
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
                //Layer.AddVisualLayer(ref work_layer_list, ref CurrentLayerIndex, ref Layer_panel, ref Work_space);

            }

            else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Перемещение)
            {
                work_layer_list[CurrentLayerIndex].shift = work_layer_list[CurrentLayerIndex].shift_tmp;
            }
            else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Пипетка) {
                work_layer_list[CurrentLayerIndex].layer_pen.Color = pipette.BackColor;
                choose_color_button.BackColor = pipette.BackColor;
                work_layer_list[CurrentLayerIndex].Active_instr = (int)instruments.Кисть;
                toolTip1.Show("Цвет выбран!", pipette, 1000);
            }

        }

        private void Work_space_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentLayerIndex < work_layer_list.Count)
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
                    Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
                    LayerVisualiser.UpdateLayersPreviews(ref work_layer_list, ref Layer_panel, ref CurrentLayerIndex);
                    Work_space.Refresh();
                    return;
                }

                if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Кисть)
                {
                    toolTip1.Hide(pipette);
                    work_layer_list[CurrentLayerIndex].original = Layer.BrushDraw(ref work_layer_list[CurrentLayerIndex].original, ref work_layer_list[CurrentLayerIndex].layer_pen, ref work_layer_list[CurrentLayerIndex].last_position, ref relative_current_position);
                    Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
                    work_layer_list[CurrentLayerIndex].last_position = relative_current_position;
                    LayerVisualiser.UpdateLayersPreviews(ref work_layer_list, ref Layer_panel, ref CurrentLayerIndex);
                    Work_space.Refresh();
                    return;
                }

                else if ((work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Выделение
                         | work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Обрезка) & e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (work_layer_list[CurrentLayerIndex].original != null)
                        Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);

                    work_layer_list[CurrentLayerIndex].selection = work_layer_list[CurrentLayerIndex].GetSelRectangle(work_layer_list[CurrentLayerIndex].start_position_selection, e.Location);
                    using (Graphics g = Graphics.FromImage(Work_space.Image))
                        g.DrawRectangle(work_layer_list[CurrentLayerIndex].selection_pen, work_layer_list[CurrentLayerIndex].selection);
                    Work_space.Refresh();
                    LayerVisualiser.UpdateLayersPreviews(ref work_layer_list, ref Layer_panel, ref CurrentLayerIndex);
                    return;
                }

                else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Перемещение)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left & work_layer_list[CurrentLayerIndex].original != null)
                    {
                        work_layer_list[CurrentLayerIndex].shift_tmp.X = Cursor.Position.X - work_layer_list[CurrentLayerIndex].start_position.X + work_layer_list[CurrentLayerIndex].shift.X;
                        work_layer_list[CurrentLayerIndex].shift_tmp.Y = Cursor.Position.Y - work_layer_list[CurrentLayerIndex].start_position.Y + work_layer_list[CurrentLayerIndex].shift.Y;
                        Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space, true);

                        Work_space.Refresh();

                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                    }
                    return;
                }
                else if (work_layer_list[CurrentLayerIndex].Active_instr == (int)instruments.Пипетка) {
                    if (work_layer_list[CurrentLayerIndex].original != null) {
                       Color cutted_color = ((Bitmap)Work_space.Image).GetPixel(e.Location.X, e.Location.Y);
                        pipette.BackColor = cutted_color;
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
                Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);

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
            Work_space.Size = new System.Drawing.Size((int)WidthUpDown.Value, (int)HeightUpDown.Value);
            Work_space.Refresh();
        }

        private void opacity_UpDown_ValueChanged(object sender, EventArgs e)
        {
            work_layer_list[CurrentLayerIndex].layer_pen.Width = (float)opacity_UpDown.Value;
        }

        private void Color_correction_button_Click(object sender, EventArgs e)
        {
            SaturationCorrection filter = new SaturationCorrection(0.5f);
            Bitmap formatted_layer_bitmap = AForge.Imaging.Image.Clone(work_layer_list[CurrentLayerIndex].original, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            filter.ApplyInPlace(formatted_layer_bitmap);
            work_layer_list[CurrentLayerIndex].original = AForge.Imaging.Image.Clone(formatted_layer_bitmap, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            
            Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);

            Work_space.Refresh();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
    }
}
