using Template.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Services.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Template.Web.Areas.Example.Dipendenti
{
    public class IndexViewModel : PagingViewModel
    {
        public IndexViewModel()
        {
            OrderBy = nameof(DipendenteIndexViewModel.Email);
            OrderByDescending = false;
            Dipendenti = Array.Empty<DipendenteIndexViewModel>();
        }

        [Display(Name = "Cerca")]
        public string Filter { get; set; }

        public IEnumerable<DipendenteIndexViewModel> Dipendenti { get; set; }

        internal void SetDipendenti(DipendentiIndexDTO dipendentiIndexDTO)
        {
            Dipendenti = dipendentiIndexDTO.Dipendenti.Select(x => new DipendenteIndexViewModel(x)).ToArray();
            TotalItems = dipendentiIndexDTO.Count;
        }

        public DipendentiIndexQuery ToDipendentiIndexQuery()
        {
            return new DipendentiIndexQuery
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

        public override IActionResult GetRoute() => MVC.Example.Dipendenti.Index(this).GetAwaiter().GetResult();

        public string OrderbyUrl<TProperty>(IUrlHelper url, System.Linq.Expressions.Expression<Func<DipendenteIndexViewModel, TProperty>> expression) => base.OrderbyUrl(url, expression);

        public string OrderbyCss<TProperty>(HttpContext context, System.Linq.Expressions.Expression<Func<DipendenteIndexViewModel, TProperty>> expression) => base.OrderbyCss(context, expression);

        public string ToJson()
        {
            return JsonSerializer.ToJsonCamelCase(this);
        }
    }

    public class DipendenteIndexViewModel
    {
        public DipendenteIndexViewModel(DipendentiIndexDTO.Dipendente dipendenteIndexDTO)
        {
            this.Id = dipendenteIndexDTO.Id;
            this.Email = dipendenteIndexDTO.Email;
            this.FirstName = dipendenteIndexDTO.FirstName;
            this.LastName = dipendenteIndexDTO.LastName;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
