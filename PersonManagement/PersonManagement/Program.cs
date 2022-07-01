using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {
        public static List<Person> persons { get; set; } = new List<Person>();
        static void Main(string[] args)
        {


            Console.WriteLine("Our available commands :");
            Console.WriteLine("/add-new-person");
            Console.WriteLine("/remove-person");
            Console.WriteLine("/show-persons");
            Console.WriteLine("/remove-all-persons");
            Console.WriteLine("/remove-person-by-id");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/add-new-person")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add person's FIN code :");
                    string fin = Console.ReadLine();

                    AddNewPerson(name, lastName, fin);



                }
                else if (command == "/remove-person-by-fin")
                {
                    Console.Write("To remove person, please enter his/her FIN code : ");
                    string fin = Console.ReadLine();
                    RemovePerson(fin);            
                        
                 }
                else if(command == "/remove-person-by-id")
                {
                    Console.Write("To remove person, please enter his/her id code : ");
                    uint id = Convert.ToUInt32(Console.ReadLine());
                    RemovePerson(id);

                }
                else if (command == "/show-persons")
                {
                    Console.WriteLine("Persons in database : ");
                    ShowPersons();


                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else if (command == "/remove-all-persons")
                {
                    RemoveAll();
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }
        }
        public static void AddNewPerson(string name, string lastName, string fin)
        {
            Person person = new Person(name, lastName, fin);
            persons.Add(person);

        }
        public static void ShowPersons()
        {

            foreach (Person person in persons)
            {
                Console.WriteLine(person.GetInfo());
            }
        }
        public static void RemovePerson(string fin)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].FIN == fin)
                {
                    Console.WriteLine(persons[i].GetInfo());
                    persons.RemoveAt(i);
                    Console.WriteLine("Person removed successfully");
                }
            }
        }
        public static void RemovePerson(uint id)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].id == id)
                {
                    Console.WriteLine(persons[i].GetInfo());
                    persons.RemoveAt(i);
                    Console.WriteLine("Person removed successfully");
                }
            }
        }
        public static void RemoveAll()
        {
            for (int i = 0; i <= persons.Count; i++)
            {
                persons.RemoveAt(0);
            }
            Console.WriteLine("All user remove");
        }
    }

    class Person
    {
        public static uint _idcounter = 1;
        public uint id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FIN { get; set; }

        public Person(string name, string lastName, string fin)
        {
            id = _idcounter;
            Name = name;
            LastName = lastName;
            FIN = fin;
            _idcounter++;
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public string GetInfo()
        {
            return Name + " " + LastName + " " + FIN + "" +id;
        }
    }
}
