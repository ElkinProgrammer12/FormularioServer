using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WformalarioServer.clases;

namespace WformalarioServer
{
    ///<summary>
    ///Autores: Elkin Riaño Díaz y Jorge Luis Sepulveda
    ///Ejercicio: Parcial Herramientas de Programación 2
    ///Objetivo: Crear un formulario donde se muestre la información de una base de datos en SQL 
    ///Server y desde el mismo formulario se pueda añadir, borrar y modificar los datos en SQL.
    ///Fecha: 18 de mayo de 2023
    ///</summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //El siguiente bloque de cógido permite realizar un vínculo entre el formulario padre
        // y el formulario hijo
        private void asistenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hijo hijo = new Hijo();
            hijo.MdiParent = this;
            hijo.Show();
        }
        //El siguiente bloque de código es el encargado de darle salida al programa
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.crearConexion();
            MessageBox.Show("esta conectado");
        }
    }
}
