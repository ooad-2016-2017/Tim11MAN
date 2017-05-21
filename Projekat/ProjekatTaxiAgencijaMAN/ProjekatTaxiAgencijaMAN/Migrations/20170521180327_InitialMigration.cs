using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatTaxiAgencijaMANMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Kompanija",
                columns: table => new
                {
                    KompanijaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    AdresaKompanije = table.Column(type: "TEXT", nullable: true),
                    BrojTelefona = table.Column(type: "INTEGER", nullable: false),
                    DatumOsnivanja = table.Column(type: "TEXT", nullable: false),
                    EmailKompanije = table.Column(type: "TEXT", nullable: true),
                    KorisnickoIme = table.Column(type: "TEXT", nullable: true),
                    NazivKompanije = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanija", x => x.KompanijaId);
                });
            migration.CreateTable(
                name: "Musterija",
                columns: table => new
                {
                    MusterijaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musterija", x => x.MusterijaId);
                });
            migration.CreateTable(
                name: "Ruta",
                columns: table => new
                {
                    RutaId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    DuzinaRute = table.Column(type: "REAL", nullable: false),
                    KrajnjaLat = table.Column(type: "REAL", nullable: false),
                    KrajnjaLong = table.Column(type: "REAL", nullable: false),
                    OdredisnaLokacija = table.Column(type: "TEXT", nullable: true),
                    PolaznaLat = table.Column(type: "REAL", nullable: false),
                    PolaznaLokacija = table.Column(type: "TEXT", nullable: true),
                    PolaznaLong = table.Column(type: "REAL", nullable: false),
                    ProcjenjenoVrijeme = table.Column(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruta", x => x.RutaId);
                });
            migration.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    VoziloId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    BrojVozila = table.Column(type: "TEXT", nullable: true),
                    GodisteVozila = table.Column(type: "INTEGER", nullable: false),
                    Predjenikilometri = table.Column(type: "REAL", nullable: false),
                    RegistracijskeTablice = table.Column(type: "TEXT", nullable: true),
                    VrstaVozila = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.VoziloId);
                });
            migration.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    ZaposlenikId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    BrojTelefona = table.Column(type: "TEXT", nullable: true),
                    DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                    DatumZaposlenja = table.Column(type: "TEXT", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    KompanijaKompanijaId = table.Column(type: "INTEGER", nullable: true),
                    KorisnickoIme = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.ZaposlenikId);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Kompanija_KompanijaKompanijaId",
                        columns: x => x.KompanijaKompanijaId,
                        referencedTable: "Kompanija",
                        referencedColumn: "KompanijaId");
                });
            migration.CreateTable(
                name: "Vozac",
                columns: table => new
                {
                    VozacId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    BrojTelefona = table.Column(type: "TEXT", nullable: true),
                    DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                    DatumZaposlenja = table.Column(type: "TEXT", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    KorisnickoIme = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Slobodan = table.Column(type: "INTEGER", nullable: false),
                    VoziloVoziloId = table.Column(type: "INTEGER", nullable: true),
                    ZaposlenikId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozac", x => x.VozacId);
                    table.ForeignKey(
                        name: "FK_Vozac_Vozilo_VoziloVoziloId",
                        columns: x => x.VoziloVoziloId,
                        referencedTable: "Vozilo",
                        referencedColumn: "VoziloId");
                });
            migration.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    DatumPrevoza = table.Column(type: "TEXT", nullable: false),
                    Napomene = table.Column(type: "TEXT", nullable: true),
                    NarucilacMusterijaId = table.Column(type: "INTEGER", nullable: true),
                    RutaRutaId = table.Column(type: "INTEGER", nullable: true),
                    VrijemeZaPrevoz = table.Column(type: "TEXT", nullable: false),
                    ZaduzeniVozacId = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Musterija_NarucilacMusterijaId",
                        columns: x => x.NarucilacMusterijaId,
                        referencedTable: "Musterija",
                        referencedColumn: "MusterijaId");
                    table.ForeignKey(
                        name: "FK_Narudzba_Ruta_RutaRutaId",
                        columns: x => x.RutaRutaId,
                        referencedTable: "Ruta",
                        referencedColumn: "RutaId");
                    table.ForeignKey(
                        name: "FK_Narudzba_Vozac_ZaduzeniVozacId",
                        columns: x => x.ZaduzeniVozacId,
                        referencedTable: "Vozac",
                        referencedColumn: "VozacId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Narudzba");
            migration.DropTable("Zaposlenik");
            migration.DropTable("Musterija");
            migration.DropTable("Ruta");
            migration.DropTable("Vozac");
            migration.DropTable("Kompanija");
            migration.DropTable("Vozilo");
        }
    }
}
