using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Compiti_vacanze_BdT
{
    internal class BdT
    {
        public List<string> zone { get; private set; }
        public List<Persona> persone { get; private set; }
        public List<Prestazione> prestazioni { get; private set; }
        public List<string> categorie { get; private set; }
        public BdT()
        {
            // Inizializza le liste vuote
            zone = new List<string>();
            persone = new List<Persona>();
            prestazioni = new List<Prestazione>();
            categorie = new List<string>();
        }


        // a. Metodo per produrre l'elenco dei soci con "debito"
        public List<Persona> GetSociConDebito()
        {
            List<Persona> sociConDebito = new List<Persona>();
            foreach (var persona in persone)
            {
                int oreErogate = persona.SaldoOre();
                if (oreErogate < 0)
                {
                    sociConDebito.Add(persona);
                }
            }
            return sociConDebito;
        }
        public Persona ricercapersone(int id)
        {
            foreach (var persona in persone)
            {
                if (persona._id == id)
                {
                    return persona;
                }
            }
            return null;
        }
        public Prestazione ricercaprestazione(int id)
        {
            foreach (var prestazione in prestazioni)
            {
                if (prestazione.Id == id)
                {
                    return prestazione;
                }
            }
            return null;
        }
        public string ricercazone(string z)
        {
            foreach (var zona in zone)
            {
                if (zona == z)
                {
                    return zona;
                }
            }
            return null;
        }
        public void Aggiungipersona(Persona p)
        {
            if (p != null)
                persone.Add(p);
            
        }
        public void Rimuovipersona(Persona p)
        {
            if (persone.Contains(p))
                persone.Remove(p);
        }
        public void Modificapersona(Persona p, Persona a)
        {
            if (persone.Contains(p))
                persone[persone.IndexOf(p)] = a;
        }

        public void Aggiungiprestazione(Prestazione p)
        {
            if (p != null)
                prestazioni.Add(p);
        }
        public void Rimuoviprestazione(Prestazione p)
        {
            if (prestazioni.Contains(p))
                prestazioni.Remove(p);
        }
        public void Modificaprestazione(Prestazione p, Prestazione a)
        {
            if (prestazioni.Contains(p))
                prestazioni[prestazioni.IndexOf(p)] = a;
        }

        public void Aggiungizona(string p)
        {
            if (p != null)
                zone.Add(p);
        }
        public void Rimuovizona(string p)
        {
            if (zone.Contains(p))
                zone.Remove(p);
        }
        public void Modificazona(string p, string a)
        {
            if (zone.Contains(p))
                zone[zone.IndexOf(p)] = a;
        }
        // b. Metodo per visualizzare i soci della segreteria che offrono altre prestazioni
        public List<Persona> GetSociSegreteriaConAltrePrestazioni()
        {
            List<Persona> socisegpres = new List<Persona>();
            foreach (Persona persona in persone)
            {
                if (persona._segreteria == true && persona._prestazione != null)
                {
                    socisegpres.Add(persona);
                }
            }
            return socisegpres;
        }

        // c. Metodo per produrre un elenco di prestazioni ordinate per ore erogate
        public List<Prestazione> GetPrestazioniOrdinatePerOre()
        {

            return prestazioni.OrderByDescending(prestazione => prestazione.OreErogate).ToList();
        }

        // d. Metodo per salvare i dati su file JSON
        public void SaveDataToJson()
        {
            string existingData = File.Exists(@"C:\Users\matve\source\repos\Compiti-vacanze-BdT\Compiti vacanze BdT\bin\Debug\BdT.json")
        ? File.ReadAllText(@"C:\Users\matve\source\repos\Compiti-vacanze-BdT\Compiti vacanze BdT\bin\Debug\BdT.json")
        : "";

            // Serializza i dati correnti e i nuovi dati in formato JSON
            string jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
            // Scrivi i dati combinati nel file JSON
            File.WriteAllText(@"C:\Users\matve\source\repos\Compiti-vacanze-BdT\Compiti vacanze BdT\bin\Debug\BdT.json",jsonData);
            /*string filePath = @"C:\Users\matve\source\repos\Compiti-vacanze-BdT\Compiti vacanze BdT\bin\Debug\BdT.json";

            // Leggi il contenuto esistente del file JSON, se presente
            string existingData = File.Exists(filePath)
                ? File.ReadAllText(filePath)
                : "";

            // Deserializza i dati esistenti in un'istanza di BdT
            BdT existingBdT = JsonConvert.DeserializeObject<BdT>(existingData);

            // Aggiungi i nuovi dati all'oggetto esistente
            existingBdT.zone.AddRange(zone);
            existingBdT.persone.AddRange(persone);
            existingBdT.prestazioni.AddRange(prestazioni);
            existingBdT.categorie.AddRange(categorie);

            // Serializza l'oggetto combinato in formato JSON
            string combinedData = JsonConvert.SerializeObject(existingBdT, Formatting.Indented);

            // Scrivi i dati combinati nel file JSON
            File.WriteAllText(filePath, combinedData);*/
        }
        public void LoadDataFromJson()
        {
            try
            {
                // Leggi il contenuto del file JSON
                string jsonData = File.ReadAllText(@"C:\Users\matve\source\repos\Compiti-vacanze-BdT\Compiti vacanze BdT\bin\Debug\BdT.json");

                // Deserializza il JSON in un'istanza della tua classe
                BdT data = JsonConvert.DeserializeObject<BdT>(jsonData);
                this.persone = data.persone;
                this.prestazioni = data.prestazioni;
            }
            catch
            {
            }
        }
    }
}
