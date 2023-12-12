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
        public string Email { get; set; }

        [Display(Name = "Nome")]
        public string FirstName { get; set; }
        [Display(Name = "Cognome")]
        public string LastName { get; set; }
        [Display(Name = "Nickname")]
        public string NickName { get; set; }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetDipendente(DipendenteDetailDTO dipendenteDetailDTO)
        {
            if (dipendenteDetailDTO != null)
            {
                Id = dipendenteDetailDTO.Id;
                Email = dipendenteDetailDTO.Email;
                FirstName = dipendenteDetailDTO.FirstName;
                LastName = dipendenteDetailDTO.LastName;
                NickName = dipendenteDetailDTO.NickName;
            }
        }

        public AddOrUpdateDipendenteCommand ToAddOrUpdateDipendenteCommand()
        {
            return new AddOrUpdateDipendenteCommand
            {
                Id = Id,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                NickName = NickName
            };
        }
    }
}