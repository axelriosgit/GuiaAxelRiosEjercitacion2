using System;

namespace GuiaEjercitacion2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SECCIÓN B — Ejercicio 1 ---");
            EjercicioB1.Demo.Ejecutar();

            Console.WriteLine("\n--- SECCIÓN B — Ejercicio 2 ---");
            EjercicioB2.Demo.Ejecutar();

            Console.WriteLine("\n--- SECCIÓN B — Ejercicio 3 ---");
            EjercicioB3.Demo.Ejecutar();

            Console.WriteLine("\n--- SECCIÓN C — Ejercicio 1 ---");
            EjercicioC1.Demo.Ejecutar();

            Console.WriteLine("\n--- SECCIÓN D — Ejercicio 1 ---");
            EjercicioD1.Demo.Ejecutar();

            Console.WriteLine("\n--- SECCIÓN D — Ejercicio 2 ---");
            EjercicioD2.Demo.Ejecutar();

            Console.WriteLine("\n--- SECCIÓN F  ---");
            EjercicioF.Demo.Ejecutar();

            Console.ReadKey();
        }
    }
}