using Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Value, x => new CourseId(x));

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(255)");

        builder.Property(x => x.StartAt)
            .IsRequired()
            .HasColumnType("timestamp");

        builder.Property(x => x.FinishAt)
            .IsRequired()
            .HasColumnType("timestamp");

        builder.Property(x => x.MaxStudents)
            .IsRequired();

        // Configuring StudentScores as a JSON column in case of PostgreSQL
        builder.Property(x => x.StudentScores)
            .HasColumnType("jsonb")
            .HasDefaultValueSql("'{}'::jsonb");

        // Many-to-many relationship through UserCourse table
        builder.HasMany(x => x.EnrolledStudents)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}