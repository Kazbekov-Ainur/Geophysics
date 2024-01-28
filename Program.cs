using System;

namespace Geophysics
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int k = 0;
			int L;
			Random random = new Random();

			Console.Write("Введите размерность квадратной области [LxL], L = ");

			while (!int.TryParse(Console.ReadLine(), out L))
			{
				Console.Write("Ошибка ввода!\nВведите целое число L:");
			}

			Console.Clear();
			int[,] array = new int[L, L];

			Console.WriteLine($"Квадратная область {L}х{L}\n"); ;

			for (int i = 0; i < array.GetLength(0); i++) // заполнение таблицы 
			{
				Console.Write(k.ToString("X") + ") ");
				k++;

				for (int j = 0; j < array.GetLength(1); j++)
				{
					int rand = random.Next(1, 101);

					if (rand > 31) // 70%
					{
						array[i, j] = 1;
					}
					else // 30%
					{
						array[i, j] = 0;
					}

					Console.Write(array[i, j] + " ");
				}
				Console.WriteLine();
			}

			int countGroup = 2;
			k = 0;

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (array[i, j] == 1)
					{
						MakeGroup(array, i, j, countGroup.ToString());
						countGroup++;
					}
				}

			}

			Console.Write("\nМатрица с номерами групп\n\n");

			// Вывод результирующий таблицы с номерами групп
			for (int i = 0; i < array.GetLength(0); i++)
			{
				Console.Write(k.ToString("X") + ") ");
				k++;

				for (int j = 0; j < array.GetLength(1); j++)
				{
					Console.Write(array[i, j] + " ");
				}
				Console.WriteLine();
			}

		}
		static void MakeGroup(int[,] array, int i, int j, string valueGroup)
		{
			if (i < 0 || i >= array.GetLength(0) || j < 0 || j >= array.GetLength(1) || array[i, j] != 1)
			{
				return;
			}

			array[i, j] = int.Parse(valueGroup);
			MakeGroup(array, i + 1, j, valueGroup);
			MakeGroup(array, i - 1, j, valueGroup);
			MakeGroup(array, i, j + 1, valueGroup);
			MakeGroup(array, i, j - 1, valueGroup);

		}
	}
}