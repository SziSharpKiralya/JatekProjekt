using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;


        public AdatbazisKezelo()
        {

            this.connectionString = "server=localhost;database=jatekdb;uid=root;pwd=;";
            // Irjuk meg a connectionstringet a megfelelő adatbázisra hivatkozva
        }

   
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
       
        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();
            using (MySqlConnection connectiom = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM karakterek";
                using (MySqlCommand command = new MySqlCommand(query, connectiom))
                {
                    connectiom.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("Id");
                            string nev = reader.GetString("Nev");
                            string osztaly = reader.GetString("Osztaly");
                            int szint = reader.GetInt32("Szint");
                            int arany = reader.GetInt32("Arany");
                            string szerver = reader.GetString("Szerver");


                            Karakter karakter = new Karakter(id, nev, osztaly, szint, arany, szerver);
                            karakterek.Add(karakter);
                        }
                    }
                }
            }

            return karakterek;
        }
    }
}
