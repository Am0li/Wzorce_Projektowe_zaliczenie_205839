using System;

namespace Decorator_205839
{
    internal class Program
    {
        class Podstawa
        {
            public virtual void oferta(int trasa)
            {
                Console.WriteLine("Cena trasy wyniesie: " + trasa);
            }
        }
        class Free:Podstawa
        {
            Podstawa p;
            public Free(Podstawa p)
            {
                this.p = p; 
            }
            public override void oferta(int trasa)
            {
                p.oferta(trasa);
                Console.WriteLine("reklama");
            }
        }
        class Small:Podstawa
        {
            Podstawa p;
            public Small(Podstawa p)
            {
                this.p = p;
            }
            public override void oferta(int trasa)
            {
                p.oferta(trasa);
                Console.WriteLine("Różni sie od średniej o "+trasa*0.5);
            }
        }
        class Big : Podstawa
        {
            Podstawa p;
            public Big(Podstawa p)
            {
                this.p = p;
            }
            public override void oferta(int trasa)
            {
                p.oferta(trasa);
                Console.WriteLine("cena za zoptymalizowaną trase wyniesie " + trasa * 0.8);
            }
        }
        class aplikacja
        {
            public void run()
            {
                Console.WriteLine("Podaj ilość kilometrów: ");
                int trasa = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("podaj typ subskrypcji F/S/E: ");
                switch(Console.ReadLine())
                {
                    case "F":
                        new Free(new Podstawa()).oferta(trasa);
                        break;
                    case "S":
                        new Small(new Podstawa()).oferta(trasa);
                        break;
                    case "E":
                        new Big(new Small(new Podstawa())).oferta(trasa);
                        break;
                }

            }
        }
        static void Main(string[] args)
        {
           new aplikacja().run();
        }
    }
}
