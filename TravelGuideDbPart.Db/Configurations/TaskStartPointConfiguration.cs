using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelGuideCore.Domain.TaskStartPoints;

namespace TravelGuideDbPart.Db.Configurations;

public sealed class TaskStartPointConfiguration : IEntityTypeConfiguration<TaskStartPoint>
{
    public const int StartPointLength = 2048;

    public void Configure(EntityTypeBuilder<TaskStartPoint> builder)
    {
        const string tableName = "TaskStartPoints";
        builder.ToTable(tableName);

        builder.HasKey(e => e.TspId);

        builder.Property(e => e.StartPoint).HasMaxLength(StartPointLength);

        builder.HasOne(d => d.TaskNavigation).WithMany(p => p.StartPoints).HasForeignKey(d => d.TaskId);
    }
}
