using AlguilerVehicular.Enums;
using AlguilerVehicular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Clases
{
    //using System;
    //using System.Collections.Generic;

    // Clase que gestiona el sistema de reservas de vehículos
    public class SistemaReservas : IGestionReserva, IGestionVehiculo
    {
        private List<Vehiculo> vehiculos;
        private List<Reserva> reservas;

        // Constructor para inicializar las listas de vehículos y reservas
        public SistemaReservas()
        {
            vehiculos = new List<Vehiculo>();
            reservas = new List<Reserva>();
        }

        // Método para registrar un nuevo vehículo
        public void RegistrarVehiculo(Vehiculo vehiculo)
        {
            vehiculos.Add(vehiculo);
            Console.WriteLine($"Vehículo registrado: {vehiculo.ObtenerTipoVehiculo()}");
        }

        // Método para eliminar un vehículo
        public void EliminarVehiculo(Vehiculo vehiculo)
        {
            vehiculos.Remove(vehiculo);
            Console.WriteLine($"Vehículo eliminado: {vehiculo.ObtenerTipoVehiculo()}");
        }

        // Método para actualizar el estado de un vehículo
        public void ActualizarEstadoVehiculo(Vehiculo vehiculo, EstadoVehiculo nuevoEstado)
        {
            vehiculo.ActualizarEstado(nuevoEstado);
            Console.WriteLine($"Estado del vehículo actualizado a: {nuevoEstado}");
        }

        // Método para realizar una reserva
        public void RealizarReserva(Cliente cliente, Vehiculo vehiculo, DateTime fechaInicio, DateTime fechaFin)
        {
            if (vehiculo.EstaDisponible())
            {
                Reserva reserva = new Reserva(cliente, vehiculo, fechaInicio, fechaFin);
                reservas.Add(reserva);
                vehiculo.ActualizarEstado(EstadoVehiculo.Alquilado);
                Console.WriteLine("Reserva realizada con éxito.");
            }
            else
            {
                Console.WriteLine("El vehículo no está disponible.");
            }
        }

        // Método para cancelar una reserva
        public void CancelarReserva(Reserva reserva)
        {
            reservas.Remove(reserva);
            reserva.Vehiculo.ActualizarEstado(EstadoVehiculo.Disponible);
            Console.WriteLine("Reserva cancelada.");
        }

        // Método para buscar un vehículo por su marca
        public Vehiculo BuscarVehiculoPorMarca(string marca)
        {
            return vehiculos.Find(v => v.Marca.Equals(marca, StringComparison.OrdinalIgnoreCase));
        }

        // Método para mostrar todos los vehículos registrados
        public void MostrarTodosLosVehiculos()
        {
            foreach (var vehiculo in vehiculos)
            {
                vehiculo.MostrarInformacion();
            }
        }

        // Método para cancelar una reserva a través del vehículo
        public void CancelarReservaPorVehiculo(Vehiculo vehiculo)
        {
            Reserva reserva = reservas.Find(r => r.Vehiculo == vehiculo);
            if (reserva != null)
            {
                CancelarReserva(reserva);
            }
        }
    }
}
