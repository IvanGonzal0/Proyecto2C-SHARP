using FERNANDES_ROCCIA_TAPIA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERNANDES_ROCCIA_TAPIA
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// 
        /// Esta aplicación es una herramienta de gestión de tareas desarrollada en C# con Windows Forms.
        /// Permite a los usuarios crear y eliminar Vehiculos Teslas y SpaceX's.
        /// La lógica de la aplicación se basa en la interacción
        /// entre los formularios (interfaz gráfica de usuario) y las clases (lógica de la aplicación).
        /// El programa se diagramo, buscando las características que tenían en común las clase Tesla y SpaceX, 
        /// para lograr una mayor abstracción, por eso se creo la clase abstracta Vehiculo, la cual contiene todas las propiedades en común.
        /// También se implementa el metodo abstracto Escaneo() para cumplir con los requisitos del punto 4, tambien de esta forma se aplica el concepto de polimorfismo en las clases derivadas.
        /// Se aclara que la autonomia y todo lo referido a services o medidas de unidad, depende de la clase y tipo de vehiculo en particular,
        /// por ejemplo en la clase tesla se les va realizar el service cada tantos KMS, mientras que a la clase SpaceX cada tantas HORAS de vuelo, pero el tipo de dato sigue siendo el mismo.
        /// Se crearon variables adicionales como ejemplo CantidadCargas para
        /// cumplir con los requerimientos del proyecto y para mayor funcionalidad del programa. 
        /// El punto 5 solicita que se muestre la cantidad de cargas de batería/combustible
        /// de todos los vehiculos, para esto se tomo la decisión de guardar la cantidad de veces que se cargó bateria/combustible
        /// en una variable de cada vehiculo y se mostrará en una columna del DataGridView para todos los vehículos, para poder realizar la cargar batería/combustible primero se debe consumir el 100%.
        /// Para una explicación más detallada de la lógica de la aplicación, las decisiones de diseño tomadas,
        /// y cómo interactúa el código con la interfaz gráfica de usuario, consulte el archivo README.md en el repositorio.
        /// De todos modos el codigo está comentado para explicar cada formulario y cada función.
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
