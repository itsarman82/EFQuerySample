using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFQuerySample.Lazyloading
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
    }

    public class LazyDbContex : DbContext
    {
        public DbSet<Person> People { get; set; }
        public LazyDbContex(DbContextOptions<LazyDbContex> options) : base(options)
        {
            
        }
    }
}
