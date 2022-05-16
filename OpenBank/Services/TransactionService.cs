using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using OpenBank.Enums;
using OpenBank.Models.DB;
using OpenBank.Request;
using OpenBank.Response;

namespace OpenBank.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BankSystemContext _context;

        public TransactionService(BankSystemContext context)
        {
            _context = context;
        }

        public Result TransferToAccount(TransferToAccountRequest request)
        {
            try
            {
                _context.TransactionHistories.Add(new TransactionHistory
                {
                    Amount = request.Amount,
                    TransactionDate = DateTime.Now,
                    BankAccountId = request.SenderBankAccountId,
                    SenderBankAccountId = null,
                    TransactionTypeId = (int)TransactionTypeEnum.OutgoingTransfer
                });
                var senderAccount = _context.BankAccounts.FirstOrDefault(account => account.Id == request.SenderBankAccountId);
                if (senderAccount != null)
                {
                    if (senderAccount.Balance < request.Amount)
                    {
                        return Result.Failure("Insufficient Balance");
                    }
                    senderAccount.Balance -= request.Amount;
                }
                _context.TransactionHistories.Add(new TransactionHistory
                {
                    Amount = request.Amount,
                    TransactionDate = DateTime.Now,
                    BankAccountId = request.ReciverBankAccountId,
                    SenderBankAccountId = request.SenderBankAccountId,

                    TransactionTypeId = (int)TransactionTypeEnum.IncomingTransfer
                });
                var receiverAccount = _context.BankAccounts.FirstOrDefault(account => account.Id == request.ReciverBankAccountId);
                if (receiverAccount != null)
                {
                    receiverAccount.Balance += request.Amount;
                }
                if (senderAccount == null || receiverAccount == null)
                {
                        return Result.Failure("Invalid Account");
                }
                _context.SaveChanges();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
        public Result<List<TransferHistoryresponse>> GetTransferHistoryByAccountId(int bankAccountId)
        {
            try
            {
                var account = _context.BankAccounts.FirstOrDefault(account => account.Id == bankAccountId);
                if (account == null)
                    return Result.Failure<List<TransferHistoryresponse>>("Invalid Account");
                
                var transactionHistories = _context.TransactionHistories.Include(transaction => transaction.TransactionType)
                                                   .Include(ba => ba.BankAccount)
                                                   .Include(transaction => transaction.SenderBankAccount)
               .Where(transaction => transaction.BankAccountId == bankAccountId)
               .Select(s => new TransferHistoryresponse()
               {
                   Amount = s.Amount,
                   TransactionDate = s.TransactionDate,
                   TransactionType = s.TransactionType.Name
               }).OrderBy(s => s.TransactionDate).ToList();
               
                return transactionHistories;
            }
            catch (Exception ex)
            {
                return Result.Failure<List<TransferHistoryresponse>>(ex.Message);
            }
           
        }

    }


}