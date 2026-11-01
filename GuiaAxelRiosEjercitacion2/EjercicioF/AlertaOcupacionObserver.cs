using System;

namespace EjercicioF
{
    public class AlertaOcupacionObserver : IPlayaObserver
    {
        private const int Limite = 2;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.LugaresLibres <= Limite)
                Console.WriteLine($"[Alerta] ¡Quedan {evento.LugaresLibres} lugares!");
        }
    }
}