using AlguilerVehicular.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Clases
{
    // Clase abstracta que representa las propiedades y métodos comunes de un vehículo
    public abstract class Vehiculo
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int AñoFabricacion { get; private set; }
        public double PrecioAlquiler { get; private set; }
        public EstadoVehiculo Estado { get; private set; }

        // Constructor para inicializar los atributos de un vehículo
        public Vehiculo(string marca, string modelo, int añoFabricacion, double precioAlquiler)
        {
            Marca = marca;
            Modelo = modelo;
            AñoFabricacion = añoFabricacion;
            PrecioAlquiler = precioAlquiler;
            Estado = EstadoVehiculo.Disponible;
        }

        // Método abstracto que será implementado en las clases derivadas para obtener el tipo de vehículo
        public abstract string ObtenerTipoVehiculo();

        // Método para actualizar el estado del vehículo
        public void ActualizarEstado(EstadoVehiculo nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        // Verifica si el vehículo está disponible
        public bool EstaDisponible()
        {
            return Estado == EstadoVehiculo.Disponible;
        }

        // Método para mostrar la información del vehículo
        public void MostrarInformacion()
        {
            Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Año: {AñoFabricacion}, Precio: {PrecioAlquiler}, Estado: {Estado}");
        }
    }
}