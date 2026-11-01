using System;
using System.Collections.Generic;
using System.Linq;

// -----------------------
// SECCIÓN C — Ejercicio 1
// ¿Cuál es el error y de qué tipo es?: 
// Es un error de ejecución del tipo "InvalidOperationException"
//
// ¿Por qué ocurre?: 
// Sucede porque la clase 'AvisoUnico' invoca al método 'Desuscribir' y altera la lista interna de '_observadores' en el mismo instante en que el bucle foreach de 'Sonar()' la está recorriendo. C# bloquea la modificación de colecciones mientras están siendo iteradas.
//
// ¿Cómo se corrige?: 
// Creando y recorriendo una réplica temporal de la lista al momento de notificar, llamando al método '.ToList()' sobre la colección original
// -----------------------
namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }
    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores = new List<IAlarmaObserver>();
        public void Suscribir(IAlarmaObserver o) => _observadores.Add(o);
        public void Desuscribir(IAlarmaObserver o) => _observadores.Remove(o);
        public void Sonar()
        {
            Console.WriteLine("¡Riiiing!");

            var copiaObservadores = _observadores.ToList();

            foreach (var o in copiaObservadores)
                o.Actualizar(this);
        }
    }
    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }
    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) => Console.WriteLine("Luz encendida");
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var alarma = new Alarma();
            alarma.Suscribir(new AvisoUnico());
            alarma.Suscribir(new Luz());
            alarma.Sonar();
        }
    }
}

// -----------------------
// SECCIÓN C — Ejercicio 2
// ¿Cuál es el error y de qué tipo es?: 
// Es un error de diseño. El código pretende estar aplicando Strategy, pero en realidad mantiene la lógica centralizada mediante condicionales dentro de una única clase, rompiendo la esencia del patrón que busca separar cada variante en una clase distinta
//
// ¿Qué pasa cuando llega un tipo nuevo, por ejemplo "Bicicleta"?: 
// Rompe el principio de Open/Closed porque obligaría al desarrollador a modificar el código fuente del método 'Calcular', añadiendo otro bloque "if" para soportar el caso de la bicicleta
//
// ¿Cómo se corrige?:
// Se corrige creando clases específicas e independientes (como 'TarifaMoto', 'TarifaCamion', etc.) que implementen el contrato 'IEnvioStrategy', eliminando completamente los condicionales
// -----------------------
namespace EjercicioC2
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal pesoKg);
    }
    public class TarifaMoto : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 1500 + pesoKg * 100;
    }

    public class TarifaCamion : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 8000 + pesoKg * 40;
    }

    public class TarifaComun : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 3000 + pesoKg * 70;
    }
}

// -----------------------
// SECCIÓN C — Ejercicio 3
// ¿Cuál es el error y de qué tipo es?: 
// Es un error de compilación. El método 'Crear' declara que siempre retorna un objeto de tipo 'INotificador', pero carece de una instrucción 'return' (o un fallo explícito) para aquellos casos en los que la variable 'canal' no coincida ni con "MAIL" ni con "SMS"
//
// ¿Cómo se corrige?: 
// Colocando un control final (fuera de los if) que arroje una excepción, garantizando así que todos los flujos de ejecución devuelvan algo o se detengan mediante un error controlado
//
// ¿Por qué conviene lanzar una excepción con un mensaje claro y no devolver null?: 
// Si se devuelve 'null', el programa fallaría mucho más adelante con un confuso "NullReferenceException" cuando otro componente intente usar el notificador. Al lanzar un 'ArgumentException' de inmediato, forzamos una falla temprana que informa exactamente cuál fue el texto inválido que provocó el error
// -----------------------
namespace EjercicioC3
{
    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }

    public class NotificadorMail : INotificador
    {
        public void Enviar(string destino, string mensaje) =>
            Console.WriteLine($"[MAIL a {destino}] {mensaje}");
    }

    public class NotificadorSms : INotificador
    {
        public void Enviar(string destino, string mensaje) =>
            Console.WriteLine($"[SMS a {destino}] {mensaje}");
    }

    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            if (canal == "MAIL") return new NotificadorMail();
            if (canal == "SMS") return new NotificadorSms();

            throw new ArgumentException($"Canal de notificación desconocido: {canal}");
        }
    }
}