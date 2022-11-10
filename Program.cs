using Microsoft.AspNetCore.Cors;
using TryPactia;
using TryPactia.Repositories;
using TryPactia.Services;


var UrlsParaPermitir = "_myAllowSpecificOrigins";
    
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: UrlsParaPermitir,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200", "localhost:4200").AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                      });
});

// Add services to the container.
builder.Services.AddSqlServer<PersonaContext>(builder.Configuration.GetConnectionString("PersonaCS"), sqlServerOptionsAction: sqlOptions =>
{
    sqlOptions.EnableRetryOnFailure(
    maxRetryCount: 2,
    maxRetryDelay: TimeSpan.FromSeconds(5),
    errorNumbersToAdd: null);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepoPersona, RepoPersona>();
builder.Services.AddScoped<IPersonaService, PersonaService>();


var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(UrlsParaPermitir);
app.UseAuthorization();

app.MapControllers();

app.Run();
