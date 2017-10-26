﻿using sklepInternetowy.DAL;
using sklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sklepInternetowy.Infrastructure
{
    public class KoszykManager
    {
        ISessionManager session;
        KursyContext db;

        public KoszykManager(ISessionManager session, KursyContext db)
        {
            this.session = session;
            this.db = db;
        }
        
        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;

            if(session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz) != null)
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz) as List<PozycjaKoszyka>;
            }
            else
            {
                koszyk = new List<PozycjaKoszyka>();
            }

            return koszyk;
        }

        public void DodajDoKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.kurs.KursId == kursId);

            if(pozycjaKoszyka != null)
            {
                pozycjaKoszyka.ilosc++;
            }
            else
            {
                var kursDoKoszyka = db.Kursy.Where(k => k.KursId == kursId).SingleOrDefault();
                if (kursDoKoszyka != null)
                {

                    pozycjaKoszyka = new PozycjaKoszyka()
                    {
                        kurs = kursDoKoszyka,
                        ilosc = 1,
                        wartosc = kursDoKoszyka.CenaKursu
                    };

                    koszyk.Add(pozycjaKoszyka);
                }
            }

            session.Set(Consts.KoszykSessionKlucz, koszyk);
        }

        public int UsunZKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.kurs.KursId == kursId);

            if(pozycjaKoszyka != null)
            {
                if(pozycjaKoszyka.ilosc > 1)
                {
                    pozycjaKoszyka.ilosc--;

                    return pozycjaKoszyka.ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            return 0;
        }

        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();

            return koszyk.Sum(k => (k.ilosc * k.kurs.CenaKursu));
        }

        public int pobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();

            return koszyk.Sum(k => k.ilosc);
        }
    }
}