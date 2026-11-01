using System.Globalization;

namespace EjercicioF
{
    public class BitacoraObserver : IPlayaObserver
    {
        private static readonly CultureInfo Ar = new CultureInfo("es-AR");

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == TipoEvento.Ingreso)
                Bitacora.Instancia.Registrar($"Ingresó {evento.Patente}");
            else
                Bitacora.Instancia.Registrar($"Egresó {evento.Patente} - $ {evento.Importe.ToString("N0", Ar)}");
        }
    }
}