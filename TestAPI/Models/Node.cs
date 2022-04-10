using Microsoft.EntityFrameworkCore;
namespace TestAPI.Models
{
    public class Node
    {
        public int Id { get; set; }
        public string? longId { get; set; }
        public int DatacenterId { get; set; } // ID del Centro de Datos. Ligado a Models.Datacenter

        public string? CPU { get; set; } // Nombre completo del procesador (Marca + Modelo)
        public int CPUCores { get; set; } // Número de núcleos del CPU
        public string? RAM { get; set; } // Memoria RAM total del Nodo en MiB

        public double Cost { get; set; } // Coste mensual en €

        public bool Retired { get; set; } // Wether or not está jubilado
        public bool Pterodactyl { get; set; } // Wether or not el nodo está conectado a Pterodactyl
        public bool Monolith { get; set; } // Wether or not es un monolito
        public bool Docker { get; set; } // Wether or not usa Docker
        public bool Kubernetes { get; set; } // Wether or not usa Kubernetes

    }
    class NodeDb : DbContext
    {
        public NodeDb(DbContextOptions options) : base(options) { }
        public DbSet<Node> Nodes { get; set; }
    }
}
