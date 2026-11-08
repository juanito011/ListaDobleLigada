using System;

namespace ListaDobleLigada
{
    class Program
    {
        static void Main(string[] args)
        {
            // Usamos string para poder probar con colores o números
            var lista = new ListaDoblementeLigada<string>();

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   LISTA DOBLEMENTE LIGADA GENÉRICA");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.WriteLine("========================================");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Presione Enter...");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el valor a adicionar: ");
                        string? valor = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(valor))
                        {
                            lista.Adicionar(valor.Trim());
                            Console.WriteLine("Elemento adicionado correctamente.");
                        }
                        break;

                    case 2:
                        Console.Write("Lista hacia adelante: ");
                        lista.MostrarAdelante();
                        break;

                    case 3:
                        Console.Write("Lista hacia atrás: ");
                        lista.MostrarAtras();
                        break;

                    case 4:
                        lista.OrdenarDescendentemente();
                        Console.WriteLine("Lista ordenada descendentemente.");
                        Console.Write("Lista actual: ");
                        lista.MostrarAdelante();
                        break;

                    case 5:
                        lista.MostrarModas();
                        break;

                    case 6:
                        lista.MostrarGrafico();
                        break;

                    case 7:
                        Console.Write("Ingrese el valor a buscar: ");
                        string? buscar = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(buscar))
                        {
                            bool existe = lista.Existe(buscar.Trim());
                            Console.WriteLine(existe
                                ? $"Sí existe el valor \"{buscar.Trim()}\"."
                                : $"No existe el valor \"{buscar.Trim()}\".");
                        }
                        break;

                    case 8:
                        Console.Write("Ingrese el valor a eliminar (una ocurrencia): ");
                        string? eliminarUno = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(eliminarUno))
                        {
                            bool eliminado = lista.EliminarUnaOcurrencia(eliminarUno.Trim());
                            Console.WriteLine(eliminado
                                ? "Se eliminó una ocurrencia."
                                : "No se encontró el valor.");
                        }
                        break;

                    case 9:
                        Console.Write("Ingrese el valor a eliminar (todas las ocurrencias): ");
                        string? eliminarTodos = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(eliminarTodos))
                        {
                            int cantidad = lista.EliminarTodasLasOcurrencias(eliminarTodos.Trim());
                            Console.WriteLine(cantidad > 0
                                ? $"Se eliminaron {cantidad} ocurrencia(s)."
                                : "No se encontró el valor.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }

            } while (opcion != 0);
        }
    }
}