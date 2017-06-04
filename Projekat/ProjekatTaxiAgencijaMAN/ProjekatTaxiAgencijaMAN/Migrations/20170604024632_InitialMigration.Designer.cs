using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatTaxiAgencijaMAN.Modeli;

namespace ProjekatTaxiAgencijaMANMigrations
{
    [ContextType(typeof(TaxiDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20170604024632_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Dispecer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojTelefona");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<int>("ZaposlenikId")
                        .ValueGeneratedOnAdd();

                    b.Key("Id");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Kompanija", b =>
                {
                    b.Property<int>("KompanijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdresaKompanije");

                    b.Property<int>("BrojTelefona");

                    b.Property<DateTime>("DatumOsnivanja");

                    b.Property<string>("EmailKompanije");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("NazivKompanije");

                    b.Property<string>("Sifra");

                    b.Key("KompanijaId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Musterija", b =>
                {
                    b.Property<int>("MusterijaId")
                        .ValueGeneratedOnAdd();

                    b.Key("MusterijaId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumPrevoza");

                    b.Property<string>("Napomene");

                    b.Property<int?>("NarucilacMusterijaId");

                    b.Property<int?>("RutaRutaId");

                    b.Property<DateTime>("VrijemeZaPrevoz");

                    b.Property<int?>("ZaduzeniVozacId");

                    b.Key("NarudzbaId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.RegistrovanaMusterija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojTelefona");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("EmailAdresa");

                    b.Property<string>("ImeKorisnika");

                    b.Property<string>("KorisnickoIme");

                    b.Property<int>("MusterijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("PrezimeKorisnika");

                    b.Key("Id");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Ruta", b =>
                {
                    b.Property<int>("RutaId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("DuzinaRute");

                    b.Property<double>("KrajnjaLat");

                    b.Property<double>("KrajnjaLong");

                    b.Property<string>("OdredisnaLokacija");

                    b.Property<double>("PolaznaLat");

                    b.Property<string>("PolaznaLokacija");

                    b.Property<double>("PolaznaLong");

                    b.Property<double>("ProcjenjenoVrijeme");

                    b.Key("RutaId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Supervizor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojTelefona");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<int>("ZaposlenikId")
                        .ValueGeneratedOnAdd();

                    b.Key("Id");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Vozac", b =>
                {
                    b.Property<int>("VozacId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojTelefona");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<bool>("Slobodan");

                    b.Property<int?>("VoziloVoziloId");

                    b.Property<int>("ZaposlenikId")
                        .ValueGeneratedOnAdd();

                    b.Key("VozacId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Vozilo", b =>
                {
                    b.Property<int>("VoziloId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GodisteVozila");

                    b.Property<double>("Predjenikilometri");

                    b.Property<string>("RegistracijskeTablice");

                    b.Property<string>("VrstaVozila");

                    b.Key("VoziloId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Zaposlenik", b =>
                {
                    b.Property<int>("ZaposlenikId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojTelefona");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<string>("Ime");

                    b.Property<int?>("KompanijaKompanijaId");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Key("ZaposlenikId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Narudzba", b =>
                {
                    b.Reference("ProjekatTaxiAgencijaMAN.Modeli.Musterija")
                        .InverseCollection()
                        .ForeignKey("NarucilacMusterijaId");

                    b.Reference("ProjekatTaxiAgencijaMAN.Modeli.Ruta")
                        .InverseCollection()
                        .ForeignKey("RutaRutaId");

                    b.Reference("ProjekatTaxiAgencijaMAN.Modeli.Vozac")
                        .InverseCollection()
                        .ForeignKey("ZaduzeniVozacId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Vozac", b =>
                {
                    b.Reference("ProjekatTaxiAgencijaMAN.Modeli.Vozilo")
                        .InverseCollection()
                        .ForeignKey("VoziloVoziloId");
                });

            builder.Entity("ProjekatTaxiAgencijaMAN.Modeli.Zaposlenik", b =>
                {
                    b.Reference("ProjekatTaxiAgencijaMAN.Modeli.Kompanija")
                        .InverseCollection()
                        .ForeignKey("KompanijaKompanijaId");
                });
        }
    }
}
