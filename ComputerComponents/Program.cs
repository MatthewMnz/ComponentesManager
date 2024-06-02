namespace ComputerComponents
{
    class Program
    {
        static ComponentesManager componentesManager = new ComponentesManager();

        static void Main(string[] args)
        {
            while (true)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ManejarComponentes();
                        break;
                    case "2":
                        componentesManager.MostrarCostoTotal();
                        break;
                    case "3":
                        componentesManager.MostrarComponentes();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\nMenú Principal:");
            Console.WriteLine("1. Componentes");
            Console.WriteLine("2. Costo Total");
            Console.WriteLine("3. Mostrar Componentes");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");
        }

        static void ManejarComponentes()
        {
            Console.WriteLine("\nOpciones de Componentes:");
            Console.WriteLine("a. Agregar Componentes");
            Console.WriteLine("b. Reemplazar Componente");
            Console.WriteLine("c. Volver al Menú Principal");
            Console.Write("Selecciona una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "a":
                    componentesManager.AgregarComponentes();
                    break;
                case "b":
                    componentesManager.ReemplazarComponente();
                    break;
                case "c":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }
}
