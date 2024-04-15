
namespace MyContacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>
        {
            new Contact{ ContactId=1, Name ="Srinu", Email ="srinu@gmail.com"},
            new Contact{ ContactId=2, Name ="teja",  Email ="teja@gmail.com"},
            new Contact{ ContactId=3, Name ="sai",   Email ="sai@gmail.com"},
            new Contact{ ContactId=4, Name ="Anvesh", Email ="Anvesh@gmail.com"},
            };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if(contact != null)
            {
                return new Contact
                {
                    ContactId = contactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Address = contact.Address,
                    Phone = contact.Phone
                };
            }
            return null;

        } 

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if(contactToUpdate != null)
            {
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Phone = contact.Phone;
            }
        }

    }   

}
