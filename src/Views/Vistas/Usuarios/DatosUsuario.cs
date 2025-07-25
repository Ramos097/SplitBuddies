﻿using Models;
using Proyecto_1.Controllers;
using Proyecto_1.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Vistas.Grupos;
using Proyecto_1.Services;
using LogicaNegocio.Services;

namespace Views.Vistas.Usuarios
{
    public partial class DatosUsuario : Form
    {

        private Usuario _usuario;
        private readonly IUsuarioController _usuarioController;
        public DatosUsuario(Usuario user)
        {
            InitializeComponent();
            _usuarioController = new UsuarioController();

            _usuario = user;
            cargarDatos();

        }

        private void DatosUsuario_Load(object sender, EventArgs e)
        {

        }

        private void cargarDatos()
        {
            txt_Contraseña.Text = _usuario.Contrasenia;
            txt_Corrreo.Text = _usuario.Correo;
            txt_Edad.Text = _usuario.Edad.ToString();
            txt_Id.Text = _usuario.Identificacion;
            txt_NombreCompleto.Text = _usuario.NombreCompleto;

            try
            {
                string rutaAbsoluta = _usuarioController.ObtenerRutaImagen(_usuario.Imagen);
                pictureBox1.Image = Image.FromFile(rutaAbsoluta);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontró la imagen del usuario. Se mostrará vacía.");
                pictureBox1.Image = null; // Deja el PictureBox en blanco
            }
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            var grupoService = new LogicaNegocio.Services.GrupoService();
            var grupoController = new Proyecto_1.Controllers.GrupoController(grupoService);

            FormcrearGrupo crearGrupoForm = new FormcrearGrupo(grupoController, _usuarioController);
            crearGrupoForm.Show();
        }

        private void btnIrACrearGrupo_Click(object sender, EventArgs e)
        {
            var grupoService = new GrupoService();
            var grupoController = new GrupoController(grupoService);
            var crearGrupoForm = new FormcrearGrupo(grupoController, _usuarioController);
            crearGrupoForm.Show();
        }
    }
}
