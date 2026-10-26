# CDM Labsync

One integrated Windows installer for a dental dashboard over existing Syncthing.

Status: initial service scaffold only. No production workflow, authentication, installer, or automatic deletion is implemented yet. Do not use patient data.

Portage is the only receiving lab. Akron Office remains a sending office.

Run: dotnet run --project src/CdmLabDesk
Health: GET /health
Build: dotnet build src/CdmLabDesk/CdmLabDesk.csproj

See docs/IMPLEMENTATION.md for requirements and delivery gates.
