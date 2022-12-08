using Microsoft.EntityFrameworkCore;
using WorldCupAPI.Models;

namespace WorldCupAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<WorldCup> WorldCups { get; set; }
        public DbSet<WorldCupCountry> WorldCupCountries { get; set; }
        public DbSet<WorldCupCountryPlayer> WorldCupCountryPlayers { get; set; }
        // public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Many to Many WorldCupCountry
            builder.Entity<WorldCupCountry>().HasKey(wcc =>
                new { wcc.WorldCupId, wcc.CountryId  }
            );
            builder.Entity<WorldCupCountry>()
                .HasOne(wcc => wcc.WorldCup)
                .WithMany(wc => wc.Countries)
                .HasForeignKey(wcc => wcc.WorldCupId);
            builder.Entity<WorldCupCountry>()
                .HasOne(wcc => wcc.Country)
                .WithMany(c => c.WorldCups)
                .HasForeignKey(wcc => wcc.CountryId);
            #endregion

            #region Many to Many WorldCupCountryPlayer
            builder.Entity<WorldCupCountryPlayer>().HasKey(wccp =>
                new { wccp.WorldCupId, wccp.CountryId, wccp.PlayerId }
            );
            builder.Entity<WorldCupCountryPlayer>()
                .HasOne(wccp => wccp.WorldCup)
                .WithMany(wc => wc.WorldCupPlayers)
                .HasForeignKey(wccp => wccp.WorldCupId);
            builder.Entity<WorldCupCountryPlayer>()
                .HasOne(wccp => wccp.Country)
                .WithMany(c => c.WorldCupPlayers)
                .HasForeignKey(wccp => wccp.CountryId);
            builder.Entity<WorldCupCountryPlayer>()
                .HasOne(wccp => wccp.Player)
                .WithMany(p => p.WorldCupPlayers)
                .HasForeignKey(wccp => wccp.PlayerId);
            #endregion
        
            #region Seed Country
            List<Country> countries = new(){
                new Country{
                    Id = 1,
                    Name = "Qatar",
                    Flag = "https://flagpedia.net/data/flags/w580/qa.webp"
                },
                new Country{
                    Id = 2,
                    Name = "Equador",
                    Flag = "https://flagpedia.net/data/flags/w580/ec.webp"
                },
                new Country{
                    Id = 3,
                    Name = "Senegal",
                    Flag = "https://flagpedia.net/data/flags/w580/sn.webp"
                },
                new Country{
                    Id = 4,
                    Name = "Holanda",
                    Flag = "https://flagpedia.net/data/flags/w580/nl.png"
                },
                new Country{
                    Id = 5,
                    Name = "Inglaterra",
                    Flag = "https://flagpedia.net/data/flags/w580/gb-eng.png"
                },
                new Country{
                    Id = 6,
                    Name = "Irã",
                    Flag = "https://flagpedia.net/data/flags/w580/ir.webp"
                },
                new Country{
                    Id = 7,
                    Name = "EUA",
                    Flag = "https://flagpedia.net/data/flags/w580/us.webp"
                },
                new Country{
                    Id = 8,
                    Name = "País de Gales",
                    Flag = "https://flagpedia.net/data/flags/w580/gb-wls.webp"
                },
                new Country{
                    Id = 9,
                    Name = "Argentina",
                    Flag = "https://flagpedia.net/data/flags/w580/ar.webp"
                },
                new Country{
                    Id = 10,
                    Name = "Arábia Saudita",
                    Flag = "https://flagpedia.net/data/flags/w580/sa.webp"
                },
                new Country{
                    Id = 11,
                    Name = "México",
                    Flag = "https://flagpedia.net/data/flags/w580/mx.webp"
                },
                new Country{
                    Id = 12,
                    Name = "Polônia",
                    Flag = "https://flagpedia.net/data/flags/w580/pl.png"
                },
                new Country{
                    Id = 13,
                    Name = "França",
                    Flag = "https://flagpedia.net/data/flags/w580/fr.png"
                },new Country{
                    Id = 14,
                    Name = "Austrália",
                    Flag = "https://flagpedia.net/data/flags/w580/au.webp"
                },
                new Country{
                    Id = 15,
                    Name = "Dinamarca",
                    Flag = "https://flagpedia.net/data/flags/w580/dk.webp"
                },
                new Country{
                    Id = 16,
                    Name = "Tunísia",
                    Flag = "https://flagpedia.net/data/flags/w580/tn.webp"
                },
                new Country{
                    Id = 17,
                    Name = "Espanha",
                    Flag = "https://flagpedia.net/data/flags/w580/es.webp"
                },
                new Country{
                    Id = 18,
                    Name = "Costa Rica",
                    Flag = "https://flagpedia.net/data/flags/w580/cr.webp"
                },
                new Country{
                    Id = 19,
                    Name = "Alemanha",
                    Flag = "https://flagpedia.net/data/flags/w580/de.png"
                },
                new Country{
                    Id = 20,
                    Name = "Japão",
                    Flag = "https://flagpedia.net/data/flags/w580/jp.webp"
                },
                new Country{
                    Id = 21,
                    Name = "Bélgica",
                    Flag = "https://flagpedia.net/data/flags/w580/be.png"
                },
                new Country{
                    Id = 22,
                    Name = "Canadá",
                    Flag = "https://flagpedia.net/data/flags/w580/ca.webp"
                },
                new Country{
                    Id = 23,
                    Name = "Marrocos",
                    Flag = "https://flagpedia.net/data/flags/w580/ma.webp"
                },
                new Country{
                    Id = 24,
                    Name = "Croácia",
                    Flag = "https://flagpedia.net/data/flags/w580/hr.webp"
                },
                new Country{
                    Id = 25,
                    Name = "Brasil",
                    Flag = "https://flagpedia.net/data/flags/w580/br.webp"
                },
                new Country{
                    Id = 26,
                    Name = "Sérvia",
                    Flag = "https://flagpedia.net/data/flags/w580/rs.webp"
                },
                new Country{
                    Id = 27,
                    Name = "Suíça",
                    Flag = "https://flagpedia.net/data/flags/w580/ch.png"
                },
                new Country{
                    Id = 28,
                    Name = "Camarões",
                    Flag = "https://flagpedia.net/data/flags/w580/cm.webp"
                },
                new Country{
                    Id = 29,
                    Name = "Portugal",
                    Flag = "https://flagpedia.net/data/flags/w580/pt.webp"
                },
                new Country{
                    Id = 30,
                    Name = "Gana",
                    Flag = "https://flagpedia.net/data/flags/w580/gh.webp"
                },
                new Country{
                    Id = 31,
                    Name = "Uruguai",
                    Flag = "https://flagpedia.net/data/flags/w580/uy.webp"
                },
                new Country{
                    Id = 32,
                    Name = "Coreia do Sul",
                    Flag = "https://flagpedia.net/data/flags/w580/kr.webp"
                }
            };
            builder.Entity<Country>().HasData(countries);
            #endregion
        
            #region Seed WorldCup
            builder.Entity<WorldCup>().HasData(
                new WorldCup {
                    Id = 1,
                    CountryId = 1,
                    Year = 2022
                }
            );
            #endregion    
        
            #region Seed WorldCupCountry
            List<WorldCupCountry> worldCupCountries = new();
            string[] groups = {"A", "B", "C", "D", "E", "F", "G", "H", "I" };
            int groupIndex = 0;
            foreach (var country in countries)
            {
                worldCupCountries.Add(
                    new WorldCupCountry()
                    {
                        WorldCupId = 1,
                        CountryId = country.Id,
                        Group = groups[groupIndex]
                    }
                );
                if (country.Id % 4 == 0)
                    groupIndex += 1;
            }
            builder.Entity<WorldCupCountry>().HasData(worldCupCountries);
            #endregion
        }
    }
}