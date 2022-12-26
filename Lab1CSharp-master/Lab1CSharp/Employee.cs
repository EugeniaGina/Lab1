using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1CSharp
{
    public class Employee
    {
        private string _fullName;
        private Position _position;
        private decimal _salary;
        private  List<string> _positionsHistory = new List<string>(5);
        private string _departmentName;
        private decimal _balance;
        public Employee(string fullName, Position position, string[] positionsHistory, string departmentName)
        {
            _fullName = CheckIfFullNameIsCorrectOrThrowException(fullName);
            _position = position;
            _salary = (decimal)position;
            _positionsHistory = CheckHistoryOfPositionsOrThrowException(positionsHistory.ToList());
            _departmentName = CheckIfDepartmentNameIsCorrectOrThrowException(departmentName);
        }
        public string FullName { get => _fullName; set => _fullName = CheckIfFullNameIsCorrectOrThrowException(value); }
        public Position Position { get => _position; }
        public decimal Salary { get => _salary;  }
        public string[] PositionsHistory { get => _positionsHistory.ToArray(); }
        public string DepartmentName { get => _departmentName; set => _departmentName = CheckIfDepartmentNameIsCorrectOrThrowException(value); }
        public decimal Balance { get => _balance; }

        private string CheckIfFullNameIsCorrectOrThrowException(string name)
        {
            Regex regex = new Regex(@"^[^0-9]+$");
            bool isMatch = regex.IsMatch(name);
            if (!isMatch || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Full name cant contain numbers or be empty");
            }
            return name;
        }
        private string CheckIfDepartmentNameIsCorrectOrThrowException(string department)
        {
            Regex regex = new Regex(@"([A-Za-z]+[0-9]|[0-9]+[A-Za-z])[A-Za-z0-9]*");
            if (!regex.IsMatch(department))
            {
                throw new ArgumentException("Deparment name must contain at least 1 number and at least 1 letter");
            }
            return department;
        }
        private List<string> CheckHistoryOfPositionsOrThrowException(List<string> positions)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                bool isParsed;
                isParsed = Enum.TryParse(typeof(Position), positions[i], out object position);
                if (!isParsed)
                {
                    throw new ArgumentException("Postions that were in history dont exist!");
                }
            }
            return positions;
        }
        public void SetPosition(Position position, string department)
        {
            if(_position == position)
            {
                throw new ArgumentException("He already has this position");
            }
            _positionsHistory.Add(this._position.ToString()); // his current position is now history
            _position = position;
            _departmentName = CheckIfDepartmentNameIsCorrectOrThrowException(department);
            _salary = (decimal)position;
        }
        public void GiveSalary()
        {
            _balance += _salary;
        }
        public (string[] AllMatchPositionsInHistory, string CurrentDepartment) GetPositionsFromHistoryBy(string position)
        {
            bool isParsed;
            isParsed = Enum.TryParse(typeof(Position), position, out object positionObj);
            if (!isParsed)
            {
                throw new ArgumentException("This position doesnt exist!");
            }
            return (_positionsHistory.FindAll(pos => pos == position).ToArray(), _departmentName);
        }
        public override string ToString()
        {
            string result = $"Full Name {this._fullName} Deparment {this._departmentName}\nBalance {this._balance}, Position {this._position}, Salary {this._salary}\n";
            StringBuilder positionsHistory = new StringBuilder();
            positionsHistory.AppendLine("History of positions:");
            foreach (var item in this._positionsHistory)
            {
                positionsHistory.AppendLine($"{item}");
            }
             return result += positionsHistory.ToString();
        }
        public static bool operator == (Employee firstEmp, Employee secondEmp)
        {
            return firstEmp.Position == secondEmp.Position;
        }
        public static bool operator != (Employee firstEmp, Employee secondEmp)
        {
            return firstEmp.Position != secondEmp.Position;
        }
        public static bool operator > (Employee firstEmp, Employee secondEmp)
        {
            return (decimal)firstEmp.Position > (decimal)secondEmp.Position;
        }
        public static bool operator < (Employee firstEmp, Employee secondEmp)
        {
            return (decimal)firstEmp.Position < (decimal)secondEmp.Position;
        }
        public static bool operator >= (Employee firstEmp, Employee secondEmp)
        {
            return (decimal)firstEmp.Position >= (decimal)secondEmp.Position;
        }
        public static bool operator <= (Employee firstEmp, Employee secondEmp)
        {
            return (decimal)firstEmp.Position <= (decimal)secondEmp.Position;
        }
    }
}
