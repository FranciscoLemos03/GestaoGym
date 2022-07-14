using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
#nullable disable

namespace GerirGym
{
    internal class ControllerDB
    {
        public MySqlConnection connection;
        public MySqlDataReader reader;
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        string sql;

        public MySqlConnection DBconn()
        {
            connection = new MySqlConnection("Server=localhost;Database=dbgym;Uid=root;Pwd=;");
            return connection;
        }

        public string loginSecretaria(string user, string passwd)
        {
            string msg = "";
            try
            {

                connection = DBconn();

                sql = "Select Username from Secretaria where Username = @username and Passwd = @passwd";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", user);
                command.Parameters.AddWithValue("@passwd", passwd);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    msg =  reader["Username"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);

            }

            return msg;
        }

        public string loginCliente(string user, string passwd)
        {
            string msg = "";
            try
            {

                connection = DBconn();

                sql = "Select Username from Cliente where Username = @username and Passwd = @passwd";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", user);
                command.Parameters.AddWithValue("@passwd", passwd);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    msg = reader["Username"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);

            }

            return msg;
        }

        public string loginPT(string user, string passwd)
        {
            string msg = "";
            try
            {

                connection = DBconn();

                sql = "Select Username from PT where Username = @username and Passwd = @passwd";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", user);
                command.Parameters.AddWithValue("@passwd", passwd);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    msg = reader["Username"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);

            }

            return msg;
        }
        public string loginNutri(string user, string passwd)
        {
            string msg = "";
            try
            {

                connection = DBconn();

                sql = "Select Username from Nutricionista where Username = @username and Passwd = @passwd";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", user);
                command.Parameters.AddWithValue("@passwd", passwd);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    msg = reader["Username"].ToString();
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                connection.Close();
                connection = new MySqlConnection(null);
                command = new MySqlCommand(null);

            }

            return msg;

        }

 

    }
}
