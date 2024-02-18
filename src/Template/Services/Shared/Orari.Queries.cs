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

    public class OrariIndexQuery
    {
        public Guid IdNave { get; set; }
        public DateOnly Giorno { get; set; }
        public string Filter { get; set; }
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
                    orari => orari.IdDipendente,
                    dipendente => dipendente.Id,
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
                .Where(o => o.IdDipendente == qry.Id); // Filtra per id del dipendente

            var result = await queryable
                .Join(
                    _dbContext.Navi,
                    orari => orari.IdNave,
                    navi => navi.Id,
                    (orari, navi) => new
                    {
                        Orario = orari,
                        Nave = navi
                    })
                .Select(x => new OrariDipendenteSelectDTO.Orario
                {
                    NomeNave = x.Nave.Nome,
                    Giorno = x.Orario.Giorno,
                    Inizio = x.Orario.Inizio,
                    Fine = x.Orario.Fine
                })
                .OrderBy(x => x.Giorno)
                .ToArrayAsync();

            return new OrariDipendenteSelectDTO
            {
                Orari = result
            };
        }


        /// <summary>
        /// Returns schedules for ship name and day
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<OrariNaveSelectDTO> Query(OrariIndexQuery qry)
        {
            var queryable = _dbContext.Orari
                .Where(x => x.IdNave == qry.IdNave && x.Giorno == qry.Giorno);

            return new OrariNaveSelectDTO
            {
                Orari = await queryable
                .Join(
                    _dbContext.Dipendenti,
                    orari => orari.IdDipendente,
                    dipendente => dipendente.Id,
                    (orari, dipendente) => new
                    {
                        Orario = orari,
                        Dipendente = dipendente
                    })
                .Select(x => new OrariNaveSelectDTO.Orario
                {
                    Nome = x.Dipendente.Nome,
                    Cognome = x.Dipendente.Cognome,
                    Ruolo = x.Dipendente.Ruolo,
                    Inizio = x.Orario.Inizio
                })
                .ToArrayAsync()
            };
        }
    }
}
