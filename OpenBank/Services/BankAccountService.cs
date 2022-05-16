using CSharpFunctionalExtensions;
using OpenBank.Enums;
using OpenBank.Models.DB;
using OpenBank.Request;

namespace OpenBank.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly BankSystemContext _context;

        public BankAccountService(BankSystemContext context)
        {
            _context = context;
        }
        public Result CreateAccount(CreateBankAccountRequest request)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(customer => customer.Id == request.CustomerId);
                if (customer == null)
                {
                    return Result.Failure("Customer Not Found");
                }

                _context.BankAccounts.Add(new BankAccount
                {
                    CustomerId = request.CustomerId,
                    Balance = request.InitialDeposite,
                    TransactionHistoryBankAccounts = {
                new TransactionHistory()
                {
                    TransactionTypeId= (Int32)TransactionTypeEnum.InitialDeposite,
                    TransactionDate=DateTime.Now,
                    Amount=request.InitialDeposite,

                }
                }
                });
                _context.SaveChanges();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }

        }

        public Result<double> GetBankAccountBalance(int accountId)
        {
            try
            {
                var account = _context.BankAccounts.FirstOrDefault(account => account.Id == accountId);
                if (account == null)
                {
                    return Result.Failure<double>("Invalid Account");
                }
                return account.Balance;
            }
            catch (Exception ex)
            {
                return Result.Failure<double>(ex.Message);
            }

        }
    }
}
