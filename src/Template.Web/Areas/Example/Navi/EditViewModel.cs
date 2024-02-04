using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;
using Template.Web.Infrastructure;
using static Template.Services.Shared.ArriviDTO;

namespace Template.Web.Areas.Example.Navi
{
    [TypeScriptModule("Example.Navi.Server")]
    public class EditViewModel
    {
        public EditViewModel() 
        {
            DateLavorazione = Array.Empty<DateLavorazioneEditViewModel>();
        }

        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public int Container {  get; set; }
        public int Bancali { get; set; }

        public IEnumerable<DateLavorazioneEditViewModel> DateLavorazione { get; set; }

        internal void SetDateLavorazione(OrariNaveSelectDTO orariNaveSelectDTO)
        {
            DateLavorazione = orariNaveSelectDTO.Orari.Select(x => new DateLavorazioneEditViewModel(x)).ToArray();
        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetNave(NaveDetailDTO naveDetailDTO)
        {
            if (naveDetailDTO != null)
            {
                Id = naveDetailDTO.Id;
                Nome = naveDetailDTO.Nome;
                NomeCliente = naveDetailDTO.NomeCliente;
                Arrivo = naveDetailDTO.Arrivo;
                Partenza = naveDetailDTO.Partenza;
                Container = naveDetailDTO.Container;
                Bancali = naveDetailDTO.Bancali;
            }
        }
    }

    public class DateLavorazioneEditViewModel
    {
        public DateLavorazioneEditViewModel(OrariNaveSelectDTO.Orario dateLavorazioneDTO)
        {
            this.Data = dateLavorazioneDTO.Giorno;
        }

        public DateOnly Data { get; set; }
    }
}