
namespace Project_work
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cropping = new System.Windows.Forms.Button();
            this.create_area = new System.Windows.Forms.Button();
            this.moving_instr = new System.Windows.Forms.Button();
            this.brush = new System.Windows.Forms.Button();
            this.pipette = new System.Windows.Forms.Button();
            this.Apply_button = new System.Windows.Forms.Button();
            this.Work_space = new System.Windows.Forms.PictureBox();
            this.contextPicBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скопироватьНаНовыйСлойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вырезатьНаНовыйСлойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_from_file = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переместитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПрямоугольнуюОбластьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обрезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кистьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ластикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пипеткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заливкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветокоррекцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.насыщенностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.яркостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветовойТонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветовойБалансToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale = new System.Windows.Forms.TrackBar();
            this.Scale_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.choose_color_button = new System.Windows.Forms.Button();
            this.current_color_label = new System.Windows.Forms.Label();
            this.opacity_UpDown = new System.Windows.Forms.NumericUpDown();
            this.brush_width_label = new System.Windows.Forms.Label();
            this.Brush_label = new System.Windows.Forms.Label();
            this.scale_changing_label = new System.Windows.Forms.Label();
            this.HeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Choose_color = new System.Windows.Forms.ColorDialog();
            this.Eraser_button = new System.Windows.Forms.Button();
            this.saveBitmapToFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Work_space)).BeginInit();
            this.contextPicBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scale)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacity_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cropping
            // 
            this.cropping.BackColor = System.Drawing.Color.DimGray;
            this.cropping.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cropping.BackgroundImage")));
            this.cropping.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cropping.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cropping.FlatAppearance.BorderSize = 0;
            this.cropping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cropping.Location = new System.Drawing.Point(12, 113);
            this.cropping.Name = "cropping";
            this.cropping.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cropping.Size = new System.Drawing.Size(30, 30);
            this.cropping.TabIndex = 0;
            this.cropping.UseVisualStyleBackColor = false;
            // 
            // create_area
            // 
            this.create_area.BackColor = System.Drawing.Color.DimGray;
            this.create_area.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("create_area.BackgroundImage")));
            this.create_area.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.create_area.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create_area.FlatAppearance.BorderSize = 0;
            this.create_area.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create_area.Location = new System.Drawing.Point(12, 77);
            this.create_area.Name = "create_area";
            this.create_area.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.create_area.Size = new System.Drawing.Size(30, 30);
            this.create_area.TabIndex = 1;
            this.create_area.UseVisualStyleBackColor = false;
            this.create_area.Click += new System.EventHandler(this.create_area_Click);
            // 
            // moving_instr
            // 
            this.moving_instr.BackColor = System.Drawing.Color.DimGray;
            this.moving_instr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moving_instr.BackgroundImage")));
            this.moving_instr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moving_instr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moving_instr.FlatAppearance.BorderSize = 0;
            this.moving_instr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moving_instr.Location = new System.Drawing.Point(12, 41);
            this.moving_instr.Name = "moving_instr";
            this.moving_instr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.moving_instr.Size = new System.Drawing.Size(30, 30);
            this.moving_instr.TabIndex = 2;
            this.moving_instr.UseVisualStyleBackColor = false;
            this.moving_instr.Click += new System.EventHandler(this.moving_instr_Click);
            // 
            // brush
            // 
            this.brush.BackColor = System.Drawing.Color.DimGray;
            this.brush.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("brush.BackgroundImage")));
            this.brush.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.brush.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brush.FlatAppearance.BorderSize = 0;
            this.brush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brush.Location = new System.Drawing.Point(12, 163);
            this.brush.Name = "brush";
            this.brush.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.brush.Size = new System.Drawing.Size(30, 30);
            this.brush.TabIndex = 3;
            this.brush.UseVisualStyleBackColor = false;
            this.brush.Click += new System.EventHandler(this.brush_Click);
            // 
            // pipette
            // 
            this.pipette.BackColor = System.Drawing.Color.DimGray;
            this.pipette.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pipette.BackgroundImage")));
            this.pipette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pipette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pipette.FlatAppearance.BorderSize = 0;
            this.pipette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pipette.Location = new System.Drawing.Point(12, 199);
            this.pipette.Name = "pipette";
            this.pipette.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pipette.Size = new System.Drawing.Size(30, 30);
            this.pipette.TabIndex = 4;
            this.pipette.UseVisualStyleBackColor = false;
            // 
            // Apply_button
            // 
            this.Apply_button.BackColor = System.Drawing.Color.DimGray;
            this.Apply_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Apply_button.BackgroundImage")));
            this.Apply_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Apply_button.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Apply_button.FlatAppearance.BorderSize = 0;
            this.Apply_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Apply_button.Location = new System.Drawing.Point(12, 411);
            this.Apply_button.Name = "Apply_button";
            this.Apply_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Apply_button.Size = new System.Drawing.Size(30, 30);
            this.Apply_button.TabIndex = 5;
            this.Apply_button.UseVisualStyleBackColor = false;
            // 
            // Work_space
            // 
            this.Work_space.BackColor = System.Drawing.Color.Black;
            this.Work_space.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Work_space.BackgroundImage")));
            this.Work_space.ContextMenuStrip = this.contextPicBox;
            this.Work_space.Cursor = System.Windows.Forms.Cursors.Default;
            this.Work_space.Location = new System.Drawing.Point(0, 0);
            this.Work_space.Name = "Work_space";
            this.Work_space.Size = new System.Drawing.Size(675, 400);
            this.Work_space.TabIndex = 6;
            this.Work_space.TabStop = false;
            this.Work_space.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Work_space_MouseDown);
            this.Work_space.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Work_space_MouseMove);
            this.Work_space.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Work_space_MouseUp);
            // 
            // contextPicBox
            // 
            this.contextPicBox.BackColor = System.Drawing.Color.Gray;
            this.contextPicBox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextPicBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вырезатьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.скопироватьНаНовыйСлойToolStripMenuItem,
            this.вырезатьНаНовыйСлойToolStripMenuItem});
            this.contextPicBox.Name = "contextMenuStrip1";
            this.contextPicBox.ShowImageMargin = false;
            this.contextPicBox.Size = new System.Drawing.Size(253, 124);
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(252, 24);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(252, 24);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(252, 24);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // скопироватьНаНовыйСлойToolStripMenuItem
            // 
            this.скопироватьНаНовыйСлойToolStripMenuItem.Name = "скопироватьНаНовыйСлойToolStripMenuItem";
            this.скопироватьНаНовыйСлойToolStripMenuItem.Size = new System.Drawing.Size(252, 24);
            this.скопироватьНаНовыйСлойToolStripMenuItem.Text = "Скопировать на новый слой";
            // 
            // вырезатьНаНовыйСлойToolStripMenuItem
            // 
            this.вырезатьНаНовыйСлойToolStripMenuItem.Name = "вырезатьНаНовыйСлойToolStripMenuItem";
            this.вырезатьНаНовыйСлойToolStripMenuItem.Size = new System.Drawing.Size(252, 24);
            this.вырезатьНаНовыйСлойToolStripMenuItem.Text = "Вырезать на новый слой";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.рисованиеToolStripMenuItem,
            this.цветокоррекцияToolStripMenuItem,
            this.видToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_from_file,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // Open_from_file
            // 
            this.Open_from_file.Name = "Open_from_file";
            this.Open_from_file.Size = new System.Drawing.Size(224, 26);
            this.Open_from_file.Text = "Открыть";
            this.Open_from_file.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переместитьToolStripMenuItem,
            this.создатьПрямоугольнуюОбластьToolStripMenuItem,
            this.обрезатьToolStripMenuItem});
            this.редактированиеToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            // 
            // переместитьToolStripMenuItem
            // 
            this.переместитьToolStripMenuItem.Name = "переместитьToolStripMenuItem";
            this.переместитьToolStripMenuItem.Size = new System.Drawing.Size(322, 26);
            this.переместитьToolStripMenuItem.Text = "Переместить";
            // 
            // создатьПрямоугольнуюОбластьToolStripMenuItem
            // 
            this.создатьПрямоугольнуюОбластьToolStripMenuItem.Name = "создатьПрямоугольнуюОбластьToolStripMenuItem";
            this.создатьПрямоугольнуюОбластьToolStripMenuItem.Size = new System.Drawing.Size(322, 26);
            this.создатьПрямоугольнуюОбластьToolStripMenuItem.Text = "Создать прямоугольную область";
            // 
            // обрезатьToolStripMenuItem
            // 
            this.обрезатьToolStripMenuItem.Name = "обрезатьToolStripMenuItem";
            this.обрезатьToolStripMenuItem.Size = new System.Drawing.Size(322, 26);
            this.обрезатьToolStripMenuItem.Text = "Обрезать";
            // 
            // рисованиеToolStripMenuItem
            // 
            this.рисованиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кистьToolStripMenuItem,
            this.ластикToolStripMenuItem,
            this.пипеткаToolStripMenuItem,
            this.заливкаToolStripMenuItem});
            this.рисованиеToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.рисованиеToolStripMenuItem.Name = "рисованиеToolStripMenuItem";
            this.рисованиеToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.рисованиеToolStripMenuItem.Text = "Рисование";
            // 
            // кистьToolStripMenuItem
            // 
            this.кистьToolStripMenuItem.Name = "кистьToolStripMenuItem";
            this.кистьToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.кистьToolStripMenuItem.Text = "Кисть";
            // 
            // ластикToolStripMenuItem
            // 
            this.ластикToolStripMenuItem.Name = "ластикToolStripMenuItem";
            this.ластикToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.ластикToolStripMenuItem.Text = "Ластик";
            // 
            // пипеткаToolStripMenuItem
            // 
            this.пипеткаToolStripMenuItem.Name = "пипеткаToolStripMenuItem";
            this.пипеткаToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.пипеткаToolStripMenuItem.Text = "Пипетка";
            // 
            // заливкаToolStripMenuItem
            // 
            this.заливкаToolStripMenuItem.Name = "заливкаToolStripMenuItem";
            this.заливкаToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.заливкаToolStripMenuItem.Text = "Заливка";
            // 
            // цветокоррекцияToolStripMenuItem
            // 
            this.цветокоррекцияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.насыщенностьToolStripMenuItem,
            this.яркостьToolStripMenuItem,
            this.цветовойТонToolStripMenuItem,
            this.цветовойБалансToolStripMenuItem});
            this.цветокоррекцияToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.цветокоррекцияToolStripMenuItem.Name = "цветокоррекцияToolStripMenuItem";
            this.цветокоррекцияToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.цветокоррекцияToolStripMenuItem.Text = "Цветокоррекция";
            // 
            // насыщенностьToolStripMenuItem
            // 
            this.насыщенностьToolStripMenuItem.Name = "насыщенностьToolStripMenuItem";
            this.насыщенностьToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.насыщенностьToolStripMenuItem.Text = "Насыщенность";
            // 
            // яркостьToolStripMenuItem
            // 
            this.яркостьToolStripMenuItem.Name = "яркостьToolStripMenuItem";
            this.яркостьToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.яркостьToolStripMenuItem.Text = "Яркость";
            // 
            // цветовойТонToolStripMenuItem
            // 
            this.цветовойТонToolStripMenuItem.Name = "цветовойТонToolStripMenuItem";
            this.цветовойТонToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.цветовойТонToolStripMenuItem.Text = "Цветовой тон";
            // 
            // цветовойБалансToolStripMenuItem
            // 
            this.цветовойБалансToolStripMenuItem.Name = "цветовойБалансToolStripMenuItem";
            this.цветовойБалансToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.цветовойБалансToolStripMenuItem.Text = "Цветовой баланс";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // Scale
            // 
            this.Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale.Location = new System.Drawing.Point(25, 330);
            this.Scale.Maximum = 500;
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(232, 56);
            this.Scale.TabIndex = 8;
            this.Scale.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Scale.Value = 100;
            this.Scale.Scroll += new System.EventHandler(this.Scale_Scroll);
            // 
            // Scale_label
            // 
            this.Scale_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale_label.AutoSize = true;
            this.Scale_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Scale_label.ForeColor = System.Drawing.Color.White;
            this.Scale_label.Location = new System.Drawing.Point(201, 366);
            this.Scale_label.Name = "Scale_label";
            this.Scale_label.Size = new System.Drawing.Size(56, 20);
            this.Scale_label.TabIndex = 9;
            this.Scale_label.Text = "100 %";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.choose_color_button);
            this.panel1.Controls.Add(this.current_color_label);
            this.panel1.Controls.Add(this.opacity_UpDown);
            this.panel1.Controls.Add(this.brush_width_label);
            this.panel1.Controls.Add(this.Brush_label);
            this.panel1.Controls.Add(this.scale_changing_label);
            this.panel1.Controls.Add(this.HeightUpDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Scale_label);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Scale);
            this.panel1.Controls.Add(this.WidthUpDown);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(750, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 400);
            this.panel1.TabIndex = 13;
            // 
            // choose_color_button
            // 
            this.choose_color_button.BackColor = System.Drawing.Color.DimGray;
            this.choose_color_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choose_color_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.choose_color_button.FlatAppearance.BorderSize = 0;
            this.choose_color_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choose_color_button.Location = new System.Drawing.Point(126, 199);
            this.choose_color_button.Name = "choose_color_button";
            this.choose_color_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.choose_color_button.Size = new System.Drawing.Size(130, 30);
            this.choose_color_button.TabIndex = 15;
            this.choose_color_button.UseVisualStyleBackColor = false;
            this.choose_color_button.Click += new System.EventHandler(this.choose_color_button_Click);
            // 
            // current_color_label
            // 
            this.current_color_label.AutoSize = true;
            this.current_color_label.Location = new System.Drawing.Point(16, 206);
            this.current_color_label.Name = "current_color_label";
            this.current_color_label.Size = new System.Drawing.Size(104, 17);
            this.current_color_label.TabIndex = 14;
            this.current_color_label.Text = "Текущий цвет:";
            // 
            // opacity_UpDown
            // 
            this.opacity_UpDown.BackColor = System.Drawing.Color.DimGray;
            this.opacity_UpDown.Location = new System.Drawing.Point(175, 155);
            this.opacity_UpDown.Maximum = new decimal(new int[] {
            8400,
            0,
            0,
            0});
            this.opacity_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.opacity_UpDown.Name = "opacity_UpDown";
            this.opacity_UpDown.Size = new System.Drawing.Size(81, 22);
            this.opacity_UpDown.TabIndex = 13;
            this.opacity_UpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.opacity_UpDown.ValueChanged += new System.EventHandler(this.opacity_UpDown_ValueChanged);
            // 
            // brush_width_label
            // 
            this.brush_width_label.AutoSize = true;
            this.brush_width_label.Location = new System.Drawing.Point(16, 157);
            this.brush_width_label.Name = "brush_width_label";
            this.brush_width_label.Size = new System.Drawing.Size(157, 17);
            this.brush_width_label.TabIndex = 12;
            this.brush_width_label.Text = "Толщина (в пикселях):";
            // 
            // Brush_label
            // 
            this.Brush_label.AutoSize = true;
            this.Brush_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Brush_label.Location = new System.Drawing.Point(16, 121);
            this.Brush_label.Name = "Brush_label";
            this.Brush_label.Size = new System.Drawing.Size(56, 17);
            this.Brush_label.TabIndex = 11;
            this.Brush_label.Text = "Кисть:";
            // 
            // scale_changing_label
            // 
            this.scale_changing_label.AutoSize = true;
            this.scale_changing_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale_changing_label.Location = new System.Drawing.Point(3, 303);
            this.scale_changing_label.Name = "scale_changing_label";
            this.scale_changing_label.Size = new System.Drawing.Size(268, 17);
            this.scale_changing_label.TabIndex = 10;
            this.scale_changing_label.Text = "Изменение размера изображения:";
            // 
            // HeightUpDown
            // 
            this.HeightUpDown.BackColor = System.Drawing.Color.DimGray;
            this.HeightUpDown.Location = new System.Drawing.Point(175, 79);
            this.HeightUpDown.Maximum = new decimal(new int[] {
            8400,
            0,
            0,
            0});
            this.HeightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightUpDown.Name = "HeightUpDown";
            this.HeightUpDown.Size = new System.Drawing.Size(81, 22);
            this.HeightUpDown.TabIndex = 4;
            this.HeightUpDown.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.HeightUpDown.ValueChanged += new System.EventHandler(this.HeightUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Высота (в пикселях):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина (в пикселях):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Свойства проекта:";
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.BackColor = System.Drawing.Color.DimGray;
            this.WidthUpDown.Location = new System.Drawing.Point(175, 43);
            this.WidthUpDown.Maximum = new decimal(new int[] {
            8400,
            0,
            0,
            0});
            this.WidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(81, 22);
            this.WidthUpDown.TabIndex = 0;
            this.WidthUpDown.Value = new decimal(new int[] {
            675,
            0,
            0,
            0});
            this.WidthUpDown.ValueChanged += new System.EventHandler(this.WidthUpDown_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.Work_space);
            this.panel2.Location = new System.Drawing.Point(48, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 400);
            this.panel2.TabIndex = 14;
            // 
            // toolTip1
            // 
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.Tag = "gfcdcgvhj";
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "vghcfghjkhvg";
            // 
            // Eraser_button
            // 
            this.Eraser_button.BackColor = System.Drawing.Color.DimGray;
            this.Eraser_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Eraser_button.BackgroundImage")));
            this.Eraser_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Eraser_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Eraser_button.FlatAppearance.BorderSize = 0;
            this.Eraser_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eraser_button.Location = new System.Drawing.Point(12, 235);
            this.Eraser_button.Name = "Eraser_button";
            this.Eraser_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Eraser_button.Size = new System.Drawing.Size(30, 30);
            this.Eraser_button.TabIndex = 15;
            this.Eraser_button.UseVisualStyleBackColor = false;
            this.Eraser_button.Click += new System.EventHandler(this.Eraser_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1038, 673);
            this.Controls.Add(this.Eraser_button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Apply_button);
            this.Controls.Add(this.pipette);
            this.Controls.Add(this.brush);
            this.Controls.Add(this.moving_instr);
            this.Controls.Add(this.create_area);
            this.Controls.Add(this.cropping);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Graphics Editor";
            ((System.ComponentModel.ISupportInitialize)(this.Work_space)).EndInit();
            this.contextPicBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scale)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacity_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cropping;
        private System.Windows.Forms.Button create_area;
        private System.Windows.Forms.Button moving_instr;
        private System.Windows.Forms.Button brush;
        private System.Windows.Forms.Button pipette;
        private System.Windows.Forms.Button Apply_button;
        private System.Windows.Forms.PictureBox Work_space;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветокоррекцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open_from_file;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переместитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПрямоугольнуюОбластьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обрезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кистьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ластикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пипеткаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заливкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem насыщенностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem яркостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветовойТонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветовойБалансToolStripMenuItem;
        private System.Windows.Forms.TrackBar Scale;
        private System.Windows.Forms.Label Scale_label;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextPicBox;
        private System.Windows.Forms.ToolStripMenuItem скопироватьНаНовыйСлойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьНаНовыйСлойToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown HeightUpDown;
        private System.Windows.Forms.Label scale_changing_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label current_color_label;
        private System.Windows.Forms.NumericUpDown opacity_UpDown;
        private System.Windows.Forms.Label brush_width_label;
        private System.Windows.Forms.Label Brush_label;
        private System.Windows.Forms.Button choose_color_button;
        private System.Windows.Forms.ColorDialog Choose_color;
        private System.Windows.Forms.Button Eraser_button;
        private System.Windows.Forms.SaveFileDialog saveBitmapToFile;
    }
}

