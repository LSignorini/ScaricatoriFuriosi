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
    }

    public class NaveIndexViewModel
    {
        public NaveIndexViewModel(NaviIndexDTO.Nave naveIndexDTO)
        {
            this.Nome = naveIndexDTO.Nome;
            this.NomeCliente = naveIndexDTO.NomeCliente;
            this.Arrivo = naveIndexDTO.Arrivo;
            this.Partenza = naveIndexDTO.Partenza;
            this.Container = naveIndexDTO.Container;
            this.Bancali = naveIndexDTO.Bancali;
        }

        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public int Container { get; set; }
        public int Bancali { get; set; }
    }
}
