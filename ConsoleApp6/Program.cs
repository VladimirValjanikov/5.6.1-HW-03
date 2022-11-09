using System;

namespace ConsoleApp6
{
	internal class Program
	{
		static string[] Pets(int amountPets)
		{
			string[] pets = new string[amountPets];
			for (int i = 0; i < pets.Length; i++)	
			{
				Console.WriteLine("Введите кличку {0} питомца: ", i + 1);
				pets[i] = Console.ReadLine();
			}
			return pets;
		}
		static string[] Colors(int amountColors)
		{
			string[] colors = new string[amountColors];
			for (int i = 0; i < colors.Length; i++)
			{
				Console.WriteLine("Введите ваш {0} любимый цвет:", i + 1);
				colors[i] = Console.ReadLine();
			}
			return colors;
		}
		static bool CheckInput(string check, out int num)
		{
			if (int.TryParse(check, out int number))
			{
				if (number > 0)				
					num = number;
				else
				{
					num = 0;
					return true;
				}
				return false;
			}
			else
			{
				Console.WriteLine("Некорректный ввод!");
				num = 0;
				return true;
			}
		}
		static (string Name, string LastName, int Age, string[] pets, string[] favcolors) GetUserInfo()
		{
			(string Name, string LastName, int Age, string[] pets, string[] favcolors) User;
			
			Console.WriteLine("Введите имя:");
			User.Name = Console.ReadLine();

			Console.WriteLine("Введите фамилию:");
			User.LastName = Console.ReadLine();

			string age;
			int intage;
			do
			{
				Console.WriteLine("Введите возраст:");
				age = Console.ReadLine();

			} while (CheckInput(age, out intage));
			User.Age = intage;

			string hasPet;
			do
			{
				Console.WriteLine("У вас есть питомцы? Да/Нет");
				hasPet = Console.ReadLine();
				if (hasPet == "Да")
				{
					string amountPets;
					int intAmountPets;
					do
					{
						Console.WriteLine("Сколько у вас питомцев?");
						amountPets = Console.ReadLine();

					} while (CheckInput(amountPets, out intAmountPets));
					User.pets = Pets(intAmountPets);
				}
				else if (hasPet == "Нет")
					User.pets = new string[0];
				else
				{
					User.pets = new string[0];
					Console.WriteLine("Введите Да/Нет");
				}
			} while (hasPet != "Да" && hasPet != "Нет");
			
			string amountColors;
			int intAmountColors;
			do
			{
				Console.WriteLine("Сколько у вас любимых цветов?");
				amountColors = Console.ReadLine();

			} while (CheckInput(amountColors, out intAmountColors));
			User.favcolors = Colors(intAmountColors);		
			
			return User;
		}
		static void PrintUserInfo((string Name, string LastName, int Age, string[] pets, string[] favcolors) User)
		{
			Console.WriteLine("Имя: " + User.Name);
			Console.WriteLine("Фамилия: " + User.LastName);
			Console.WriteLine("Возраст: " + User.Age);
			if (User.pets.Length > 0)
			{
				if (User.pets.Length == 1)				
					Console.WriteLine("Кличка питомца:");
				else Console.WriteLine("Клички питомцев:");
				foreach (var pet in User.pets)
				{
					Console.WriteLine(pet);
				}
			}
			if (User.favcolors.Length == 1)
				Console.WriteLine("Любимый цвет:");
			else Console.WriteLine("Любимые цвета:");
			foreach (var color in User.favcolors)
			{
				Console.WriteLine(color);
			}
		}
		static void Main(string[] args)
		{
			PrintUserInfo(GetUserInfo());
			Console.ReadLine();
		}
	}
}
