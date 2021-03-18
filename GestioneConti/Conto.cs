using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneConti
{
    enum Formato
    {
        Plain,
        CSV
    }

    [Serializable]  // marco come serializzabile la classe conto
    class Conto
    {
        public int ID { get; }
        public string Intestatario { get; } // con tutti i discorsi fatti
        public decimal Saldo { get; private set;}

        public string OttieniProspetto(Formato formato)
        {
            switch (formato)
            {
                case Formato.Plain:
                    return $"Conto: {ID}, Intestatario: {Intestatario}, Saldo: {Saldo}";
                case Formato.CSV:
                    return $"{ID};{Intestatario};{Saldo}";
                default:
                    throw new ArgumentOutOfRangeException();
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
