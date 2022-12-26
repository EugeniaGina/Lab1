namespace Lab1CSharp
{
    class Program
    {
        private static void Main()
        {
            string[] positions = { Position.Manager.ToString(), Position.Handyman.ToString(), Position.Manager.ToString(), Position.Director.ToString(), Position.Manager.ToString() };
            Employee edwardEmp = new Employee("Edward", Position.Handyman, positions, "GG"); // Initialize constructor
            Console.WriteLine($"Before change {edwardEmp.Position}, {edwardEmp.DepartmentName}");
            edwardEmp.SetPosition(Position.Director, "2C"); // Position Change
            Console.WriteLine($"After change {edwardEmp.Position}, {edwardEmp.DepartmentName}");
            edwardEmp.GiveSalary(); // Salary give method
            edwardEmp.GiveSalary();
            Console.WriteLine($"Edward`s balance after he got 2 salaries as {edwardEmp.Position}, ({(decimal)edwardEmp.Position}) BALANCE: {edwardEmp.Balance}");
            var queryResult = edwardEmp.GetPositionsFromHistoryBy(Position.Manager.ToString()); // Query Method
            Console.WriteLine("Edwards history as manager");
            foreach (var item in queryResult.AllMatchPositionsInHistory)
            {
                Console.WriteLine($"{item}, department {queryResult.CurrentDepartment}");
            }
            Console.WriteLine("To string");
            Console.WriteLine(edwardEmp.ToString());
            Employee alexEmp = new Employee("Alex", Position.Engineer, positions, "4B");
            Console.WriteLine(new String('-', 50));
            alexEmp.ToString();
            Console.WriteLine($"Comparing Alex ({alexEmp.Position}) and Edward ({edwardEmp.Position})");
            Console.WriteLine(alexEmp > edwardEmp);
            Console.WriteLine(alexEmp < edwardEmp);
            Console.WriteLine(alexEmp == edwardEmp);
            Console.WriteLine(alexEmp >= edwardEmp);
            Console.WriteLine(alexEmp <= edwardEmp);
        }
    }
}