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
        public Persone()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(String.IsNullOrEmpty(textBox6.Text))
            {
                Persona socio = new Persona(textBox1.Text, textBox2.Text, textBox3.Text, checkBox1.Checked, textBox4.Text/*, p*/);
                banca.Aggiungipersona(socio);
                banca.SaveDataToJson();
                MessageBox.Show("socio creato con successo");
            }
            else if(!String.IsNullOrEmpty(textBox6.Text))
            {
                Prestazione p = banca.ricercaprestazione(int.Parse(textBox5.Text));
                Persona socio = new Persona(textBox1.Text, textBox2.Text, textBox3.Text, checkBox1.Checked, textBox4.Text, p);
                banca.Aggiungipersona(socio);
                banca.SaveDataToJson();
                MessageBox.Show("socio creato con successo");
            }
            else
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
                MessageBox.Show(listaDaStampare, "Contenuto della Lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (attributiDaStampare != null)
            //    MessageBox.Show(attributiDaStampare.ToString());
            else
                MessageBox.Show("nessun socio che fa parte della segreteria ha anche altre prestazioni");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
