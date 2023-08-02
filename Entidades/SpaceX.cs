using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FERNANDES_ROCCIA_TAPIA.Entidades
{
    /// <summary>
    /// La clase SpaceX hereda de la clase abstracta Vehiculo,
    /// en la interfaz se podran seleccionar e ingrasar datos,
    /// que seran verificados con condiciones logicas para
    /// la correcta instanciacion de la clase SpaceX acorde
    /// a su metodo constructor y al modelo seleccionado por el usuario
    /// solo se podran crear SpaceX's modelo: (Falcon 9,  Starship).
    /// Las propiedades caracteristicas de cada modelo se asignaran
    /// automaticamente y sera transparente para el usuario.
    /// Por ejemplo si se elige en el comboBox "Falcon 9" se asignara
    /// como autonomia:200 HS y como service: 400HS
    /// </summary>
    public class SpaceX : Vehiculo
    {
        #region Propiedades
        private static int contadorId = 1;
        private int id;
        private int HsVueloActual;
        private int horasService;
        private const int sistemaPropulsion = 1000;
        private const int sistemaNavegacion = 500;
        private int cantPropulsion;
        private int cantNavegacion;

        public SpaceX(string modelo, int anio, int hsVueloActual, string color, string duenio, int autonomia, int service)
        {
            id = contadorId++;
            Marca = "SpaceX";
            Modelo = modelo;
            Anio = anio;
            HsVueloActual = hsVueloActual;
            Color = color;
            Duenio = duenio;
            Autonomia = autonomia;
            IntervaloService = service; // Para mostrar el intervalo de service corrspondiente a cada modelo

            ProximoService = ((hsVueloActual / service) + 1) * service; // Para calcular el proximo service
            CantServices = (HsVueloActual / service); // Para mostrar la  cantidad de service total realizados
            CantCargas = (HsVueloActual / autonomia); // Cantidad de cargas de combustible realizadas
        }


        public int Id
        {
            get { return id; }
        }
        public int HorasVueloActual
        {
            get { return HsVueloActual; }
            set { HsVueloActual = value; }
        }
        #endregion

        #region Funcionalidades

        /// <summary>
        /// Metodo abstracto ToString() declarado en la clase padre Vehiculo, que es sobreescrito.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"SpaceX";
        }

        /// <summary>
        /// 
        /// Escaneo()
        /// Funcion abstracta heredada de la clase Vehiculo que retorna un string
        /// Se usan variables para almacenar la cantidad de services
        /// que se le realizaron al SpaceX respecto del checkeo y su horas de vuelo actual.
        /// Y finalmente devuelve un String elaborado con las variables 
        /// correspondientes a este objeto.
        /// 
        /// </summary>
        public override string Escaneo()
        {
            cantPropulsion = HsVueloActual / sistemaPropulsion;
            cantNavegacion = HsVueloActual / sistemaNavegacion;
            double sobranteCarga = ((double)HsVueloActual % Autonomia / Autonomia) * 100;
            double porcentajeCombustible = Convert.ToInt32(-sobranteCarga + 100);
            /// La clase SpaceX, además de implementar la funcionalidad para calcular la cantidad de cargas de combustible realizadas, 
            /// también incorpora la funcionalidad para registrar el porcentaje de combustible disponible durante el escaneo.
            /// Esto proporciona un seguimiento no solo de la cantidad de cargas, sino también del porcentaje de combustible restante.
            string reporte =

                $"SpaceX {Modelo} | ID: {Id} | Horas de vuelo: {HorasVueloActual}hs | Service cada: {IntervaloService}hs | Combustible disponible: {porcentajeCombustible}%\n" +
                $"Control del Sistema de Propulsion: cada 1000Hs\n" +
                $"Control del Sistema de Navegacion: cada 500Hs\n\n" +
                $"Se realizaron [{CantServices}] servicios.\n" +
                $"({cantPropulsion}) Controles del Sistema de Propulsión.\n" +
                $"({cantNavegacion}) Controles del Sistema de Navegación.";

            return reporte;
        }
        #endregion
    }
}
