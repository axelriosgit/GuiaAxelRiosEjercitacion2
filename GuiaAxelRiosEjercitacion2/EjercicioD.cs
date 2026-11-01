using System;
using System.Collections.Generic;
using System.Linq;

// -----------------------
// SECCIÓN D — Ejercicio 1
namespace EjercicioD1
{
    public interface ITemperaturaObserver
    {
        void Actualizar(double grados);
    }
    public class Termometro
    {
        private readonly List<ITemperaturaObserver> _observadores = new List<ITemperaturaObserver>();
        public void Suscribir(ITemperaturaObserver o) => _observadores.Add(o);
        public void Desuscribir(ITemperaturaObserver o) => _observadores.Remove(o);
        public void Medir(double grados)
        {
            Console.WriteLine($"Termómetro: {grados}°");
            foreach (var o in _observadores.ToList())
                o.Actualizar(grados);
        }
    }
    public class PantallaCocina : ITemperaturaObserver
    {
        public void Actualizar(double grados) => Console.WriteLine($" Pantalla: {grados}°");
    }
    public class AlarmaCalor : ITemperaturaObserver
    {
        public void Actualizar(double grados)
        {
            if (grados > 30)
                Console.WriteLine(" ¡Alarma! Hace demasiado calor");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var termo = new Termometro();
            termo.Suscribir(new PantallaCocina());
            termo.Suscribir(new AlarmaCalor());
            termo.Medir(25);
            termo.Medir(34);
        }
    }
}

// -----------------------
// SECCIÓN D — Ejercicio 2
namespace EjercicioD2
{
    public interface IDescuento
    {
        decimal Aplicar(decimal precio);
    }
    public class SinDescuento : IDescuento
    {
        public decimal Aplicar(decimal precio) => precio;
    }
    public class DescuentoJubilado : IDescuento // 15% de descuento
    {
        public decimal Aplicar(decimal precio) => precio * 0.85m;
    }
    public class DescuentoEstudiante : IDescuento // 10% de descuento
    {
        public decimal Aplicar(decimal precio) => precio * 0.90m;
    }
    public static class DescuentoFactory
    {
        public static IDescuento Crear(string tipo)
        {
            switch (tipo)
            {
                case "JUBILADO": return new DescuentoJubilado();
                case "ESTUDIANTE": return new DescuentoEstudiante();
                case "NINGUNO": return new SinDescuento();
                default: throw new ArgumentException($"Tipo desconocido: {tipo}");
            }
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            // El tipo llega como TEXTO (de un ComboBox, de un JSON...)
            string tipoElegido = "JUBILADO";
            IDescuento descuento = DescuentoFactory.Crear(tipoElegido);
            Console.WriteLine(descuento.Aplicar(10000m).ToString("0"));   // imprime 8500
        }
    }

    // En una línea: ¿por qué en este caso la factory sí está justificada?: 
    // Se justifica porque el sistema necesita crear distintos objetos (las estrategias de descuento) en base a un dato dinámico de tipo string ("JUBILADO", "ESTUDIANTE"), evitando así que los condicionales de creación se repitan por todo el programa.
}