namespace Views.Vistas.Menus
{
    partial class MenuPrincipal
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
            panel1 = new Panel();
            PanelContenido = new Panel();
            PanelMenu = new Panel();
            panel3 = new Panel();
            btnRGrupos = new Button();
            btnRGastos = new Button();
            panel6 = new Panel();
            panel5 = new Panel();
            txtName = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            PanelMenu.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 50, 50);
            panel1.Controls.Add(PanelContenido);
            panel1.Controls.Add(PanelMenu);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // PanelContenido
            // 
            PanelContenido.Dock = DockStyle.Fill;
            PanelContenido.Location = new Point(195, 0);
            PanelContenido.Name = "PanelContenido";
            PanelContenido.Size = new Size(605, 450);
            PanelContenido.TabIndex = 1;
            // 
            // PanelMenu
            // 
            PanelMenu.Controls.Add(panel3);
            PanelMenu.Controls.Add(panel6);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(195, 450);
            PanelMenu.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(45, 45, 60);
            panel3.Controls.Add(btnRGrupos);
            panel3.Controls.Add(btnRGastos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 129);
            panel3.Name = "panel3";
            panel3.Size = new Size(195, 321);
            panel3.TabIndex = 2;
            // 
            // btnRGrupos
            // 
            btnRGrupos.BackColor = Color.MediumSeaGreen;
            btnRGrupos.FlatAppearance.BorderSize = 0;
            btnRGrupos.FlatStyle = FlatStyle.Flat;
            btnRGrupos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRGrupos.Location = new Point(12, 75);
            btnRGrupos.Name = "btnRGrupos";
            btnRGrupos.Size = new Size(161, 44);
            btnRGrupos.TabIndex = 2;
            btnRGrupos.Text = "Registrar Grupos";
            btnRGrupos.UseVisualStyleBackColor = false;
            btnRGrupos.Click += btnRGrupos_Click;
            // 
            // btnRGastos
            // 
            btnRGastos.BackColor = Color.MediumSeaGreen;
            btnRGastos.FlatAppearance.BorderSize = 0;
            btnRGastos.FlatStyle = FlatStyle.Flat;
            btnRGastos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRGastos.Location = new Point(12, 16);
            btnRGastos.Name = "btnRGastos";
            btnRGastos.Size = new Size(161, 44);
            btnRGastos.TabIndex = 0;
            btnRGastos.Text = "Registrar Gastos";
            btnRGastos.UseVisualStyleBackColor = false;
            btnRGastos.Click += btnRGastos_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(45, 45, 60);
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(pictureBox1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(195, 129);
            panel6.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(50, 150, 50);
            panel5.Controls.Add(txtName);
            panel5.Dock = DockStyle.Bottom;
            panel5.Font = new Font("Segoe UI", 1F);
            panel5.Location = new Point(0, 105);
            panel5.Name = "panel5";
            panel5.Size = new Size(195, 24);
            panel5.TabIndex = 21;
            // 
            // txtName
            // 
            txtName.AutoSize = true;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.ForeColor = Color.White;
            txtName.Location = new Point(69, 1);
            txtName.Name = "txtName";
            txtName.Size = new Size(49, 20);
            txtName.TabIndex = 22;
            txtName.Text = "Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(51, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(89, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            panel1.ResumeLayout(false);
            PanelMenu.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel PanelContenido;
        private Panel PanelMenu;
        private Button btnRGastos;
        private Panel panel3;
        private Button btnRGrupos;
        private PictureBox pictureBox1;
        private Panel panel5;
        private Panel panel6;
        private Label txtName;
    }
}