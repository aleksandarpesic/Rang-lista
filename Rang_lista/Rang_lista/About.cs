using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rang_lista
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.EQiMf1u;

            label1.Text += Environment.NewLine+ "  "; 

            label2.Text += "Program je namenjen za pamcenje rezultata." + Environment.NewLine + Environment.NewLine; 
            label2.Text += "Mogu da se pamte razultati PES utakmica," + Environment.NewLine;
            label2.Text +="nekih drugih sportskih ili van sportskih aktivnosti," + Environment.NewLine;
            label2.Text += "kako u racunarskoim tako i u realnim aktivnostima." + Environment.NewLine;
            label2.Text += Environment.NewLine + "  ";

            label3.Text += "Dizajn i implementacija softvera" + Environment.NewLine + Environment.NewLine;
            label3.Text += "        Aleksandar Pesic" + Environment.NewLine;
            label3.Text += "        acko9x@gmail.com" + Environment.NewLine;            
        }
    }
}
