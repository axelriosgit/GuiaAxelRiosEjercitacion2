using System;

namespace EjercicioF
{
    public interface ITarifa
    {
        string Nombre { get; }
        decimal Calcular(int minutos);
    }
}
