using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Services.Shared
{
    public class Orari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CF { get; set; }
        public string NomeNave { get; set; }
        public DateOnly Giorno { get; set; }
        public TimeOnly Inizio { get; set; }
        public TimeOnly Fine { get; set; }
    }
}
