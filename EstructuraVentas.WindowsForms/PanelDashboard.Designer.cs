
﻿using static System.Net.Mime.MediaTypeNames;

namespace EstructuraVentas.WindowsForms


{
    partial class PanelDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelDashboard));
            panelside = new Panel();
            button2 = new Button();
            button1 = new Button();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            button5 = new FontAwesome.Sharp.IconButton();
            button4 = new FontAwesome.Sharp.IconButton();
            button3 = new FontAwesome.Sharp.IconButton();
            panelheader = new Panel();
            mainpanel = new Panel();
            panelside.SuspendLayout();
            SuspendLayout();
            // 
            // panelside
            // 
            panelside.BackColor = SystemColors.AppWorkspace;
            panelside.Controls.Add(button2);
            panelside.Controls.Add(button1);
            panelside.Controls.Add(iconButton3);
            panelside.Controls.Add(iconButton1);
            panelside.Controls.Add(panelLogo);
            panelside.Controls.Add(button5);
            panelside.Controls.Add(button4);
            panelside.Controls.Add(button3);
            panelside.Dock = DockStyle.Left;
            panelside.Location = new Point(0, 0);
            panelside.Name = "panelside";
            panelside.Size = new Size(194, 716);
            panelside.TabIndex = 2;
            panelside.Paint += panel1_Paint;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Location = new Point(-6, 401);
            button2.Name = "button2";
            button2.Size = new Size(200, 45);
            button2.TabIndex = 8;
            button2.Text = "Compras";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(0, 340);
            button1.Name = "button1";
            button1.Size = new Size(200, 45);
            button1.TabIndex = 7;
            button1.Text = "Proveedores";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // iconButton3
            // 
            iconButton3.Dock = DockStyle.Bottom;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Cog;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 35;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(0, 628);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(194, 44);
            iconButton3.TabIndex = 6;
            iconButton3.Text = "Configuraciones";
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // iconButton1
            // 
            iconButton1.Dock = DockStyle.Bottom;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 35;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(0, 672);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(194, 44);
            iconButton1.TabIndex = 1;
            iconButton1.Text = "Cerrar sesion";
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackgroundImage = (System.Drawing.Image)resources.GetObject("panelLogo.BackgroundImage");
            panelLogo.BackgroundImageLayout = ImageLayout.Stretch;
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(194, 71);
            panelLogo.TabIndex = 4;
            panelLogo.Paint += panelLogo_Paint;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.Window;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            button5.IconColor = Color.Black;
            button5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button5.IconSize = 24;
            button5.Location = new Point(0, 271);
            button5.Name = "button5";
            button5.Size = new Size(200, 44);
            button5.TabIndex = 2;
            button5.Text = "Ventas";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Window;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ActiveCaptionText;
            button4.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked;
            button4.IconColor = Color.Black;
            button4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button4.IconSize = 24;
            button4.Location = new Point(0, 221);
            button4.Name = "button4";
            button4.Size = new Size(200, 44);
            button4.TabIndex = 1;
            button4.Text = "Productos";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Window;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.IconChar = FontAwesome.Sharp.IconChar.Users;
            button3.IconColor = Color.Black;
            button3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button3.IconSize = 24;
            button3.Location = new Point(0, 171);
            button3.Name = "button3";
            button3.Size = new Size(200, 44);
            button3.TabIndex = 0;
            button3.Text = "Clientes";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panelheader
            // 
            panelheader.BackColor = SystemColors.AppWorkspace;
            panelheader.Dock = DockStyle.Top;
            panelheader.Location = new Point(194, 0);
            panelheader.Name = "panelheader";
            panelheader.Size = new Size(1030, 71);
            panelheader.TabIndex = 3;
            panelheader.Paint += panelheader_Paint;
            // 
            // mainpanel
            // 
            mainpanel.BackColor = SystemColors.MenuBar;
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(194, 71);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1030, 645);
            mainpanel.TabIndex = 4;
            mainpanel.Paint += mainpanel_Paint;
            // 
            // PanelDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 716);
            Controls.Add(mainpanel);
            Controls.Add(panelheader);
            Controls.Add(panelside);
            Name = "PanelDashboard";
            Text = "PanelDashboard";
            Load += PanelDashboard_Load;
            panelside.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelside;
        private Panel panelheader;
        private Panel mainpanel;
        private FontAwesome.Sharp.IconButton button5;
        private FontAwesome.Sharp.IconButton button4;
        //private Button button3;
        private FontAwesome.Sharp.IconButton button3;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private Button button1;
        private Button button2;
    }
}