DbContext dbContext = null;

if (args.Length != 1 ||
    (args[0] != "fixed" && args[0] != "legacy"))
{
    dbContext = DomainContext.Create(CONSTR);
}
else if (args[0] == "fixed")
{
    dbContext = DomainContextFixed.Create(CONSTR);
}
else
{
    dbContext = DomainContextLegacy.Create(CONSTR);
}

var baby = await dbContext.Set<Person>().SingleOrDefaultAsync(p => p.Name == "Baby Doe");
baby.NickName = Guid.NewGuid().ToString();
dbContext.Set<Person>().Update(baby);
await dbContext.SaveChangesAsync();
Console.WriteLine("Success...");