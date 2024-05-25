using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Template.Services.Shared
{
    public class AddOrRemoveOrariCommand
    {
        public Guid Id { get; set; }
        public Guid IdDipendente { get; set; }
        public Guid IdNave { get; set; }
        public DateOnly Giorno { get; set; }
        public TimeOnly Inizio { get; set; }
        public TimeOnly Fine { get; set; }
    }

    public partial class SharedService
    {
        public async void Handle(AddOrRemoveOrariCommand cmd)
        {
            var turno = await _dbContext.Orari
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (turno == null)
            {
                turno = new Orari
                {
                    Id = Guid.NewGuid(),
                    IdDipendente = cmd.IdDipendente,
                    IdNave = cmd.IdNave,
                    Giorno = cmd.Giorno,
                    Inizio = cmd.Inizio,
                    Fine = cmd.Fine
                };
                _dbContext.Orari.Add(turno);
            } 
            else
            {
                _dbContext.Orari.Remove(turno);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}