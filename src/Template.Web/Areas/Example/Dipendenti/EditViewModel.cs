using System;
using System.ComponentModel.DataAnnotations;
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
}