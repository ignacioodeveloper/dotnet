using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
namespace crudwindowsformnet
{
    public class PeopleDB
    {
        private string connectionString
            = "Data Source=LAPTOP-FBQD8RJL;Initial Catalog=cursomvc;Integrated Security=True;";

        //metodo conectarse db
        public bool Ok()
        {
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }


        public List<People> Get()
        { 
            List<People> people = new List<People>();

            string query = "select id, email, edad from [user]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        People oPeople = new People();
                        oPeople.Id = reader.GetInt32(0);
                        oPeople.Email = reader.GetString(1);
                        oPeople.Edad = reader.GetInt32(2);

                        people.Add(oPeople);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    throw new Exception("hay un error" + ex.Message);
                }
            }

            return people;
        }

        public People Get(int Id)
        {

            string query = "select id, email, edad from [user]"+
                " where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    People oPeople = new People();
                    oPeople.Id = reader.GetInt32(0);
                    oPeople.Email = reader.GetString(1);
                    oPeople.Edad = reader.GetInt32(2);

                    reader.Close();
                    connection.Close();
                    return oPeople;
                }
                catch (Exception ex)
                {
                    throw new Exception("hay un error" + ex.Message);
                }
            }

        }
        public void Add(string Email, int Edad)
        {
            string query = "insert into [user](email, edad) values" +
                // alias
                "(@email, @edad)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // parametros
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@edad", Edad);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("hay un error" + ex.Message);
                }
            }
        }

        public void Update(string Email, int Edad, int Id)
        {
            string query = "update [user] set email=@email, edad=@edad" +
                // alias
                " where id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // parametros
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@edad", Edad);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("hay un error" + ex.Message);
                }
            }
        }
        public void Delete(int Id)
        {
            string query = "delete from [user]" +
                // alias
                " where id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // parametros
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("hay un error" + ex.Message);
                }
            }
        }
    }
    public class People
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }

    }
}