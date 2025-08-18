namespace Views.Vistas.Gastos
{
    partial class FrmListadoGastos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            PanelPlantilla = new Panel();
            panel3 = new Panel();
            panel7 = new Panel();
            btnEditar = new Button();
            panel6 = new Panel();
            dgvGastos = new DataGridView();
            panel5 = new Panel();
            panel4 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            Column1 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            PanelPlantilla.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelPlantilla
            // 
            PanelPlantilla.BackColor = Color.FromArgb(50, 50, 50);
            PanelPlantilla.Controls.Add(panel3);
            PanelPlantilla.Controls.Add(panel2);
            PanelPlantilla.Dock = DockStyle.Fill;
            PanelPlantilla.Location = new Point(0, 0);
            PanelPlantilla.Name = "PanelPlantilla";
            PanelPlantilla.Size = new Size(840, 549);
            PanelPlantilla.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(840, 502);
            panel3.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnEditar);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(37, 342);
            panel7.Name = "panel7";
            panel7.Size = new Size(766, 160);
            panel7.TabIndex = 27;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.LightGreen;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEditar.Location = new Point(315, 5);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 37);
            btnEditar.TabIndex = 17;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(dgvGastos);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(37, 44);
            panel6.Name = "panel6";
            panel6.Size = new Size(766, 298);
            panel6.TabIndex = 26;
            // 
            // dgvGastos
            // 
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.AllowUserToDeleteRows = false;
            dgvGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGastos.Columns.AddRange(new DataGridViewColumn[] { Column1, Column7, Column2, Column3, Column4, Column5, Column6 });
            dgvGastos.Dock = DockStyle.Fill;
            dgvGastos.Location = new Point(0, 0);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.ReadOnly = true;
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.Size = new Size(766, 298);
            dgvGastos.TabIndex = 20;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(803, 44);
            panel5.Name = "panel5";
            panel5.Size = new Size(37, 458);
            panel5.TabIndex = 25;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 44);
            panel4.Name = "panel4";
            panel4.Size = new Size(37, 458);
            panel4.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 44);
            panel1.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(290, 21);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 21;
            label1.Text = "TABLA DE GASTOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(56, 284);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 22;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 150, 50);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(840, 47);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(342, 12);
            label3.Name = "label3";
            label3.Size = new Size(208, 28);
            label3.TabIndex = 5;
            label3.Text = "LISTADO DE GASTOS";
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Gasto";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Grupo";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Descripcion";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Fecha";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Monto";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Miembros Que Deben";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // FrmListadoGastos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelPlantilla);
            Name = "FrmListadoGastos";
            Size = new Size(840, 549);
            PanelPlantilla.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelPlantilla;
        private Panel panel3;
        private Panel panel7;
        private Button btnEditar;
        private Panel panel6;
        private DataGridView dgvGastos;
        private Panel panel5;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Panel panel1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
    }
}
