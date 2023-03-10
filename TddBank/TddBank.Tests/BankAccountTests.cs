namespace TddBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_account_should_have_zero_as_balance()
        {
            var ba = new BankAccount();

            var result = ba.Balance;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Deposit_adds_to_balance()
        {
            var ba = new BankAccount();

            ba.Deposit(3m);
            ba.Deposit(4m);

            Assert.Equal(7m, ba.Balance);
        }

        [Fact]
        public void Deposit_more_than_MAX_should_throw_OverflowException()
        {
            var ba = new BankAccount();

            ba.Deposit(decimal.MaxValue);

            Assert.Throws<OverflowException>(() => ba.Deposit(1m));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Deposit_a_negative_or_zero_value_throws_ArgumentException(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(value));
        }

        [Fact]
        public void Withdraw_should_reduce_from_balance()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            ba.Withdraw(4m);
            ba.Withdraw(3m);

            Assert.Equal(5m, ba.Balance);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Withdraw_a_negative_value_throws_ArgumentException(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(value));
        }

        [Fact]
        public void Withdraw_more_than_Balance_throws_InvalidOperationException()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(13m));
        }
    }
}