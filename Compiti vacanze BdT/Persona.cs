using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Compiti_vacanze_BdT
{
    internal class Persona
    {
        public int _id { get; private set; }
        public string _name { get; private set; }
        public string _surname { get; private set; }
        public string _phone { get; private set; }
        public bool _segreteria { get; private set; }
        public int _ore { get; private set; }
        public string _zona { get; private set; }
        public Prestazione _prestazione { get; private set; }
        public static int contatore=0;

        public Persona(string name, string surname, string phone, bool segreteria, string zona, Prestazione prestazione)
        {
            _id = contatore++;
            _name = name;
            _surname = surname;
            _phone = phone;
            _segreteria = segreteria;
            _ore = 0; // Inizialmente, il socio non ha ore di prestazioni erogate o ricevute.
            _zona = zona;
            _prestazione = prestazione;
        }

        // Metodo per registrare le ore di una prestazione erogata
        public void AggiungiOre(int ore)
        {
            _ore += ore;
        }

        // Metodo per registrare le ore di una prestazione ricevuta
        public void SottraiOre(int ore)
        {
            _ore -= ore;
        }

        // Metodo per ottenere il saldo delle ore (prestazioni erogate - prestazioni ricevute)
        public int SaldoOre()
        {
            return _ore;
        }
    }
}

