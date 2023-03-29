using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mar27.Data
{
    public class DatabaseManager
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=PeopleDB; Integrated Security=true;";
        public List<Person> GetPeople()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            List<Person> people = new List<Person>();
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (string)reader["Age"]
                });
            }
            connection.Close();
            return people;
        }
        public void AddPerson(Person person)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO People " +
                "VALUES (@firstName, @lastName, @age) ";
            cmd.Parameters.AddWithValue("@firstName", person.FirstName);
            cmd.Parameters.AddWithValue("@lastName", person.LastName);
            cmd.Parameters.AddWithValue("@age", person.Age);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        public void AddPeople(List<Person> people)
        {
            foreach(Person p in people)
            {
                AddPerson(p);
            }
        }
    }
}
