using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Compiti_vacanze_BdT
{
    public partial class Persone : Form
    {
        BdT banca;
        Persona persona;
        Prestazione prestazione;
        public Persone()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int controllonumerotelefono = int.Parse(textBox3.Text);
            }
            catch
            {
                throw new Exception("numero di telefono non valido, inserire solo numeri");
            }
            try
            { 
                Persona socio = new Persona(textBox1.Text, textBox2.Text, textBox3.Text, checkBox1.Checked, textBox5.Text/*, p*/);
                banca.Aggiungipersona(socio);
                banca.SaveDataToJson();
                MessageBox.Show("socio creato con successo, id: " + socio._id.ToString());
            }
            //else if(!String.IsNullOrEmpty(textBox6.Text))
            //{
            //    Prestazione p = banca.ricercaprestazione(int.Parse(textBox5.Text));
            //    Persona socio = new Persona(textBox1.Text, textBox2.Text, textBox3.Text, checkBox1.Checked, textBox4.Text, p);
            //    banca.Aggiungipersona(socio);
            //    banca.SaveDataToJson();
            //    MessageBox.Show("socio creato con successo");
            //}
            catch
            {
                throw new Exception("c'è qualcosa che non va, ricontrolla i dati inseriti");
            }
        }

        private void Persone_Load(object sender, EventArgs e)
        {
            banca = new BdT();
            banca.LoadDataFromJson();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //List<Persona> lista = banca.GetSociSegreteriaConAltrePrestazioni();
            //List<string> attributiDaStampare = lista
            //.Select(persona => $"Nome: {persona._name}, Cognome: {persona._surname}, telefono: {persona._phone}")
            //.ToList();
            string listaDaStampare = string.Join(Environment.NewLine, banca.GetSociSegreteriaConAltrePrestazioni());
            if(listaDaStampare.Length > 0)
                MessageBox.Show(listaDaStampare.ToString(), "Contenuto della Lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (attributiDaStampare != null)
            //    MessageBox.Show(attributiDaStampare.ToString());
            else
                MessageBox.Show("nessun socio che fa parte della segreteria ha anche altre prestazioni");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            persona = banca.ricercapersone(int.Parse(textBox12.Text));
            banca.Rimuovipersona(persona);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            prestazione = banca.ricercaprestazione(int.Parse(textBox12.Text));
            banca.Rimuoviprestazione(prestazione);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int prova = int.Parse(textBox6.Text);
                prova = int.Parse(textBox7.Text);
                prova = int.Parse(textBox8.Text);
            }
            catch
            {
                throw new Exception("devi inserire numeri, non lettere o simboli");
            }
            try
            {
                if (textBox6.Text != "" && textBox6.Text != "" && textBox8.Text != "")
            {
                persona=banca.ricercapersone(int.Parse(textBox6.Text));
                prestazione = banca.ricercaprestazione(int.Parse(textBox7.Text));
                persona.AggiungiOre(int.Parse(textBox8.Text));
                prestazione.AggiungiOreP(int.Parse(textBox8.Text));
            }
            }

            catch
            {
                throw new Exception("qualcosa è andato storto, riprova");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int prova=int.Parse(textBox6.Text);
                prova = int.Parse(textBox7.Text);
                prova = int.Parse(textBox8.Text);
            }
            catch
            {
                throw new Exception("devi inserire numeri, non lettere o simboli");
            }
            try
            {
                if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    persona = banca.ricercapersone(int.Parse(textBox6.Text));
                    prestazione = banca.ricercaprestazione(int.Parse(textBox7.Text));
                    persona.SottraiOre(int.Parse(textBox8.Text));
                    prestazione.SottraiOreP(int.Parse(textBox8.Text));
                }
            }

            catch
            {
                throw new Exception("qualcosa è andato storto, riprova");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime data = DateTime.Now;
            Persona creatore=banca.ricercapersone(int.Parse(textBox22.Text));
            Persona richiedente = banca.ricercapersone(int.Parse(textBox21.Text));
            try
            {
                Prestazione pr = new Prestazione(textBox23.Text, creatore, richiedente, data, checkBox1.Checked, richTextBox1.Text/*, p*/);
                banca.Aggiungiprestazione(pr);
                banca.SaveDataToJson();
                MessageBox.Show("prestazione creata con successo, id: " + pr.Id.ToString());
            }
            //else if(!String.IsNullOrEmpty(textBox6.Text))
            //{
            //    Prestazione p = banca.ricercaprestazione(int.Parse(textBox5.Text));
            //    Persona socio = new Persona(textBox1.Text, textBox2.Text, textBox3.Text, checkBox1.Checked, textBox4.Text, p);
            //    banca.Aggiungipersona(socio);
            //    banca.SaveDataToJson();
            //    MessageBox.Show("socio creato con successo");
            //}
            catch
            {
                throw new Exception("c'è qualcosa che non va, ricontrolla i dati inseriti");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
