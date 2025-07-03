using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Domain.Interfaces
{
    internal interface IUserAcountActions
    {
        void CheckBalance();
        void PlaceDeposit();
        void MakeWithdrawals();
        
    }
}
