namespace EstructuraVentas.WindowsForms
{
    partial class PanelProductos
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
            AgregarProducto = new Button();
            ModificarProducto = new Button();
            EliminarProducto = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            button5 = new Button();
            button6 = new Button();
            botonAnterior = new Button();
            botonSiguiente = new Button();
            LabelPaginacion = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(90, 46);
            label1.Name = "label1";
            label1.Size = new Size(146, 15);
            label1.TabIndex = 0;
            label1.Text = "Mantenimiento Productos";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(90, 141);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(648, 221);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // AgregarProducto
            // 
            AgregarProducto.Location = new Point(501, 408);
            AgregarProducto.Name = "AgregarProducto";
            AgregarProducto.Size = new Size(75, 23);
            AgregarProducto.TabIndex = 2;
            AgregarProducto.Text = "Agregar";
            AgregarProducto.UseVisualStyleBackColor = true;
            AgregarProducto.Click += button1_Click;
            // 
            // ModificarProducto
            // 
            ModificarProducto.Location = new Point(582, 408);
            ModificarProducto.Name = "ModificarProducto";
            ModificarProducto.Size = new Size(75, 23);
            ModificarProducto.TabIndex = 3;
            ModificarProducto.Text = "Modificar";
            ModificarProducto.UseVisualStyleBackColor = true;
            ModificarProducto.Click += button2_Click;
            // 
            // EliminarProducto
            // 
            EliminarProducto.Location = new Point(663, 408);
            EliminarProducto.Name = "EliminarProducto";
            EliminarProducto.Size = new Size(75, 23);
            EliminarProducto.TabIndex = 4;
            EliminarProducto.Text = "Eliminar";
            EliminarProducto.UseVisualStyleBackColor = true;
            EliminarProducto.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(90, 408);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "Actualizar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(277, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(126, 23);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.Location = new Point(90, 109);
            label2.Name = "label2";
            label2.Size = new Size(60, 23);
            label2.TabIndex = 14;
            label2.Text = "Columna";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nombre Producto", "Codigo Producto" });
            comboBox1.Location = new Point(156, 106);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(115, 23);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // iconButton2
            // 
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 18;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(409, 106);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(33, 23);
            iconButton2.TabIndex = 12;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // button5
            // 
            button5.Location = new Point(618, 105);
            button5.Name = "button5";
            button5.Size = new Size(86, 23);
            button5.TabIndex = 16;
            button5.Text = "Limpiar Filtro";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(171, 408);
            button6.Name = "button6";
            button6.Size = new Size(115, 23);
            button6.TabIndex = 17;
            button6.Text = "Agregar Categoria";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // botonAnterior
            // 
            botonAnterior.Location = new Point(561, 368);
            botonAnterior.Name = "botonAnterior";
            botonAnterior.Size = new Size(75, 23);
            botonAnterior.TabIndex = 18;
            botonAnterior.Text = "Anterior";
            botonAnterior.UseVisualStyleBackColor = true;
            botonAnterior.Click += button7_Click;
            // 
            // botonSiguiente
            // 
            botonSiguiente.Location = new Point(663, 368);
            botonSiguiente.Name = "botonSiguiente";
            botonSiguiente.Size = new Size(75, 23);
            botonSiguiente.TabIndex = 19;
            botonSiguiente.Text = "Siguiente";
            botonSiguiente.UseVisualStyleBackColor = true;
            botonSiguiente.Click += button8_Click;
            // 
            // LabelPaginacion
            // 
            LabelPaginacion.AutoSize = true;
            LabelPaginacion.Location = new Point(478, 374);
            LabelPaginacion.Name = "LabelPaginacion";
            LabelPaginacion.Size = new Size(38, 15);
            LabelPaginacion.TabIndex = 20;
            LabelPaginacion.Text = "label3";
            // 
            // PanelProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 621);
            Controls.Add(LabelPaginacion);
            Controls.Add(botonSiguiente);
            Controls.Add(botonAnterior);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(iconButton2);
            Controls.Add(button4);
            Controls.Add(EliminarProducto);
            Controls.Add(ModificarProducto);
            Controls.Add(AgregarProducto);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "PanelProductos";
            Text = "PanelProductos";
            Load += PanelProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button AgregarProducto;
        private Button ModificarProducto;
        private Button EliminarProducto;
        private Button button4;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Button button5;
        private Button button6;
        private Button botonAnterior;
        private Button botonSiguiente;
        private Label LabelPaginacion;
    }
}