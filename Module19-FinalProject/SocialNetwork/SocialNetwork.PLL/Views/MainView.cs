using System;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("To login (press 1)");
            Console.WriteLine("To register (press 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program._authenticationView.Show();
                        break;
                    }

                case "2":
                    {
                        Program._registrationView.Show();
                        break;
                    }
            }
        }
    }
}
