using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioF
{
    public class Playa
    {
        private readonly int _capacidad;
        private readonly Dictionary<string, ITarifa> _vehiculos = new Dictionary<string, ITarifa>();
        private readonly List<IPlayaObserver> _observadores = new List<IPlayaObserver>();

        public Playa(int capacidad)
        {
            _capacidad = capacidad;
        }

        public int LugaresLibres => _capacidad - _vehiculos.Count;

        public void Suscribir(IPlayaObserver o) => _observadores.Add(o);
        public void Desuscribir(IPlayaObserver o) => _observadores.Remove(o);

        public void Ingresar(string patente, string codigoTarifa)
        {
            if (string.IsNullOrWhiteSpace(patente))
                throw new InvalidOperationException("La patente no puede estar vacía.");
            if (_vehiculos.ContainsKey(patente))
                throw new InvalidOperationException($"El vehículo {patente} ya está en la playa.");
            if (LugaresLibres == 0)
                throw new InvalidOperationException("La playa está llena.");

            ITarifa tarifa = TarifaFactory.Crear(codigoTarifa);
            _vehiculos.Add(patente, tarifa);

            Notificar(new EventoPlaya(TipoEvento.Ingreso, patente, 0, LugaresLibres));
        }

        public decimal Egresar(string patente, int minutos)
        {
            if (!_vehiculos.ContainsKey(patente))
                throw new InvalidOperationException($"El vehículo {patente} no está en la playa.");

            ITarifa tarifa = _vehiculos[patente];
            decimal importe = tarifa.Calcular(minutos);
            _vehiculos.Remove(patente);

            Notificar(new EventoPlaya(TipoEvento.Egreso, patente, importe, LugaresLibres));
            return importe;
        }

        private void Notificar(EventoPlaya evento)
        {
            foreach (var o in _observadores.ToList())
                o.Actualizar(evento);
        }
    }
}