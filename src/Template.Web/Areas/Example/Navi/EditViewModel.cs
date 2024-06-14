using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;
using Template.Web.Areas.Example.Dipendenti;
using Template.Web.Areas.Example.Orari;
using Template.Web.Infrastructure;

namespace Template.Web.Areas.Example.Navi
{
    [TypeScriptModule("Example.Navi.Server")]
    public class EditViewModel
    {
        public EditViewModel() 
        {
            DateLavorazione = Array.Empty<DataLavorazioneEditViewModel>();
            FasceOrarie = new List<FasceOrarie>();
            DipendentiDisponibili = Array.Empty<DipendentiDisponibiliEditViewModel>();
        }

        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public int Container {  get; set; }
        public int Bancali { get; set; }

        public IEnumerable<DataLavorazioneEditViewModel> DateLavorazione { get; set; }

        public IEnumerable<OrarioDipendenteEditViewModel> OrariDipendenti { get; set; }

        public IEnumerable<DipendentiDisponibiliEditViewModel> DipendentiDisponibili { get; set; }

        public Orari.IndexViewModel OrariIndexViewModel { get; set; }
        public List<FasceOrarie> FasceOrarie { get; set; }

        internal void SetDateLavorazione(OrariNaveSelectDTO orariNaveSelectDTO)
        {
            SetOrariDipendenti(orariNaveSelectDTO);
            List<FasceOrarie> fasceOrariePerGiorno = new List<FasceOrarie>();
            for (DateOnly giorno = DateOnly.FromDateTime(Arrivo); giorno.CompareTo(DateOnly.FromDateTime(Partenza)) < 0; giorno = giorno.AddDays(1)) {
                foreach(FasceOrarie fasciaOraria in FasceOrarie)
                {
                    if(fasciaOraria.Giorno == giorno)
                    {
                        fasceOrariePerGiorno.Add(fasciaOraria);

                    }
                }
                IEnumerable<DataLavorazioneEditViewModel> a = Enumerable.Empty<DataLavorazioneEditViewModel>().Append(new DataLavorazioneEditViewModel(giorno, fasceOrariePerGiorno));
                DateLavorazione = DateLavorazione.Concat(a);
            }
        }

        public IEnumerable<DataLavorazioneEditViewModel> GetDateLavorazione()
        {
            return DateLavorazione;
        }

        internal void SetOrariDipendenti(OrariNaveSelectDTO orariNaveSelectDTO)
        {
            var orariInizio = new int[] { 00, 06, 12, 18 };
            int i = 0;
            DateOnly giorno = new DateOnly();
            foreach (var orarioInizio in orariInizio)
            {
                
                if (i < orariNaveSelectDTO.Orari.Count())
                {
                    if(orariNaveSelectDTO.Orari.ElementAt(i) != null)
                    {
                        giorno = orariNaveSelectDTO.Orari.ElementAt(i++).Giorno;
                    }                
                }
                FasceOrarie.Add(new FasceOrarie
                {
                    Etichetta = orarioInizio + "-" + (orarioInizio + 6),
                    OrarioInizio = orarioInizio,
                    Orari = orariNaveSelectDTO.Orari.Where(x => x.Inizio.Hour == orarioInizio).Select(x => new OrarioDipendenteEditViewModel(x)).ToArray(),
                    Giorno = giorno
                });
            }
            //OrariDipendenti = orariNaveSelectDTO.Orari.Select(x => new OrarioDipendenteEditViewModel(x)).ToArray();
        }

        public IEnumerable<OrarioDipendenteEditViewModel> GetOrariDipendenti() 
        {
            return OrariDipendenti;
        }

        internal void setDipendentiDisponibili(IEnumerable<DipDisponibiliSelectDTO> dipendentiDisponibili)
        {
            foreach (DipDisponibiliSelectDTO dipDisponibiliGiorno in dipendentiDisponibili)
            {
                IEnumerable<DipendentiDisponibiliEditViewModel> a = Enumerable.Empty<DipendentiDisponibiliEditViewModel>().Append(new DipendentiDisponibiliEditViewModel(dipDisponibiliGiorno));
                DipendentiDisponibili = DipendentiDisponibili.Concat(a);
            }
        }

        public IEnumerable<DipendentiDisponibiliEditViewModel> GetDipendentiDisponibili()
        {
            return DipendentiDisponibili;
        }

        internal void setOrariIndexViewModel()
        {
            OrariIndexViewModel = new Orari.IndexViewModel();
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
    public class FasceOrarie
    {
        public string Etichetta { get; set; }
        public int OrarioInizio { get; set; }
        public IEnumerable<OrarioDipendenteEditViewModel> Orari { get; set; }
        public DateOnly Giorno { get; set; }
    }
    public class DataLavorazioneEditViewModel
    {
        public DataLavorazioneEditViewModel(DateOnly giorno, List<FasceOrarie> fasceOrarie)
        {
            this.Data = giorno;
            this.FasceOrarie = fasceOrarie;
        }

        public DateOnly Data { get; set; }
        public List<FasceOrarie> FasceOrarie { get; set; }
    }

    public class OrarioDipendenteEditViewModel
    {
        public OrarioDipendenteEditViewModel(OrariNaveSelectDTO.Orario orario)
        {
            this.Nome = orario.Nome;
            this.Cognome = orario.Cognome;
            this.Ruolo = orario.Ruolo;
            this.Giorno = orario.Giorno;
            this.Inizio = orario.Inizio;
        }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public DateOnly Giorno { get; set; }
        public TimeOnly Inizio { get; set; }
    }

    public class DipendentiDisponibiliEditViewModel
    {
        public DipendentiDisponibiliEditViewModel(DipDisponibiliSelectDTO dipDisponibili)
        {
            this.Numero = dipDisponibili.Disponibili;
        }

        public int Numero { get; set; }
    }
}