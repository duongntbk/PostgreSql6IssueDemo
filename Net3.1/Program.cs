using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Common.Constants;

namespace Net31
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var dbContext = DomainContext.Create(CONSTR);
            var baby = await dbContext.People.SingleOrDefaultAsync(p => p.Name == "Baby Doe");
            
            baby.Dob = DateTime.Now;
            dbContext.Set<Person>().Update(baby);
            await dbContext.SaveChangesAsync();

            Console.WriteLine("Success...");
        }
    }
}
