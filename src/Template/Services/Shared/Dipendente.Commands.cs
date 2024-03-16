using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Services.Shared
{
    public class UpdateDipendentiCommand
    {
        public Guid? Id { get; set; }
        public string CF { get; set; }
        public DateOnly VisitaMedica { get; set; }
        public DateOnly Patente { get; set; }
    }

    public partial class SharedService
    {
        public async Task<Guid> Handle(UpdateDipendentiCommand cmd)
        {
            var turno = await _dbContext.Dipendenti
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            turno.VisitaMedica = cmd.VisitaMedica;
            turno.Patente = cmd.Patente;

            await _dbContext.SaveChangesAsync();
            return turno.Id;
        }
    }
}