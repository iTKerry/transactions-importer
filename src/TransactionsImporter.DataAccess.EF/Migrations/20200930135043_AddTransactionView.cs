using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionsImporter.DataAccess.EF.Migrations
{
    public partial class AddTransactionView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create view TransactionView
                as
                select
                        Id=TransactionId,
                        Amount,
                        CurrencyCode=Code,
                        Time=TransactionDate,
                        Status
                from [Transaction]
                join Currency C on C.CurrencyId = [Transaction].CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view TransactionView");
        }
    }
}
