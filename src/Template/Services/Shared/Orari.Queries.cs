using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Services.Shared
{
    public class NomeNaveDetailQuery
    {
        public Guid Id { get; set; }
    }
    public class OrariNaveSelectDTO
    {
        public IEnumerable<Orario> Orari { get; set; }

        public class Orario
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string Ruolo { get; set; }
            public DateOnly Giorno { get; set; }
            public TimeOnly Inizio { get; set; }
        }
    }
    
    public class GiornoSelectQuery
    {
        public DateTime Giorno { get; set; }
    }
   
    public class DipDisponibiliSelectDTO
    {
        public int Disponibili { get; set; }
    }

    public class NomeDipendenteDetailQuery
    {
        public Guid Id { get; set; }
    }

    public class OrariDipendenteSelectDTO
    {
        public IEnumerable<Orario> Orari { get; set; }

        public class Orario
        {
            public Guid Id { get; set; }
            public string NomeNave { get; set; }
            public DateOnly Giorno { get; set; }
            public TimeOnly Inizio { get; set; }
            public TimeOnly Fine { get; set; }
        }
    }

    public partial class SharedService
    {
        /// <summary>
        /// Returns schedules for a select ship with names
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<OrariNaveSelectDTO> Query(NomeNaveDetailQuery qry)
        {
            var queryable = _dbContext.Orari
                .Where(o => o.Id == qry.Id); // Filtra per id della nave

            var result = await queryable
                .Join(
                    _dbContext.Dipendenti,
                    orari => orari.CF,
                    dipendente => dipendente.CF,
                    (orari, dipendente) => new
                    {
                        Orario = orari,
                        Dipendente = dipendente
                    })
                .Select(x => new OrariNaveSelectDTO.Orario
                {
                    Id = x.Orario.Id,
                    Nome = x.Dipendente.Nome,
                    Cognome = x.Dipendente.Cognome,
                    Ruolo = x.Dipendente.Ruolo,
                    Giorno = x.Orario.Giorno,
                    Inizio = x.Orario.Inizio
                })
                .ToArrayAsync();

            return new OrariNaveSelectDTO
            {
                Orari = result
            };
        }

        /// <summary>
        /// Returns workers available for a given day
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<DipDisponibiliSelectDTO> Query(GiornoSelectQuery qry)
        {
            var dipendentiTotali = await _dbContext.Dipendenti
                .CountAsync();

            var dipendentiOccupati = await _dbContext.Orari
                .Where(x => x.Giorno.Equals(qry.Giorno))
                .Distinct()
                .CountAsync();

            return new DipDisponibiliSelectDTO
            {
                Disponibili = dipendentiTotali - dipendentiOccupati
            };
        }

        /// <summary>
        /// Returns schedules for a given worker
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<OrariDipendenteSelectDTO> Query(NomeDipendenteDetailQuery qry)
        {
            var queryable = _dbContext.Orari
                .Where(o => o.Id == qry.Id); // Filtra per id del dipendente

            var result = await queryable
                .Select(x => new OrariDipendenteSelectDTO.Orario
                {
                    NomeNave = x.NomeNave,
                    Giorno = x.Giorno,
                    Inizio = x.Inizio,
                    Fine = x.Fine
                })
                .ToArrayAsync();

            return new OrariDipendenteSelectDTO
            {
                Orari = result
            };
        }
    }
}
