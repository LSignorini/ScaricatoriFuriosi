using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;

namespace Template.Web.Areas.Example.Navi
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Navi = Array.Empty<NaveIndexViewModel>();
            Arrivi = Array.Empty<ArriviIndexViewModel>();
        }

        [Display(Name = "Cerca")]
        public string Filter { get; set; }

        public IEnumerable<NaveIndexViewModel> Navi { get; set; }

        internal void SetNavi(NaviIndexDTO naviIndexDTO)
        {
            Navi = naviIndexDTO.Navi.Select(x => new NaveIndexViewModel(x)).ToArray();
        }

        public NaviIndexQuery ToNaviIndexQuery()
        {
            return new NaviIndexQuery
            {
                Filter = Filter
            };
        }

        public IEnumerable<ArriviIndexViewModel> Arrivi { get; set; }

        internal void SetArrivi(ArriviDTO arriviDTO)
        {
            Arrivi = arriviDTO.Arrivi.Select(x => new ArriviIndexViewModel(x)).ToArray();
        }
    }

    public class NaveIndexViewModel
    {
        public NaveIndexViewModel(NaviIndexDTO.Nave naveIndexDTO)
        {
            this.Id = naveIndexDTO.Id;
            this.Nome = naveIndexDTO.Nome;
            this.NomeCliente = naveIndexDTO.NomeCliente;
            this.Arrivo = naveIndexDTO.Arrivo;
            this.Partenza = naveIndexDTO.Partenza;
            this.Container = naveIndexDTO.Container;
            this.Bancali = naveIndexDTO.Bancali;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public int Container { get; set; }
        public int Bancali { get; set; }
    }

    public class ArriviIndexViewModel
    {
        public ArriviIndexViewModel(ArriviDTO.Arrivo arriviDTO)
        {
            this.Arrivo = arriviDTO.Data;
        }
        
        public DateTime Arrivo { get; set; }
    }
}
