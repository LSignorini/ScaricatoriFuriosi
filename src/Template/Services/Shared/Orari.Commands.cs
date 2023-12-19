using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Template.Services.Shared
{
    public class AddOrRemoveOrariCommand
    {
        public Guid Id { get; set; }
        public string CF { get; set; }
        public string NomeNave { get; set; }
        public DateOnly Giorno { get; set; }
        public TimeOnly Inizio { get; set; }
        public TimeOnly Fine { get; set; }
    }

    public partial class SharedService
    {
        public async void Handle(AddOrRemoveOrariCommand cmd)
        {
            var turno = await _dbContext.Orari
                .Where(x => x.CF == cmd.CF && x.NomeNave == cmd.NomeNave && x.Giorno == cmd.Giorno)
                .FirstOrDefaultAsync();

            if (turno == null)
            {
                turno = new Orari
                {
                    CF = cmd.CF,
                    NomeNave = cmd.NomeNave,
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