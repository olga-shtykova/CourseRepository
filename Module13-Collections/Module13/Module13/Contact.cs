namespace ListExample
{
    public class Contact
    {
        public string Name { get; }
        public long PhoneNumber { get; }
        public string Email { get; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
