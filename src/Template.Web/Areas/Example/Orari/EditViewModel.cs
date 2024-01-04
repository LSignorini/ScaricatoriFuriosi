using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Template.Services.Shared;
using Template.Web.Infrastructure;

namespace Template.Web.Areas.Example.Orari
{
    [TypeScriptModule("Example.Orari.Server")]
    public class EditViewModel
    {
        public EditViewModel()
        {
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public DateOnly Giorno { get; set; }
        public TimeOnly Inizio { get; set; }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetOrari(OrariNaveSelectDTO.Orario orariNaveSelectDTO)
        {
            if (orariNaveSelectDTO != null)
            {
                Id = orariNaveSelectDTO.Id;
                Nome = orariNaveSelectDTO.Nome;
                Cognome = orariNaveSelectDTO.Cognome;
                Ruolo = orariNaveSelectDTO.Ruolo;
                Giorno = orariNaveSelectDTO.Giorno;
                Inizio = orariNaveSelectDTO.Inizio;
            }
        }
    }
}