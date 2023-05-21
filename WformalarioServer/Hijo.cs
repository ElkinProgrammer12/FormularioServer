using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using WformalarioServer.clases;

namespace WformalarioServer
{
    public partial class Hijo : Form
    {
        public Hijo()
        {
            InitializeComponent();
        }
                    
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                //Indicaciones que le van a señalar al usuario que debe agregar un id para comenzar a inserta un registro en la base de datos 
                if (txtId.Text == "")
                {
                    errorProvider1.SetError(txtId, "Debe ingresar el id del estudiante");
                    txtId.Focus();
                    return;
                }
                errorProvider1.SetError(txtId, "");

                //Validacion del nombre
                if (txtNombre.Text == "")
                {
                    errorProvider1.SetError(txtNombre, "Debe ingresar el nombre del estudiante");
                    txtNombre.Focus();
                    return;
                }
                errorProvider1.SetError(txtNombre, "");

                //Validacion de la edad 
                if (txtEdad.Text == "")
                {
                    errorProvider1.SetError(txtEdad, "Debe ingresar la edad del estudiante");
                    txtEdad.Focus();
                    return;
                }
                errorProvider1.SetError(txtEdad, "");

                //validacion del grado
                if (cmbGrado.Text == "")
                {
                    errorProvider1.SetError(cmbGrado, "Debe ingresar el grado del estudiante");
                    cmbGrado.Focus();
                    return;
                }
                errorProvider1.SetError(cmbGrado, "");

                //validacion de telefono
                if (txtTelefono.Text == "")
                {
                    errorProvider1.SetError(txtTelefono, "Debe ingresar el telefono del estudiante");
                    txtTelefono.Focus();
                    return;
                }
                errorProvider1.SetError(txtTelefono, "");

                //Validacion de la institucion
                if (txtInstitucion.Text == "")
                {
                    errorProvider1.SetError(txtInstitucion, "Debe ingresar nombre 'Institucion o Universidad'");
                    txtInstitucion.Focus();
                    return;
                }
                errorProvider1.SetError(txtInstitucion, "");

                //Validacion de correo
                if (txtCorreo.Text == "")
                {
                    errorProvider1.SetError(txtCorreo, "Debe ingresar el correo electronico");
                    txtCorreo.Focus();
                    return;
                }
                errorProvider1.SetError(txtCorreo, "");

                //Validacion de genero 
                if (cmbGenero.Text == "")
                {
                    errorProvider1.SetError(cmbGenero, "Debe ingresar sexo del estudiante");
                    cmbGenero.Focus();
                    return;
                }
                errorProvider1.SetError(cmbGenero, "");

                //generar una instancia a la clase usuario
                Usuarios insertar = new Usuarios();
                //enviar la información a la clase usuario
                //dicha información se enviara a la consulta y esta la enviara a la tabla asistencia
                insertar.IntID = Convert.ToInt32(txtId.Text);
                insertar.StrNOMBRE = txtNombre.Text;
                insertar.IntEDAD = Convert.ToInt32(txtEdad.Text);
                insertar.StrGRADO = cmbGrado.Text;
                insertar.StrTELEFONO = txtTelefono.Text;
                insertar.StrINSTITUCION = txtInstitucion.Text;
                insertar.StrCORREO = txtCorreo.Text;
                insertar.StrGENERO = cmbGenero.Text;

