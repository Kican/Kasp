object mapper help you to map `object` and `IQueryable` to Distance model.  


## installation
add this package to your csproj file:  
for automapper: `Kasp.ObjectMapper.AutoMapper`  
for mapster: `Kasp.ObjectMapper.Mapster`

## configuration
add following line in `ConfigureServices` on the `Startup` class:
```c#
services.AddObjectMapper<Mapster>();
```
or
```c#
services.AddObjectMapper<AutoMapper>();
```

## usage

#### use extensions
for objects: `obj.MapTo<TDistance>()`  
for IQueryable: `query.MapTo<TDistance>()`