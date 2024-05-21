using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CS_W2
{

    public interface IEmployee
    {
        int calculateSalary();
        string getName();
    }
    
    public abstract class Employee : IEmployee
    {// lop abstract goi cac phuong thuc theo yeu cau
        protected string name { get; set; }
        protected int paymentPerHour { get; set; }

        public Employee(string name, int paymentPerHour) {
            this.name = name;
            this.paymentPerHour = paymentPerHour;
        }
        
        public void setName(string name) { this.name = name; }
        public string getName() { return name; }

        public void setPaymentPerHour(int paymentPerHour) 
        { this.paymentPerHour= paymentPerHour; }
        public int getPaymentPerHour() {  return paymentPerHour; }
        

        // cac phuong thuc ke thua tu lop interface
        public abstract int calculateSalary();
        //public abstract string getName();
        public override string ToString()
        {
            return $"Name: {name}, Payment Per Hour: {paymentPerHour}"; 
        }
    }

    public class PartTimeEmployee : Employee
    {
        private int workingHours { set; get; }

        public PartTimeEmployee(string name, int paymentPerHour, 
            int workingHours):base(name, paymentPerHour)
        {
            this.workingHours = workingHours;
        }

        public override int calculateSalary()
        {
            return workingHours * paymentPerHour;
        }

        public override string ToString()
        {
            return base.ToString() + $", Working Hours: {workingHours}, Salary: {calculateSalary()}";
        }
    }

    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string name, int paymentPerHours):base(name, paymentPerHours) { }

        public override int calculateSalary()
        {
            return 8 * paymentPerHour;
        }

        public override string ToString()
        {
            return base.ToString() + $", Salary: {calculateSalary()}"; ;
        }
    }
}
