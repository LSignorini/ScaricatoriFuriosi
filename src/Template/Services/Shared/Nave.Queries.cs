using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Template.Infrastructure;

namespace Template.Services.Shared
{
    public class NaviSelectQuery
    {
        public Guid IdCurrentNave { get; set; }
        public string Filter { get; set; }
    }

    public class NaviSelectDTO
    {
        public IEnumerable<Nave> Navi { get; set; }
        public int Count { get; set; }

        public class Nave
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string NomeCliente { get; set; }
            public DateTime Arrivo { get; set; }
            public DateTime Partenza { get; set; }
        }
    }

    public class ClienteSelectQuery
    {
        public string NomeClienteCurrentNave { get; set; }
        public string Filter { get; set; }
    }

    public class ClienteSelectDTO
    {
        public IEnumerable<Nave> Navi { get; set; }
        public int Count { get; set; }

        public class Nave
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string NomeCliente { get; set; }
            public DateTime Arrivo { get; set; }
            public DateTime Partenza { get; set; }
        }
    }
    public class NaviIndexQuery
    {
        public string Filter { get; set; }
        public string Tipologia { get; set; }
    }

    public class NaviIndexDTO
    {
        public IEnumerable<Nave> Navi { get; set; }
        public int Count { get; set; }

        public class Nave
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string NomeCliente { get; set; }
            public DateTime Arrivo { get; set; }
            public DateTime Partenza { get; set; }
            public int Container { get; set; }
            public int Bancali { get; set; }
        }
    }

    public class NaveDetailQuery
    {
        public Guid Id { get; set; }
    }

    public class NaveDetailDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public int Container {  get; set; }
        public int Bancali { get; set; }
    }

    public class ArriviDTO
    {
        public IEnumerable<Arrivo> Arrivi { get; set; }
        public class Arrivo
        {
            public DateOnly Data { get; set; }
        }
    }

    public partial class SharedService
    {
        /// <summary>
        /// Returns Navi for name field
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<NaviSelectDTO> Query(NaviSelectQuery qry)
        {
            var queryable = _dbContext.Navi
                .Where(x => x.Id != qry.IdCurrentNave);

            return new NaviSelectDTO
            {
                Navi = await queryable
                .Select(x => new NaviSelectDTO.Nave
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    NomeCliente = x.NomeCliente,
                    Arrivo = x.Arrivo,
                    Partenza = x.Partenza
                })
                .ToArrayAsync(),
                Count = await queryable.CountAsync(),
            };
        }

        /// <summary>
        /// Returns Navi for client name field
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<ClienteSelectDTO> Query(ClienteSelectQuery qry)
        {
            var queryable = _dbContext.Navi
                .Where(x => x.NomeCliente != qry.NomeClienteCurrentNave);

            return new ClienteSelectDTO
            {
                Navi = await queryable
                .Select(x => new ClienteSelectDTO.Nave
                {
                    Nome = x.Nome,
                    NomeCliente = x.NomeCliente,
                    Arrivo = x.Arrivo,
                    Partenza = x.Partenza
                })
                .ToArrayAsync(),
                Count = await queryable.CountAsync(),
            };
        }

        /// <summary>
        /// Returns ships for ships page
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<NaviIndexDTO> Query(NaviIndexQuery qry)
        {
            var queryable = _dbContext.Navi.AsQueryable();
            if (string.IsNullOrWhiteSpace(qry.Filter) == false)
            {
                var filtri = qry.Filter.Split(" ");
                foreach (var filtro in filtri.Where(x => x.Length > 0))
                {
                    // metti tutti i campi per cui vuoi cercare
                    queryable = queryable.Where(x => x.Nome.Contains(filtro, StringComparison.OrdinalIgnoreCase) 
                                                    || x.NomeCliente.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (string.IsNullOrWhiteSpace(qry.Tipologia) == false)
            {
                if (qry.Tipologia != "Tutte")
                {
                    var soglia = DateTime.Now.AddDays(7);
                    queryable = queryable.Where(x => x.Partenza <= soglia && x.Partenza >= DateTime.Now);
                }
            }

            return new NaviIndexDTO
            {
                Navi = await queryable
                    .Select(x => new NaviIndexDTO.Nave
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        NomeCliente = x.NomeCliente,
                        Arrivo = x.Arrivo,
                        Partenza = x.Partenza
                    })
                    .ToArrayAsync(),
                Count = await queryable.CountAsync()
            };
        }

        /// <summary>
        /// Returns the detail of the ship who matches the id passed in the qry parameter
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<NaveDetailDTO> Query(NaveDetailQuery qry)
        {
            return await _dbContext.Navi
                .Where(x => x.Id == qry.Id)
                .Select(x => new NaveDetailDTO
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    NomeCliente = x.NomeCliente,
                    Arrivo = x.Arrivo,
                    Partenza = x.Partenza,
                    Container = x.Container,
                    Bancali = x.Bancali
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns a list of all day with an arrive
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<ArriviDTO> Query()
        {
            var queryable = _dbContext.Navi;

            return new ArriviDTO
            {
                Arrivi = await queryable
                .Select(x => new ArriviDTO.Arrivo
                {
                    Data = new DateOnly(x.Arrivo.Year, x.Arrivo.Month, x.Arrivo.Day) 
                })
                .Distinct()
                .ToArrayAsync()
            };
        }
    }
}
