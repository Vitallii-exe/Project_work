using System;
using System.Drawing;

public class Layer
{
    public Bitmap original;
    public int Active_instr = 0;

    public Pen layer_pen = new Pen(Brushes.Black, 10.0f) { StartCap = System.Drawing.Drawing2D.LineCap.Round, EndCap = System.Drawing.Drawing2D.LineCap.Round };
    public Pen selection_pen = new Pen(Brushes.Black, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash};

    public Point start_position = new Point(0, 0);
    public Point start_position_selection = new Point(0, 0);
    public Point shift = new Point(0, 0);
    public Point shift_tmp = new Point(0, 0);
    public Point last_position = new Point(0, 0);

    public Rectangle selection = new Rectangle(0, 0, 0, 0);
    public int scale = 100;


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

    public Point CorrectPoint(Point current_coord, Point _shift, int _scale) {
        // Корректирует координаты, учитывая сдвиг и масштаб
        Point new_coord = new Point(current_coord.X / _scale * 100 - _shift.X, current_coord.Y / _scale * 100 - _shift.Y);
        //Point new_coord = new Point((current_coord.X - _shift.X) / _scale * 100, (current_coord.Y - _shift.Y) / _scale * 100);
        return new_coord;
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

    public static Bitmap BrushDraw(Bitmap source, Pen brush_pen, Point start_point, Point finish_point) 
    {
        // Рисует brush_pen'ом линию по 2-м точкам
        using (Graphics g = Graphics.FromImage(source))
        {
            g.DrawLine(brush_pen, start_point.X, start_point.Y, finish_point.X, finish_point.Y);
        }
        return source;
    }
}
