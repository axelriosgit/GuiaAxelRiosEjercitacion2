using System;
using System.Collections.Generic;

namespace EjercicioF
{
    public class Bitacora
    {
        private static Bitacora? _instancia;
        private readonly List<string> _registros = new List<string>();

        private Bitacora() { }

        public static Bitacora Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Bitacora();
                return _instancia;
            }
        }

        public void Registrar(string texto)
        {
            int numero = _registros.Count + 1;
            _registros.Add($"{numero:00}. {texto}");
        }

        public void MostrarTodo()
        {
            Console.WriteLine("--- Bitácora ---");
            foreach (var registro in _registros)
                Console.WriteLine(registro);
        }
    }
}