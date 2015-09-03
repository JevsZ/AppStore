using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace StoreApp.ConexionClass
{
    class ConnClass
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //constructor
        public ConnClass()
        {
            Initialize();
            //OpenConnection();
        }

        private void Initialize()
        {
            server = "127.0.0.1";
            database = "dbpaymentc";
            uid = "root";
            password = "Josue123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }



        /// <summary>
        /// Funcion Para Conectarse a la Base de Datos
        /// </summary>
        /// <returns></returns>
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact Administrator");
                        break;
                    case 1054:
                        MessageBox.Show("Invalid Username/password, please try again");
                        break;
                }
                return false;
            }
            finally
            {

            }
        }//fin de funcion OpenConnection
        
        /// <summary>
        /// funcion para cerrar conexion a base de datos
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }//fin funcion para cerrar conexion

        public void insert(String Comand)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Comand, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Esta funcion sirve para retornar un valor escalar
        /// ejemplo "SELECT Count(*) FROM tableinfo"
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>
        public int Count(String Command)
        {
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Command, connection);
                //Execute escalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");
                this.CloseConnection();
                return Count;
            }
            else
            {
                return Count;
            }
        }

        public List<string>[] Select()
        {
            string query = "SELECT * FROM products";
            //create a list to store the result;
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["IdProducts"] + "");
                    list[1].Add(dataReader["ProductName"] + "");
                    list[2].Add(dataReader["ProductValue"] + "");
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

    }
}
