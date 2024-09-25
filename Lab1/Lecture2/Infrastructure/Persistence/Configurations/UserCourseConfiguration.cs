using Domain.Courses;
using Domain.UserCourses;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
{
    public void Configure(EntityTypeBuilder<UserCourse> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Value, x => new UserCourseId(x));

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserCourses)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("fk_user_courses_users_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Course)
            .WithMany(x => x.EnrolledStudents)
            .HasForeignKey(x => x.CourseId)
            .HasConstraintName("fk_user_courses_courses_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.EnrollmentDate)
            .HasDefaultValueSql("timezone('utc', now())");
    }
}