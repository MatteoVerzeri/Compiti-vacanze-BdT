using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiti_vacanze_BdT
{
    public partial class Persone : Form
    {
        BdT banca=new BdT();
        public Persone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prestazione p = banca.ricercaprestazione(int.Parse(textBox5.Text));
            if(p != null)
            {
                Persona socio = new Persona(textBox1.Text, textBox2.Text, textBox3.Text, radioButton1.Checked, textBox4.Text, p);
                banca.persone.Add(socio);
            }
            else
            {
                throw new Exception("prestazione non trovata");
            }
        }
    }
}
