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
                Console.WriteLine("1. Crea conto");
                Console.WriteLine("2. Versamento");
                Console.WriteLine("3. Prelievo");
                Console.WriteLine("4. Estinzione conto");
                Console.WriteLine("5. Saldo");
                Console.WriteLine("6. Saldo totale di tutti i conti");
                Console.WriteLine("7. Visualizza prospetto completo");
                Console.WriteLine("8. Salva");
                Console.WriteLine("0. Esci");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        CreaConto();
                        break;
                    case '2':
                        Versamento();
                        break;
                    case '3':
                        // Prelievo
                        break;
                    case '4':
                        // Estinzione
                        break;
                    case '5':
                        VisualizzaSaldo();
                        break;
                    case '6':
                        VisualizzaSaldoTotale();
                        break;
                    case '7':
                        VisualizzaProspetto();
                        break;
                    case '8':
                        Salva();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (true);
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
