using AlguilerVehicular.Clases;
using AlguilerVehicular.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Interfaces
{
    // Interfaz que define los métodos para la gestión de vehículos
    public interface IGestionVehiculo
    {
        void RegistrarVehiculo(Vehiculo vehiculo);
        void EliminarVehiculo(Vehiculo vehiculo);
        void ActualizarEstadoVehiculo(Vehiculo vehiculo, EstadoVehiculo nuevoEstado);
    }
}
