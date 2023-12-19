using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Services.Shared
{
    public class Nave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public int Container { get; set; }
        public int Bancali { get; set; }
    }
}

