using System;
using System.Collections.Generic;

namespace ObserverDesignPattern
{
    class Program
    {
        interface IMarket
        {
            void Update(Urun urun);
        }
        abstract class Urun
        {
            private double fiyat;
            List<IMarket> marketler = new List<IMarket>();
            public Urun(double _fiyat)
            {
                fiyat = _fiyat;

            }

            public void ekle(IMarket market)
            {
                marketler.Add(market);
            }
            public void cikar(IMarket market)
            {
                marketler.Remove(market);
            }

            public void Bildirim()
            {
                foreach (IMarket market in marketler)
                {
                    market.Update(this);
                }
                Console.WriteLine("");


            }
            public double yenifiyat
            {
                get { return fiyat; }
                set
                {
                    if(fiyat!=value)
                    {
                        fiyat = value;
                        Bildirim();
                    }
                }
            }



        }
        class market : IMarket
        {
            private string _urunad;
            private double fiyat;
            public market(string urunad,double _fiyat)
            {
                fiyat = _fiyat;
                _urunad = urunad;
            }



            public void Update(Urun urun)
            {
                Console.WriteLine("Bildirim:" + _urunad + " deki" + urun.GetType().Name + " ' nın fiyatı " + urun.yenifiyat
                    + " olarak değişmiştir.");
            }
        }
        class Kola : Urun
        {
            public Kola(double fiyat) : base(fiyat) { }

        }

        static void Main(string[] args)
        {
            Kola kola = new Kola(2);
            kola.ekle(new market("Market1", 1));
            kola.ekle(new market("Market2", 2));
            kola.ekle(new market("Market3", 3));
            kola.yenifiyat = 4;
            kola.yenifiyat = 5;
            kola.yenifiyat = 6;
            kola.yenifiyat = 1;
            Console.ReadKey();
        }
    }
}
