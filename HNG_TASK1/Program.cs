using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Customize the response for invalid model states
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new BadRequestObjectResult(new { error = true });
            result.ContentTypes.Add("application/json");
            return result;
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Allow requests from any origin
              .AllowAnyMethod() // Allow all HTTP methods
              .AllowAnyHeader(); // Allow all headers
    });
});

var app = builder.Build();


// Use CORS policy
app.UseCors("AllowAllOrigins");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
