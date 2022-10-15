namespace DbSetup;

[Table("Person")]
public class Person
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public string NickName { get; set; }

    public DateTime Dob { get; set; }
}
