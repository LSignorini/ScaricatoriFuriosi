using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Services.Shared
{
    public class DipendentiNomeSelectQuery
    {
        public Guid IdCurrentDipendente { get; set; }
        public string Filter { get; set; }
    }

    public class DipendentiNomeSelectDTO
    {
        public IEnumerable<DipendenteNome> Dipendenti { get; set; }
        public int Count { get; set; }

        public class DipendenteNome
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
        }
        public class DipendenteRuolo
        {
            public Guid Id { get; set; }
            public string Ruolo { get; set; }
        }
    }
    public class DipendentiCognomeSelectQuery
    {
        public Guid IdCurrentDipendente { get; set; }
        public string Filter { get; set; }
    }
    public class DipendentiCognomeSelectDTO
    {
        public IEnumerable<DipendenteCognome> Dipendenti { get; set; }
        public int Count { get; set; }

        public class DipendenteCognome
        {
            public Guid Id { get; set; }
            public string Cognome { get; set; }
        }
    }
    public class DipendentiRuoloSelectQuery
    {
        public Guid IdCurrentDipendente { get; set; }
        public string Filter { get; set; }
    }
    public class DipendentiRuoloSelectDTO
    {
        public IEnumerable<DipendenteRuolo> Dipendenti { get; set; }
        public int Count { get; set; }

        public class DipendenteRuolo
        {
            public Guid Id { get; set; }
            public string Ruolo { get; set; }
        }
    }

    public class DipendentiIndexQuery
    {
        public Guid IdCurrentDipendente { get; set; }
        public string Filter { get; set; }
        //public Paging Paging { get; set; }
    }

    public class DipendentiIndexDTO
    {
        public IEnumerable<Dipendente> Dipendenti { get; set; }

        public class Dipendente
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string Ruolo { get; set; }
            public DateOnly VisitaMedica { get; set; }
            public DateOnly Patente { get; set; }
        }
    }

    public class DipendenteDetailQuery
    {
        public Guid Id { get; set; }
    }

    public class DipendenteDetailDTO
    {
        public Guid Id { get; set; }
        public string CF { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public DateOnly DataNascita { get; set; }
        public DateOnly VisitaMedica { get; set; }
        public DateOnly Patente { get; set; }
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
                .Where(x => x.Id != qry.IdCurrentDipendente);

            if (string.IsNullOrWhiteSpace(qry.Filter) == false)
            {
                queryable = queryable.Where(x => x.Nome.Contains(qry.Filter, StringComparison.OrdinalIgnoreCase));
            }

            return new DipendentiNomeSelectDTO
            {
                Dipendenti = await queryable
                .Select(x => new DipendentiNomeSelectDTO.DipendenteNome
                {
                    Id = x.Id,
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
                .Where(x => x.Id != qry.IdCurrentDipendente);

            if (string.IsNullOrWhiteSpace(qry.Filter) == false)
            {
                queryable = queryable.Where(x => x.Cognome.Contains(qry.Filter, StringComparison.OrdinalIgnoreCase));
            }

            return new DipendentiCognomeSelectDTO
            {
                Dipendenti = await queryable
                .Select(x => new DipendentiCognomeSelectDTO.DipendenteCognome
                {
                    Id = x.Id,
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
                .Where(x => x.Id != qry.IdCurrentDipendente);

            if (string.IsNullOrWhiteSpace(qry.Filter) == false)
            {
                queryable = queryable.Where(x => x.Ruolo.Contains(qry.Filter, StringComparison.OrdinalIgnoreCase));
            }

            return new DipendentiRuoloSelectDTO
            {
                Dipendenti = await queryable
                .Select(x => new DipendentiRuoloSelectDTO.DipendenteRuolo
                {
                    Id = x.Id,
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
                    .OrderBy(x => x.Nome).ThenBy(x=> x.Cognome)
                    .Select(x => new DipendentiIndexDTO.Dipendente
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Cognome = x.Cognome,
                        Ruolo = x.Ruolo,
                        VisitaMedica = x.VisitaMedica,
                        Patente = x.Patente
                    })
                    .ToArrayAsync(),
            };
        }

        /// <summary>
        /// Returns the detail of the dipendente who matches the Id passed in the qry parameter
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<DipendenteDetailDTO> Query(DipendenteDetailQuery qry)
        {
            return await _dbContext.Dipendenti
                .Where(x => x.Id == qry.Id)
                .Select(x => new DipendenteDetailDTO
                {
                    Id = x.Id,
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
