using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDb.Map
{
    using EmployeeManagementSystemDb.Models;
    using FluentNHibernate.Mapping;

    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees"); // Specify the name of the database table

            Id(x => x.EmployeeId).GeneratedBy.Identity(); // Specify the primary key and generation strategy
            Map(x => x.FirstName).Not.Nullable(); // Map FirstName property
            Map(x => x.LastName).Not.Nullable(); // Map LastName property
            Map(x => x.Department).Not.Nullable(); // Map Department property
            Map(x => x.HireDate).Not.Nullable(); // Map HireDate property
            Map(x => x.Salary).Not.Nullable(); // Map Salary property

            HasMany(x => x.Projects) // Map the Projects collection
                .Cascade.All() // Specify the cascade behavior for projects (optional, adjust as needed)
                .Inverse() // Specify the inverse side of the relationship
                .KeyColumn("EmployeeId"); // Specify the foreign key column in the Projects table
        }
    }

}
