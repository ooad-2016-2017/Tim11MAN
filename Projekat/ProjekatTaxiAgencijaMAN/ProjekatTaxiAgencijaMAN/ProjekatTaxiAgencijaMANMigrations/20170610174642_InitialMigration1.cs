using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatTaxiAgencijaMANMigrations
{
    public partial class InitialMigration1 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropColumn(name: "KrajnjaLat", table: "Ruta");
            migration.DropColumn(name: "KrajnjaLong", table: "Ruta");
            migration.DropColumn(name: "OdredisnaLokacija", table: "Ruta");
            migration.DropColumn(name: "PolaznaLat", table: "Ruta");
            migration.DropColumn(name: "PolaznaLokacija", table: "Ruta");
            migration.DropColumn(name: "PolaznaLong", table: "Ruta");
            migration.DropColumn(name: "VrijemeZaPrevoz", table: "Narudzba");
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Zaposlenik",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "VoziloId",
                table: "Vozilo",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Vozac",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "VozacId",
                table: "Vozac",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Supervizor",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "Id",
                table: "Supervizor",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "RutaId",
                table: "Ruta",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "MusterijaId",
                table: "RegistrovanaMusterija",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "Id",
                table: "RegistrovanaMusterija",
                type: "INTEGER",
                nullable: false);
            //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "NarudzbaId",
                table: "Narudzba",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "MusterijaId",
                table: "Musterija",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "KompanijaId",
                table: "Kompanija",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Dispecer",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "Id",
                table: "Dispecer",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Zaposlenik",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "VoziloId",
                table: "Vozilo",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Vozac",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "VozacId",
                table: "Vozac",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Supervizor",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "Id",
                table: "Supervizor",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "RutaId",
                table: "Ruta",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AddColumn(
                name: "KrajnjaLat",
                table: "Ruta",
                type: "REAL",
                nullable: false,
                defaultValue: 0);
            migration.AddColumn(
                name: "KrajnjaLong",
                table: "Ruta",
                type: "REAL",
                nullable: false,
                defaultValue: 0);
            migration.AddColumn(
                name: "OdredisnaLokacija",
                table: "Ruta",
                type: "TEXT",
                nullable: true);
            migration.AddColumn(
                name: "PolaznaLat",
                table: "Ruta",
                type: "REAL",
                nullable: false,
                defaultValue: 0);
            migration.AddColumn(
                name: "PolaznaLokacija",
                table: "Ruta",
                type: "TEXT",
                nullable: true);
            migration.AddColumn(
                name: "PolaznaLong",
                table: "Ruta",
                type: "REAL",
                nullable: false,
                defaultValue: 0);
            migration.AlterColumn(
                name: "MusterijaId",
                table: "RegistrovanaMusterija",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "Id",
                table: "RegistrovanaMusterija",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "NarudzbaId",
                table: "Narudzba",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AddColumn(
                name: "VrijemeZaPrevoz",
                table: "Narudzba",
                type: "TEXT",
                nullable: false,
                defaultValue: new System.DateTime(1, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Unspecified));
            migration.AlterColumn(
                name: "MusterijaId",
                table: "Musterija",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "KompanijaId",
                table: "Kompanija",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ZaposlenikId",
                table: "Dispecer",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "Id",
                table: "Dispecer",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
        }
    }
}
