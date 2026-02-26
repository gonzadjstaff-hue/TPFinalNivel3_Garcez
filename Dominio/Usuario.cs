namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string Pass { get; set; } = "";
        public bool Admin { get; set; }
    }
}