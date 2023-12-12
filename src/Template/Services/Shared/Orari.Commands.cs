using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Template.Services.Shared
{
    public class AddOrRemoveOrariCommand
    {
        public Guid CF { get; set; }
        public Guid NomeNave { get; set; }
        public Guid Inizio { get; set; }
        public Guid Fine { get; set; }
    }

    public partial class SharedService
    {
        public async void Handle(AddOrRemoveOrariCommand cmd)
        {
            var turno = await _dbContext.Orari
                .Where(x => x.CF == cmd.CF && x.NomeNave == cmd.NomeNave && x.Inizio == cmd.Inizio && x.Fine == cmd.Fine)
                .FirstOrDefaultAsync();

            if (turno == null)
            {
                turno = new Orari
                {
                    CF = cmd.CF,
                    NomeNave = cmd.NomeNave,
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