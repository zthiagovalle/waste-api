var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://recicle-municipio-zthiagovalle.vercel.app", "https://recicle-saosimao.vercel.app/home")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
