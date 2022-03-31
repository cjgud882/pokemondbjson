using System;
using System.Collections;
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
using System.IO;

namespace pokemonjson
{
    public partial class Form2 : Form
    {
        private ArrayList Pokes = new ArrayList();

        public int current;



        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader inFile = File.OpenText("Pokemon.JSON");
                while (inFile.Peek() != -1)
                {
                    string pLine = inFile.ReadLine();
                    pokemon p = JsonSerializer.Deserialize<pokemon>(pLine);
                    Pokes.Add(p);
                }
                inFile.Close();
                Show();

            }
            catch
            {
                StreamWriter outFile = File.CreateText("Pokemon.JSON");
                outFile.Close();
                StreamReader inFile = File.OpenText("Pokemon.JSON");
                while (inFile.Peek() != -1)
                {
                    string pLine = inFile.ReadLine();
                    pokemon p = JsonSerializer.Deserialize<pokemon>(pLine);
                    Pokes.Add(p);
                }
                inFile.Close();
                Show();
            }


            
        }
        
        public void Show()
        {
            if (current >= 0 && current <Pokes.Count)
            {
                pokemon pk = (pokemon)Pokes[current];
                nameTextBox.Text = pk.m_name;
                hpTextBox.Text = pk.m_hp.ToString();
                dmgTextBox.Text = pk.m_dmg.ToString();
                abilityTextBox.Text = pk.m_ability;

            }




           

        }




        public void Clear()
        {
            nameTextBox.Clear();
            hpTextBox.Clear();
            dmgTextBox.Clear();
            abilityTextBox.Clear();

        }

        private void enterButton_Click_1(object sender, EventArgs e)
        {
             
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var pokemon = new pokemon
            {
                m_name = nameTextBox.Text,
                m_hp = Int32.Parse(hpTextBox.Text),
                m_dmg = Int32.Parse(dmgTextBox.Text),
                m_ability = abilityTextBox.Text,

            };

            StreamWriter outFile = File.CreateText("Pokemon.JSON");
            Pokes.Add(pokemon);
            

            foreach(var item in Pokes)
            {
                outFile.WriteLine(JsonSerializer.Serialize(item));

            }
            outFile.Close();


            Clear();
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            current = 0;
            Show();
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            current = Pokes.Count - 1;
            Show();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            current = current - 1;
            Show();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            current = current + 1;
            Show();
        }
    }
}
