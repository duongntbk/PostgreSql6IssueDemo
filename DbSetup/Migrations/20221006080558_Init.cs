namespace DbSetup.Migrations;

public partial class Init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Person",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: false),
                NickName = table.Column<string>(type: "text", nullable: true),
                Dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Person", x => x.Id);
            });

        migrationBuilder.Sql("INSERT INTO \"Person\" (\"Name\", \"NickName\", \"Dob\") VALUES" +
            "('John Doe', 'Big Daddy', '1980-01-01T01:00:00.000000')," +
            "('Jane Doe', 'Big Mommy', '1981-01-01T01:00:00.000000')," +
            "('Baby Doe', 'Little Sister', '2010-01-01T01:00:00.000000')");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Person");
    }
}
