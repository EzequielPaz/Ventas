namespace EstructuraVentas.WindowsForms
{
    partial class PanelProveedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dataGridView1 = new DataGridView();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            comboBox1 = new ComboBox();
            label2 = new Label();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(145, 65);
            label1.Name = "label1";
            label1.Size = new Size(238, 59);
            label1.TabIndex = 0;
            label1.Text = "Proveedores";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(145, 224);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(874, 280);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 25;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(630, 522);
            iconButton1.Margin = new Padding(3, 4, 3, 4);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(111, 43);
            iconButton1.TabIndex = 3;
            iconButton1.Text = "Agregar";
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // iconButton2
            // 
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 18;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(313, 143);
            iconButton2.Margin = new Padding(3, 4, 3, 4);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(38, 31);
            iconButton2.TabIndex = 4;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // iconButton3
            // 
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Edit;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 25;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(781, 522);
            iconButton3.Margin = new Padding(3, 4, 3, 4);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(111, 43);
            iconButton3.TabIndex = 5;
            iconButton3.Text = "Editar";
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // iconButton4
            // 
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.Redo;
            iconButton4.IconColor = Color.Black;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 25;
            iconButton4.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton4.Location = new Point(145, 522);
            iconButton4.Margin = new Padding(3, 4, 3, 4);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(119, 43);
            iconButton4.TabIndex = 6;
            iconButton4.Text = "Actualizar";
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += iconButton4_Click;
            // 
            // iconButton5
            // 
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.Remove;
            iconButton5.IconColor = Color.Black;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton5.IconSize = 25;
            iconButton5.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton5.Location = new Point(911, 522);
            iconButton5.Margin = new Padding(3, 4, 3, 4);
            iconButton5.Name = "iconButton5";
            iconButton5.Size = new Size(122, 43);
            iconButton5.TabIndex = 7;
            iconButton5.Text = "Eliminar";
            iconButton5.UseVisualStyleBackColor = true;
            iconButton5.Click += iconButton5_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Razon Social", "CUIT", "Codigo Proveedor", "Correo" });
            comboBox1.Location = new Point(145, 181);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Location = new Point(149, 148);
            label2.Name = "label2";
            label2.Size = new Size(135, 31);
            label2.TabIndex = 9;
            label2.Text = "Columna";
            // 
            // iconButton6
            // 
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.Download;
            iconButton6.IconColor = Color.Black;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton6.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton6.Location = new Point(966, 831);
            iconButton6.Margin = new Padding(3, 4, 3, 4);
            iconButton6.Name = "iconButton6";
            iconButton6.Size = new Size(207, 56);
            iconButton6.TabIndex = 10;
            iconButton6.Text = "Descargar excel";
            iconButton6.UseVisualStyleBackColor = true;
            iconButton6.Click += iconButton6_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(313, 181);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(143, 27);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // button1
            // 
            button1.Location = new Point(558, 143);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(119, 41);
            button1.TabIndex = 12;
            button1.Text = "Limpiar Filtro";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PanelProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1126, 629);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(iconButton6);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(iconButton5);
            Controls.Add(iconButton4);
            Controls.Add(iconButton3);
            Controls.Add(iconButton2);
            Controls.Add(iconButton1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PanelProveedores";
            Text = "PanelProveedores";
            Load += PanelProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton5;
        private ComboBox comboBox1;
        private Label label2;
        private FontAwesome.Sharp.IconButton iconButton6;
        private TextBox textBox1;
        private Button button1;
    }
}