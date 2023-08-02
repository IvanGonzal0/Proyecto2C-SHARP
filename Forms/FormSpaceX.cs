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

namespace FERNANDES_ROCCIA_TAPIA
{
    /// <summary>
    /// 
    /// En este formulario, se gestionará todo lo relacionado a la clase FormSpaceX.
    /// Se podran dar de alta y eliminar objetos SpaceX's, de la lista recibida
    /// del formulario principal que es donde se van a ir almacenando los cohetes.
    /// Tambien contendrá toda la funcionalidad, y toda la lógica necesaria
    /// para que la instancia de un nuevo objeto SpaceX sea correcta.
    /// Se tendran en cuenta los datos ingresados/seleccionados
    /// por el usuario y dependiendo de ellos, se haran calculos para 
    /// implentar lo solicitado en el proyecto.
    /// Se tendra la vista de la lista actual de SpaceX's en un DataGridView vinculado a lista de SpaceX's
    /// y se podran dar de alta, o eliminar de esta lista.
    /// Se usará una función(guardarSpaceX()) para asignar todos los datos y dar de alta un cohete,
    /// se implementa la lógica necesaria para que cada modelo de SpaceX se cree
    /// con las propiedades particulares del modelo seleccionado del comboBox por el usuario.
    /// Esto evita que se creen modelos que no existen, o designados por un usuario normal.
    /// Por ejemplo si se elige en el comboBox "Falcon 9" se asignará
    /// como autonomia:200 HS y como service: 400HS.
    /// Las opciones de modelos, años y colores estarán predefinidos en listas estáticas,
    /// estas listas solo podrán ser modificadas por los desarrolladores, como asi tambien la asignacion
    /// de las propiedades particulares, asientos, autonomia y service.
    /// 
    /// </summary>
    public partial class FormSpaceX : Form
    {
        #region Cargar un SpaceX
        List<SpaceX> lista;
        static string[] modelos_disponibles = { "Falcon 9", "Starship" };
        static int[] anios_disponibles = { 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 };
        static string[] colores_disponibles = { "Amarillo", "Azul", "Blanco", "Bordo", "Gris", "Marron", "Naranja", "Negro" };
        /// <summary>
        /// Esta función se ejecuta cuando se inicia el formulario, y se hace una validación para constatar si la lista 
        /// esta vacía, si esta vacía el datagridview estará vacio, caso contrario el datagrid se cargará con la información de la lista.
        /// Además se cargaran los comboBox con las opciones predefinidas en las listas estaticas.
        /// </summary>
        public FormSpaceX(List<SpaceX> listaSpaceX)
        {
            InitializeComponent();
            lista = listaSpaceX;
            popularModelos();
            popularAnios();
            popularColores();
            if (lista.Count > 0)
            {
                dgv_spacex.DataSource = lista;
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

        #region Boton Guardar y funcion guardarSpaceX
        /// <summary>
        /// El botón Guardar sera el encargado de hacer todas las validaciones
        /// de campos, sino no se podra llamar al metodo guardarSpaceX() que es quien 
        /// permite la instanciación de la clase SpaceX, y agrega el objeto a la lista principal
        /// de SpaceX's. 
        /// Este boton controlará que si o sí se seleccione algun dato de los combobox,
        /// que los datos ingresados en el textBox horas de vuelo actuales se ingresen datos del tipo correcto,
        /// numeros que sean positivos y no mayor a 100 millones.
        /// En el textBox Dueño se controlará que los datos ingresados sean letras u espacios,
        /// que el tamaño mínimo sea de 1 caracter y el máximo de 35 caracteres.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((modelos.SelectedIndex >= 0) && (anios.SelectedIndex >= 0) &&
                !string.IsNullOrEmpty(hsVueloActual.Text) && hsVueloActual.Text.All(Char.IsDigit)
                && (hsVueloActual.Text.Length > 0) && (hsVueloActual.Text.Length < 9)
                && (colores.SelectedIndex >= 0) && (duenio.Text.Trim() != string.Empty)
                && (duenio.Text.All(Char.IsLetter)
                || duenio.Text.Any(Char.IsWhiteSpace)) && (duenio.Text.Trim().ToString().Length >= 1)
                && (duenio.Text.Trim().ToString().Length <= 35))
            {
                guardarSpaceX();
                errorProvider1.SetError(btnGuardar, "");
            }
            else
            {
                errorProvider1.SetError(btnGuardar, "* Para guardar un SpaceX todos los campos deben estar completos y deben ser del tipo correcto.\n" +
                                                "! Hs. Actuales: Debe contener numeros positivos entre 0 y 100 millones.\n" +
                                                "! Dueño: Debe contener mínimo 1 caracter y máximo 35.");
                btnGuardar.Focus();
            }
        }
        /// <summary>
        /// Esta funcion tendrá un condicional para evaluar que modelo de SpaceX se eligió
        /// para asi asignar la autonomia(int), service(int) y así no 
        /// se creen modelos con datos erroneos. Tambien obtendra los datos
        /// de los textbox y los combobox.
        /// Tambien se tomarán y convertirán todos los datos ingresados/seleccionados por el usuario
        /// y se guardaran en variables para ser asignadas al nuevo objeto SpaceX.
        /// Se mostrará un messageBox cuando se agregue un SpaceX a la lista, se refrescará
        /// el dgv vaciandoló y cargandoló nuevamente con la lista actualizada. Y por último se hace
        /// un clear de los campos de los textbox, combobox y errores si los hubiera. 
        /// Tambien se controlá en manejo de errores en caso de que surja alguno se mostrará un mensaje con el tipo de error.
        /// </summary> 
        private void guardarSpaceX()
        {
            try
            {
                string modelo = modelos.SelectedItem.ToString();
                int autonomia;
                int service;
                int anio = Convert.ToInt32(anios.SelectedItem);
                int HsVueloActual = Convert.ToInt32(hsVueloActual.Text);
                string color = colores.SelectedItem.ToString();
                string nombre = duenio.Text.Trim().ToUpper();

                //condicion para asignar service y autonomia del SpaceX segun modelo
                if (modelo == "Falcon 9")
                {
                    autonomia = 200;
                    service = 400;
                }
                else
                {
                    // Starship
                    autonomia = 500;
                    service = 1000;
                }
                // Instancia de clase y se agrega a la lista correspondiente
                SpaceX spaceX = new SpaceX(modelo, anio, HsVueloActual, color, nombre, autonomia, service);
                lista.Add(spaceX);
                // Mensaje de creacion correcta
                string mensaje = $"Creó un SpaceX correctamente y se agregó a la lista con el ID: {spaceX.Id}.";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBox.Show(mensaje, "Genial", botones);
                // Reset clear

                dgv_spacex.DataSource = null;
                dgv_spacex.DataSource = lista;
                errorProvider1.SetError(btnEliminar, "");
                errorProvider1.SetError(btnEscanear, "");

                modelos.SelectedIndex = -1;
                anios.SelectedIndex = -1;
                hsVueloActual.Clear();
                colores.SelectedIndex = -1;
                duenio.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al crear un tesla" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Boton eliminar y funcionalidad
        /// <summary>
        /// Funcion para obtener informacion y poder eliminar elementos de la lista
        /// mostrada en el datagridview, para eso se usa la función 
        /// CellClick del datagrid para obtener el índice
        /// del elemento que queremos eliminar, y eliminamos por índice = id.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private int indiceFila;
        private int idc;
        private void dgv_spacex_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            indiceFila = e.RowIndex;
            labelEscaneo.Visible = false;
        }
        /// <summary>
        /// Esta función elminara por fila seleccionada del datagidview, haciendo referencia a la celda 0, que es donde esta almacenado el ID.
        /// Se controla que la fila seleccionada, sea una lista del dgv y en caso de ser correcto antes de eliminar el objeto
        /// se muestra un messageBox con los botones de yes/no para confirmar o rechazar la eliminación de un SpaceX.
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
                    idc = (int)dgv_spacex.Rows[indiceFila].Cells[0].Value;
                    DialogResult dialogResult = MessageBox.Show($"Esta seguro que desea eliminar el SpaceX ID: {idc} ?"
                                            , "Eliminar SpaceX", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lista.RemoveAt(indiceFila);
                        dgv_spacex.DataSource = null;
                        dgv_spacex.DataSource = lista;
                        indiceFila = -1;
                    }
                }
                else if(lista.Count == 0)
                {
                    errorProvider1.SetError(btnEliminar, "La lista está vacía. Error: ");
                    btnEliminar.Focus();
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(btnEliminar, "Error: " +ex.Message);
                btnEliminar.Focus();
            }

        }
        #endregion

        #region Boton Escanear
        /// <summary>
        /// Este botón va a realizar el escaneo del SpaceX que se seleccione
        /// del DataGridView, haciendo referencia al objeto que se encuentra 
        /// guardado en la lista del programa principal.
        /// Para evitar errores de ejecución se valida que la lista no este vacía,
        /// y en el DataGridView unicamente se permite la seleccion de filas.
        /// Si el DTG esta vacío se mostrará un error al costado derecho 
        /// del botón.
        /// También se controlan excepciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnEscanear_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.SetError(btnEscanear, "");
                if (lista.Count > 0)
                {
                    SpaceX teslac = (SpaceX)dgv_spacex.CurrentRow.DataBoundItem;
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
                MessageBox.Show("Se produjo un error al escanear un SpaceX. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

    }
}