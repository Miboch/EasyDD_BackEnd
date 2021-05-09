param([string]$name="")
dotnet-ef migrations add $name --project=".\easydd.infrastructure" --startup-project=".\easydd.web"