                //Se instancia al metodo insertar, para enviar la información a la tabla asistencia
                int estado = Funciones.insertarDatos(insertar);
                if (estado > 0)
                {
                    MessageBox.Show("Datos guardados");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al ingresar el dato ");

                }
                llenarTabla();

            }
            catch (Exception)
            {

                throw;
            }
        }
        //El siguiente bloque de código, va a permitir borrar todas las casillas luego de haber realizado la petición de insertar 
        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            cmbGrado.Text = "";
            txtTelefono.Text = "";
            txtInstitucion.Text = "";
            txtCorreo.Text = "";
            cmbGenero.Text = "";
            txtNombre.Focus();
        }
        //Se hace el llamado al método eliminar para que el botón ejecute la tarea de suprimir a alguien en la base de datos. Hay un condicional que va a controlar que si se cumplen condiciones se elimine el código (id) o si no se cumplen, sale en pantalla un mensaje que menciona que no se llevó a cabo la tarea.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int eliminar = Funciones.eliminarUsuario(int.Parse(txtId.Text));
            if (eliminar > 0)
            {
                MessageBox.Show("Usuario eliminado");
                limpiar();
            }
            else
            {
                MessageBox.Show("Usuario no pudo ser eliminado");
            }
            llenarTabla();
        }
      //Las líneas de código a continuación, son las que permiten guardar la información de determinado usuario como un documento .txt .
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() != "" && txtNombre.Text.Trim() != "" && txtEdad.Text.Trim() != "" && cmbGrado.SelectedItem != null && txtTelefono.Text.Trim() != "" && txtInstitucion.Text.Trim() != "" && txtCorreo.Text.Trim() != "" && cmbGenero.SelectedItem != null)
            {
                //Se toman valores del constructor.
                string strID = txtId.Text;
                string strNOMBRE = txtNombre.Text;
                string intEDAD = txtEdad.Text;
                string strGRADO = cmbGrado.Text;
                string strTELEFONO = txtTelefono.Text;
                string strINSTITUCION = txtInstitucion.Text;
                string strCORREO = txtCorreo.Text;
                string strGENERO = cmbGenero.Text;
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Archivos de texto (*.txt)|*.txt";
                    sfd.Title = "Guardar archivo";
                    sfd.ShowDialog();
                    //Las siguientes líneas van permitir guardar el archivo .txt con el nombre que se desee, por eso es que se muestra el "" para que el que manipule el programa, le coloque el nombre que él se desee y que lo guarde en cualquier carpeta del pc.
                    if (sfd.FileName != "")
                    {
                        StreamWriter sw = new StreamWriter(sfd.FileName);
                        //Estos son los mensajes con los cuales se guardará el .txt .
                        sw.WriteLine("Id: " + strID);
                        sw.WriteLine("Nombre: " + strNOMBRE);
                        sw.WriteLine("Edad: " + intEDAD);
                        sw.WriteLine("Grado: " + strGRADO);
                        sw.WriteLine("Teléfono: " + strTELEFONO);
                        sw.WriteLine("Institución: " + strINSTITUCION);
                        sw.WriteLine("Correo: " + strCORREO);
                        sw.WriteLine("Género: " + strGENERO);
                        sw.Close();

                        MessageBox.Show("Los datos han sido guardados correctamente.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al guardar los datos: " + ex.Message);
                }
            }
            else
            {
                //Esta línea le saldrá en pantalla al usuario, si no diligencia todas las casillas.
                MessageBox.Show("Debes ingresar todos los campos requeridos");
            }

        }
        //Se logra que en el datagridview se muestre la busqueda de un código. Si no se coloca el id (código), aparece un mensaje en pantalla.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    errorProvider1.SetError(txtId, "Debe ingresar el id del estudiante");
                    txtId.Focus();
                    return;
                }
                errorProvider1.SetError(txtId, "");

                dtgCSV.DataSource = Funciones.buscar(Convert.ToInt32(txtId.Text));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            llenarTabla();

        }
        //metodo para llenar tabla 
        private void llenarTabla()
        {
            //gerenamos una instancia a la clase funciones para usar el metodo
            dtgCSV.DataSource = Funciones.mostrarRegistro();
        }

        private void dtgCSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             //El siguiente bloque de código permite que donde yo haga un click en una línea de dato en el dataGridView, me aparezcan los datos que allí estan, pero en las casillas  de TextBox. Esto se logra  configurando SelectionMode y colocando FullRowSelect, en la página de eventos del dataGridView.

        //En el dataGridView es necesario colocar en ReadOnly porque sino al aparecer los datos se pueden cambiar y lo que me interesa es que solo lea la base de datos en la pantalla.
        
            txtId.Text = dtgCSV.SelectedCells[0].Value.ToString();
            txtNombre.Text = dtgCSV.SelectedCells[1].Value.ToString();
            txtEdad.Text = dtgCSV.SelectedCells[2].Value.ToString();
            cmbGrado.Text = dtgCSV.SelectedCells[3].Value.ToString();
            txtTelefono.Text = dtgCSV.SelectedCells[4].Value.ToString();
            txtInstitucion.Text = dtgCSV.SelectedCells[5].Value.ToString();
            txtCorreo.Text = dtgCSV.SelectedCells[6].Value.ToString();
            cmbGenero.Text = dtgCSV.SelectedCells[7].Value.ToString();        
        }

        private void dtgCSV_MouseClick(object sender, MouseEventArgs e)
        {
            txtId.Text = this.dtgCSV.CurrentRow.Cells[0].Value.ToString();
        }

        private void dtgCSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = this.dtgCSV.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
