using System;

using System;

namespace EjercicioF
{
    public class TarifaHora : ITarifa
    {
        private const decimal PrecioHora = 1200m;

        public string Nombre => "HORA";

        public decimal Calcular(int minutos)
        {
            int horas = (int)Math.Ceiling(minutos / 60.0);
            return horas * PrecioHora;
        }
    }
}
