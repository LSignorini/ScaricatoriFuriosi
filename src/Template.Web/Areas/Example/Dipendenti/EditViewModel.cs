using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;
using Template.Web.Infrastructure;

namespace Template.Web.Areas.Example.Dipendenti
{
    [TypeScriptModule("Example.Dipendenti.Server")]
    public class EditViewModel
    {
        public EditViewModel()
        {
        }

        public Guid? Id { get; set; }
        [Display(Name = "Codice Fiscale")]
        public string CF { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Display(Name = "Ruolo")]
        public string Ruolo { get; set; }
        [Display(Name = "Data di nascita")]
        public DateTime DataNascita { get; set; }
        [Display(Name = "Visita medica")]
        public DateTime VisitaMedica { get; set; }
        [Display(Name = "Patente")]
        public DateTime Patente { get; set; }

        public IEnumerable<OrariEditViewModel> Orari { get; set; }

        internal void SetOrari(OrariDipendenteSelectDTO orariDipendenteSelectDTO)
        {
            Orari = orariDipendenteSelectDTO.Orari.Select(x => new OrariEditViewModel(x)).ToArray();
        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetDipendente(DipendenteDetailDTO dipendenteDetailDTO)
        {
            if (dipendenteDetailDTO != null)
            {
                Id = dipendenteDetailDTO.Id;
                CF = dipendenteDetailDTO.CF;
                Nome = dipendenteDetailDTO.Nome;
                Cognome = dipendenteDetailDTO.Cognome;
                Ruolo = dipendenteDetailDTO.Ruolo;
                DataNascita = dipendenteDetailDTO.DataNascita;
                VisitaMedica = dipendenteDetailDTO.VisitaMedica;
                Patente = dipendenteDetailDTO.Patente;
            }
        }

        public UpdateDipendentiCommand ToUpdateDipendenteCommand()
        {
            return new UpdateDipendentiCommand
            {
                Id = Id,
                VisitaMedica = VisitaMedica,
                Patente = Patente
            };
        }
    }

    public class OrariEditViewModel
    {
        public OrariEditViewModel(OrariDipendenteSelectDTO.Orario orariDTO)
        {
            this.Giorno = orariDTO.Giorno;
            this.Inizio = orariDTO.Inizio;
            this.Fine = orariDTO.Fine;
            this.NomeNave = orariDTO.NomeNave;
        }

        public DateOnly Giorno { get; set; }
        public TimeOnly Inizio { get; set;}
        public TimeOnly Fine { get; set; }
        public string NomeNave { get; set;}
    }
}