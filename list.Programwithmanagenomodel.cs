using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void DisplayContactDetails()
        {
            Console.WriteLine($"Contact ID: {ContactId}, Name: {Name}, Age: {Age}, Gender: {Gender}, Phone Number: {PhoneNumber}, Email: {Email}");
        }
    }

    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();

        public void Add(Contact c)
        {
            if (contacts.Any(x => x.ContactId == c.ContactId))
            {
                Console.WriteLine($"A contact with ID {c.ContactId} already exists.");
                return;
            }
            contacts.Add(c);
            Console.WriteLine("Contact added successfully.");
        }

        public void Update(int id)
        {
            var c = contacts.FirstOrDefault(x => x.ContactId == id);
            if (c == null) { Console.WriteLine("Contact not found."); return; }

            c.Name = Console.ReadLine();
            c.Age = int.Parse(Console.ReadLine());
            c.Gender = Console.ReadLine();
            c.PhoneNumber = Console.ReadLine();
            c.Email = Console.ReadLine();

            Console.WriteLine("Contact updated successfully.");
        }

        public void Delete(int id)
        {
            var c = contacts.FirstOrDefault(x => x.ContactId == id);
            if (c == null) { Console.WriteLine("Contact not found."); return; }

            contacts.Remove(c);
            Console.WriteLine("Contact deleted successfully.");
        }

        public void List()
        {
            if (contacts.Count == 0) Console.WriteLine("No contacts available.");
            else foreach (var c in contacts) c.DisplayContactDetails();
        }

        public void SortById() => contacts.OrderBy(x => x.ContactId).ToList().ForEach(c => c.DisplayContactDetails());
        public void SortByName() => contacts.OrderBy(x => x.Name).ToList().ForEach(c => c.DisplayContactDetails());
        public void SearchById(int id)
        {
            var c = contacts.FirstOrDefault(x => x.ContactId == id);
            if (c == null) Console.WriteLine("Contact not found.");
            else c.DisplayContactDetails();
        }

        public void SearchByName(string name)
        {
            var found = contacts.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (found.Count == 0) Console.WriteLine("No contact found.");
            else foreach (var c in found) c.DisplayContactDetails();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ContactManager manager = new ContactManager();

            while (true)
            {
                Console.WriteLine("1 - Add Contact");
                Console.WriteLine("2 - Update Contact");
                Console.WriteLine("3 - Delete Contact");
                Console.WriteLine("4 - List Contacts");
                Console.WriteLine("5 - Sort by ID");
                Console.WriteLine("6 - Sort by Name");
                Console.WriteLine("7 - Search by ID");
                Console.WriteLine("8 - Search by Name");
                Console.WriteLine("9 - Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Contact c = new Contact();
                    c.ContactId = int.Parse(Console.ReadLine());
                    c.Name = Console.ReadLine();
                    c.Age = int.Parse(Console.ReadLine());
                    c.Gender = Console.ReadLine();
                    c.PhoneNumber = Console.ReadLine();
                    c.Email = Console.ReadLine();
                    manager.Add(c);
                }
                else if (choice == "2") manager.Update(int.Parse(Console.ReadLine()));
                else if (choice == "3") manager.Delete(int.Parse(Console.ReadLine()));
                else if (choice == "4") manager.List();
                else if (choice == "5") manager.SortById();
                else if (choice == "6") manager.SortByName();
                else if (choice == "7") manager.SearchById(int.Parse(Console.ReadLine()));
                else if (choice == "8") manager.SearchByName(Console.ReadLine());
                else if (choice == "9") { Console.WriteLine("Exiting..."); break; }
                else Console.WriteLine("Invalid choice");
            }
        }
    }
}
