using AlguilerVehicular.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Interfaces
{
    // Interfaz que define los métodos para la gestión de reservas
    public interface IGestionReserva
    {
        void RealizarReserva(Cliente cliente, Vehiculo vehiculo, DateTime fechaInicio, DateTime fechaFin);
        void CancelarReserva(Reserva reserva);
    }
}
