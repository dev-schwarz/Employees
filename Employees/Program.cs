using Employees.Entities;
using System.Globalization;

namespace Employees
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ReadEmployeesFile();
		}

		static void ReadEmployeesFile()
		{
			// Substituir pelo caminho do arquivo a ser lido.
			string filePath = @"D:\Projects\Employees\Employees\employees.txt";

			// Create a new list of Employees.
			List<Employee> employees = new();

			try
			{
				using (StreamReader sr = File.OpenText(filePath))
				{
					while (!sr.EndOfStream)
					{
						// an array with comma separated values
						// e.g.: [ 1, "Maria", "maria@gmail.com", 3200.0 ]
						string[] line = sr.ReadLine().Split(',');

						int id = int.Parse(line[0]);
						string name = line[1];
						string email = line[2];
						double salary = double.Parse(line[3], CultureInfo.InvariantCulture);

						// Create a new Employee.
						Employee employee = new(id, name, email, salary);

						// Add the new Employee to the list.
						employees.Add(employee);
					}
				}
			}
			catch (IOException e)
			{
				Console.WriteLine("Error reading file: " + e.Message);
			}

			// All Employees already in the list.
			// Let'a print some data.

			Console.Write("Enter minimum salary (only numbers): ");
			double minSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			// Printing the Names from people with salary bigger than 'minSalary'.
			var filter = employees
				.Where(e => e.Salary >= minSalary)
				.OrderBy(e => e.Name)
				.Select(e => e.Name);
			Console.WriteLine("Names from people whose salary is bigger than "
				+ minSalary.ToString("F2", CultureInfo.InvariantCulture)
				+ ":");
			foreach (string name in filter)
			{
				Console.WriteLine(name);
			}

			// Salaries sum of employees whose name starts with letter 'm'.
			var salariesSum = employees
				.Where(e => e.Name[0].ToString().ToLower() == "m")
				.Sum(e => e.Salary);
			Console.WriteLine();
			Console.WriteLine("Sum of salary of people whose Name starts with 'M': "
				+ salariesSum.ToString("F2", CultureInfo.InvariantCulture));
		}
	}
}