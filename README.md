# TravelGuideDbPart

EF Core persistence of [TravelGuide](https://github.com/merabza/TravelGuide): `TravelGuideDbContext` (implements `ITravelGuideApplicationDbContext` from [TravelGuideCore](https://github.com/merabza/TravelGuideCore)) and the per-entity configurations.

| Project | Purpose |
|---|---|
| `TravelGuideDbPart.Db` | `TravelGuideDbContext` and `IEntityTypeConfiguration<T>` classes (`Configurations` folder) |

EF Core migrations live in the [TravelGuide](https://github.com/merabza/TravelGuide) repository (`TravelGuideDbMigration` project).

## Repository layout — sibling repos are required

Projects reference sibling clones by relative path (`..\..\TravelGuideCore\...`, `..\..\SystemTools\...`), so the repositories must be cloned next to each other:

```
<root>\
├── TravelGuideDbPart\       this repository (TravelGuideDbPart.slnx lives here)
├── TravelGuideCore\         domain entities and abstractions (merabza/TravelGuideCore)
└── SystemTools\             shared libraries (merabza/SystemTools)
```

## Build

```powershell
dotnet build TravelGuideDbPart.slnx
```

## License

[MIT](LICENSE)
