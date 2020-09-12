using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Rang_lista
{ 
    public partial class Form1 : Form
    {
        public Igrac[] players;
        private int broj_igraca, broj_utakmica;
        public static int broj_klikova = 0;

        private String[ , ] lista;
        public static myButton[] btn_lista;
        Label[] lbl_lista_Rangiranja;

        string lozinkaBazeAdmin="799projekat#36254189";

        int app_id=-1;
        public static int pokusaji_aktivacije =0;
        public static bool keyOK = false;

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources._1172866;

            players = new Igrac[10]; 
            broj_igraca=0;
		    lista=new String[10,2]; //sluzi kao lista meceva gde je i prvom [] prvi igrac, a [drugi] igrac
            
            btn_lista = new myButton[10];
            lbl_lista_Rangiranja = new Label[10];
            

            for (int j = 0; j < 10; j++)
            {

                btn_lista[j] = new myButton();
                btn_lista[j].Num1 = j; //j-ti element 
                btn_lista[j].Click+= new EventHandler(myButtonClick);
                btn_lista[j].Location = new Point(270, j * 28 + 186); btn_lista[j].Visible = false;
                btn_lista[j].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //Controls.Add(btn_lista[j]);

                             
                
            }

           
            AktivacijaKljuca();
            //baza.generateKeys();
            //if (baza.conect())
              //  lblNewLabel.Text = ""+baza.CountRows();
           
        }
        public void AktivacijaKljuca()
        {
            //deo za aktivaciju
            Baza baza = new Baza();
           
            string curFile = @"c:\Windows\trr.txt";
            if (File.Exists(curFile))
            {
                string text = System.IO.File.ReadAllText(@"C:\Windows\trr.txt");
                app_id = Convert.ToInt32(text);
                keyOK = true;
            }
            else
            {
                String prefix = "";

                while (!keyOK && pokusaji_aktivacije < 3)
                {
                    string uneto = Prompt.ShowDialog(prefix + "Serijski broj:", "Aktivacija");
                    if (uneto != "" && uneto.All(char.IsDigit))
                    {
                        app_id = Convert.ToInt32(uneto);

                        if (baza.keyOK(app_id))
                        {

                            //baza.KreiranjeTabela(); //izbrise tabelu i napravi novu
                            lblNewLabel.Text = "Kljuc uredu";

                            System.IO.File.WriteAllText(@"C:\Windows\trr.txt", uneto);
                            keyOK = true;
                        }
                    }
                    pokusaji_aktivacije++;
                    prefix = "Neispravno! Unesite ponovo ";

                }

            } //kraj dela za aktivaciju

        }
  
        private void myButtonClick(object sender, EventArgs e)
        {            
            myButton btn = sender as myButton;

            unos1 un = new unos1(lista[btn.Num1, 0], lista[btn.Num1, 1], ref players, broj_igraca, btn.Num1);
            un.Show();

           // lblNewLabel.Text = "" + broj_utakmica +" "+broj_klikova;
            
            if (broj_klikova+1 == broj_utakmica)
            {
                broj_klikova = 0; 
                button1.Enabled = true;             
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (keyOK)
            {
                if ((findPlayer(textField_upisIgraca.Text) != -1) || textField_upisIgraca.Text == "")
                {
                    lblNewLabel.Text = "Niste popunili polje ili igrac sa imenom " + textField_upisIgraca.Text + " vec postoji.\nMorate se upisati drugacije";
                }
                else
                {
                    players[broj_igraca] = new Igrac(textField_upisIgraca.Text);
                    lblNewLabel.Text = "Unet " + players[broj_igraca].getIme();
                    broj_igraca++;
                }
                textField_upisIgraca.Text = "";
            }
            else
            {
                MessageBox.Show("Nije moguce upisivati igrace dok ne aktivirate program", "Ne aktiviran");
            }
        }

        public int findPlayer(String n)
        {
            int i = 0;
            while (i < broj_igraca)
            {
                if (n.Equals(players[i].getIme()))
                    return i;
                i++;
            }
            return -1;
        }

        private void unetiSviIgraci_CheckedChanged(object sender, EventArgs e)
        {
            if (unetiSviIgraci.Checked)
            {
                kada_se_unesu_igraci();
            }
        }
        private void kada_se_unesu_igraci()
        {
            if (broj_igraca < 2) { MessageBox.Show("Najmanji broj unetih igraca mora da bude 2"); return; }
            unetiSviIgraci.Enabled = false;
            textField_upisIgraca.Enabled = false;
            btn_upis.Enabled = false;
            lblNewLabel.Text = "Svi igraci su upisani";

            broj_utakmica = sredi_sortirane();
            lista_utakmica(broj_utakmica);
           
            for (int j = 0; j < broj_igraca; j++) //levo labele za igrace (prebaceno iz konstruktora jer ovde znam tacan broj igraca)
            {
                lbl_lista_Rangiranja[j] = new Label();
                lbl_lista_Rangiranja[j].Location = new Point(60, j * 28 + 80);
                // lbl_lista_Rangiranja[j].BackColor = System.Drawing.Color.Transparent;
                //lbl_lista_Rangiranja[j].ForeColor = System.Drawing.Color.DarkSalmon;
                lbl_lista_Rangiranja[j].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl_lista_Rangiranja[j].BackColor = System.Drawing.Color.Gainsboro;                
                lbl_lista_Rangiranja[j].Size = new System.Drawing.Size(leng_lbl_lista_Rangiranja(players[j].getIme(),160), 19);

                lbl_lista_Rangiranja[j].Text = players[j].getIme();
                Controls.Add(lbl_lista_Rangiranja[j]);

            }
        }

        public int leng_lbl_lista_Rangiranja(String upis_u_listu, int default_size) //za datog igraca da prosiri po potrebi labelu da stane ime
        {
            int leng_btn = default_size;
            if ((upis_u_listu.Length + 8) * 8 > leng_btn) leng_btn = (upis_u_listu.Length + 8) * 8;
            return leng_btn;
        }

        public void lista_utakmica(int broj_utakmica2)
        {
            //pravim listu utakmica
            int i = 0;
            Random r = new Random();
          
            for (i = 0; i < broj_utakmica2; i++)
            {
                int prvi = r.Next(broj_igraca), drugi = 0;
                while (players[prvi].ukljucen != true)
                {
                    prvi = r.Next(broj_igraca);
                }
                players[prvi].ukljucen = false;
                drugi = r.Next(broj_igraca);
                int brPonavljanja = 0;
                while ((players[drugi].ukljucen != true || players[drugi].getPoeni() != players[prvi].getPoeni() || drugi == prvi) && (brPonavljanja) < broj_igraca)
                {
                    drugi = brPonavljanja; brPonavljanja++;
                }
                while ((players[drugi].getPoeni() != players[prvi].getPoeni() || drugi == prvi) && brPonavljanja >= broj_igraca)
                {
                    drugi = r.Next(broj_igraca);
                }
                players[drugi].ukljucen = false;
                lista[i,0] = players[prvi].getIme();
                lista[i,1] = players[drugi].getIme();
            }
          
            for (int j = 0; j < broj_utakmica2; j++)
            {
                String dodaj_btn = lista[j, 0] + "  VS  " + lista[j, 1];
                int leng_btn = 150; 
                if (dodaj_btn.Length*8 > leng_btn) leng_btn = dodaj_btn.Length*8;
                btn_lista[j].Size = new System.Drawing.Size(leng_btn, 25);
                btn_lista[j].Text=lista[j,0] + "  VS  " + lista[j,1];
                Controls.Add(btn_lista[j]); 
                btn_lista[j].Visible = true; //jer ih unos1 forma onemoguci kad se unese za kliknuti mec
            } button1.Enabled = false;
        }
        public int sredi_sortirane()
        {
            int i, j, k = 0, isti;

            for (i = 0; i < broj_igraca; i++) { players[i].ukljucen = false; }

            for (i = 0; i < broj_igraca; i++)
            {
                isti = 1;
                for (j = 0; j < broj_igraca; j++)
                {
                    if (i != j && players[i].getPoeni() == players[j].getPoeni() && players[j].ukljucen == false)
                    {
                        ++isti;
                        players[j].ukljucen = true;
                    }
                }
                if (isti > 1)
                {
                    if (isti % 2 != 0) k += (isti / 2) + 1;
                    else k += isti / 2;
                    players[i].ukljucen = true;
                }
            }
            return k; //vraca broj utakmica
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Sort_Write(); //samo ispis na formu u sortiranom redosledu

            broj_utakmica=sredi_sortirane(); //da broj utakmica za trenutne poene igraca

            if (broj_utakmica >= 1)
            {
                lista_utakmica(broj_utakmica); //uparuje igrace sa istim poenima 
                //button1.Enabled = false;
            }
            else
            {
                button1.Text = "Kraj";
                button1.Enabled = false;
            }
            broj_klikova = 0; //zbog  button1.Enabled iz funkcije myButtonClick()

        }

        public void Sort_Write() //sortira samo za ispis na formu bez remecenja trenutnog niza players
        {
            Igrac[] playersTmp = new Igrac[10];
            for (int i = 0; i < broj_igraca; i++)
            { //deep constructor copy
                Igrac tmp = players[i];
                if (tmp != null)
                    playersTmp[i] = new Igrac(tmp);
            }
            sortiraj_igrace(ref playersTmp);
            //sad ispisujem u levom delu igrace redom
            for (int i = 0; i < broj_igraca; i++)
            {
                lbl_lista_Rangiranja[i].Size = new System.Drawing.Size(leng_lbl_lista_Rangiranja(playersTmp[i].getIme(), 160), 19);
                lbl_lista_Rangiranja[i].Text=(playersTmp[i].getIme() + " ->" + playersTmp[i].getPoeni());
            }
        }

        public void sortiraj_igrace(ref Igrac[] players2)
        {
            Igrac tmp = players2[0]; //sortiram		 

            for (int i = 0; i < broj_igraca; i++)
            {
                for (int j = i; j < broj_igraca; j++)
                {
                    if (players2[i].getPoeni() < players2[j].getPoeni())
                    {
                        tmp = players2[i];
                        players2[i] = players2[j];
                        players2[j] = tmp;
                    }
                }
            }
        }

        private void lista1ToolStripMenuItem_Click(object sender, EventArgs e)  //Unos igraca iz txt fajla (sa menija)
        {
            if (keyOK)
            {
                using (FileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.ShowDialog();
                    string fileName = fileDialog.FileName;
                    lblNewLabel.Text = fileName;
                    bool korentno_uneti = true;
                    if (fileName != "")      //ako izadje iz browse fileName je prazan string i puca program
                        foreach (string line in File.ReadLines(@fileName, Encoding.UTF8))
                        {
                            if ((findPlayer(line) != -1) || line == "")
                            {
                                MessageBox.Show("Nekorektan sadrzaj fajla. Info: Svaki igrac mora da ima jedinstveno ime. Upisite igrace iz aplikacije rucno");
                                broj_igraca = 0; korentno_uneti = false;
                            }
                            else
                            {
                                if (broj_igraca < 10)
                                {
                                    players[broj_igraca] = new Igrac(line);
                                    broj_igraca++;
                                }
                                else
                                {
                                    MessageBox.Show("Nekorektan sadrzaj fajla. Prekoracen limit igraca. Upisite igrace iz aplikacije rucno.");
                                    broj_igraca = 0; korentno_uneti = false;
                                }
                            }
                        }
                    else korentno_uneti = false;
                    if (korentno_uneti)
                        kada_se_unesu_igraci();

                }
            }
            else              
            {
                MessageBox.Show("Nije moguce upisivati igrace dok ne aktivirate program", "Ne aktiviran");
            }
        }

        private void upisPodatakaToolStripMenuItem_Click(object sender, EventArgs e) //upis u bazu po zavrsetku turnira
        {
           
                if (broj_utakmica > 0 || broj_igraca < 1)
                    MessageBox.Show("Dok traje turnir ne mozete upisivati u bazu ili dok nema upisanih igraca");
                else
                {
                    sortiraj_igrace(ref players);
                    Baza baza = new Baza();
                    baza.Insert(broj_igraca, players);
                    MessageBox.Show("Upisao");
                }
            
            
        }

        private void databaseHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Baza baza = new Baza(); 
            baza.Database_To_HTML();
        }

        private void upisRangListeUFailToolStripMenuItem_Click(object sender, EventArgs e)
        {
                           
                if (broj_utakmica > 0 || broj_igraca < 1)
                {
                     MessageBox.Show("Dok traje turnir ne mozete upisivati konacnu rang listu ili dok nema upisanih igraca");
                }
                else
                {
                    StreamWriter st = new StreamWriter("rang_lista.txt", append: true);
                    st.WriteLine("Konacna rang lista");
                    st.WriteLine("Ime       Poeni");
                    st.WriteLine();
                    for (int i = 0; i < broj_igraca; i++)
                    {
                        st.WriteLine(players[i].getIme() + " --->" + players[i].getPoeni());
                    }
                    st.WriteLine();
                    st.Close();
                    MessageBox.Show("Uspesno upisano");
                }
            
            
            
        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void izbrisiIzBazeSveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Uneti lozinku za brisanje podataka iz baze", "Admin");
            
            if (promptValue == lozinkaBazeAdmin)
            {
                Baza b = new Baza(); 
                b.KreiranjeTabela(); //izbrise tabelu i napravi novu
                lblNewLabel.Text = "Lozinka prihvacena. Uspesno ispraznjena baza";
            }
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }
   
}
