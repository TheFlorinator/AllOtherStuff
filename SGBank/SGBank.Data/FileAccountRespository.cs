using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRespository : IAccountRepository
    {
        public Account LoadAccount(string accountNumber)
        {
            return ListOfAccounts().FirstOrDefault(f => f.AccountNumber == accountNumber);
        }

        public void SaveAccount(Account account)
        {
            var newAccounts = ListOfAccounts();
            var oldAccount = newAccounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);
            oldAccount.Balance = account.Balance;
            StreamWriter sw = new StreamWriter("Accounts.txt", false);
            foreach (var a in newAccounts)
            {
                sw.WriteLine("{0},{1},{2},{3}", a.AccountNumber, a.Name, a.Balance, a.Type.ToString().Substring(0,1));
            }
        }

        private List<Account> ListOfAccounts()
        {
            List<Account> accountList = new List<Account>();
            using (StreamReader reader = new StreamReader("Accounts.txt"))
            {
                Account account = new Account();
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    string[] splitsLines = lines.Split(',');
                    decimal number = Decimal.Parse(splitsLines[2]);

                    account = new Account();
                    account.AccountNumber = splitsLines[0];
                    account.Name = splitsLines[1];
                    account.Balance = number;

                    if (splitsLines[3] == "F")
                    {
                        account.Type = AccountType.Free;
                    }
                    else if (splitsLines[3] == "B")
                    {
                        account.Type = AccountType.Basic;
                    }
                    else if (splitsLines[3] == "P")
                    {
                        account.Type = AccountType.Premium;
                    }
                    accountList.Add(account);
                }
            }
        return accountList;

        }
    }
}


