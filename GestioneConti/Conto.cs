using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneConti
{
    class Conto
    {
        private static int _ID;
        public int ID { get; }
        public string Intestatario { get; } // con tutti i discorsi fatti
        public decimal Saldo { get; private set;}

        public string Prospetto
        {
            get
            {
                return $"Conto: {ID}, Intestatario: {Intestatario}, Saldo: {Saldo}";
            }
        }

        public Conto(string intestatario)
        {
            Intestatario = intestatario;
            ID = ++_ID;
        }

        public void Versa(decimal importo)
        {
            Saldo += importo;
        }

        public void Preleva(decimal importo)
        {
            Saldo -= importo;
        }
    }
}
