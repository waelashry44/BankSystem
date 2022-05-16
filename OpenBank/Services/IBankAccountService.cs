using CSharpFunctionalExtensions;
using OpenBank.Request;

namespace OpenBank.Services
{
    public interface IBankAccountService
    {
        Result CreateAccount(CreateBankAccountRequest request);
        Result<double> GetBankAccountBalance(int accountId);
    }
}