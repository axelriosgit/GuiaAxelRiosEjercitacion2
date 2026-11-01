// ------------------------------
// SECCIÓN F 
// Justificación de los patrones:

// Singleton (Bitacora): Necesitamos que todo el historial de la playa se guarde en un único lugar. 
//   Si hiciéramos un "new" en cada clase, los registros quedarían desparramados y los números 
//   no coincidirían. Al poner el constructor en privado, me aseguro de que exista una sola instancia global.

// Strategy (ITarifa + TarifaHora / TarifaEstadia / TarifaNocturna): Cada tarifa tiene su propia regla matemática para cobrar. 
//   Si no usara este patrón, el método Egresar sería un if/switch enorme y cada vez que inventen una tarifa 
//   nueva tendría que tocar código viejo. De esta forma, la Playa no sabe qué tarifa es, solo le dice "Calcular()".

// Factory (TarifaFactory): Como el empleado tipea la tarifa como un string ("HORA", "ESTADIA"), necesito 
//   transformar ese texto crudo en un objeto real. La factory centraliza todos los instanciamientos ahí mismo 
//   y, si mandan un código inventado, tira una excepción para evitar cobrar cualquier cosa.

// Observer (IPlayaObserver + Pantalla, Caja, Alerta, Bitácora): Al entrar o salir un auto, hay que actualizar 
//   un montón de cosas (pantalla, caja, etc). En vez de que la clase Playa llame a cada una y se acople a todo 
//   el sistema, simplemente maneja una lista de suscriptos. Si a futuro quieren sumar un aviso por WhatsApp, 
//   agrego el suscriptor y no toco la Playa para nada.

using System;

namespace EjercicioF
{
    public static class Demo
    {
        public static void Ejecutar()
        {
            var playa = new Playa(10);
            var pantalla = new PantallaLugares();
            playa.Suscribir(pantalla);
            playa.Suscribir(new CajaObserver());
            playa.Suscribir(new AlertaOcupacionObserver());
            playa.Suscribir(new BitacoraObserver());

            // Ingresan 8 vehículos con distintos códigos de tarifa
            playa.Ingresar("AB123CD", "HORA");
            playa.Ingresar("AC456EF", "ESTADIA");
            playa.Ingresar("AD789GH", "NOCHE");
            playa.Ingresar("AE111AA", "HORA");
            playa.Ingresar("AF222BB", "ESTADIA");
            playa.Ingresar("AG333CC", "NOCHE");
            playa.Ingresar("AH444DD", "HORA");
            playa.Ingresar("AI555EE", "ESTADIA");   // quedan 2 lugares -> salta la alerta

            playa.Egresar("AB123CD", 150);   // HORA, 2 h 30 min -> $ 3.600
            playa.Egresar("AC456EF", 900);   // ESTADIA, 15 h     -> $ 9.600
            playa.Desuscribir(pantalla);     // la pantalla deja de mostrar
            playa.Egresar("AD789GH", 600);   // NOCHE             -> $ 4.500

            try { playa.Ingresar("AZ999ZZ", "SEMANAL"); }
            catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }

            Bitacora.Instancia.MostrarTodo();
        }
    }
}