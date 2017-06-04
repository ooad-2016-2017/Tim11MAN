using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ProjekatTaxiAgencijaMAN.Modeli
{
    class TaxiDbContext : DbContext
    {
        public DbSet<Vozilo> vozila { get; set; }
        public DbSet<Narudzba> narudzbe { get; set; }
        public DbSet<Musterija> musterije { get; set; }
        public DbSet<Zaposlenik> zaposlenici { get; set; }
        public DbSet<Kompanija> kompanije { get; set; }
        public DbSet<Vozac> vozaci { get; set; }
        public DbSet<RegistrovanaMusterija> regMusterije { get; set; }
        public DbSet<Dispecer> dispeceri { get; set; }
        public DbSet<Supervizor> supervizor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "ProjekatTaxiAgencijaMAN.db";
            try
            {
                //za tačnu putanju gdje se nalazi baza uraditi ovdje debug i procitati Path
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
                databaseFilePath);
            }
            catch (InvalidOperationException) { }
            //Sqlite baza
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }


    }
}
