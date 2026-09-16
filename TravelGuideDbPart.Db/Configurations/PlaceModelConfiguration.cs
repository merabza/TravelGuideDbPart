using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelGuideCore.Domain.PlaceModels;

namespace TravelGuideDbPart.Db.Configurations;

public sealed class PlaceModelConfiguration : IEntityTypeConfiguration<PlaceModel>
{
    public const int NameLength = 200;

    public void Configure(EntityTypeBuilder<PlaceModel> builder)
    {
        const string tableName = "Places";
        builder.ToTable(tableName);

        builder.HasKey(e => e.PlaceId);

        builder.Property(e => e.Name).HasMaxLength(NameLength);

        builder.HasOne(d => d.RegionNavigation).WithMany().HasForeignKey(d => d.RegionId);
        builder.HasOne(d => d.MunicipalityNavigation).WithMany().HasForeignKey(d => d.MunicipalityId);

        //მისამართი Urls ცხრილის ჩანაწერია და არასავალდებულოა — ხელით შეყვანილ ადგილს UrlId არ აქვს
        builder.HasOne(d => d.UrlNavigation).WithMany().HasForeignKey(d => d.UrlId);
    }
}
