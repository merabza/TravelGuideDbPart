//Created by DbContextClassCreator at 7/24/2025 11:44:10 PM

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SystemTools.DatabaseToolsShared;
using TravelGuideCore.Application.Abstractions;
using TravelGuideCore.Domain.CategoryModels;
using TravelGuideCore.Domain.DistancesByPlaces;
using TravelGuideCore.Domain.FromPointModels;
using TravelGuideCore.Domain.LocationModels;
using TravelGuideCore.Domain.MonthModels;
using TravelGuideCore.Domain.MotorcycleModels;
using TravelGuideCore.Domain.MunicipalityModels;
using TravelGuideCore.Domain.PlaceModels;
using TravelGuideCore.Domain.PlacesByBestSeasons;
using TravelGuideCore.Domain.PlacesByCategories;
using TravelGuideCore.Domain.PlacesByLocations;
using TravelGuideCore.Domain.PlacesByTags;
using TravelGuideCore.Domain.RegionModels;
using TravelGuideCore.Domain.RouteDistanceModels;
using TravelGuideCore.Domain.TagModels;
using TravelGuideCore.Domain.TaskModels;
using TravelGuideCore.Domain.TaskStartPoints;
using TravelGuideCore.Domain.UrlGraphNodes;
using TravelGuideCore.Domain.UrlModels;
using TravelGuideCore.Domain.VisitImages;
using TravelGuideCore.Domain.VisitModels;

namespace TravelGuideDbPart.Db;

public sealed class TravelGuideDbContext : DbContext, ITravelGuideApplicationDbContext
{
    public TravelGuideDbContext(DbContextOptions<TravelGuideDbContext> options) : base(options)
    {
    }

    public DbSet<TaskModel> Tasks => Set<TaskModel>();
    public DbSet<TaskStartPoint> TaskStartPoints => Set<TaskStartPoint>();
    public DbSet<PlaceModel> Places => Set<PlaceModel>();
    public DbSet<MonthModel> Months => Set<MonthModel>();
    public DbSet<CategoryModel> Categories => Set<CategoryModel>();
    public DbSet<TagModel> Tags => Set<TagModel>();
    public DbSet<PlaceByBestSeason> PlacesByBestSeasons => Set<PlaceByBestSeason>();
    public DbSet<PlaceByCategory> PlacesByCategories => Set<PlaceByCategory>();
    public DbSet<PlaceByTag> PlacesByTags => Set<PlaceByTag>();
    public DbSet<LocationModel> Locations => Set<LocationModel>();
    public DbSet<PlaceByLocation> PlacesByLocations => Set<PlaceByLocation>();
    public DbSet<FromPointModel> FromPoints => Set<FromPointModel>();
    public DbSet<DistanceByPlace> DistanceByPlaces => Set<DistanceByPlace>();
    public DbSet<RegionModel> Regions => Set<RegionModel>();
    public DbSet<MunicipalityModel> Municipalities => Set<MunicipalityModel>();
    public DbSet<MotorcycleModel> Motorcycles => Set<MotorcycleModel>();
    public DbSet<UrlGraphNode> UrlGraphNodes => Set<UrlGraphNode>();
    public DbSet<UrlModel> Urls => Set<UrlModel>();
    public DbSet<VisitModel> Visits => Set<VisitModel>();
    public DbSet<VisitImage> VisitImages => Set<VisitImage>();
    public DbSet<RouteDistanceModel> RouteDistances => Set<RouteDistanceModel>();

    public IDbContextTransaction BeginTransaction()
    {
        return Database.BeginTransaction();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelGuideDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new DatabaseEntitiesDefaultConvention());
    }
}
