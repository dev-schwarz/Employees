namespace Employees.Entities
{
	internal class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public double Salary { get; set; }

		public Employee() { }

		public Employee(int id, string name, string email, double salary)
		{
			Id = id;
			Name = name;
			Email = email;
			Salary = salary;
		}
	}
}
