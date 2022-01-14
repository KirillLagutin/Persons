using System;
using System.Collections.Generic;
using Persons.DataModel;
using Persons.Lib;

namespace Persons.ConsoleTest
{
    internal static class Program
    {
        private static void Main()
        {
            var db = new DB();
            var persons = db.GetAllPersons();
            ShowPersons(persons);

            persons[0].Age = 35;
            db.UpdatePerson(persons[0]);
            ShowPersons(db.GetAllPersons());
        }

        private static void ShowPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Id}: {person.LastName} {person.FirstName}, {person.Age}; is delete: {person.IsDelete}");
            }
        }
    }
}