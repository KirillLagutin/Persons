using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using Persons.DataModel;

namespace Persons.Lib
{
    public class DB
    {
        private MySqlConnection _db;

        public DB()
        {
            _db = new MySqlConnection(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            using var file = new StreamReader("connect_to_db.ini");
            return file.ReadToEnd();
        }

        public List<Person> GetAllPersons()
        {
            var persons = new List<Person>();
            
            _db.Open();
            var command = new MySqlCommand()
            {
                Connection = _db,
                CommandText = "SELECT * FROM tab_persons"
            };
            var result = command.ExecuteReader();
            while (result.Read())
            {
                var person = new Person
                {
                    Id = result.GetInt32("id"),
                    FirstName = result.GetString("first_name"),
                    LastName = result.GetString("last_name"),
                    Age = result.GetInt32("age"),
                    IsDelete = result.GetBoolean("is_delete")
                };
                persons.Add(person);
            }
            
            _db.Close();

            return persons;
        }
    }
}