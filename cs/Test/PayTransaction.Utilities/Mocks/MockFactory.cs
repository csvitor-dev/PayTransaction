using Bogus;

namespace PayTransaction.Utils.Mocks;

public abstract class MockFactory
{
    protected static readonly Faker Faker = new();
}