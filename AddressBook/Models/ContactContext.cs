using Microsoft.EntityFrameworkCore;

namespace AddressBook.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
                : base(options)
        { }

        public DbSet<Contact> Contact { get; set; }
    }
}
