using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Services.Shared
{
    public class Dipendente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CF { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public DateTime DataNascita { get; set; }
        public DateTime VisitaMedica { get; set; }
        public DateTime Patente { get; set; }
    }
}
