using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using SendApi.Service.IServices;
using SendApi.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISendDataService, SendDataService>();
builder.Services.AddTransient<IHttpService, HttpService>();
builder.Services.AddOpenTelemetry()
    .ConfigureResource(res => res
        .AddService("BasicOpenTelemetry.API"))
    .WithMetrics(metrics =>
    {
        metrics
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            .AddRuntimeInstrumentation();

        metrics.AddMeter("BasicOpenTelemetry.API");

        metrics.AddOtlpExporter(opt => opt.Endpoint = new Uri("http://localhost:4317/"));
    })
    .WithTracing(tracing =>
    {

        tracing
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation();

        tracing.AddOtlpExporter(opt => opt.Endpoint = new Uri("http://localhost:4317/"));

    }
    );

builder.Logging.AddOpenTelemetry(log =>
{
    log.AddOtlpExporter(opt => opt.Endpoint = new Uri("http://localhost:4317/"));
    log.IncludeScopes = true;
    log.IncludeFormattedMessage = true;
});
builder.Services.AddHttpClient("MyApi", client =>
{
    client.BaseAddress = new Uri("https://api.example.com/");
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
