using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Layer
{
    public Bitmap original = new Bitmap(675, 504);
    public Button preview = new Button();
    public CheckBox visible_checkbox = new CheckBox();
    public Label label_caption = new Label();
    public bool visible = true;

    public int Active_instr = 0;
    public int Current_state = -1;

    public Pen layer_pen = new Pen(Brushes.Black, 10.0f) { StartCap = System.Drawing.Drawing2D.LineCap.Round, EndCap = System.Drawing.Drawing2D.LineCap.Round };
    public Pen selection_pen = new Pen(Brushes.Black, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash};

    public Point start_position = new Point(0, 0);
    public Point start_position_selection = new Point(0, 0);
    public Point shift = new Point(0, 0);
    public Point shift_tmp = new Point(0, 0);
    public Point last_position = new Point(0, 0);

    public Rectangle selection = new Rectangle(0, 0, 0, 0);
    public int scale = 100;

    public Layer(int num) {
        Point now_locate_preview = new Point(20, num * 60);
        Point now_locate_checkbox = new Point(5, num * 60 + 15);
        Point now_locate_caption = new Point(120, num * 60 + 15);
        preview.Location = now_locate_preview;
        preview.Size = new Size(80, 50);
        preview.Visible = true;
        preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

        visible_checkbox.Location = now_locate_checkbox;
        visible_checkbox.Checked = true;

        label_caption.Location = now_locate_caption;
        label_caption.Visible = true;
        label_caption.Text = "Слой " + num.ToString();


    }
    public Bitmap ResizeBitmap(Bitmap source_bitmap, int PicBoxWidth, int PicBoxHeight, int width, int height, int shift_X = 0, int shift_Y = 0)
    {
        // Изменяет размер Bitmapa, а также сдвигает его на заданное число пикселей
        Bitmap result = new Bitmap(PicBoxWidth, PicBoxHeight);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.DrawImage(source_bitmap, shift_X, shift_Y, width, height);
        }
        return result;
    }

    public Bitmap CropBitmap(Bitmap source_bitmap, Rectangle cropArea)
    {
        if (cropArea.Width > 0 & cropArea.Height > 0)
        {
            // Обрезает Bitmap по заданному Rectangle
            Bitmap bmpImage = new Bitmap(source_bitmap);
            Bitmap cropped_bitmap = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return cropped_bitmap;
        }
        else return source_bitmap;
    }

    public Rectangle GetSelRectangle(Point orig, Point location)
    {
        // Создает Rectangle по двум точкам - orig и location
        int deltaX = location.X - orig.X, deltaY = location.Y - orig.Y;
        Size size_area = new Size(Math.Abs(deltaX), Math.Abs(deltaY));
        Rectangle selected_square = new Rectangle();

        if (deltaX >= 0 & deltaY >= 0)
        {
            selected_square = new Rectangle(orig, size_area);
            return selected_square;
        }
        else if (deltaX < 0 & deltaY > 0)
        {
            selected_square = new Rectangle(location.X, orig.Y, size_area.Width, size_area.Height);
            return selected_square;
        }
        else if (deltaX < 0 & deltaY < 0)
        {
            selected_square = new Rectangle(location, size_area);
            return selected_square;
        }
        else if (deltaX > 0 & deltaY < 0)
        {
            selected_square = new Rectangle(orig.X, location.Y, size_area.Width, size_area.Height);
            return selected_square;
        }
        else return selected_square;
    }

    public static Bitmap BrushDraw(ref Bitmap source, ref Pen brush_pen, ref Point start_point, ref Point finish_point) 
    {
        // Рисует brush_pen'ом линию по 2-м точкам
        using (Graphics g = Graphics.FromImage(source))
        {
            g.DrawLine(brush_pen, start_point.X, start_point.Y, finish_point.X, finish_point.Y);
        }
        return source;
    }

    public static Bitmap DrawLayersList(ref List<Layer> _work_layer_list, ref PictureBox Work_space, bool tmp = false)
    {
        Bitmap result = new Bitmap(Work_space.Width, Work_space.Height);
        using (Graphics g = Graphics.FromImage(result))
        {
            for (int i = 0; i < _work_layer_list.Count; i++)
            {
                if (_work_layer_list[i].visible)
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
        }
        return result;
    }
}