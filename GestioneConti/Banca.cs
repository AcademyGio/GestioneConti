using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneConti
{
    class Banca
    {
        private Dictionary<int, Conto> _conti = new Dictionary<int, Conto>();

        public string OttieniProspetto(Formato formato)
        {
            string s = "";

            foreach (Conto c in _conti.Values)
                s += c.OttieniProspetto(formato) + '\n';

            return s;
        }

        public decimal SaldoTotale 
        { 
            get
            {
                decimal s = 0;

                foreach (Conto c in _conti.Values)
                    s += c.Saldo;

                return s;
            }
        }

        public bool Esiste(int id)
        {
            return _conti.ContainsKey(id);
        }

        public Conto CreaConto(string intestatario)
        {
            Conto c = new Conto(intestatario);

            // associa ad ogni ID il conto corrispondente
            _conti.Add(c.ID, c);

            return c;
        }

        public void Versa(int id, decimal importo)
        {
            _conti[id].Versa(importo);
        }

        public decimal OttieniSaldo(int id)
        {
            return _conti[id].Saldo;
        }
    }
}
