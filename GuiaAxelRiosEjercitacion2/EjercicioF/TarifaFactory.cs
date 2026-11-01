using System;
using System.Collections.Generic;

namespace EjercicioF
{
     static class TarifaFactory
    {
        public static ITarifa Crear(string codigo)
        {
            switch (codigo?.Trim().ToUpper())
            {
                case "HORA": return new TarifaHora();
                case "ESTADIA": return new TarifaEstadia();
                case "NOCHE": return new TarifaNocturna();
                default: throw new ArgumentException($"Código de tarifa desconocido: {codigo}");
            }
        }

        public static List<string> CodigosDisponibles()
        {
            return new List<string> { "HORA", "ESTADIA", "NOCHE" };
        }
    }
}
