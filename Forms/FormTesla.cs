using FERNANDES_ROCCIA_TAPIA.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FERNANDES_ROCCIA_TAPIA
{
    /// <summary>
    /// 
    /// En este formulario, se gestiona todo lo relacionado a la clase Tesla.
    /// Se podran dar de alta y eliminar objetos Tesla de la lista recibida
    /// del formulario principal que es donde se van a ir almacenando los teslas.
    /// También contiene toda la funcionalidad, y la lógica necesaria
    /// para que la instancia de un nuevo objeto Tesla sea correcta.
    /// Se tendrán en cuenta los datos ingresados/seleccionados
    /// por el usuario y dependiendo de ellos, se haran calculos para 
    /// implentar lo solicitado en el proyecto.
    /// Se tendrá la vista de la lista actual de teslas en un DataGridView vinculado con la lista de Teslas
    /// y se podrán dar de alta, o eliminar teslas de esta lista.
    /// Se usará una funcion(agregarTesla()) para asignar todos los datos y dar de alta un tesla,
    /// con la logica necesaria para que cada modelo de Tesla se cree
    /// con las propiedades particulares del modelo seleccionado del comboBox.
    /// Esto evita que se creen modelos que no existen, o designados por un usuario normal.
    /// Por ejemplo si se elige en el comboBox "Modelo X" se asignara automaticamente en
    /// la funcion guardarTesla() = asientos:7, autonomia:560 KMS y como service: 1000 KMS
    /// Las opciones de modelos, anios y colores estarán predefinidos en listas estaticas,
    /// estas listas solo podran ser modificadas por los desarrolladores, como asi tambien la asignacion
    /// de las propiedades particulares, asientos, autonomia y service.
    /// 
    /// </summary>
    public partial class FormTesla : Form
    {
        #region Cargar dar de alta un Tesla
        List<Tesla> lista;
        static string[] modelos_disponibles = { "Model X", "Model S", "Cybertruck" };
        static int[] anios_disponibles = { 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 };
        static string[] colores_disponibles = { "Amarillo", "Azul", "Blanco", "Bordo","Gris", "Marron", "Naranja", "Negro" };
        /// <summary>
        /// Esta funcion se ejecuta cuando se inicia el formulario, y se hace una validacion para constatar si la lista 
        /// esta vacía, si esta vacia el datagridview estará vacio, caso contrario el datagrid se cargara con la información de la lista.
        /// Además se cargaran los comboBox con las opciones predefinidas en las listas estaticas.
        /// </summary>
        /// <param name="listaTeslas">lista que contiene los teslas y esta declarada en el formulario principal</param>
        public FormTesla(List<Tesla> listaTeslas)
        {
            InitializeComponent();
            lista = listaTeslas;
            popularModelos();
            popularAnios();
            popularColores();
            if (lista.Count > 0)
            {
                dgv_tesla.DataSource = lista;
            }
        }

        /// <summary>
        /// Agrega los modelos disponibles al ComboBox "modelos".
        /// </summary>
        private void popularModelos()
        {
            foreach (string modelo in modelos_disponibles)
            {
                modelos.Items.Add(modelo);
            }
        }
        /// <summary>
        /// Agrega los años disponibles al ComboBox "anios".
        /// </summary>
        private void popularAnios()
        {
            foreach (int anio in anios_disponibles)
            {
                anios.Items.Add(anio);
            }
        }

        /// <summary>
        /// Agrega los colores disponibles al ComboBox "colores".
        /// </summary>
        private void popularColores()
        {
            foreach (string color in colores_disponibles)
            {
                colores.Items.Add(color);
            }
        }
        #endregion

        #region Boton Guardar y funcion guardarTesla
        /// <summary>
        /// El botón Guardar sera el encargado de hacer todas las validaciones
        /// de campos, sino no se podra llamar al metodo guardarTesla() que es quien 
        /// permite la instanciacion de la clase Tesla, y agrega el objeto a la lista principal
        /// de Teslas. 
        /// Este boton controlará que si o sí se seleccione algun dato de los combobox,
        /// que los datos ingresados en el textBox km actuales se ingresen datos del tipo correcto,
        /// numeros que sean positivos y no mayor a 10 millones.
        /// En el textBox Dueño se controlará que los datos ingresados sean letras u espacios,
        /// que el tamaño mínimo sea de 5 caracteres y el máximo de 35 caracteres.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((modelos.SelectedIndex >= 0) && (anios.SelectedIndex >= 0) &&
                !string.IsNullOrEmpty(kmActuales.Text) && kmActuales.Text.All(Char.IsDigit)
                && (kmActuales.Text.Length > 0) && (kmActuales.Text.Length < 8)
                && (colores.SelectedIndex >= 0) && (duenio.Text.Trim() != string.Empty)
                && (duenio.Text.All(Char.IsLetter)
                || duenio.Text.Any(Char.IsWhiteSpace)) && (duenio.Text.Trim().ToString().Length > 4)
                && (duenio.Text.Trim().ToString().Length <= 35))
            {
                guardarTesla();
                errorProvider1.SetError(btnGuardar, "");
            }
            else
            {
                errorProvider1.SetError(btnGuardar, "* Para guardar un Tesla todos los campos deben estar completos y deben ser del tipo correcto.\n" +
                                                "! Kms. Actuales: Debe contener numeros positivos entre 0 y 10 millones.\n" +
                                                "! Dueño: Debe contener mínimo 5 caracteres y máximo 35.");
                btnGuardar.Focus();
            }
        }

        /// <summary>
        /// Esta funcion tendrá un condicional para evaluar que modelo de Tesla se eligió
        /// para asi asignar la autonomia(int), asientos(int), service(int) y asi no 
        /// se creen modelos con datos erroneos. Tambien obtendra los datos
        /// de los textbox y los combobox.
        /// "Modelo X: 560, 7, 1000"
        /// "Modelo S: 650, 5, 2000"
        /// "Cybertruck: 800, 6, 3000"
        /// Tambien se tomarán y convertirán todos los datos ingresados/seleccionados por el usuario
        /// y se guardaran en variables para ser asignadas al nuevo objeto Tesla.
        /// Se mostrará un messageBox cuando se agregue un tesla a la lista, se refrescará
        /// el dgv vaciandoló y cargandoló nuevamente con la lista actualizada. Y por último se hace
        /// un clear de los campos de los textbox, combobox y errores si los hubiera. 
        /// Tambien se controlá en manejo de errores en caso de que surja alguno se mostrará un mensaje con el tipo de error.
        /// </summary>
        private void guardarTesla()
        {
            try
            {
                string modelo = modelos.SelectedItem.ToString();
                int asientos;
                int autonomia;
                int service;
                int anio = Convert.ToInt32(anios.SelectedItem);
                int kmActual = Convert.ToInt32(kmActuales.Text);
                string color = colores.SelectedItem.ToString();
                string nombre = duenio.Text.Trim().ToUpper();

                //condicion para asignar asientos y autonomia del Tesla segun modelo
                if (modelo == "Model X")
                {
                    autonomia = 560;
                    asientos = 7;
                    service = 1000;
                }
                else if (modelo == "Model S")
                {
                    autonomia = 650;
                    asientos = 5;
                    service = 2000;
                }
                else
                {
                    autonomia = 800;
                    asientos = 6;
                    service = 3000;
                }

                // Instancia de clase y se agrega a la lista correspondiente
                Tesla tesla = new Tesla(modelo, anio, kmActual, color, nombre, autonomia, asientos, service);
                lista.Add(tesla);
                // Mensaje de creacion correcta
                string mensaje = $"Creó un Tesla correctamente y se agregó a la lista con el ID: {tesla.Id}.";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBox.Show(mensaje, "Genial", botones);
                // Reset clear

                dgv_tesla.DataSource = null;
                dgv_tesla.DataSource = lista;
                errorProvider1.SetError(btnEliminar, "");
                errorProvider1.SetError(btnEscanear, "");
                errorProvider1.SetError(btnMostrarTeslaMasKm, "");

                modelos.SelectedIndex = -1;
                anios.SelectedIndex = -1;
                kmActuales.Clear();
                colores.SelectedIndex = -1;
                duenio.Clear();

            }catch(Exception ex)
            {
                MessageBox.Show("Se produjo un error al crear un tesla" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

        #region Boton Eliminar y funcionalidad

        /// <summary>
        /// Funcion para obtener informacion y poder eliminar elementos de la lista
        /// mostrada en el datagridview, para eso se usa la función 
        /// CellClick del datagrid para obtener el índice
        /// del elemento seleccionado que queremos eliminar, y eliminamos por índice = id.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private int indiceFila;
        private int idc;

        private void dgv_tesla_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            indiceFila = e.RowIndex;
            labelEscaneo.Visible = false;
        }
        /// <summary>
        /// Esta función elminara por fila seleccionada del datagidview, haciendo referencia a la celda 0, que es donde esta almacenado el ID.
        /// Se controla que la fila seleccionada, sea una lista del dgv y en caso de ser correcto antes de eliminar el objeto
        /// se muestra un messageBox con los botones de yes/no para confirmar o rechazar la eliminación de un Tesla.
        /// También se controla el manejo de errores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.SetError(btnEliminar, "");
                if (indiceFila != -1)
                {

                    labelEscaneo.Visible = false;
                    idc = (int)dgv_tesla.Rows[indiceFila].Cells[0].Value;
                    DialogResult dialogResult = MessageBox.Show($"Esta seguro que desea eliminar el tesla ID: {idc} ?"
                                            , "Eliminar tesla", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lista.RemoveAt(indiceFila);
                        dgv_tesla.DataSource = null;
                        dgv_tesla.DataSource = lista;
                        indiceFila = -1;
                    }
                }
                else if (lista.Count == 0)
                {
                    errorProvider1.SetError(btnEliminar, "Error la lista esta vacía.");
                    btnEliminar.Focus();
                }
            }catch(Exception ex)
            {
                errorProvider1.SetError(btnEliminar, "La lista está vacía. Error: " + ex.Message);
                btnEliminar.Focus();
            }

        }
        #endregion

        #region Boton Escanear
        /// <summary>
        /// Este boton va a realizar el escaneo del tesla que se seleccione
        /// del DataGridView, haciendo referencia al objeto que se encuentra 
        /// guardado en la lista de teslas del prgorama principal.
        /// Para evitar errores de ejecucion se valida que la lista no este vacía,
        /// y en el DataGridView unicamente se permite la seleccion de filas.
        /// Si el DTG esta vacío se mostrará un error al costado derecho del botón.
        /// También se controlan excepciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEscanear_Click(object sender, EventArgs e)
        {
            try
            {   
                errorProvider1.SetError(btnEscanear, "");

                if(lista.Count > 0)               
                {
                    Tesla teslac = (Tesla)dgv_tesla.CurrentRow.DataBoundItem;
                    labelEscaneo.Text = teslac.Escaneo();
                    labelEscaneo.Visible = true;
                }
                else
                {
                    errorProvider1.SetError(btnEscanear, "Error la lista esta vacía.");
                    btnEscanear.Focus();
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                MessageBox.Show("Se produjo un error al escanear un Tesla. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Boton Mostrar Tesla con mas kilometraje
        /// <summary>
        /// Esta función va a comprobar que lista no este vacia, y si no lo esta
        /// va a mostrar un messageBox, que contendra los datos del tesla con mayor
        /// kilometraje. Se obtiene el tesla con mayor kilometraje buscando en la lista
        /// principal de teslas y guardando a este objeto en la variable tesla.
        /// Objeto que se utiliza para mostrar todos los datos a traves del 
        /// metodo sobreescrito ToString() y en el titulo de la ventana
        /// se mostrará el tesla y su ID correspondiente.
        /// Caso que la lista este vacía se mostrará un error 
        /// al costado derecho del boton "Mostrar el tesla con más kilometraje"
        /// Tambien se controlan excepciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTeslaMasKm_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.SetError(btnMostrarTeslaMasKm, "");
                if (lista.Count > 0)
                {
                    
                    Tesla tesla = lista.OrderByDescending(t => t.KmActual).FirstOrDefault();
                    string mensaje = $"El tesla con más kilometraje es el: {tesla} ";
                    string titulo = $"Tesla ID: {tesla.Id} ";
                    MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK);
                }
                else
                {
                    errorProvider1.SetError(btnMostrarTeslaMasKm, "Error la lista esta vacía.");
                    btnMostrarTeslaMasKm.Focus();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al mostrar el tesla con más km." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        #endregion
    }
}

