
namespace W2_OOP_TX2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Customer> customers = new List<Customer>();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Display Employee with highest salary");
                Console.WriteLine("4. Display Customer with lowest balance");
                Console.WriteLine("5. Find Employee by name");                
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        AddEmployee(employees);
                        break;
                    case 2:
                        AddCustomer(customers);
                        break;
                    case 3:
                        FindHighestEmployee(employees);
                        break;
                    case 4:
                        FindLowestCustomer(customers);
                        break;
                    case 5:
                        FindEmployeeByName(employees);
                        break ; 
                    case 6:
                        Console.WriteLine("Exit!");
                        return;
                    default:
                        Console.WriteLine("Invalid Option! Try again: ");
                        break;        
                }

            }
        }

        private static void FindEmployeeByName(List<Employee> employees)
        {
            Console.WriteLine("Enter name want to find: ");
            string name = Console.ReadLine();
            var employee = employees.FirstOrDefault(emp => emp.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
            if(employee !=null)
            {
                employee.display();
            }
            else
            {
                Console.WriteLine($"Employee with name {name} not found.");

            }
        }

        private static void FindLowestCustomer(List<Customer> customers)
        {
            if(customers.Count == 0)
            {
                Console.WriteLine("No customer available.");
            }


            Customer lowestCustomer = customers[0];
            foreach(var customer in customers)
            {
                if(customer.GetBalance() < lowestCustomer.GetBalance())
                {
                    lowestCustomer = customer;
                }
            }
            Console.WriteLine("Customer with the lowest balance:");
            lowestCustomer.display();
        }

        private static void FindHighestEmployee(List<Employee> employees)
        {
            if(employees.Count > 0)
            {
                var highest = employees.OrderByDescending(emp => emp.GetSalary()).First();
                highest.display();
            }
            else
            {
                Console.WriteLine("No employees available.");
            }
        }

        private static void AddCustomer(List<Customer> customers)
        {
            try
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Balance: ");
                int balance = int.Parse(Console.ReadLine());

                if( name == null || address == null )
                {
                    throw new Exception("Must be input Name and Address!");
                }
                else
                {
                    customers.Add(new Customer(name, address, balance));
                    Console.WriteLine("Add Successfully!");
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        private static void AddEmployee(List<Employee> employees)
        {
            try
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Salary: ");
                int salary = int.Parse(Console.ReadLine());

                if (name == null || address == null)
                {
                    throw new Exception("Must be input Name and Address!");
                }
                else
                {
                    employees.Add(new Employee(name, address, salary));
                    Console.WriteLine("Add Successfully!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}
