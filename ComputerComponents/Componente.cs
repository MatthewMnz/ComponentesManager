namespace ComputerComponents
{
    public class Componente
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Componente(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}
