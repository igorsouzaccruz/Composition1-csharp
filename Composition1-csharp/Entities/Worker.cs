using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composition1_csharp.Entities.Enums;

namespace Composition1_csharp.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        } 

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public Double Income(int year, int month)
        {
            double income = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Data.Year == year && contract.Data.Month == month)
                {
                   income += contract.TotalValue();
                }
            }
            return income;
        }
    }
}
