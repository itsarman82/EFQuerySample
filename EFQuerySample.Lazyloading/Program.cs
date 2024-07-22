using System.Threading.Channels;
using EFQuerySample.Lazyloading;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<LazyDbContex>();
// optionBuilder.LogTo(Console.WriteLine);
optionBuilder.UseSqlServer("Server=.; Database=LazyLoadingDB; TrustServerCertificate=True;MultipleActiveResultSets=True; User Id=sa; Password=armanz582");
optionBuilder.UseLazyLoadingProxies();

using LazyDbContex ctx = new LazyDbContex(optionBuilder.Options);

var people  = ctx.People;

foreach (var person in people)
{
    Console.WriteLine($"{person.Id}, {person.Name}");

    foreach (var personAddress in person.Addresses)
    {
        Console.WriteLine($"{person.Id} {person.Name}");
    }
}