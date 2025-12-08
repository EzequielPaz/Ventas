namespace EstructuraVentas.WindowsForms
{
    partial class PanelAgregarProveedor
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(194, 174);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(194, 63);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 2;
            label3.Text = "Razon social";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(194, 100);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 3;
            label4.Text = "CUIT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(194, 137);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 4;
            label5.Text = "Codigo";
            // 
            // button1
            // 
            button1.Location = new Point(194, 254);
            button1.Name = "button1";
            button1.Size = new Size(91, 35);
            button1.TabIndex = 10;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(288, 254);
            button2.Name = "button2";
            button2.Size = new Size(91, 35);
            button2.TabIndex = 11;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 211);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 12;
            label2.Text = "Correo";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(279, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 13;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(279, 97);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 14;
            textBox2.TextChanged += textBox2_TextChanged_1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(279, 134);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 15;
            textBox3.TextChanged += textBox3_TextChanged_1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(279, 171);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 16;
            textBox4.TextChanged += textBox4_TextChanged_1;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(279, 208);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 17;
            textBox5.TextChanged += textBox5_TextChanged_1;
            // 
            // PanelAgregarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "PanelAgregarProveedor";
            Text = "PanelAgregarProveedor";
            Load += PanelAgregarProveedor_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button2;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
    }
}