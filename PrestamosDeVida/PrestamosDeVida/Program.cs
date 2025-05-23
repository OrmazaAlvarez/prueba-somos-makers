using Shared;

var builder = WebApplication.CreateBuilder(args);

SqlServerContext _context = new SqlServerContext();

// Registra SqlServerContext como servicio (ajusta AddSingleton/AddScoped según tu caso):
builder.Services.AddSingleton<SqlServerContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    
    configuration.GetSection("SQLServerContext").Bind(_context);
    return _context;
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
