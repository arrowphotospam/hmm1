namespace DotnetApp.Models
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
}
