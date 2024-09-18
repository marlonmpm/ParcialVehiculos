using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Clases
{
    // Clase que representa una motocicleta, hereda de Vehiculo
    public class Motocicleta : Vehiculo
    {
        public Motocicleta(string marca, string modelo, int añoFabricacion, double precioAlquiler)
            : base(marca, modelo, añoFabricacion, precioAlquiler)
        {
        }

        // Implementa el método abstracto para obtener el tipo de vehículo
        public override string ObtenerTipoVehiculo()
        {
            return "Motocicleta";
        }
    }
}
