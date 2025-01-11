namespace PayTransaction.Utils.Models.Account;

public record AccountExpected(int Id, double Balance)
{
    public bool Active => true;
    public DateOnly CreatedOn => DateOnly.FromDateTime(DateTime.Now);
}