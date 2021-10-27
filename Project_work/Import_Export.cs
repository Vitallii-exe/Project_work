using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Project_work
{
    class Import_Export
    {
        public Import_Export() {
        
        }
        public static void ImportFromFile(ref List <Layer> work_layer_list, ref PictureBox Work_space) {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.ICO)|*.BMP;*.JPG;*.PNG;*.ICO|All files(*.*)|*.*";

            if (FD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Layer fromfilelayer = new Layer(work_layer_list.Count);
                    Bitmap orig = new Bitmap(FD.FileName);
                    Bitmap clone = new Bitmap(orig.Width, orig.Height,
                                              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                    using (Graphics gr = Graphics.FromImage(clone))
                    {
                        gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                    }
                    Work_space.Image = clone;
                    fromfilelayer.original = clone;
                    work_layer_list.Add(fromfilelayer);
                    Work_space.Image = Layer.DrawLayersList(ref work_layer_list, ref Work_space);
                    Work_space.Refresh();
                }
                catch
                {
                    MessageBox.Show("Выбранный файл невозможно открыть. Данный тип файла не поддерживается!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ExportToFile(ref List<Layer> work_layer_list, ref int CurrentLayerIndex) {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.ICO)|*.BMP;*.JPG;*.PNG;*.ICO|All files(*.*)|*.*";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    work_layer_list[CurrentLayerIndex].original.Save(FD.FileName);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка записи. Возможно, вы пытаетесь сохранить картинку, не содержащую ни одного пикселя.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
