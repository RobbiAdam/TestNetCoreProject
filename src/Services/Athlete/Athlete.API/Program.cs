using Athlete.API;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.
    AddAthleteAPI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseExceptionHandler(_ => { });

app.MapCarter();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PlayerContext>();
    context.Database.EnsureCreated();
}

app.Run();
