using ATMApp.Domain.Entities;
using ATMApp.Domain.Interfaces;
using ATMApp.UI;
using System;

namespace ATMApp.App
{
    public class ATM : IUserLogin
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
            switch(Validator.Convert<int>("an option: "))
            {
                case (int)AppMenu.CheckBalance:
                    Console.WriteLine("Checking account balance ..");
                    break;
                case (int)AppMenu.PlaceDeposit:
                    Console.WriteLine(" Make Deposits  ..");
                    break;
                case (int)AppMenu.MakeWithdrawals:
                    Console.WriteLine(" Extracting Money ..");
                    break;
                case (int)AppMenu.Internal_Transfer:
                    Console.WriteLine("Making internal transfer ..");
                    break;
                case (int)AppMenu.ViewTransaction:
                    Console.WriteLine("Checking account balance ..");
                    break;
                case (int)AppMenu.Logout:
                    Appscreen.LogoutProgress();
                    Utility.printMessage("you have succsully logged out , colect your ATM card ", true);
                    break;
                default:
                    Console.WriteLine("default action ...");
                    break;
                
            }
        }

    }

}

        

    
