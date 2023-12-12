using Template.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Template.Web.Areas.Example.Navi
{
    public class IndexViewModel : PagingViewModel
    {
        public IndexViewModel()
        {
            OrderBy = nameof(NaveIndexViewModel.Nome);
            OrderByDescending = false;
            Navi = Array.Empty<NaveIndexViewModel>();
        }

        [Display(Name = "Cerca")]
        public string Filter { get; set; }

        public IEnumerable<NaveIndexViewModel> Navi { get; set; }

        internal void SetNavi(NaviIndexDTO naviIndexDTO)
        {
            Navi = naviIndexDTO.Navi.Select(x => new NaveIndexViewModel(x)).ToArray();
            TotalItems = naviIndexDTO.Count;
        }

        public NaviIndexQuery ToNaviIndexQuery()
        {
            return new NaviIndexQuery
            {
                Filter = Filter,
                Paging = new Template.Infrastructure.Paging
                {
                    OrderBy = OrderBy,
                    OrderByDescending = OrderByDescending,
                    Page = Page,
                    PageSize = PageSize
                }
            };
        }

        public override IActionResult GetRoute() => MVC.Example.Navi.Index(this).GetAwaiter().GetResult();

        public string OrderbyUrl<TProperty>(IUrlHelper url, System.Linq.Expressions.Expression<Func<NaveIndexViewModel, TProperty>> expression) => base.OrderbyUrl(url, expression);

        public string OrderbyCss<TProperty>(HttpContext context, System.Linq.Expressions.Expression<Func<NaveIndexViewModel, TProperty>> expression) => base.OrderbyCss(context, expression);

        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
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
