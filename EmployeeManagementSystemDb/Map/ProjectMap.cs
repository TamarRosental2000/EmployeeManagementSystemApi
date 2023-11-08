using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDb.Map
{
    using EmployeeManagementSystemDb.Models;
    using FluentNHibernate.Mapping;

    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("Projects"); // Specify the name of the database table

            Id(x => x.ProjectId).GeneratedBy.Identity(); // Specify the primary key and generation strategy
            Map(x => x.ProjectName).Not.Nullable(); // Map ProjectName property
            Map(x => x.Description); // Map Description property (nullable)
            Map(x => x.StartDate).Not.Nullable(); // Map StartDate property
            Map(x => x.EndDate); // Map EndDate property (nullable)

            HasManyToMany(x => x.Employees) // Map the Employees collection using many-to-many relationship
                .Table("EmployeeProjects") // Specify the join table name
                .ParentKeyColumn("ProjectId") // Specify the foreign key column in the join table referencing ProjectId
                .ChildKeyColumn("EmployeeId") // Specify the foreign key column in the join table referencing EmployeeId
                .Cascade.All(); // Specify the cascade behavior for the Employees collection (optional, adjust as needed)
        }
    }

}
