using System;

namespace AbstractFactory
{
    class Program
    {
        abstract class Yemek { }
        abstract class Tatli { }
        abstract class Restoran
        {
            public abstract Yemek YemekGetirr();
            public abstract Tatli TatliGetir();

        }

        class Kofte : Yemek { }
        class Kunefe : Tatli { }
        class YemekGetir : Restoran
        {
            public override Tatli TatliGetir()
            {
                return new Kunefe();
            }

            public override Yemek YemekGetirr()
            {
                return new Kofte();
            }
        }


        static void Main(string[] args)
        {
            Restoran restoran;
            restoran = new YemekGetir();
            var kofte = restoran.YemekGetirr();
            var kunefe = restoran.TatliGetir();
            Console.WriteLine("Yemeğimiz:" + kofte.GetType().Name);
            Console.WriteLine("Tatlımız:" + kunefe.GetType().Name);
            Console.ReadKey();
        }
    }
}
