using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoApp.Migrations
{
    public partial class SeedDatabase : Migration
    {                    
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Makes (Name) values ('Make1')");
            migrationBuilder.Sql("insert into Makes (Name) values ('Make2')");
            migrationBuilder.Sql("insert into Makes (Name) values ('Make3')");

            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make1-ModelA', (select Id from Makes where Name='Make1'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make1-ModelB', (select Id from Makes where Name='Make1'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make1-ModelC', (select Id from Makes where Name='Make1'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make1-ModelD', (select Id from Makes where Name='Make1'))");

            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make2-ModelA', (select Id from Makes where Name='Make2'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make2-ModelB', (select Id from Makes where Name='Make2'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make2-ModelC', (select Id from Makes where Name='Make2'))");

            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make3-ModelA', (select Id from Makes where Name='Make3'))");
            migrationBuilder.Sql("insert into Models (Name, MakeId) values ('Make3-ModelB', (select Id from Makes where Name='Make3'))");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Makes where Name in ('Make1', 'Make2', 'Make3')");
        }
    }
}
