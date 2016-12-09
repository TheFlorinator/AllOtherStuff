﻿using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithDrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = "Error: a non-basic account hit the Basic Withdraw Rule. Contact IT";
                return response;
            }
            else if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdraw amounts must be negative!";
                return response;
            }
            else if (amount < -500)
            {
                response.Success = false;
                response.Message = "Basic accounts cannot withdraw more than $500";
                return response;
            }
            else if (account.Balance + amount < -100)
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit";
                return response;
            }
            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;

            if (account.Balance <= -1)
            {
                account.Balance -= 10;
                response.Message = "You have been charged $10 for an overdraft fee";
                return response;
            }
            return response;

        }
    }
}
