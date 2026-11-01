using System;
using System.Globalization;

namespace EjercicioF
{
    public class CajaObserver : IPlayaObserver
    {
        private static readonly CultureInfo Ar = new CultureInfo("es-AR");
        private decimal _totalRecaudado = 0;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo != TipoEvento.Egreso)
                return;

            _totalRecaudado += evento.Importe;
            Console.WriteLine($"[Caja] Cobrado $ {evento.Importe.ToString("N0", Ar)} a {evento.Patente}. " +
                              $"Recaudado: $ {_totalRecaudado.ToString("N0", Ar)}");
        }
    }
}
