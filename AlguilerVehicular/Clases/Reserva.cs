using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Clases
{
    //using System;

    // Clase que representa una reserva de un vehículo por parte de un cliente
    public class Reserva
    {
        public Cliente Cliente { get; private set; }
        public Vehiculo Vehiculo { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }

        // Constructor para inicializar los atributos de la reserva
        public Reserva(Cliente cliente, Vehiculo vehiculo, DateTime fechaInicio, DateTime fechaFin)
        {
            Cliente = cliente;
            Vehiculo = vehiculo;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        // Método para mostrar los detalles de la reserva
        public void MostrarDetallesReserva()
        {
            Console.WriteLine($"Cliente: {Cliente.Nombre}, Vehículo: {Vehiculo.ObtenerTipoVehiculo()}, " +
                              $"Fecha de Inicio: {FechaInicio.ToShortDateString()}, Fecha de Fin: {FechaFin.ToShortDateString()}");
        }
    }
}
