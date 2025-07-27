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

namespace Views.Vistas.Grupos
{
    public partial class FrmRGrupos : UserControl
    {
        private readonly Usuario _usuario;
        public FrmRGrupos(Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
        }
    }
}
