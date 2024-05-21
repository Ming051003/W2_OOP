

namespace OOP_CS_W2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IEmployee> employees = new List<IEmployee>();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Find highest salary");
                Console.WriteLine("3. Find employee by name");
                Console.WriteLine("4. Exit");

                int op = int.Parse(Console.ReadLine());

                switch(op)
                {
                    case 1:
                        AddEmployee(employees);
                        break;
                    case 2:
                        FindHighestSalary(employees); break;
                    case 3:
                        FindEmployeeByName(employees); break;
                    case 4:
                        Console.WriteLine("Exit!");
                        return;
                    default: Console.WriteLine("Invalid option! Enter again: ");
                        break;
                }
            }
        }

        public static void FindEmployeeByName(List<IEmployee> employees)
        {
            Console.WriteLine("Enter name want to find: ");
            string name = Console.ReadLine();

            foreach(var employee in employees)
            {// Duyet vong lap de tim nhan vien theo ten
                if(employee.getName().Equals(name))
                {
                    Console.WriteLine(employee.ToString());
                    return;
                }
            }

            Console.WriteLine("Employee not found!");
        }

        public static void FindHighestSalary(List<IEmployee> employees)
        {
            //Neu list khong co ai thi khong tim thay
            if(employees.Count == 0)
            {
                Console.WriteLine("No employee found!");
                return;
            }

            //Tim nhan vien co luong cao nhat
            IEmployee highestSalaryEmployee = employees[0];
            foreach(var employee in employees)
            {
                if(employee.calculateSalary() > highestSalaryEmployee.calculateSalary())
                {
                    highestSalaryEmployee = employee;
                }
            }

            Console.WriteLine("Employee with the highest salary: ");
            Console.WriteLine(highestSalaryEmployee.ToString());

        }

        public static void AddEmployee(List<IEmployee> employees)
        {
            try
            {
                Console.WriteLine("Enter employee type: (1:Full Time, 2:Part Time): ");
                int type = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter payment per hour: ");
                int paymentPerHour = int.Parse(Console.ReadLine());

                if(type == 1)
                {//Case 1 la them nhan vien fullTime vao lisst
                    employees.Add(new FullTimeEmployee(name, paymentPerHour));
                    Console.WriteLine("Add succesfully!");
                }
                else if(type == 2)
                {// Case2 la them nhan vien partTime vao list
                    Console.WriteLine("Enter working hours: ");
                    int workingHours = int.Parse(Console.ReadLine());
                    employees.Add(new PartTimeEmployee(name, paymentPerHour, workingHours));
                    Console.WriteLine("Add succesfully!");
                }
                else
                {
                    Console.WriteLine("Invalid employee type!");
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Input invalid! Please try again: ");
            }
        }
    }
}
