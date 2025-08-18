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
            txtAvisoDeudas = new Label();
            btnGastos = new Button();
            lbDeudas = new ListBox();
            txtDeudas = new Label();
            btnReportes = new Button();
            btnInvitaciones = new Button();
            btnGrupos = new Button();
            btnRGrupos = new Button();
            btnRGastos = new Button();
            panel6 = new Panel();
            btnCerrarSesion = new Button();
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
            panel1.Size = new Size(1275, 651);
            panel1.TabIndex = 0;
            // 
            // PanelContenido
            // 
            PanelContenido.Dock = DockStyle.Fill;
            PanelContenido.Location = new Point(257, 0);
            PanelContenido.Name = "PanelContenido";
            PanelContenido.Size = new Size(1018, 651);
            PanelContenido.TabIndex = 1;
            // 
            // PanelMenu
            // 
            PanelMenu.Controls.Add(panel3);
            PanelMenu.Controls.Add(panel6);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(257, 651);
            PanelMenu.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(45, 45, 60);
            panel3.Controls.Add(txtAvisoDeudas);
            panel3.Controls.Add(btnGastos);
            panel3.Controls.Add(lbDeudas);
            panel3.Controls.Add(txtDeudas);
            panel3.Controls.Add(btnReportes);
            panel3.Controls.Add(btnInvitaciones);
            panel3.Controls.Add(btnGrupos);
            panel3.Controls.Add(btnRGrupos);
            panel3.Controls.Add(btnRGastos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 105);
            panel3.Name = "panel3";
            panel3.Size = new Size(257, 546);
            panel3.TabIndex = 2;
            // 
            // txtAvisoDeudas
            // 
            txtAvisoDeudas.AutoSize = true;
            txtAvisoDeudas.Font = new Font("Segoe UI", 8F);
            txtAvisoDeudas.ForeColor = Color.White;
            txtAvisoDeudas.Location = new Point(12, 511);
            txtAvisoDeudas.Name = "txtAvisoDeudas";
            txtAvisoDeudas.Size = new Size(145, 26);
            txtAvisoDeudas.TabIndex = 24;
            txtAvisoDeudas.Text = "Para mas detalles \r\nrevise la sección de grupos\r\n";
            // 
            // btnGastos
            // 
            btnGastos.BackColor = Color.MediumSeaGreen;
            btnGastos.FlatAppearance.BorderSize = 0;
            btnGastos.FlatStyle = FlatStyle.Flat;
            btnGastos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGastos.Location = new Point(12, 206);
            btnGastos.Name = "btnGastos";
            btnGastos.Size = new Size(225, 44);
            btnGastos.TabIndex = 6;
            btnGastos.Text = "Gastos";
            btnGastos.UseVisualStyleBackColor = false;
            btnGastos.Click += btnGastos_Click;
            // 
            // lbDeudas
            // 
            lbDeudas.FormattingEnabled = true;
            lbDeudas.Location = new Point(12, 417);
            lbDeudas.Name = "lbDeudas";
            lbDeudas.Size = new Size(225, 94);
            lbDeudas.TabIndex = 21;
            // 
            // txtDeudas
            // 
            txtDeudas.AutoSize = true;
            txtDeudas.Font = new Font("Segoe UI", 11F);
            txtDeudas.ForeColor = Color.White;
            txtDeudas.Location = new Point(12, 394);
            txtDeudas.Name = "txtDeudas";
            txtDeudas.Size = new Size(134, 20);
            txtDeudas.TabIndex = 23;
            txtDeudas.Text = "Deudas Pendientes";
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.MediumSeaGreen;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReportes.Location = new Point(12, 335);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(225, 44);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnInvitaciones
            // 
            btnInvitaciones.BackColor = Color.MediumSeaGreen;
            btnInvitaciones.FlatAppearance.BorderSize = 0;
            btnInvitaciones.FlatStyle = FlatStyle.Flat;
            btnInvitaciones.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnInvitaciones.Location = new Point(12, 18);
            btnInvitaciones.Name = "btnInvitaciones";
            btnInvitaciones.Size = new Size(225, 44);
            btnInvitaciones.TabIndex = 4;
            btnInvitaciones.Text = "Invitaciones";
            btnInvitaciones.UseVisualStyleBackColor = false;
            btnInvitaciones.Click += btnInvitaciones_Click;
            // 
            // btnGrupos
            // 
            btnGrupos.BackColor = Color.MediumSeaGreen;
            btnGrupos.FlatAppearance.BorderSize = 0;
            btnGrupos.FlatStyle = FlatStyle.Flat;
            btnGrupos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGrupos.Location = new Point(12, 82);
            btnGrupos.Name = "btnGrupos";
            btnGrupos.Size = new Size(225, 44);
            btnGrupos.TabIndex = 3;
            btnGrupos.Text = "Grupos";
            btnGrupos.UseVisualStyleBackColor = false;
            btnGrupos.Click += btnGrupos_Click;
            // 
            // btnRGrupos
            // 
            btnRGrupos.BackColor = Color.MediumSeaGreen;
            btnRGrupos.FlatAppearance.BorderSize = 0;
            btnRGrupos.FlatStyle = FlatStyle.Flat;
            btnRGrupos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRGrupos.Location = new Point(12, 144);
            btnRGrupos.Name = "btnRGrupos";
            btnRGrupos.Size = new Size(225, 44);
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
            btnRGastos.Location = new Point(12, 268);
            btnRGastos.Name = "btnRGastos";
            btnRGastos.Size = new Size(225, 44);
            btnRGastos.TabIndex = 0;
            btnRGastos.Text = "Registrar Gastos";
            btnRGastos.UseVisualStyleBackColor = false;
            btnRGastos.Click += btnRGastos_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(45, 45, 60);
            panel6.Controls.Add(btnCerrarSesion);
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(pictureBox1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(257, 105);
            panel6.TabIndex = 22;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.IndianRed;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.Location = new Point(156, 21);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(81, 44);
            btnCerrarSesion.TabIndex = 22;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(50, 150, 50);
            panel5.Controls.Add(txtName);
            panel5.Dock = DockStyle.Bottom;
            panel5.Font = new Font("Segoe UI", 1F);
            panel5.Location = new Point(0, 81);
            panel5.Name = "panel5";
            panel5.Size = new Size(257, 24);
            panel5.TabIndex = 21;
            // 
            // txtName
            // 
            txtName.AutoSize = true;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.ForeColor = Color.White;
            txtName.Location = new Point(12, 1);
            txtName.Name = "txtName";
            txtName.Size = new Size(49, 20);
            txtName.TabIndex = 22;
            txtName.Text = "Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(47, 0);
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
            ClientSize = new Size(1275, 651);
            Controls.Add(panel1);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            FormClosing += MenuPrincipal_FormClosing;
            panel1.ResumeLayout(false);
            PanelMenu.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private Button btnInvitaciones;
        private Button btnGrupos;
        private Button btnReportes;
        private Button btnGastos;
        private Label txtAvisoDeudas;
        private Label txtDeudas;
        private ListBox lbDeudas;
        private Button btnCerrarSesion;
    }
}