using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Crud.Student.V1.Entities;

namespace Crud.Student.V1.Configurations;

public class StudentConfiguration:IEntityTypeConfiguration<Entities.Student>
{
    public void Configure(EntityTypeBuilder<Entities.Student> builder)
    {
        builder.HasKey(x => x.Id);
    }
}