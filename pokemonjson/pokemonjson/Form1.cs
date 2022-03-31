using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pokemonjson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            var pokemon = new pokemon
            {
                m_name = nameTextBox.Text,
                m_hp = Int32.Parse(hpTextBox.Text),
                m_dmg = Int32.Parse(dmgTextBox.Text),
                m_ability = abilityTextBox.Text,
                
            };

            Clear();
        }





        public void Clear()
        {
            nameTextBox.Clear();
            hpTextBox.Clear();
            dmgTextBox.Clear();
            abilityTextBox.Clear();

        }
    }
}
