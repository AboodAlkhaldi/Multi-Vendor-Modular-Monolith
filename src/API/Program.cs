var builder = WebApplication.CreateBuilder(args);


// the Database options registration  
builder.Services.AddOptions<DataBaseOptions>(
    builder.Configuration.GetSection(DataBaseOptions.Position)
    );


builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
