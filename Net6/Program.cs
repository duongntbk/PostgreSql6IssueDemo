DbContext dbContext = null;

if (args.Length != 1 || args[0] != "fixed")
{
    dbContext = DomainContext.Create(CONSTR);
}
else
{
    dbContext = DomainContextFixed.Create(CONSTR);
}

var baby = await dbContext.Set<Person>().SingleOrDefaultAsync(p => p.Name == "Baby Doe");
baby.NickName = Guid.NewGuid().ToString();
dbContext.Set<Person>().Update(baby);
await dbContext.SaveChangesAsync();
Console.WriteLine("Success...");