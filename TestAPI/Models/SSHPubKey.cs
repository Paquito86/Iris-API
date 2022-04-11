using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public class SSHPubKey
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Nombre de la clave
        public string? Workstation { get; set; } // Identificador del Equipo Autorizado
        public int Node_Id { get; set; } // Id del Nodo sobre el que se nada acceso
        public string? RSA { get; set; }

        //public bool wildcard { get; set; } // ¡Peligroso!
    }
    class KeyDb : DbContext
    {
        public KeyDb(DbContextOptions<KeyDb> options) : base(options) { }
        public DbSet<SSHPubKey> Keys { get; set; }
    }
}
