using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double,Person> phoneBook = new Dictionary<double, Person>();
            do
            {
                Console.Write("Please enter a number from the selection below:\n" +
                    "1)Add new Number\n"+
                    "2)Search by First Name\n" +
                    "3)Search by Last Name\n" +
                    "4)Search by City\n"+
                    "5)Delete by First Name\n"+
                    "6)Sort the list by contact's first name\n"+
                    "7)Exit\n");

                Person andrew = new Person();
                try {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter Phone Number then information to add a person");
                                do
                                {
                                    try
                                    {
                                        double phoneNumber = Convert.ToDouble(Console.ReadLine());

                                        phoneBook.Add(phoneNumber, MakePerson(phoneNumber));
                                        Console.WriteLine("Added");
                                    }
                                    catch { Console.WriteLine("Something went wrong please try agian"); }

                                    Console.WriteLine("Please enter another phone number or stop to stop");
                                } while (Console.ReadLine() != "stop");
                                Console.WriteLine();
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Who would you like to find: ");
                                string nameToFind = Console.ReadLine();
                                foreach (Person person in phoneBook.Values)
                                {
                                    if (person.firstName .Equals(nameToFind))
                                    {
                                        DisplayPerson(person);
                                    }

                                }
                                Console.WriteLine();
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Who would you like to find: ");
                                string lastNameToFind = Console.ReadLine();
                                foreach (Person person in phoneBook.Values)
                                {
                                    if (person.lastName.Equals(lastNameToFind))
                                    {
                                        DisplayPerson(person);
                                    }
                                }
                                Console.WriteLine();
                                break;
                            }
                        case 4:
                            {
                                Console.Write("Which City do you want to search for: ");
                                string cityToFind = Console.ReadLine();
                                foreach (Person person in phoneBook.Values)
                                {
                                    if (person.address.city.Equals(cityToFind))
                                    {
                                        DisplayPerson(person);
                                    }
                                }
                                Console.WriteLine();
                                break;
                            }
                        case 5:
                            {
                                Console.Write("Who would you like to delete: ");
                                string nameToFind = Console.ReadLine();
                                Dictionary<double,Person> tempHastable = phoneBook;
                                foreach (Person person in phoneBook.Values)
                                {
                                    if (person.firstName.Equals(nameToFind))
                                    {
                                        tempHastable.Remove(person.phoneNumber);
                                    }

                                }
                                phoneBook = tempHastable;
                                Console.WriteLine();
                                break;
                            }
                        case 6:
                            {
                                var orderedPhoneBookByFirstName = phoneBook.OrderBy(b => b.Value.firstName).Select(b=>b.Value);
                                foreach (Person person in orderedPhoneBookByFirstName)
                                {
                                    DisplayPerson(person);
                                }
                                Console.WriteLine();
                                break;
                            }                            
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input. please try again.\n");
                            break;
                    }
                }
                catch { Console.WriteLine("Something went wrong please try again."); }
            } while (true);
                
            
        }

        public static Person MakePerson(double phoneNumber)
        {
            Person person = new Person();
            person.phoneNumber = phoneNumber;
            Console.Write("First Name: ");
            person.firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            person.lastName = Console.ReadLine();
            Console.WriteLine("Address:");
            Console.Write("Street: ");
            person.address.street = Console.ReadLine();
            Console.Write("City: ");
            person.address.city = Console.ReadLine();
            Console.Write("Zip Code: ");
            person.address.zipCode = Console.ReadLine();


            return person;
        }

        public static void DisplayPerson(Person person)
        {
            Console.WriteLine("Phone Number: " + person.phoneNumber);
            Console.WriteLine("First Name: "+person.firstName);
            Console.WriteLine("Last Name: "+person.lastName);
            Console.WriteLine("Address:");
            Console.WriteLine("Street: "+person.address.street);
            Console.WriteLine("City: "+person.address.city);
            Console.WriteLine("Zip Code: "+person.address.zipCode);
        }
    }

    class Person
    {
        public Address address= new Address();
        public string firstName, lastName;
        public double phoneNumber;
    }

    class Address
    {
        public string street;
        public string city;
        public string zipCode;
    }
}
