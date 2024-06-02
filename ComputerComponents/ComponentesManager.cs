namespace ComputerComponents
{
    public class ComponentesManager
    {
        private List<Componente> componentes;

        public ComponentesManager()
        {
            componentes = new List<Componente>();
        }

        public bool HayComponentesRegistrados()
        {
            return componentes.Any();
        }

        public void AgregarComponentes()
        {
            List<string> componentesObligatorios = new List<string>
            {
                "Procesador (CPU)",
                "Placa Base (Motherboard)",
                "Memoria RAM",
                "Tarjeta Gráfica (GPU)",
                "Almacenamiento (M.2)",
                "Almacenamiento (SSD)",
                "Fuente de Alimentación (PSU)",
                "Sistema de Refrigeración"
            };

            List<string> componentesOpcionales = new List<string>
            {
                "Monitor",
                "Teclado",
                "Mouse",
            };

            // Agregar componentes obligatorios
            foreach (var componente in componentesObligatorios)
            {
                AgregarComponente(componente, obligatorio: true);
            }

            // Agregar componentes opcionales
            foreach (var componente in componentesOpcionales)
            {
                Console.WriteLine($"El componente {componente} no es necesario y se puede saltar.");
                AgregarComponente(componente, obligatorio: false);
            }

            Console.WriteLine("Componentes agregados exitosamente.");
        }

        private void AgregarComponente(string nombre, bool obligatorio)
        {
            while (true)
            {
                Console.Write($"Ingresa el nombre del componente ({nombre}): ");
                string inputNombre = Console.ReadLine();
                if (!obligatorio && inputNombre.ToLower() == "saltar")
                {
                    Console.WriteLine($"Componente {nombre} saltado.");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(inputNombre))
                {
                    Console.Write($"Ingresa el precio del componente ({nombre}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal precio))
                    {
                        componentes.Add(new Componente(nombre, precio));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Precio no válido.");
                    }
                }
                else
                {
                    if (obligatorio)
                    {
                        Console.WriteLine($"{nombre} es obligatorio.");
                    }
                    else
                    {
                        Console.WriteLine($"Componente {nombre} omitido.");
                        return;
                    }
                }
            }
        }

        public void ReemplazarComponente()
        {
            if (!HayComponentesRegistrados())
            {
                Console.WriteLine("No hay componentes registrados.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Selecciona el tipo de componente a reemplazar:");
                var tipos = componentes.Select(c => c.Nombre).Distinct().ToList();
                for (int i = 0; i < tipos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tipos[i]}");
                }

                if (int.TryParse(Console.ReadLine(), out int tipoIndice) && tipoIndice > 0 && tipoIndice <= tipos.Count)
                {
                    string tipoSeleccionado = tipos[tipoIndice - 1];
                    var componentesDeTipo = componentes.Where(c => c.Nombre == tipoSeleccionado).ToList();

                    Console.WriteLine($"Selecciona el componente {tipoSeleccionado} a reemplazar:");
                    for (int i = 0; i < componentesDeTipo.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {componentesDeTipo[i].Nombre} - ${componentesDeTipo[i].Precio}");
                    }

                    if (int.TryParse(Console.ReadLine(), out int componenteIndice) && componenteIndice > 0 && componenteIndice <= componentesDeTipo.Count)
                    {
                        int indice = componentes.IndexOf(componentesDeTipo[componenteIndice - 1]);
                        Console.Write("Ingresa el nuevo nombre del componente: ");
                        string nuevoNombre = Console.ReadLine();
                        Console.Write("Ingresa el nuevo precio del componente: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                        {
                            componentes[indice] = new Componente(nuevoNombre, nuevoPrecio);
                            Console.WriteLine("Componente reemplazado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Precio no válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Índice no válido.");
                    }

                    // Opción para reemplazar otro componente o salir
                    Console.WriteLine("¿Queres reemplazar otro componente? (s/n)");
                    string continuar = Console.ReadLine().ToLower();
                    if (continuar != "s")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Tipo de componente no válido.");
                }
            }
        }

        public void MostrarComponentes()
        {
            if (!HayComponentesRegistrados())
            {
                Console.WriteLine("No hay componentes registrados.");
                return;
            }

            Console.WriteLine("\nComponentes actuales:");
            var tipos = componentes.Select(c => c.Nombre.Split(' ')[0]).Distinct().ToList();
            foreach (var tipo in tipos)
            {
                var componentesDeTipo = componentes.Where(c => c.Nombre.StartsWith(tipo)).ToList();
                Console.WriteLine($"Tipo: {tipo}");
                foreach (var componente in componentesDeTipo)
                {
                    Console.WriteLine($"{componente.Nombre} - ${componente.Precio}");
                }
            }
        }

        public void MostrarCostoTotal()
        {
            decimal costoTotal = componentes.Sum(c => c.Precio);
            Console.WriteLine($"El costo total de todos los componentes es: ${costoTotal}");
        }
    }
}
