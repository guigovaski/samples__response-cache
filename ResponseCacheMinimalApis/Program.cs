using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOutputCache(options => {
    options.AddPolicy("Default60", policy => {
        policy.Expire(TimeSpan.FromMinutes(1));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var products = new[]
{
    "Banana", "Macarrao", "Feijao", "Arroz", "Milho", "Morango"
};

var users = new[]
{
    "Teste1", "Teste2", "Teste3", "Teste4", "Teste5", "Teste6"
};

app.MapGet("/products", () =>
{    
    return products;
})
.WithName("Products")
.WithOpenApi()
.CacheOutput("Default60");

app.MapGet("/users", [OutputCache(Duration = 30)] () =>
{    
    return users;
})
.WithName("Products")
.WithOpenApi();

app.Run();
