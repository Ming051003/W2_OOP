using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace W2_OOP_TX2_2
{
    public abstract class Person
    {
        protected string name {  get; set; }
        protected string address { get; set; }

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address; 
        }
        public string GetName() => name;
        public abstract void display();
    }

    public class Employee : Person
    {
        private int salary { get; set; }

        public Employee(string name, string address, int salary):base(name, address)
        {
            this.salary = salary;
        }

        public int GetSalary()
        {
            return salary;
        }

        public override void display()
        {
            Console.WriteLine($"Employee: Name = {name}, Address = {address}, Salary = {salary}");
        }
    }

    public class Customer : Person
    {
        private int balance { get; set; }

        public Customer(string name, string address, int balance):base(name, address)
        {
            this.balance = balance;
        }
        public int GetBalance() => balance;
        public override void display()
        {
            Console.WriteLine($"Customer: Name = {name}, Address = {address}, Balance = {balance}");
        }
    }
}
