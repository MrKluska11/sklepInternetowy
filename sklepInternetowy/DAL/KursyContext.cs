using sklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace sklepInternetowy.DAL
{
    public class KursyContext : DbContext 
    {
        public KursyContext() : base("KursyContext") { } 

        /*static KursyContext()
        {
            Database.SetInitializer<KursyContext>(new KursyInitializer2());
        } */

        public DbSet<Kurs> Kursy { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }

        //dzięki tej metodzie przy nazwach tabel nie jest dodawana na końcu litera "s"
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}