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
    public partial class LayerVisualiser : UserControl
    {
        public LayerVisualiser()
        {
            InitializeComponent();
        }

        public static void UpdateLayersPreviews(ref List<Layer> _work_layer_list, ref Panel _layer_panel, ref int curr_layer_pos)
        {
            for (int i = 0; i < _work_layer_list.Count; i++)
            {
                int reversed_number = _work_layer_list.Count - i - 1;
                _work_layer_list[i].preview.Location = new Point(20, reversed_number * 60);
                _work_layer_list[i].visible_checkbox.Location = new Point(5, reversed_number * 60 + 15);
                _work_layer_list[i].label_caption.Location = new Point(120, reversed_number * 60 + 15);

                if (curr_layer_pos == i)
                {
                    _work_layer_list[i].label_caption.Text = "Слой " + i.ToString() + " (Активный)";
                }
                else _work_layer_list[i].label_caption.Text = "Слой " + i.ToString();

                _work_layer_list[i].preview.BackgroundImage = _work_layer_list[i].original;
            }
            _layer_panel.Refresh();
        }

        public static void AddVisualLayer(ref List<Layer> work_layer_list, ref int CurrentLayerIndex, ref Panel Layer_panel, ref PictureBox Work_space)
        {
            Layer_panel.Controls.Clear();
            UpdateLayersPreviews(ref work_layer_list, ref Layer_panel, ref CurrentLayerIndex);
            for (int i = 0; i < work_layer_list.Count; i++)
            {
                Layer_panel.Controls.Add(work_layer_list[i].preview);
                Layer_panel.Controls.Add(work_layer_list[i].visible_checkbox);
                Layer_panel.Controls.Add(work_layer_list[i].label_caption);

                //work_layer_list[i].visible_checkbox.Click += EventHandler();
                Layer_panel.Refresh();
            }
        }
    }
}
