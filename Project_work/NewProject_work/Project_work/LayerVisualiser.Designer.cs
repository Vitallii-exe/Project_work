using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Project_work
{
    partial class LayerVisualiser
    {
        private System.ComponentModel.IContainer components = null;
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Point now_locate_preview = new Point(20, 60);
            Point now_locate_checkbox = new Point(5, 60 + 15);
            Point now_locate_caption = new Point(120, 60 + 15);
            preview.Location = now_locate_preview;
            preview.Size = new Size(80, 50);
            preview.Visible = true;
            preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

            visible_checkbox.Location = now_locate_checkbox;
            visible_checkbox.Checked = true;

            label_caption.Location = now_locate_caption;
            label_caption.Visible = true;
            label_caption.Text = "Слой ";
        }

        public Button preview = new Button();
        public CheckBox visible_checkbox = new CheckBox();
        public Label label_caption = new Label();
    }
}
