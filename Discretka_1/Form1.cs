using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discretka_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            bool[,] cells = new bool[6, 32];           
            for (int i = 0; i < 32; i++) 
            {
                int d = i;
                for (int j = 4; j > -1; j--) 
                {
                    if (d > 0) 
                    {
                        cells[j, i] = Convert.ToBoolean(d % 2);
                        d = d / 2;
                    } 
                    else
                    {
                        cells[j, i] = false;
                    }
                    Table[j, i].Value = Convert.ToInt32(cells[j, i]);

                    cells[5, i] = (!cells[0, i] && cells[1, i]) || cells[2, i] || (cells[3, i] && !cells[4, i]);
                    Table[5, i].Value = Convert.ToInt32(cells[5, i]);
                }  
            }

            string SDNF = "";
            string SKNF = "";
            string vars = "abcde";
            for (int i=0; i < 32; i++)
            {
                string SKO = "";
                string SDO = "";
                if (cells[5, i] == true)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cells[j, i] == false)
                            SKO += "¬";

                        SKO += vars[j];

                        if (j != 4)
                            SKO += " ⋀  ";
                    }

                    SDNF += "(" + SKO + ") ∨ ";
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cells[j, i] == true)
                            SDO += "¬";

                        SDO += vars[j];

                        if (j != 4)
                            SDO += " ∨ ";
                    }

                    SKNF += "(" + SDO + ") ⋀ ";
                }
            }

            SDNF = SDNF.Substring(0, SDNF.Length - 3);
            SKNF = SKNF.Substring(0, SKNF.Length - 3);

            textBox2.Text = SDNF;
            textBox1.Text = SKNF;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Table.RowCount = 32;
            label1.Text = "\r\nИсходное выражение:\r\n\r\n(¬a ⋀ b) ∨ c ∨ (d ⋀ ¬e)\r\n";
        } 
    }
}
