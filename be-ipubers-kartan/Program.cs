using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Middlewares;
using be_ipubers_kartan.Models;
using be_ipubers_kartan.Repositories;
using be_ipubers_kartan.Services;
using be_ipubers_kartan.ViewsModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Serilog;
using be_ipubers_kartan.Handlers;
using Hangfire;
using Hangfire.SqlServer;
using be_ipubers_kartan.Jobs;
using Hangfire.Dashboard.BasicAuthorization;
using Serilog.Events;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Logs;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Setup service name
string envName = builder.Environment.EnvironmentName;
string serviceName = $"ipubers-kartan-api-{envName.ToLower()}";

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });

builder.Services.AddDbContext<be_ipubers_kartan.Models.Rekan.RekanContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RekanConnection")
    )
);
builder.Services.AddDbContext<be_ipubers_kartan.Models.RMSContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<PenjualanRekanViewModel>();
builder.Services.AddDbContext<RMSContext>(options => options.UseSqlServer("DefaultConnection"));

builder.Services.AddScoped<ITransaksiKartanService, TransaksiKartanRepo>();
builder.Services.AddScoped<ICetakanService, CetakanServiceRepo>();
builder.Services.AddScoped<IPetaniService, PetaniRepo>();
builder.Services.AddScoped<IProdukRetailerService, ProdukRetailerRepo>();
builder.Services.AddScoped<ISyncRekanService, SycnRekanRepo>();
builder.Services.AddScoped<ISyncAlokasiService, SyncAlokasiRepo>();
builder.Services.AddScoped<PenjualanProdukRetailerRepo>();
builder.Services.AddScoped<IStokKiosService, StokKiosService>();
builder.Services.AddScoped<ICekStokRepo, StokKiosRepo>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPenjualanRepo, PenjualanRepo>();
builder.Services.AddScoped<IRetailerRepo, RetailerRepo>();
builder.Services.AddScoped<IPembayaran, PembayaranRepo>();
builder.Services.AddScoped<IProdukRetailerStokRekanService, ProdukRetailerStokRekanRepo>();
builder.Services.AddScoped<IProdukRetailerStokKecamatanService, ProdukRetailerStokKecamatanRekanRepo>();
builder.Services.AddScoped<IPenjualanRepo, PenjualanRepo>();
builder.Services.AddScoped<IJenisKomoditasRepo, JenisKomoditasRepo>();
builder.Services.AddScoped<SftpUploaderService>();
builder.Services.AddScoped<RekonTransaksiJob>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

var elasticUriRaw = builder.Configuration["Elasticsearch:Uri"];
string elasticUsername = builder.Configuration["Elasticsearch:Username"];
string elasticPassword = builder.Configuration["Elasticsearch:Password"];
string elasticCertificateFingerprint = builder.Configuration["Elasticsearch:CertificateFingerprint"];

if (!string.IsNullOrWhiteSpace(elasticUriRaw) && Uri.TryCreate(elasticUriRaw, UriKind.Absolute, out var elasticUri))
{
    var elasticSettings = new ConnectionSettings(elasticUri).BasicAuthentication(elasticUsername, elasticPassword);
    if (!string.IsNullOrWhiteSpace(elasticCertificateFingerprint))
    {
        elasticSettings.CertificateFingerprint(elasticCertificateFingerprint);
    }

    builder.Services.AddSingleton<IElasticClient>(new ElasticClient(elasticSettings));
}

builder.Services.AddSingleton<IElasticLoggingService, ElasticLoggingService>();

builder.Services.AddHttpClient();

// Add JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add Hangfire services
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.FromSeconds(15),
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true,
        PrepareSchemaIfNecessary = true
    }));

// Add the Hangfire Server
builder.Services.AddHangfireServer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Web API Ipubers Kartan",
        Version = "v1",
        Description = "API RMS Pupuk Indonesia"
    });
    
    options.SwaggerDoc("v1.1", new OpenApiInfo
    {
        Title = "Web API Ipubers Kartan",
        Version = "v1.1",
        Description = "API RMS Pupuk Indonesia"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Masukkan token valid Anda."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
    .WriteTo.Console()
    .Enrich.WithProperty("Application", serviceName)
    .CreateLogger();

builder.Host.UseSerilog();

// This service will be started by the host and will schedule all jobs.
builder.Services.AddHostedService<HangfireSchedulerService>();

// OpenTelemetry setup
builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder =>
    {
        tracerProviderBuilder
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
            .AddAspNetCoreInstrumentation(options => { options.RecordException = true; })
            .AddHttpClientInstrumentation(options =>
            {
                options.RecordException = true;
                options.EnrichWithHttpRequestMessage = (activity, request) =>
                {
                    activity.SetTag("http.request.uri", request.RequestUri?.ToString());
                };

                options.EnrichWithHttpResponseMessage = (activity, response) =>
                {
                    activity.SetTag("http.response.length", response.Content?.Headers.ContentLength);
                    activity.SetTag("http.status_code", (int)response.StatusCode);
                };

                options.EnrichWithException = (activity, ex) =>
                {
                    activity.SetTag("exception.message", ex.Message);
                };
            })
            .AddSqlClientInstrumentation(options => { options.SetDbStatementForText = true; })
            .AddEntityFrameworkCoreInstrumentation(options => { options.SetDbStatementForText = true; });

        string jaegerEndpoint = builder.Configuration["JaegerSettings:Endpoint"];
        string elasticApmServerUrl = builder.Configuration["ElasticApm:ServerUrl"];

        if (!string.IsNullOrWhiteSpace(elasticApmServerUrl))
        {
            tracerProviderBuilder.AddOtlpExporter(options => { options.Endpoint = new Uri(elasticApmServerUrl); });
        }
        else if (!string.IsNullOrWhiteSpace(jaegerEndpoint))
        {
            tracerProviderBuilder.AddOtlpExporter(options => { options.Endpoint = new Uri(jaegerEndpoint); });
        }
    });

builder.Logging.AddOpenTelemetry(options =>
{
    options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName));
    
    options.IncludeFormattedMessage = true;
    options.IncludeScopes = true;
    options.ParseStateValues = true;

    options.AddOtlpExporter();
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    // Enable buffering to allow multiple reads of the request body
    context.Request.EnableBuffering();
    await next();
});

app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var apiBaseUrl = builder.Configuration["AppSettings:BaseUrl"];

    if (!string.IsNullOrWhiteSpace(apiBaseUrl))
    {
        var swaggerEndpointUrl = $"{apiBaseUrl}/swagger/v1/swagger.json";
        options.SwaggerEndpoint(swaggerEndpointUrl, $"Kartan API - {envName.ToUpper()}");
    }
    else
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", $"Kartan API - {envName.ToUpper()}");
    }

    options.SwaggerEndpoint("/swagger/v1/swagger.json", $"Kartan API - {envName.ToUpper()}");
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(_ => {});

// Enable if want to use request logging middleware
// app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

var basicAuthFilter = new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
{
    RequireSsl = builder.Environment.IsProduction(),
    SslRedirect = builder.Environment.IsProduction(),
    LoginCaseSensitive = true,
    Users =
    [
        new BasicAuthAuthorizationUser
        {
            Login = builder.Configuration["HangfireSettings:Dashboard:Username"],
            PasswordClear = builder.Configuration["HangfireSettings:Dashboard:HashedPassword"]
        }
    ]
});

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = [ basicAuthFilter ]
});

app.Run();