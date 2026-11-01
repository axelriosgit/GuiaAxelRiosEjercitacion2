using System;

namespace EjercicioF
{
    public class TarifaNocturna : ITarifa
    {
        public string Nombre => "NOCHE";

        public decimal Calcular(int minutos) => 4500m;
    }
}