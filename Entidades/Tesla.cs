using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERNANDES_ROCCIA_TAPIA.Entidades
{
    /// <summary>
    /// La clase Tesla hereda de la clase abstracta vehiculo la cual no se puede
    /// instanciar, para el constructor del tesla se solicitan datos, y acorde esos 
    /// datos y al modelo seleccionado, se asignaran automaticamente
    /// las propiedades asientos, autonomia y service ya que las mismas dependen del modelo.
    /// Por ejemplo si se elige en el comboBox "Modelo X" se asignara =
    ///  asientos:7, autonomia:560 KMS y como service: 1000 KMS
    /// Para la correcta instanciación de los Tesla se crea un constructor.
    /// Para la cantidad de cargas de baterias se tiene en cuenta que la bateria se 
    /// cargó solo cuando se uso el 100%, para esto hacemos la cuenta de kmActuales / autonomia
    /// y como resultado obtenemos la cantidad de veces que se cargó la bateria.
    /// Para obtener el kilometraje del proximo service se realiza la cuenta
    /// para buscar el siguiente multiplo del service que le corresponda a cada vehículo
    /// para eso hicimos la cuenta (kmActual / service +1) * service;
    /// A la propiedad Id se le creo unicamente un getter y no un setter
    /// para evitar que pueda ser modificado.
    /// Todos los atributos de clase Tesla son declarados como privados
    /// por diseño y encapsulación.
    /// Las constantes representan el intervalo en kilómetros con el que se 
    /// deben realizar los checkeos exhaustivos, y las variables
    /// cantCinturones, cantBaterias, cantNavegacion, etc.
    /// se usarán para almacenar la cantidad de checkeos realizados en la función Escaneo()
    /// </summary>
    public class Tesla : Vehiculo
    {
        #region Propiedades
        private static int contadorId = 1;
        private int id;
        private int kmActual;
        private int asientos;
        private const int controlCinturones = 1000;
        private const int controlBaterias = 2000;
        private const int controlSistemaNavegacion = 2500;
        private const int controlSistemaTraccion = 3000;
        private const int controlMotor = 3000;
        private int cantCinturones;
        private int cantBaterias;
        private int cantNavegacion;
        private int cantTraccion;
        private int cantMotor;

        /// <summary>
        /// Contructor, se tiene en cuenta que el modelo es de tipo string,
        /// la unidad de medida de la autonomia es en Kms
        /// las propiedades autonomia, asientos y service dependen del modelo de tesla
        /// </summary>
        /// <param name="modelo">modelo del tesla</param>
        /// <param name="anio">año de creación del vehiculo</param>
        /// <param name="kmActual">kilometraje actual</param>
        /// <param name="color">color del vehículo</param>
        /// <param name="duenio">porpietario</param>
        /// <param name="autonomia">cantidad de kilometros que el vehículo puede recorrer con una carga completa de batería</param>
        /// <param name="asientos">cantidad de asientos del vehículo</param>
        /// <param name="service">intervalo con el que se deben realizar los services(depende del modelo y se mide en kilómetros)</param>
        public Tesla(string modelo, int anio, int kmActual, string color, string duenio, int autonomia, int asientos, int service)
        {
            id = contadorId++;
            Marca = "Tesla";
            Modelo = modelo;
            Anio = anio;
            KmActual = kmActual;
            Color = color;
            Duenio = duenio;
            Autonomia = autonomia;
            Asientos = asientos;
            IntervaloService =  service;

            ProximoService = ((kmActual / service) + 1) * service;   //kilometraje que se  debe realizar el próximo service            
            CantServices = (kmActual/ service); //cantidad de services que fueron realizados
            CantCargas = (kmActual / autonomia);    //cantidad de cargas de baterías
        }

        public int Id
        {
            get { return id; }
        }
        public int KmActual
        {
            get { return kmActual; }
            set { kmActual = value; }
        }

        public int Asientos
        {
            get { return asientos; }
            set { asientos = value; }
        }
        #endregion

        #region Funcionalidades
        /// <summary>
        /// Metodo abstracto ToString() declarado en la clase padre Vehiculo, que es sobreescrito.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ID: {id}, Marca:{Marca}, Modelo: {Modelo}, Año: {Anio}, Kilometraje Actual: {KmActual}, Kilometraje Service: {ProximoService}, Color: {Color}, Dueño: {Duenio}.";
        }

        /// <summary>
        /// 
        /// Escaneo()
        /// Funcion abstracta heredada de la clase Vehiculo que retorna un string
        /// Se usan variables para almacenar la cantidad de services
        /// que se le realizaron al Tesla respecto de su kilometraje actual.
        /// Y finalmente devuelve un String elaborado con las variables 
        /// correspondientes a este objeto.
        /// 
        /// </summary>

        public override string Escaneo()
        {            
            cantCinturones = kmActual / controlCinturones;
            cantBaterias = kmActual / controlBaterias;
            cantNavegacion = kmActual / controlSistemaNavegacion;
            cantTraccion = kmActual / controlSistemaTraccion;
            cantMotor = kmActual / controlMotor;
            // calcular el porcentaje de batería que queda
            double sobranteCarga = ((double)kmActual % Autonomia / Autonomia) * 100;
            double porcentajeBateria = Convert.ToInt32(-sobranteCarga + 100);
            /// <summary>
            /// La clase Tesla, además de implementar la funcionalidad para calcular la cantidad de cargas de batería realizadas, 
            /// también incorpora la funcionalidad para registrar el estado de la batería durante el escaneo.
            /// Esto proporciona un seguimiento no solo de la cantidad de cargas, sino también del porcentaje de batería restante.
            /// </summary>
            string reporte = $"Tesla {Modelo} | ID: {Id} | Kilometros actuales: {KmActual}kms | Service cada: {IntervaloService}kms | Bateria: {porcentajeBateria}%\n" +
                $"Se realizaron [{CantServices}] services.\n" +
                $"({cantCinturones}) Controles de cinturones de seguridad.\n" +
                $"({cantBaterias}) Controles de baterias.\n" +
                $"({cantNavegacion}) Controles del Sistema de Navegación.\n" +
                $"({cantTraccion}) Controles del Sistema de Tracción.\n" +
                $"({cantMotor}) Controles de Motor.\n";

            return reporte;
        }
        #endregion
    }
}
