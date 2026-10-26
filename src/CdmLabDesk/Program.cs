var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/health", () => Results.Ok(new {
    application = "CDM Labsync",
    status = "scaffold-only",
    caseWorkflowEnabled = false,
    automaticCleanupEnabled = false
}));
app.MapGet("/", () => Results.Content("CDM Labsync foundation. Dental dashboard and case workflow are not implemented yet.", "text/plain"));
app.Run();
