using System;
using System.ComponentModel.DataAnnotations;
using Template.Services.Shared;
using Template.Web.Infrastructure;

namespace Template.Web.Areas.Example.Navi
{
    [TypeScriptModule("Example.Navi.Server")]
    public class EditViewModel
    {
        public EditViewModel()
        {
        }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        public string NomeCliente { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public int Container {  get; set; }
        public int Bancali { get; set; }


        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetNave(NaveDetailDTO naveDetailDTO)
        {
            if (naveDetailDTO != null)
            {
                Nome = naveDetailDTO.Nome;
                NomeCliente = naveDetailDTO.NomeCliente;
                Arrivo = naveDetailDTO.Arrivo;
                Partenza = naveDetailDTO.Partenza;
                Container = naveDetailDTO.Container;
                Bancali = naveDetailDTO.Bancali;
            }
        }
    }
}