using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using Persons.DataModel;

namespace Persons.Lib
{
    public class DB
    {
        private MySqlConnection _db;
        private MySqlCommand _command;

        public DB()
        {
            _db = new MySqlConnection(GetConnectionString());
            _command = new MySqlCommand { Connection = _db };
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
            _command.CommandText = "SELECT id, first_name, last_name, age, is_delete FROM tab_persons";
            var result = _command.ExecuteReader();
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

        public bool UpdatePerson(Person person)
        {
            _db.Open();
            _command.CommandText = @$"UPDATE tab_persons 
                                        SET first_name = {person.FirstName}, 
                                            last_name = {person.LastName}, 
                                            age = {person.Age},
                                            is_delete = {person.IsDelete}
                                         WHERE id = {person.Id}";
            var result = _command.ExecuteNonQuery();
            return result == 1;
        }
    }
}