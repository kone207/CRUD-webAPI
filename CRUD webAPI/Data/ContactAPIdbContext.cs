using CRUD_webAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_webAPI.Data
{
    public class ContactAPIdbContext : DbContext
    {
        public ContactAPIdbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
