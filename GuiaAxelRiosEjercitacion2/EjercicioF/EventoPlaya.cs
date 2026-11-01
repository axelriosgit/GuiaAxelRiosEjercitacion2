namespace EjercicioF
{
    public class EventoPlaya
    {
        public TipoEvento Tipo { get; }
        public string Patente { get; }
        public decimal Importe { get; }
        public int LugaresLibres { get; }

        public EventoPlaya(TipoEvento tipo, string patente, decimal importe, int lugaresLibres)
        {
            Tipo = tipo;
            Patente = patente;
            Importe = importe;
            LugaresLibres = lugaresLibres;
        }
    }
}