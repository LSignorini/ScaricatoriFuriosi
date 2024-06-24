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
                    Id = Guid.Parse("d3e932bf-c083-45f1-9a93-12c67d8ae67b"), // Forced to specific Guid for tests
                    CF = "CQGSVT83L26F839S",
                    Nome = "Salvatore",
                    Cognome = "Acquagrana",
                    Ruolo = "Mulettista",
                    DataNascita = new DateOnly(1983, 07, 26),
                    VisitaMedica = new DateOnly(2024, 12, 12),
                    Patente = new DateOnly(2024, 12, 25)
                },
                new Dipendente
                {
                    Id = Guid.Parse("6424df69-7fe6-4df3-ad7e-360ea3736c1e"), // Forced to specific Guid for tests
                    CF = "GMRCCC89H11H501G",
                    Nome = "Ciccio",
                    Cognome = "Gamer",
                    Ruolo = "Operatore Gru",
                    DataNascita = new DateOnly(1989, 06, 11),
                    VisitaMedica = new DateOnly(2023, 12, 12),
                    Patente = new DateOnly(2024, 11, 01)
                },
                new Dipendente
                {
                    Id = Guid.Parse("2a7c1d72-73c2-48af-bb45-fa3f7e40a410"), // Forced to specific Guid for tests
                    CF = "RRBTZI62B28E466R",
                    Nome = "Tizio",
                    Cognome = "Arrabbiato",
                    Ruolo = "Manovalanza",
                    DataNascita = new DateOnly(1962, 02, 28),
                    VisitaMedica = new DateOnly(2026, 09, 11),
                    Patente = new DateOnly(2023, 11, 23)
                },
                new Dipendente
                {
                    Id = Guid.Parse("e35a87f6-8418-46d3-8497-331c89fdb6eb"), // Forced to specific Guid for tests
                    CF = "BZZLDA99D28D643X",
                    Nome = "Aldo",
                    Cognome = "Bazzo",
                    Ruolo = "Mulettista",
                    DataNascita = new DateOnly(1999, 04, 28),
                    VisitaMedica = new DateOnly(2026, 05, 13),
                    Patente = new DateOnly(2028, 12, 31)
                },
                new Dipendente
                {
                    Id = Guid.Parse("d9dabff4-e63d-4c66-abd7-b4c4d8a861fc"), // Forced to specific Guid for tests
                    CF = "MTTSRG76A06D612Q",
                    Nome = "Sergio",
                    Cognome = "Mattarello",
                    Ruolo = "Operatore Gru",
                    DataNascita = new DateOnly(1976, 01, 06),
                    VisitaMedica = new DateOnly(2025, 03, 16),
                    Patente = new DateOnly(2030, 10, 21)
                },
                new Dipendente
                {
                    Id = Guid.Parse("264990fa-81ab-471d-ac73-858d29408f20"), // Forced to specific Guid for tests
                    CF = "RSSBNT94P12D704L",
                    Nome = "Benito",
                    Cognome = "Rosso",
                    Ruolo = "Manovalanza",
                    DataNascita = new DateOnly(1994, 09, 12),
                    VisitaMedica = new DateOnly(2029, 05, 04),
                    Patente = new DateOnly(2032, 01, 19)
                },
                new Dipendente
                {
                    Id = Guid.Parse("31fb4d9c-bb2a-4d0a-90b8-68d70bc5da8e"), // Forced to specific Guid for tests
                    CF = "SPFNTL90P12D704L",
                    Nome = "Superfluo",
                    Cognome = "Inutile",
                    Ruolo = "Manovalanza",
                    DataNascita = new DateOnly(1990, 09, 12),
                    VisitaMedica = new DateOnly(2027, 05, 18),
                    Patente = new DateOnly(2028, 06, 19)
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
                    Id = Guid.Parse("cfcea22c-dda5-42a5-8216-9ae740edad9e"), // Forced to specific Guid for tests
                    Nome = "Fenice",
                    NomeCliente = "Hanse Yachts",
                    Arrivo = new DateTime(2024, 09, 26, 6, 0, 0),
                    Partenza = new DateTime(2024, 09, 28, 6, 0, 0),
                    Container = 3,
                    Bancali = 12
                },
                new Nave
                {
                    Id = Guid.Parse("b2c265ef-bc64-49e2-a44a-a0f4e3f4dadd"), // Forced to specific Guid for tests
                    Nome = "Sibilla",
                    NomeCliente = "Nautitech",
                    Arrivo = new DateTime(2024, 11, 10, 18, 0, 0),
                    Partenza = new DateTime(2024, 11, 12, 0, 0, 0),
                    Container = 8,
                    Bancali = 2
                },
                new Nave
                {
                    Id = Guid.Parse("a47fcf2b-793c-4e50-9f46-93236622e737"), // Forced to specific Guid for tests
                    Nome = "Totano",
                    NomeCliente = "Baltic",
                    Arrivo = new DateTime(2024, 11, 12, 0, 0, 0),
                    Partenza = new DateTime(2024, 11, 19, 12, 0, 0),
                    Container = 4,
                    Bancali = 9
                },
                new Nave
                {
                    Id = Guid.Parse("d3ede598-24ed-461b-a9b1-5fc2ac0b8ed7"), // Forced to specific Guid for tests
                    Nome = "Orione",
                    NomeCliente = "Vismara",
                    Arrivo = new DateTime(2024, 12, 04, 6, 0, 0),
                    Partenza = new DateTime(2024, 12, 11, 14, 0, 0),
                    Container = 6,
                    Bancali = 18
                },
                new Nave
                {
                    Id = Guid.Parse("49b6f5b8-94d5-47c5-8678-f5eec15da617"), // Forced to specific Guid for tests
                    Nome = "Chioggia",
                    NomeCliente = "Jeanneau",
                     Arrivo = new DateTime(2024, 07, 12, 0, 0, 0),
                    Partenza = new DateTime(2024, 08, 17, 20, 0, 0),
                    Container = 17,
                    Bancali = 0
                },
                new Nave
                {
                    Id = Guid.Parse("be0693bc-0655-4ec1-99e6-9ff2e35dd9f8"), // Forced to specific Guid for tests
                    Nome = "Jennifer",
                    NomeCliente = "Aniston",
                    Arrivo = new DateTime(2024, 07, 12, 0, 0, 0),
                    Partenza = new DateTime(2024, 07, 18, 0, 0, 0),
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
                    Id = Guid.Parse("f1edcedc-c283-41e1-a426-26cfd8f0f957"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("d3e932bf-c083-45f1-9a93-12c67d8ae67b"),
                    IdNave = Guid.Parse("cfcea22c-dda5-42a5-8216-9ae740edad9e"),
                    Giorno = new DateOnly(2024, 09, 26),
                    Inizio = new TimeOnly(12, 0, 0),
                    Fine = new TimeOnly(18, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("18194d96-9c1c-4410-8117-ef7ec51aba1f"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("6424df69-7fe6-4df3-ad7e-360ea3736c1e"),
                    IdNave = Guid.Parse("cfcea22c-dda5-42a5-8216-9ae740edad9e"),
                    Giorno = new DateOnly(2024, 09, 26),
                    Inizio = new TimeOnly(12, 0, 0),
                    Fine = new TimeOnly(18, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("9500823b-e0ac-4aed-a9bb-2b26c9754bcf"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("d3e932bf-c083-45f1-9a93-12c67d8ae67b"),
                    IdNave = Guid.Parse("b2c265ef-bc64-49e2-a44a-a0f4e3f4dadd"),
                    Giorno = new DateOnly(2024, 11, 10),
                    Inizio = new TimeOnly(18, 0, 0),
                    Fine = new TimeOnly(0, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3caeb0a5-2df4-4e1e-80c5-14c2d43be0b9"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("6424df69-7fe6-4df3-ad7e-360ea3736c1e"),
                    IdNave = Guid.Parse("a47fcf2b-793c-4e50-9f46-93236622e737"),
                    Giorno = new DateOnly(2024, 11, 12),
                    Inizio = new TimeOnly(0, 0, 0),
                    Fine = new TimeOnly(6, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("cd61aa20-38fd-41d4-8b7a-0c66c7d3f720"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("2a7c1d72-73c2-48af-bb45-fa3f7e40a410"),
                    IdNave = Guid.Parse("d3ede598-24ed-461b-a9b1-5fc2ac0b8ed7"),
                    Giorno = new DateOnly(2024, 12, 04),
                    Inizio = new TimeOnly(12, 0, 0),
                    Fine = new TimeOnly(18, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("851d6b9b-d276-4400-a926-dec65861a274"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("2a7c1d72-73c2-48af-bb45-fa3f7e40a410"), //ricambia
                    IdNave = Guid.Parse("d3ede598-24ed-461b-a9b1-5fc2ac0b8ed7"),
                    Giorno = new DateOnly(2024, 12, 05),
                    Inizio = new TimeOnly(18, 0, 0),
                    Fine = new TimeOnly(0, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("4f271b81-3661-4499-bd86-3fbc36e26445"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("2a7c1d72-73c2-48af-bb45-fa3f7e40a410"),
                    IdNave = Guid.Parse("49b6f5b8-94d5-47c5-8678-f5eec15da617"),
                    Giorno = new DateOnly(2024, 08, 13),
                    Inizio = new TimeOnly(6, 0, 0),
                    Fine = new TimeOnly(12, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("8ed30246-0d02-4473-9569-535b4cb04c0f"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("d9dabff4-e63d-4c66-abd7-b4c4d8a861fc"),
                    IdNave = Guid.Parse("be0693bc-0655-4ec1-99e6-9ff2e35dd9f8"),
                    Giorno = new DateOnly(2024, 07, 12),
                    Inizio = new TimeOnly(0, 0, 0),
                    Fine = new TimeOnly(6, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("3944a7c2-85cd-4c9e-8b70-20cfa246aff5"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("264990fa-81ab-471d-ac73-858d29408f20"),
                    IdNave = Guid.Parse("be0693bc-0655-4ec1-99e6-9ff2e35dd9f8"),
                    Giorno = new DateOnly(2024, 07, 12),
                    Inizio = new TimeOnly(0, 0, 0),
                    Fine = new TimeOnly(6, 0, 0)
                },
                new Orari
                {
                    Id = Guid.Parse("e22c13f1-25a1-41d6-b1c9-e1bd2c638dbc"), // Forced to specific Guid for tests
                    IdDipendente = Guid.Parse("2a7c1d72-73c2-48af-bb45-fa3f7e40a410"),
                    IdNave = Guid.Parse("be0693bc-0655-4ec1-99e6-9ff2e35dd9f8"),
                    Giorno = new DateOnly(2024, 07, 12),
                    Inizio = new TimeOnly(6, 0, 0),
                    Fine = new TimeOnly(12, 0, 0)
                });

            context.SaveChanges();
        }
    }
}