using Template.Services.Shared;
using System;
using System.Linq;
using Template.Services;

namespace Template.Infrastructure
{
    public class DataGenerator
    {
        public static void InitializeUsers(TemplateDbContext context)
        {
            if (context.Users.Any())
            {
                return;   // Data was already seeded
            }

            context.Users.AddRange(
                new User
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Email = "email1@test.it",
                    Password = "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=", // SHA-256 of text "Prova"
                    FirstName = "Nome1",
                    LastName = "Cognome1",
                    NickName = "Nickname1"
                },
                new User
                {
                    Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), // Forced to specific Guid for tests
                    Email = "email2@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    FirstName = "Nome2",
                    LastName = "Cognome2",
                    NickName = "Nickname2"
                },
                new User
                {
                    Id = Guid.Parse("bfdef48b-c7ea-4227-8333-c635af267354"), // Forced to specific Guid for tests
                    Email = "email3@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    FirstName = "Nome3",
                    LastName = "Cognome3",
                    NickName = "Nickname3"
                });

            context.SaveChanges();
        }

        public static void InitializeDipendenti(TemplateDbContext context)
        {
            if (context.Dipendenti.Any())
            {
                return;   // Data was already seeded
            }

            context.Dipendenti.AddRange(
                new Dipendente
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    CF = "CQGSVT83L26F839S",
                    Nome = "Salvatore",
                    Cognome = "Acquagrana",
                    Ruolo = "Mulettista",
                    DataNascita = new DateTime(1983, 07, 26),
                    VisitaMedica = new DateTime(2024, 12, 12),
                    Patente = new DateTime(2024, 12, 25)
                },
                new Dipendente
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    CF = "GMRCCC89H11H501G",
                    Nome = "Ciccio",
                    Cognome = "Gamer",
                    Ruolo = "Operatore Gru",
                    DataNascita = new DateTime(1989, 06, 11),
                    VisitaMedica = new DateTime(2023, 12, 12),
                    Patente = new DateTime(2024, 11, 01)
                },
                new Dipendente
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    CF = "RRBTZI62B28E466R",
                    Nome = "Tizio",
                    Cognome = "Arrabbiato",
                    Ruolo = "Manovalanza",
                    DataNascita = new DateTime(1962, 02, 28),
                    VisitaMedica = new DateTime(2026, 09, 11),
                    Patente = new DateTime(2023, 11, 23)
                },
                new Dipendente
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    CF = "BZZLDA99D28D643X",
                    Nome = "Aldo",
                    Cognome = "Bazzo",
                    Ruolo = "Mulettista",
                    DataNascita = new DateTime(1999, 04, 28),
                    VisitaMedica = new DateTime(2026, 05, 13),
                    Patente = new DateTime(2028, 12, 31)
                },
                new Dipendente
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    CF = "MTTSRG76A06D612Q",
                    Nome = "Sergio",
                    Cognome = "Mattarello",
                    Ruolo = "Operatore Gru",
                    DataNascita = new DateTime(1976, 01, 06),
                    VisitaMedica = new DateTime(2025, 03, 16),
                    Patente = new DateTime(2030, 10, 21)
                },
                new Dipendente
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    CF = "RSSBNT94P12D704L",
                    Nome = "Benito",
                    Cognome = "Rosso",
                    Ruolo = "Manovalanza",
                    DataNascita = new DateTime(1994, 09, 12),
                    VisitaMedica = new DateTime(2029, 05, 04),
                    Patente = new DateTime(2032, 01, 19)
                });

            context.SaveChanges();
        }

        public static void InitializeNavi(TemplateDbContext context)
        {
            if (context.Navi.Any())
            {
                return;   // Data was already seeded
            }

            context.Navi.AddRange(
                new Nave
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Nome = "Fenice",
                    NomeCliente = "Hanse Yachts",
                    Arrivo = new DateTime(2024, 01, 26),
                    Partenza = new DateTime(2024, 01, 28),
                    Container = 3,
                    Bancali = 12
                },
                new Nave
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Nome = "Sibilla",
                    NomeCliente = "Nautitech",
                    Arrivo = new DateTime(2024, 03, 10),
                    Partenza = new DateTime(2024, 03, 12),
                    Container = 8,
                    Bancali = 2
                },
                new Nave
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Nome = "Totano",
                    NomeCliente = "Baltic",
                    Arrivo = new DateTime(2024, 03, 12),
                    Partenza = new DateTime(2024, 03, 19),
                    Container = 4,
                    Bancali = 9
                },
                new Nave
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Nome = "Orione",
                    NomeCliente = "Vismara",
                    Arrivo = new DateTime(2024, 04, 04),
                    Partenza = new DateTime(2024, 04, 11),
                    Container = 6,
                    Bancali = 18
                },
                new Nave
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Nome = "Chioggia",
                    NomeCliente = "Jeanneau",
                    Arrivo = new DateTime(2024, 02, 13),
                    Partenza = new DateTime(2024, 02, 17),
                    Container = 17,
                    Bancali = 0
                },
                new Nave
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Nome = "Jennifer",
                    NomeCliente = "Aniston",
                    Arrivo = new DateTime(2024, 01, 12),
                    Partenza = new DateTime(2024, 01, 18),
                    Container = 0,
                    Bancali = 35
                });

            context.SaveChanges();
        }

        public static void InitializeOrari(TemplateDbContext context)
        {
            if (context.Orari.Any())
            {
                return;   // Data was already seeded
            }

            context.Orari.AddRange(
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 01, 26),
                    Inizio = new TimeOnly(12, 0, 0),
                    Fine = new TimeOnly(18, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 01, 26),
                    Inizio = new TimeOnly(12, 0, 0),
                    Fine = new TimeOnly(18, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 03, 10),
                    Inizio = new TimeOnly(18, 0, 0),
                    Fine = new TimeOnly(24, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 03, 12),
                    Inizio = new TimeOnly(00, 0, 0),
                    Fine = new TimeOnly(06, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 04, 04),
                    Inizio = new TimeOnly(12, 0, 0),
                    Fine = new TimeOnly(18, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 04, 04),
                    Inizio = new TimeOnly(18, 0, 0),
                    Fine = new TimeOnly(24, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 02, 13),
                    Inizio = new TimeOnly(06, 0, 0),
                    Fine = new TimeOnly(12, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 01, 12),
                    Inizio = new TimeOnly(00, 0, 0),
                    Fine = new TimeOnly(06, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    IdNave = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Giorno = new DateOnly(2024, 01, 12),
                    Inizio = new TimeOnly(00, 0, 0),
                    Fine = new TimeOnly(06, 0, 0)
                });

            context.SaveChanges();
        }
    }
}