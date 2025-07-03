using ATMApp.Domain.Entities;
using ATMApp.Domain.Interfaces;
using ATMApp.UI;
using System;

namespace ATMApp.App
{
    public class ATM : IUserLogin , IUserAcountActions
    {
        private List<UserAccount>? userAccountLists;
        private UserAccount selectedAccounts;

        public void Run()
        {
            CheckUserCardNumPass();
            WelcomeCust();

            
                Appscreen.ShowMenu();
                ProcessMenuOption();
            

            

        }


        public void InitializeData()
        {
            userAccountLists =
            [
                new UserAccount{id=1, FullName = " Ash ", AccountNumber=123456,CardNumber =321321, CardPin=123123,AccountBalance=50000.00m,IsLocked=false},
                new UserAccount{id=2, FullName = "Aslin Dcunha", AccountNumber=010101,CardNumber =654654, CardPin=456456,AccountBalance=4000.00m,IsLocked=false},
                new UserAccount{id=3, FullName = "Darish Dias", AccountNumber=123555,CardNumber =987987, CardPin=789789,AccountBalance=2000.00m,IsLocked=true},
            ];

        }



        public void CheckUserCardNumPass()
        {
            bool isCorrectLogin = false;

            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = Appscreen.UserLoginForm();

                Appscreen.LoginProgress();
                foreach (UserAccount account in userAccountLists)
                {
                    selectedAccounts = account;
                    if (inputAccount.CardNumber.Equals(selectedAccounts.CardNumber))
                    {
                        selectedAccounts.TotalLogin++;
                        
                        if (selectedAccounts.TotalLogin > 3)
                        {
                            Appscreen.PrintLockScreen();
                        }

                        if (inputAccount.CardPin.Equals(selectedAccounts.CardPin))
                        {
                            //selectedAccounts = account;

                            if (selectedAccounts.IsLocked || selectedAccounts.TotalLogin > 3)
                            {
                                Appscreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccounts.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;

                            }
                        }

                    }

                }


            }

            if (isCorrectLogin == false)
            {
                Utility.printMessage("\n Invalid Credentials ", false);
                selectedAccounts.IsLocked = selectedAccounts.TotalLogin == 3;
                if (selectedAccounts.IsLocked == true)
                {
                    Appscreen.PrintLockScreen();
                }

                Console.Clear();

            }
        }

        

            public void WelcomeCust()
        {
            Console.WriteLine($"Welcome back {selectedAccounts.FullName}  ");
        }


        private void ProcessMenuOption()
        {
            bool flag = true;
            while (flag) {
                switch (Validator.Convert<int>("an option: "))
                {
                    case (int)AppMenu.CheckBalance:
                        Console.WriteLine("Checking account balance ..");
                        CheckBalance();
                        break;
                    case (int)AppMenu.PlaceDeposit:
                        Console.WriteLine(" Make Deposits  ..");
                        PlaceDeposit();
                        break;
                    case (int)AppMenu.MakeWithdrawals:
                        Console.WriteLine(" Extracting Money ..");
                        MakeWithdrawals();
                        break;
                    case (int)AppMenu.Internal_Transfer:
                        Console.WriteLine("Making internal transfer ..");
                        //var internalTransfer = Appscreen.InternalTransferForm();
                        break;
                    case (int)AppMenu.Logout:
                        Appscreen.LogoutProgress();
                        flag = false;
                        Utility.printMessage("you have succsully logged out , colect your ATM card ", true);

                        break;
                    default:
                        Console.WriteLine("default action ...");
                        break;

                }
            }

            
        }

        public void CheckBalance()
        {
            Utility.printMessage($" Your Account Balance is  :  { selectedAccounts.AccountBalance }  Rupees ", true);
        }

        public void PlaceDeposit()
        {
            Console.WriteLine("Lets get that money ready , enter the amount you want to deposit ");
            decimal trans_amt = decimal.Parse(Console.ReadLine());
            selectedAccounts.AccountBalance += trans_amt;
            Console.WriteLine($"Money deposited , your current balnce is {selectedAccounts.AccountBalance} Rupees ");
        }

        public void MakeWithdrawals()
        {
            Console.WriteLine(" Enter the amount you want to WithDraw ");
            decimal withdrawal_amt = decimal.Parse(Console.ReadLine());
            selectedAccounts.AccountBalance -= withdrawal_amt;
            Console.WriteLine($"Money deposited , your current balnce is {selectedAccounts.AccountBalance} Rupees ");

        }

        private void ProcessInternalTransfer(InternalTransfer internalTransfer)
        {
            selectedAccounts.AccountBalance -= internalTransfer.TransferAmount;
            internalTransfer.ReciepeintBankAccNum += (long)internalTransfer.TransferAmount;
            Console.WriteLine("You have successfully transferred the amount ");

            Console.WriteLine($" Your account blance : {selectedAccounts.AccountBalance} ");
            

        }
    }

}

        

    
