using PayTransaction.Application.Movement;
using PayTransaction.Utils.Models.Movement;

namespace PayTransaction.Utils.Mocks;

public abstract class MovementMockFactory : MockFactory
{
    private static (int, double) GetBaseData()
    {
        var id = Faker.Random.Number(1, 2_000);
        var amount = Faker.Random.Double(100, 1_000);

        return (id, amount);
    }
    public static (AddIncome, MovementExpected) CreateIncomeMock(int accountId)
    {
        var (id, amount) = GetBaseData();
        var expected = new MovementExpected(id, amount);
        
        return (new AddIncome(accountId, id, amount), expected);
    }
    
    public static (AddExpense, MovementExpected) CreateExpenseMock(int accountId)
    {
        var (id, amount) = GetBaseData();
        var expected = new MovementExpected(id, amount);
        
        return (new AddExpense(accountId, id, amount), expected);
    }
    
    public static (AddTransfer, MovementExpected) CreateTransferMock(int accountId)
    {
        var (id, amount) = GetBaseData();
        var expected = new MovementExpected(id, amount);
        
        return (new AddTransfer(accountId, id, amount), expected);
    }
}