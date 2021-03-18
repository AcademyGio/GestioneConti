using System;
using System.IO;

namespace GestioneConti
{
    class Program
    {
        private static Banca banca = new Banca();    // la banca che viene gestita dalla mia applicazione

        static void Main(string[] args)
        {
            Console.WriteLine("Gestione conti");

            do
            {
                Console.WriteLine();
                Console.WriteLine("a. Crea conto");
                Console.WriteLine("b. Versamento");
                Console.WriteLine("c. Prelievo");
                Console.WriteLine("d. Estinzione conto");
                Console.WriteLine("e. Saldo");
                Console.WriteLine("f. Saldo totale di tutti i conti");
                Console.WriteLine("g. Visualizza prospetto completo");
                Console.WriteLine("h. Salva");
                Console.WriteLine("i. Serializza");
                Console.WriteLine("J. Deserializza");
                Console.WriteLine("x. Esci");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        CreaConto();
                        break;
                    case ConsoleKey.B:
                        Versamento();
                        break;
                    case ConsoleKey.C:
                        Prelievo();
                        break;
                    case ConsoleKey.D:
                        Estinzione();
                        break;
                    case ConsoleKey.E:
                        VisualizzaSaldo();
                        break;
                    case ConsoleKey.F:
                        VisualizzaSaldoTotale();
                        break;
                    case ConsoleKey.G:
                        VisualizzaProspetto();
                        break;
                    case ConsoleKey.H:
                        Salva();
                        break;
                    case ConsoleKey.I:
                        Serializza();
                        break;
                    case ConsoleKey.J:
                        Deserializza();
                        break;
                    case ConsoleKey.X:
                        return;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (true);
        }

        private static void Estinzione()
        {
            Console.WriteLine();
            int id;
            do
                Console.Write("Numero di conto da estinguere: ");
            while (!int.TryParse(Console.ReadLine(), out id));

            if (banca.Esiste(id))
                banca.Estingui(id);
            else
                Console.WriteLine("Conto inesistente");
        }

        private static void Prelievo()
        {
            Console.WriteLine();
            int id;
            do
                Console.Write("Numero di conto da cui prelevare: ");
            while (!int.TryParse(Console.ReadLine(), out id));

            if (banca.Esiste(id))
            {
                decimal importo;
                do
                    Console.Write("Importo da prelevare: ");
                while (!decimal.TryParse(Console.ReadLine(), out importo));

                banca.Preleva(id, importo);
            }
            else
                Console.WriteLine("Conto inesistente");
        }

        private static void Deserializza()
        {
            const string fileName = @"conti.bin";    // @ - verbatim string

            banca.Deserializza(fileName);
        }

        private static void Serializza()
        {
            const string fileName = @"conti.bin";    // @ - verbatim string

            banca.Serializza(fileName);
        }

        private static void Salva()
        {
            const string fileName = @"conti.csv";    // @ - verbatim string
            Formato formato = Formato.CSV;  // chiedi all'utente il formato

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(banca.OttieniProspetto(formato));
                // utitlizzo sw

                // sw.Close();
                // alla fine del blocco using l'oggetto sw verrà correttamente rilasciato
            }
        }

        private static void VisualizzaSaldoTotale()
        {
            Console.WriteLine();
            Console.WriteLine($"Il saldo totale è {banca.SaldoTotale}");
        }

        private static void VisualizzaSaldo()
        {
            Console.WriteLine();
            int id;
            do
                Console.Write("Numero di conto di cui visualizzare il saldo: ");
            while (!int.TryParse(Console.ReadLine(), out id));

            if (banca.Esiste(id))
                Console.WriteLine($"Saldo del conto {id}: {banca.OttieniSaldo(id)}");
        }
        private static void VisualizzaProspetto()
        {
            Console.WriteLine();
            Console.WriteLine("Prospetto completo dei conti esistenti");
            Console.WriteLine(banca.OttieniProspetto(Formato.Plain));
        }

        private static void Versamento()
        {
            Console.WriteLine();
            int id;
            do
                Console.Write("Numero di conto su cui versare: ");
            while (!int.TryParse(Console.ReadLine(), out id));

            if (banca.Esiste(id))
            {
                decimal importo;
                do
                    Console.Write("Importo da versare: ");
                while (!decimal.TryParse(Console.ReadLine(), out importo));

                banca.Versa(id, importo);
            }
            else
                Console.WriteLine("Conto inesistente");
        }

        private static void CreaConto()
        {
            Console.WriteLine();
            Console.Write("Nome dell'intestatario: ");
            Conto c = banca.CreaConto(Console.ReadLine());
            Console.WriteLine($"Conto {c.ID} creato per {c.Intestatario}");
        }
    }
}
