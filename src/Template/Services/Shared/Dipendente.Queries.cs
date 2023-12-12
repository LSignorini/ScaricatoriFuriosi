using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Template.Infrastructure;

namespace Template.Services.Shared
{
    public class DipendentiNomeSelectQuery
    {
        public Guid CFCurrentDipendente { get; set; }
        public string Filter { get; set; }
    }

    public class DipendentiNomeSelectDTO
    {
        public IEnumerable<DipendenteNome> Dipendenti { get; set; }
        public int Count { get; set; }

        public class DipendenteNome
        {
            public Guid CF { get; set; }
            public string Nome { get; set; }
        }
        public class DipendenteRuolo
        {
            public Guid CF { get; set; }
            public string Ruolo { get; set; }
        }
    }
    public class DipendentiCognomeSelectQuery
    {
        public Guid CFCurrentDipendente { get; set; }
        public string Filter { get; set; }
    }
    public class DipendentiCognomeSelectDTO
    {
        public IEnumerable<DipendenteCognome> Dipendenti { get; set; }
        public int Count { get; set; }

        public class DipendenteCognome
        {
            public Guid CF { get; set; }
            public string Cognome { get; set; }
        }
    }
    public class DipendentiRuoloSelectQuery
    {
        public Guid CFCurrentDipendente { get; set; }
        public string Filter { get; set; }
    }
    public class DipendentiRuoloSelectDTO
    {
        public IEnumerable<DipendenteRuolo> Dipendenti { get; set; }
        public int Count { get; set; }

        public class DipendenteRuolo
        {
            public Guid CF { get; set; }
            public string Ruolo { get; set; }
        }
    }

    public class DipendentiIndexQuery
    {
        public Guid IdCurrentDipendente { get; set; }
        public string Filter { get; set; }
    }

    public class DipendentiIndexDTO
    {
        public IEnumerable<Dipendente> Dipendenti { get; set; }
        public int Count { get; set; }

        public class Dipendente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string Ruolo { get; set; }
            public DateTime VisitaMedica { get; set; }
            public DateTime Patente { get; set; }
        }
    }

    public class DipendenteDetailQuery
    {
        public Guid CF { get; set; }
    }

    public class DipendenteDetailDTO
    {
        public Guid CF { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public DateTime DataNascita { get; set; }
        public DateTime VisitaMedica { get; set; }
        public DateTime Patente { get; set; }
    }

    public partial class SharedService
    {
        /// <summary>
        /// Returns dipendenti for name field
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<DipendentiNomeSelectDTO> Query(DipendentiNomeSelectQuery qry)
        {
            var queryable = _dbContext.Dipendenti
                .Where(x => x.CF != qry.CFCurrentDipendente);

            if (string.IsNullOrWhiteSpace(qry.Filter) == false)
            {
                queryable = queryable.Where(x => x.Nome.Contains(qry.Filter, StringComparison.OrdinalIgnoreCase));
            }

            return new DipendentiNomeSelectDTO
            {
                Dipendenti = await queryable
                .Select(x => new DipendentiNomeSelectDTO.DipendenteNome
                {
                    CF = x.CF,
                    Nome = x.Nome
                })
                .ToArrayAsync(),
                Count = await queryable.CountAsync(),
            };
        }

        /// <summary>
        /// Returns dipendenti for surname field
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<DipendentiCognomeSelectDTO> Query(DipendentiCognomeSelectQuery qry)
        {
            var queryable = _dbContext.Dipendenti
                .Where(x => x.CF != qry.CFCurrentDipendente);

            if (string.IsNullOrWhiteSpace(qry.Filter) == false)
            {
                queryable = queryable.Where(x => x.Cognome.Contains(qry.Filter, StringComparison.OrdinalIgnoreCase));
            }

            return new DipendentiCognomeSelectDTO
            {
                Dipendenti = await queryable
                .Select(x => new DipendentiCognomeSelectDTO.DipendenteCognome
                {
                    CF = x.CF,
                    Cognome = x.Cognome
                })
                .ToArrayAsync(),
                Count = await queryable.CountAsync(),
            };
        }

        /// <summary>
        /// Returns dipendenti for role field
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<DipendentiRuoloSelectDTO> Query(DipendentiRuoloSelectQuery qry)
        {
            var queryable = _dbContext.Dipendenti
                .Where(x => x.CF != qry.CFCurrentDipendente);

            if (string.IsNullOrWhiteSpace(qry.Filter) == false)
            {
                queryable = queryable.Where(x => x.Ruolo.Contains(qry.Filter, StringComparison.OrdinalIgnoreCase));
            }

            return new DipendentiRuoloSelectDTO
            {
                Dipendenti = await queryable
                .Select(x => new DipendentiRuoloSelectDTO.DipendenteRuolo
                {
                    CF = x.CF,
                    Ruolo = x.Ruolo
                })
                .ToArrayAsync(),
                Count = await queryable.CountAsync(),
            };
        }

        /// <summary>
        /// Returns dipendenti for dipendenti page
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<DipendentiIndexDTO> Query(DipendentiIndexQuery qry)
        {
            var queryable = _dbContext.Dipendenti;

            return new DipendentiIndexDTO
            {
                Dipendenti = await queryable
                    .Select(x => new DipendentiIndexDTO.Dipendente
                    {
                        Nome = x.Nome,
                        Cognome = x.Cognome,
                        Ruolo = x.Ruolo,
                        VisitaMedica = x.VisitaMedica,
                        Patente = x.Patente
                    })
                    .ToArrayAsync(),
                Count = await queryable.CountAsync()
            };
        }

        /// <summary>
        /// Returns the detail of the dipendente who matches the CF passed in the qry parameter
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<DipendenteDetailDTO> Query(DipendenteDetailQuery qry)
        {
            return await _dbContext.Dipendenti
                .Where(x => x.CF == qry.CF)
                .Select(x => new DipendenteDetailDTO
                {
                    CF = x.CF,
                    Nome = x.Nome,
                    Cognome = x.Cognome,
                    Ruolo = x.Ruolo,
                    DataNascita = x.DataNascita,
                    VisitaMedica = x.VisitaMedica,
                    Patente = x.Patente
                })
                .FirstOrDefaultAsync();
        }
    }
}
