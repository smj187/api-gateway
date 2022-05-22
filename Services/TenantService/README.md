## HTTPS setup

```
// create pfx file
dotnet dev-certs https -ep $env:APPDATA\ASP.NET\Https\TenantService.API.pfx -p crypticpassword

// open api folder
cd Services/TenantService/TenantService.API

// generate user secret
dotnet user-secrets -p ./TenantService.API.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword"
```

## Docker build

Run the service container

```
docker-compose -f docker-compose-services.yaml up --build
docker-compose -f docker-compose-services.yaml down
```

Run the database container

```
docker-compose -f docker-compose-database.yaml up --build
```