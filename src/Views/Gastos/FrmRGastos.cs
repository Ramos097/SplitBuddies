using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views.Gastos
{
    public partial class FrmRGastos : UserControl
    {
        private readonly Usuario _usuario;
        public FrmRGastos(Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pago el usuario "+ _usuario.Identificacion);
        }
    }
}
