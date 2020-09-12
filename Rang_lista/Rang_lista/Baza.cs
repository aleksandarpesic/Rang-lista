using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //zbog MessageBox.Show...
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Rang_lista
{
    class Baza
    {
        MySqlConnection myCon; 
        string connection; 

        public Baza()
        {
            connection = "Server=den1.mysql1.gear.host;Database=rezultati;User ID=rezultati;Password=askme;"; // Potreban je Password za pristup bazi
            //deo za povezivanje na localhost u promenljivu connectionString
            string server = "localhost";
            string database = "rezultati";
            string uid = "root";
            string password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            myCon = new MySqlConnection(connection);
        }
        public bool conect()
        {                                    
            try
            {
                myCon.Open();
                return true;
            }
            catch (MySqlException ex)
            {               
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        public int CountRows()
        {
            string query = "use rezultati; SELECT Count(*) FROM main"; int Count = -1;
           // if (this.conect() == true){
                
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                Count = int.Parse(cmd.ExecuteScalar() + "");
               // CloseConnection();
           // }
            return Count;
        }

        public void Insert(int broj_igraca, Igrac[] players)
        {
            string query = "insert into main (num_players) values (" + broj_igraca + "); "; //prvo broj igraca
           
            if (this.conect() == true) 
            {               
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.ExecuteNonQuery(); 
                
                int id =CountRows();
                for (int i = 1; i <= broj_igraca; i++) //za svakog igraca pojedinacno ime i poene
                {
                    query = "UPDATE main SET player"+i+"= '"+players[i-1].getIme()+"' , val"+i+" = "+players[i-1].getPoeni()+", datum=NOW() WHERE id="+id+"; "; //"UPDATE main SET player"+i+" = 'Mil' "+" , val"+i+" = "+players[i].getPoeni()+" WHERE id="+id+"; ";
                    cmd = new MySqlCommand(query, myCon);
                    cmd.ExecuteNonQuery();                    
                }
                CloseConnection();    
            } 
        }
        public void Database_To_HTML()
        {
            StreamWriter st=new StreamWriter("rang_liste(Database).html");
            st.WriteLine("<html>");
            st.WriteLine("<head>");
            st.WriteLine("<style>");
            st.WriteLine("#customers {");
            st.WriteLine("font-family: Trebuchet MS, Arial, Helvetica, sans-serif;");
            st.WriteLine("border-collapse: collapse;");
            st.WriteLine("width: 100%;");
            st.WriteLine("}");

             st.WriteLine("#customers td, #customers th { ");
             st.WriteLine("border: 2px solid #ddd;");
             st.WriteLine("padding: 8px; ");
            st.WriteLine("}");

            st.WriteLine("#players tr:nth-child(even){background-color: #CFCFFF;} ");

         st.WriteLine("#players tr:hover {background-color: #ddd;} ");

         st.WriteLine("#players th {");
             st.WriteLine("padding-top: 12px;");
             st.WriteLine("padding-bottom: 12px;");
             st.WriteLine("text-align: left;");
             st.WriteLine("background-color: #4CAF50;");
            st.WriteLine(" color: white;");
         st.WriteLine("}");
         st.WriteLine(" div {        margin-left: 200px;  margin-right: 300px;  margin-top: 50px; } ");
         st.WriteLine(" h1 {  color: #CFCFFF;   }");
         st.WriteLine(" h2 {  color: #C5C5FF;    }");
         st.WriteLine("</style>");
         st.WriteLine("</head>");

         st.WriteLine("<body bgcolor=#F2F2FF>");         
          st.WriteLine("<div>");
          st.WriteLine("<h1>Generisanje izvestaja </h1>");
          st.WriteLine("<h2>Prikaz rang listi sa odigranih turnira </h2>");
            if (this.conect() == true)
            {
                int id = CountRows(); //broj odigranih meceva

                for (int i = 1; i <= id; i++)
                {
                    string queryDate = "SELECT datum FROM main where id=" + i + "; ";
                    MySqlCommand cmd = new MySqlCommand(queryDate, myCon);
                    st.WriteLine("<br><br>Datum: "+cmd.ExecuteScalar());

                    string query = "SELECT num_players FROM main where id="+i +"; "; int num_players = -1;                  
                    cmd = new MySqlCommand(query, myCon);
                    num_players = int.Parse(cmd.ExecuteScalar() + "");

                    

                    st.WriteLine("<table id=players >");
                    st.WriteLine("<tr> <th> &nbsp;&nbsp; &nbsp; Igrac  &nbsp; &nbsp;&nbsp;</th> <th>&nbsp;&nbsp; &nbsp; Poeni  &nbsp; &nbsp;&nbsp;</th> </tr>");
                        for (int j = 1; j <= num_players; j++)
                        {
                            //uzimam ime za datog igraca
                            query = "SELECT player" + j + " FROM main where id=" + i + "; "; String player_name;
                            cmd = new MySqlCommand(query, myCon);
                            player_name = (cmd.ExecuteScalar() + "");
                            
                            //uzimam poene za datog igraca
                            query = "SELECT val"+j + " FROM main where id=" + i + "; "; Byte val;
                            cmd = new MySqlCommand(query, myCon);
                            val = Convert.ToByte(cmd.ExecuteScalar() + "");
                            st.WriteLine("<tr> <td>" + player_name + "</td> <td>" + val + "</td> </tr>"); 

                        }
                    

                    st.WriteLine("</table>");
                }
            }
            CloseConnection();


            st.WriteLine("</div>");
            st.WriteLine("</body>");
            st.WriteLine("</html>");
            st.Close();
            MessageBox.Show("Uspesno upisano");
        }


        public bool CloseConnection()
        {
            try
            {
                myCon.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        public void KreiranjeTabela() //samo jednom se pozove nad bazom (setup baze)
        {
            string query = "drop table if exists main; CREATE TABLE main (id int(11) unsigned not null auto_increment,  num_players int(11) unsigned not null, datum  DATETIME," +
            "player1 varchar(20), player2 varchar(20),player3 varchar(20),player4 varchar(20),player5 varchar(20),player6 varchar(20),player7 varchar(20),player8 varchar(20),player9 varchar(20),player10 varchar(20)," +
            "val1 TINYINT,val2 TINYINT,val3 TINYINT,val4 TINYINT,val5 TINYINT,val6 TINYINT,val7 TINYINT,val8 TINYINT,val9 TINYINT,val10 TINYINT," +
            "Primary key (id)) ENGINE = InnoDB;";

            if (this.conect() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, myCon);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void generateKeys()
        {
            List<int> keys = new List<int>();
            Random r = new Random();
            bool upis=false;
            
            for (int i = 0; i < 1000; )
            {
                int key = r.Next(999999);
                upis = true;
                for (int j = 0; j < keys.Count(); j++)
                    if (keys[j] == key) upis = false;
                
                if(upis) {
                    keys.Add(r.Next(999999));
                    i++;
                }
            }

            
            string query = "drop table if exists APPkeys; CREATE TABLE APPkeys (id int(11) unsigned not null auto_increment,  APPkey int(11) unsigned not null, used bool default false ," +
            "Primary key (id)) ENGINE = InnoDB;";

            if (this.conect() == true)
            {                
                MySqlCommand cmd = new MySqlCommand(query, myCon);
                cmd.ExecuteNonQuery();

                StreamWriter st = new StreamWriter("GeneratedKeys.txt", append: true);
                st.WriteLine("Lista kljuceva za aplikaciju");
                st.WriteLine("id u bazi         key");
                for (int i = 1; i < 500; i++) 
                {
                    query = "insert into APPkeys (APPkey) values (" + keys[i] + "); "; 
                    cmd = new MySqlCommand(query, myCon);
                    cmd.ExecuteNonQuery();
                    st.WriteLine(i +"  "+keys[i]);
                }
                CloseConnection();
            }


        }

        public bool keyOK(int k)
        {
            string query = "use rezultati; SELECT Count(*) FROM APPkeys where APPkey="+k+" and used = false ;"; int Count = -1;
            if (this.conect() == true){
            MySqlCommand cmd = new MySqlCommand(query, myCon);
            Count = int.Parse(cmd.ExecuteScalar() + "");
            CloseConnection();
            }
            if (Count == 1)
            { //kljuc je jedinstven i neiskoriscen. Sada postaje iskoriscen i vraca true
                if (this.conect() == true)
                {
                    query = "UPDATE APPkeys  set used = true where APPkey=" + k + " ;";
                    MySqlCommand cmd = new MySqlCommand(query, myCon);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
                return true;
            }
            
            return false;
        }

    }
}
