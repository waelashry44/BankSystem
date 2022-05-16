using CSharpFunctionalExtensions;
using OpenBank.Request;
using OpenBank.Response;

namespace OpenBank.Services
{
    public interface ITransactionService
    {
        Result<List<TransferHistoryresponse>> GetTransferHistoryByAccountId(int bankAccountId);
        Result TransferToAccount(TransferToAccountRequest request);
    }
}