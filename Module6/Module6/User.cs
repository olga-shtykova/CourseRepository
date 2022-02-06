using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module6
{
    public class User
    {
		private int age;
		private string login;
		private string email;

		public int Age
		{
			get
			{
				return age;
			}

			private set
			{
				if (value < 18)
				{
					Console.WriteLine("Возраст должен быть не меньше 18");
				}
				else
				{
					age = value;
				}
			}
		}

        public string Login { get
            {
				return login;
            }
            set
            {
				if (login.Length < 3)
					Console.WriteLine("Поле логина должно быть не менее 3 символов длиной.");
				login = value;
            }
		}

        public string Email { get 
			{ 
				return email;
			}
			set 
			{
				if (!email.Contains('@'))
					Console.WriteLine("Поле почты должно содержать знак @.");
				email = value;
			} 
		}
    }
}
