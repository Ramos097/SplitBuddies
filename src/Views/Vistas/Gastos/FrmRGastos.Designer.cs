namespace Views.Gastos
{
    partial class FrmRGastos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel3 = new Panel();
            btnActualizar = new Button();
            clbMiembros = new CheckedListBox();
            label7 = new Label();
            cbGrupos = new ComboBox();
            label6 = new Label();
            btnPagar = new Button();
            txtMonto = new TextBox();
            txtDescripcion = new TextBox();
            dtpFecha = new DateTimePicker();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            txtNombreGasto = new TextBox();
            panel2 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 50, 50);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(701, 584);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnActualizar);
            panel3.Controls.Add(clbMiembros);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(cbGrupos);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(btnPagar);
            panel3.Controls.Add(txtMonto);
            panel3.Controls.Add(txtDescripcion);
            panel3.Controls.Add(dtpFecha);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtNombreGasto);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(701, 537);
            panel3.TabIndex = 2;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.LightGreen;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnActualizar.Location = new Point(350, 450);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 37);
            btnActualizar.TabIndex = 24;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // clbMiembros
            // 
            clbMiembros.FormattingEnabled = true;
            clbMiembros.Location = new Point(224, 292);
            clbMiembros.Name = "clbMiembros";
            clbMiembros.Size = new Size(299, 94);
            clbMiembros.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(49, 292);
            label7.Name = "label7";
            label7.Size = new Size(153, 20);
            label7.TabIndex = 22;
            label7.Text = "Miembros del Grupo";
            // 
            // cbGrupos
            // 
            cbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupos.FormattingEnabled = true;
            cbGrupos.Location = new Point(224, 251);
            cbGrupos.Name = "cbGrupos";
            cbGrupos.Size = new Size(299, 23);
            cbGrupos.TabIndex = 18;
            cbGrupos.SelectedIndexChanged += cbGrupos_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(49, 251);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 17;
            label6.Text = "Grupo";
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.LightGreen;
            btnPagar.FlatAppearance.BorderSize = 0;
            btnPagar.FlatStyle = FlatStyle.Flat;
            btnPagar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPagar.Location = new Point(224, 450);
            btnPagar.Margin = new Padding(3, 2, 3, 2);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(110, 37);
            btnPagar.TabIndex = 16;
            btnPagar.Text = "Pagar";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI", 11F);
            txtMonto.Location = new Point(224, 72);
            txtMonto.Margin = new Padding(3, 2, 3, 2);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(139, 27);
            txtMonto.TabIndex = 15;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 11F);
            txtDescripcion.Location = new Point(224, 161);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(299, 71);
            txtDescripcion.TabIndex = 14;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(224, 120);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(219, 23);
            dtpFecha.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(49, 118);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 12;
            label4.Text = "Fecha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 68);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 11;
            label1.Text = "Monto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(49, 154);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 10;
            label2.Text = "Descripción";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(49, 26);
            label5.Name = "label5";
            label5.Size = new Size(133, 20);
            label5.TabIndex = 9;
            label5.Text = "Nombre de Gasto";
            // 
            // txtNombreGasto
            // 
            txtNombreGasto.Font = new Font("Segoe UI", 11F);
            txtNombreGasto.Location = new Point(224, 27);
            txtNombreGasto.Margin = new Padding(3, 2, 3, 2);
            txtNombreGasto.Name = "txtNombreGasto";
            txtNombreGasto.Size = new Size(190, 27);
            txtNombreGasto.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 150, 50);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(701, 47);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(212, 10);
            label3.Name = "label3";
            label3.Size = new Size(180, 28);
            label3.TabIndex = 5;
            label3.Text = "PAGO DE GASTOS";
            // 
            // FrmRGastos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "FrmRGastos";
            Size = new Size(701, 584);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label label3;
        private TextBox txtMonto;
        private TextBox txtDescripcion;
        private DateTimePicker dtpFecha;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label5;
        private TextBox txtNombreGasto;
        private Button btnPagar;
        private Label label6;
        private ComboBox cbGrupos;
        private Label label7;
        private CheckedListBox clbMiembros;
        private Button btnActualizar;
    }
}
