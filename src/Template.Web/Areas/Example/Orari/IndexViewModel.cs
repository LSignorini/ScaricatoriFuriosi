using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;

namespace Template.Web.Areas.Example.Orari
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Orari = Array.Empty<OrarioIndexViewModel>();
        }

        [Display(Name = "Cerca")]
        public string Filter { get; set; }

        public IEnumerable<OrarioIndexViewModel> Orari { get; set; }

        public NaveDetailDTO Nave { get; set; }

        public DateOnly Giorno { get; set; }

        public DipendentePerRuoloDTO[] DipendentiLiberi { get; set; }

        internal void SetOrari(OrariNaveSelectDTO orariIndexDTO)
        {
            Orari = orariIndexDTO.Orari.Select(x => new OrarioIndexViewModel(x)).ToArray();
        }

        internal void SetNave(NaveDetailDTO naveDetailDTO)
        {
            Nave = naveDetailDTO;
        }

        internal void SetGiorno(DateOnly giornoCorrente)
        {
            Giorno = giornoCorrente;
        }

        internal void SetDipendentiLiberi(DipendentePerRuoloDTO[] dipendenti)
        {
            DipendentiLiberi = dipendenti;
        }

        public OrariIndexQuery ToOrariIndexQuery()
        {
            return new OrariIndexQuery
            {
                Filter = Filter
            };
        }
    }

    public class OrarioIndexViewModel
    {
        public OrarioIndexViewModel(OrariNaveSelectDTO.Orario orarioIndexDTO)
        {
            this.Id = orarioIndexDTO.Id;
            this.Nome = orarioIndexDTO.Nome;
            this.Cognome = orarioIndexDTO.Cognome;
            this.Ruolo = orarioIndexDTO.Ruolo;
            this.Giorno = orarioIndexDTO.Giorno;
            this.Inizio = orarioIndexDTO.Inizio;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public DateOnly Giorno { get; set; }
        public TimeOnly Inizio { get; set; }
    }
}
