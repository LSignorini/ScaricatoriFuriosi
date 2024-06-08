using System;
using System.Collections.Generic;
using System.Linq;
using Template.Services.Shared;

namespace Template.Web.Areas.Example.Orari
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            FasceOrarie = new List<FasceOrarie>();
        }

        public List<FasceOrarie> FasceOrarie { get; set; }

        public NaveDetailDTO Nave { get; set; }

        public DateOnly Giorno { get; set; }

        public DipendentePerRuoloDTO[] DipendentiLiberi { get; set; }

        internal void SetOrari(OrariNaveSelectDTO orariIndexDTO)
        {
            var orariInizio = new int[] {00, 06, 12, 18}; 
            foreach(var orarioInizio in orariInizio)
            {
                FasceOrarie.Add(new FasceOrarie
                {
                    Etichetta = orarioInizio + " " + (orarioInizio + 6),
                    OrarioInizio = orarioInizio,
                    Orari = orariIndexDTO.Orari.Where(x => x.Inizio.Hour == orarioInizio).Select(x => new OrarioIndexViewModel(x)).ToArray()
                });
            }
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

        public AddOrRemoveOrariCommand ToAddOrarioCommand(Guid idDipendente, TimeOnly inizio, Guid idNave, DateOnly giorno)
        {
            TimeOnly fine = inizio.Add(new TimeSpan(6, 0, 0));

            return new AddOrRemoveOrariCommand
            {
                IdDipendente = idDipendente,
                IdNave = idNave,
                Giorno = giorno,
                Inizio = inizio,
                Fine = fine
            };
        }

        public AddOrRemoveOrariCommand ToAddOrarioCommand(Guid idOrario)
        {
            return new AddOrRemoveOrariCommand
            {
                Id = idOrario
            };
        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }
    }

    public class FasceOrarie
    {
        public string Etichetta { get; set; }
        public int OrarioInizio { get; set; }
        public IEnumerable<OrarioIndexViewModel> Orari { get; set; }
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
