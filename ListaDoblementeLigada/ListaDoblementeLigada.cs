using System;
using System.Collections.Generic;

namespace ListaDobleLigada
{
    public class ListaDoblementeLigada<T>
    {
        private Nodo<T>? cabeza;
        private Nodo<T>? cola;
        private int cantidad;

        public ListaDoblementeLigada()
        {
            cabeza = null;
            cola = null;
            cantidad = 0;
        }

        public int Cantidad => cantidad;
        public bool EstaVacia => cantidad == 0;

        public void Adicionar(T valor)
        {
            Nodo<T> nuevo = new Nodo<T>(valor);

            if (EstaVacia)
            {
                cabeza = cola = nuevo;
            }
            else if (Comparer<T>.Default.Compare(valor, cabeza!.Valor) <= 0)
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            else if (Comparer<T>.Default.Compare(valor, cola!.Valor) >= 0)
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
            else
            {
                Nodo<T> actual = cabeza;
                while (actual.Siguiente != null &&
                       Comparer<T>.Default.Compare(valor, actual.Siguiente.Valor) > 0)
                {
                    actual = actual.Siguiente;
                }

                nuevo.Siguiente = actual.Siguiente;
                nuevo.Anterior = actual;
                actual.Siguiente!.Anterior = nuevo;
                actual.Siguiente = nuevo;
            }

            cantidad++;
        }

        public void MostrarAdelante()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T>? actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor);
                if (actual.Siguiente != null) Console.Write(" → ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }

        public void MostrarAtras()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T>? actual = cola;
            while (actual != null)
            {
                Console.Write(actual.Valor);
                if (actual.Anterior != null) Console.Write(" → ");
                actual = actual.Anterior;
            }
            Console.WriteLine();
        }

        public void OrdenarDescendentemente()
        {
            if (cantidad <= 1) return;

            Nodo<T>? actual = cabeza;
            Nodo<T>? temp = null;

            while (actual != null)
            {
                temp = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temp;
                actual = actual.Anterior;
            }

            temp = cabeza;
            cabeza = cola;
            cola = temp;
        }

        public void MostrarModas()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Dictionary<T, int> frecuencias = new Dictionary<T, int>();
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (frecuencias.ContainsKey(actual.Valor))
                    frecuencias[actual.Valor]++;
                else
                    frecuencias[actual.Valor] = 1;
                actual = actual.Siguiente;
            }

            int maxFrecuencia = 0;
            foreach (var frecuencia in frecuencias.Values)
                if (frecuencia > maxFrecuencia) maxFrecuencia = frecuencia;

            List<T> modas = new List<T>();
            foreach (var par in frecuencias)
            {
                if (par.Value == maxFrecuencia)
                    modas.Add(par.Key);
            }

            if (modas.Count == 1)
                Console.WriteLine($"La moda es: {modas[0]} (aparece {maxFrecuencia} veces)");
            else
            {
                Console.Write("Las modas son: ");
                Console.WriteLine(string.Join(", ", modas) + $" (aparecen {maxFrecuencia} veces cada una)");
            }
        }

        public void MostrarGrafico()
        {
            if (EstaVacia)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Dictionary<T, int> frecuencias = new Dictionary<T, int>();
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (frecuencias.ContainsKey(actual.Valor))
                    frecuencias[actual.Valor]++;
                else
                    frecuencias[actual.Valor] = 1;
                actual = actual.Siguiente;
            }

            var ordenados = new List<KeyValuePair<T, int>>(frecuencias);
            ordenados.Sort((a, b) => Comparer<T>.Default.Compare(a.Key, b.Key));

            Console.WriteLine("\nGráfico de ocurrencias:");
            Console.WriteLine("-----------------------");
            foreach (var par in ordenados)
            {
                Console.Write($"{par.Key} ");
                Console.WriteLine(new string('*', par.Value));
            }
            Console.WriteLine();
        }

        public bool Existe(T valor)
        {
            Nodo<T>? actual = cabeza;
            while (actual != null)
            {
                if (Comparer<T>.Default.Compare(actual.Valor, valor) == 0)
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public bool EliminarUnaOcurrencia(T valor)
        {
            if (EstaVacia) return false;

            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (Comparer<T>.Default.Compare(actual.Valor, valor) == 0)
                {
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    else
                        cabeza = actual.Siguiente;

                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                    else
                        cola = actual.Anterior;

                    cantidad--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public int EliminarTodasLasOcurrencias(T valor)
        {
            int eliminados = 0;
            while (EliminarUnaOcurrencia(valor))
            {
                eliminados++;
            }
            return eliminados;
        }
    }
}