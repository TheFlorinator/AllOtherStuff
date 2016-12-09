using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithDrawRules
{
    public class FreeAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error a non-free account hit the Free Withdraw Rule. Contact IT";
                return response;
            }
            else if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must me a negative!";
                return response;
            }
            else if (amount < -100)
            {
                response.Success = false;
                response.Message = "Free accounts cannot withdraw more than $100!";
                return response;
            }
            else if (account.Balance + amount < 0)
            {
                response.Success = false;
                response.Message = "Free accounts cannot overdraft";
                return response;
            }
            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;

            return response;

        }
    }
}
