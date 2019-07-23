using ioayFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioayFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.UserName).HasColumnName("Username");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.FirstName).HasColumnName("Firstname");
            Property(x => x.LastName).HasColumnName("Lastname");

        }
    }
}
