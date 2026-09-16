using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelGuideCore.Domain.UrlModels;

namespace TravelGuideDbPart.Db.Configurations;

public sealed class UrlModelConfiguration : IEntityTypeConfiguration<UrlModel>
{
    //Url არ ინდექსირდება — სიგრძის ზღვარი მხოლოდ სვეტის ზომაა და ზედმეტად გრძელი მისამართების გამოსატოვებლად გამოიყენება
    public const int UrlLength = 500;

    public void Configure(EntityTypeBuilder<UrlModel> builder)
    {
        const string tableName = "Urls";
        builder.ToTable(tableName);

        builder.HasKey(e => e.UrlId);

        //Url-ის მაგივრად მისი დეტერმინისტული ხეშ-კოდი ინდექსირდება — ინდექსი არაუნიკალურია (სხვადასხვა Url-ს
        //იშვიათად ერთი ხეში შეიძლება ჰქონდეს); Url-ის უნიკალურობას აპლიკაცია იცავს შენახვამდე შემოწმებით
        builder.HasIndex(e => e.UrlHashCode);

        builder.Property(e => e.Url).HasMaxLength(UrlLength);
    }
}
