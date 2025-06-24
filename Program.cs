using System;
using System.Collections.Generic;
using System.Linq;
using ContactApp.Models;

namespace ContactApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();

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
                    if (contacts.Any(x => x.ContactId == c.ContactId))
                    {
                        Console.WriteLine($"A contact with ID {c.ContactId} already exists.");
                        continue;
                    }
                    c.Name = Console.ReadLine();
                    c.Age = int.Parse(Console.ReadLine());
                    c.Gender = Console.ReadLine();
                    c.PhoneNumber = Console.ReadLine();
                    c.Email = Console.ReadLine();
                    contacts.Add(c);
                    Console.WriteLine("Contact added successfully.");
                }
                else if (choice == "2")
                {
                    int id = int.Parse(Console.ReadLine());
                    var c = contacts.FirstOrDefault(x => x.ContactId == id);
                    if (c == null) Console.WriteLine("Contact not found.");
                    else
                    {
                        c.Name = Console.ReadLine();
                        c.Age = int.Parse(Console.ReadLine());
                        c.Gender = Console.ReadLine();
                        c.PhoneNumber = Console.ReadLine();
                        c.Email = Console.ReadLine();
                        Console.WriteLine("Contact updated successfully.");
                    }
                }
                else if (choice == "3")
                {
                    int id = int.Parse(Console.ReadLine());
                    var c = contacts.FirstOrDefault(x => x.ContactId == id);
                    if (c == null) Console.WriteLine("Contact not found.");
                    else
                    {
                        contacts.Remove(c);
                        Console.WriteLine("Contact deleted successfully.");
                    }
                }
                else if (choice == "4")
                {
                    if (contacts.Count == 0) Console.WriteLine("No contacts available.");
                    else
                    {
                        Console.WriteLine("Contact List:");
                        foreach (var c in contacts) c.DisplayContactDetails();
                    }
                }
                else if (choice == "5")
                {
                    foreach (var c in contacts.OrderBy(x => x.ContactId)) c.DisplayContactDetails();
                }
                else if (choice == "6")
                {
                    foreach (var c in contacts.OrderBy(x => x.Name)) c.DisplayContactDetails();
                }
                else if (choice == "7")
                {
                    int id = int.Parse(Console.ReadLine());
                    var c = contacts.FirstOrDefault(x => x.ContactId == id);
                    if (c == null) Console.WriteLine("Contact not found.");
                    else c.DisplayContactDetails();
                }
                else if (choice == "8")
                {
                    string name = Console.ReadLine();
                    var found = contacts.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (found.Count == 0) Console.WriteLine("No contact found.");
                    else foreach (var c in found) c.DisplayContactDetails();
                }
                else if (choice == "9")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }
}
