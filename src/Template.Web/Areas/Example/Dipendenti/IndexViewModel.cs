using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;

namespace Template.Web.Areas.Example.Dipendenti
{
    public class IndexViewModel 
    {
        public IndexViewModel()
        {
            Dipendenti = Array.Empty<DipendenteIndexViewModel>();
        }

        [Display(Name = "Cerca")]
        public string Filter { get; set; }

        public IEnumerable<DipendenteIndexViewModel> Dipendenti { get; set; }

        internal void SetDipendenti(DipendentiIndexDTO dipendentiIndexDTO)
        {
            Dipendenti = dipendentiIndexDTO.Dipendenti.Select(x => new DipendenteIndexViewModel(x)).ToArray();
        }

        public DipendentiIndexQuery ToDipendentiIndexQuery()
        {
            return new DipendentiIndexQuery
            {
                Filter = Filter
            };
        }
    }

    public class DipendenteIndexViewModel
    {
        public DipendenteIndexViewModel(DipendentiIndexDTO.Dipendente dipendenteIndexDTO)
        {
            this.Nome = dipendenteIndexDTO.Nome;
            this.Cognome = dipendenteIndexDTO.Cognome;
            this.Ruolo = dipendenteIndexDTO.Ruolo;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public DateTime DataNascita { get; set; }
        public DateTime VisitaMedica { get; set; }
        public DateTime Patente { get; set; }
    }
}
