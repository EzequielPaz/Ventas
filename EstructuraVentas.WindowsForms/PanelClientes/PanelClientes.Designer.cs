namespace EstructuraVentas.WindowsForms
{
    partial class PanelClientes
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            button5 = new Button();
            botonAnterior = new Button();
            botonSiguiente = new Button();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label7 = new Label();
            cboEstado = new ComboBox();
            txtDocumento = new TextBox();
            txtEmail = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(78, 152);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(641, 250);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(78, 134);
            label1.Name = "label1";
            label1.Size = new Size(134, 15);
            label1.TabIndex = 1;
            label1.Text = "Mantenimiento Clientes";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(481, 452);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(643, 452);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(562, 452);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Modificar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(78, 408);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "Actualizar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // iconButton2
            // 
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 18;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(375, 123);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(89, 23);
            iconButton2.TabIndex = 16;
            iconButton2.Text = "Buscar";
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // button5
            // 
            button5.Location = new Point(470, 123);
            button5.Name = "button5";
            button5.Size = new Size(86, 23);
            button5.TabIndex = 20;
            button5.Text = "Limpiar Filtro";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // botonAnterior
            // 
            botonAnterior.Location = new Point(562, 408);
            botonAnterior.Name = "botonAnterior";
            botonAnterior.Size = new Size(75, 23);
            botonAnterior.TabIndex = 21;
            botonAnterior.Text = "Anterior";
            botonAnterior.UseVisualStyleBackColor = true;
            botonAnterior.Click += button6_Click;
            // 
            // botonSiguiente
            // 
            botonSiguiente.Location = new Point(643, 408);
            botonSiguiente.Name = "botonSiguiente";
            botonSiguiente.Size = new Size(75, 23);
            botonSiguiente.TabIndex = 22;
            botonSiguiente.Text = "Siguiente";
            botonSiguiente.UseVisualStyleBackColor = true;
            botonSiguiente.Click += button7_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(470, 412);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 25;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboEstado);
            groupBox1.Controls.Add(txtDocumento);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(562, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(235, 134);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 105);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 7;
            label7.Text = "Estado";
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cboEstado.Location = new Point(91, 105);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(100, 23);
            cboEstado.TabIndex = 6;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(91, 73);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(100, 23);
            txtDocumento.TabIndex = 5;
            txtDocumento.TextChanged += txtDocumentoFilter_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(91, 45);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 4;
            txtEmail.TextChanged += txtEmailFilter_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(91, 16);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            txtNombre.TextChanged += txtNombreFilter_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 73);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 2;
            label6.Text = "Documento";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 48);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 1;
            label5.Text = "Email";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 19);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 0;
            label4.Text = "Nombre";
            label4.Click += label4_Click;
            // 
            // PanelClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(825, 488);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(botonSiguiente);
            Controls.Add(botonAnterior);
            Controls.Add(button5);
            Controls.Add(iconButton2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "PanelClientes";
            Text = "Panel De Clientes";
            Load += PanelClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Button button5;
        private Button botonAnterior;
        private Button botonSiguiente;
        private Label label3;
        private GroupBox groupBox1;
        private TextBox txtDocumento;
        private TextBox txtEmail;
        private TextBox txtNombre;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label7;
        private ComboBox cboEstado;
    }
}