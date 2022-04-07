namespace SortedDictionaryExample
{
    public class Contact
    {
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(long phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
