using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiti_vacanze_BdT
{
    internal class Prestazione
    {
        public int Id { get; private set; }
        public int OreErogate { get; private set; }
        public Persona Creatore { get; private set; }
        public Persona Richiedente { get; private set; }
        public DateTime GiornoCreazione { get; private set; }
        public bool Segreteria { get; private set; }
        public string Categoria { get; private set; }
        public string Descrizione { get; private set; }
        public static int Contatore { get; private set; } = 0;

        public Prestazione(Persona creatore, Persona richiedente, DateTime giornoCreazione,
                          bool segreteria, string categoria, string descrizione, int oreErogate)
        {
            Id = Contatore++;
            OreErogate = 0;
            Creatore = creatore;
            Richiedente = richiedente;
            GiornoCreazione = giornoCreazione;
            Segreteria = segreteria;
            Categoria = categoria;
            Descrizione = descrizione;
        }
        // Metodo per registrare le ore di una prestazione erogata
        public void AggiungiOreP(int ore)
        {
            OreErogate += ore;
        }

        // Metodo per registrare le ore di una prestazione ricevuta
        public void SottraiOreP(int ore)
        {
            OreErogate -= ore;
        }

        // Metodo per ottenere il saldo delle ore (prestazioni erogate - prestazioni ricevute)
        public int SaldoOreP()
        {
            return OreErogate;
        }
    }
}
