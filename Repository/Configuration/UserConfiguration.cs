using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FirstName = "John",
                    LastName = "Legend",
                    Email = "JohnLegend@gmail.com",
                    AccountId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new User
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FirstName = "Bradley",
                    LastName = "Legend",
                    Email = "BradleyLegend@gmail.com",
                    AccountId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new User
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),

                    FirstName = "Michael",
                    LastName = "Cooper",
                    Email = "cooper@gmail.com",
                    AccountId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                }

            );

        }
    }
}
