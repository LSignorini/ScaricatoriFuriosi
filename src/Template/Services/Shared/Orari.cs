using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Services.Shared
{
    public class Orari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CF { get; set; }
        public Guid NomeNave { get; set; }
        public Guid Inizio { get; set; }
        public Guid Fine { get; set; }
    }
}
