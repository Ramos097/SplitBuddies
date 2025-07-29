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
            btnPagar = new Button();
            txtMonto = new TextBox();
            txtDescripcion = new TextBox();
            dateTimePicker1 = new DateTimePicker();
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
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(679, 524);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnPagar);
            panel3.Controls.Add(txtMonto);
            panel3.Controls.Add(txtDescripcion);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtNombreGasto);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 63);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(679, 461);
            panel3.TabIndex = 2;
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.LightGreen;
            btnPagar.FlatAppearance.BorderSize = 0;
            btnPagar.FlatStyle = FlatStyle.Flat;
            btnPagar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPagar.Location = new Point(249, 380);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(126, 49);
            btnPagar.TabIndex = 16;
            btnPagar.Text = "Pagar";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI", 11F);
            txtMonto.Location = new Point(249, 112);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(158, 32);
            txtMonto.TabIndex = 15;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 11F);
            txtDescripcion.Location = new Point(249, 231);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(340, 109);
            txtDescripcion.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(249, 176);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(49, 173);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 12;
            label4.Text = "Fecha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 107);
            label1.Name = "label1";
            label1.Size = new Size(73, 25);
            label1.TabIndex = 11;
            label1.Text = "Monto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(49, 221);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 10;
            label2.Text = "Descripción";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(49, 51);
            label5.Name = "label5";
            label5.Size = new Size(169, 25);
            label5.TabIndex = 9;
            label5.Text = "Nombre de Gasto";
            // 
            // txtNombreGasto
            // 
            txtNombreGasto.Font = new Font("Segoe UI", 11F);
            txtNombreGasto.Location = new Point(249, 52);
            txtNombreGasto.Name = "txtNombreGasto";
            txtNombreGasto.Size = new Size(217, 32);
            txtNombreGasto.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 150, 50);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(679, 63);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(242, 13);
            label3.Name = "label3";
            label3.Size = new Size(226, 35);
            label3.TabIndex = 5;
            label3.Text = "PAGO DE GASTOS";
            // 
            // FrmRGastos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmRGastos";
            Size = new Size(679, 524);
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
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label5;
        private TextBox txtNombreGasto;
        private Button btnPagar;
    }
}
