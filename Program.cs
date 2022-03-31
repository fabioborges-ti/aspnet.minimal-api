using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region endpoints: CARS 

// Get cars
app.MapGet("api/cars",
    async (ApplicationDbContext db) =>
    {
        var result = await db.Cars.ToListAsync();

        return Results.Ok(result);
    })
    .WithName("GetCars")
    .WithTags("Cars");

// Get car
app.MapGet("api/cars/{id}",
    async (int id, ApplicationDbContext db) =>
    {
        var car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);

        if (car == null) return Results.NotFound($"Car with id: {id} is not found");

        return Results.Ok(car);
    })
    .WithName("GetCar")
    .WithTags("Cars");

// Create car
app.MapPost("api/cars",
    async (CarCreateModel obj, ApplicationDbContext db) =>
    {
        var car = new Car
        {
            TeamName = obj.TeamName,
            Speed = obj.Speed,
            MelfunctionChance = obj.MelfunctionChance
        };

        db.Cars.Add(car);

        await db.SaveChangesAsync();

        return Results.CreatedAtRoute("GetCar", new { id = car.Id }, car);
    })
    .WithName("CreateCar")
    .WithTags("Cars");

// Update car
app.MapPut("api/cars/{id}",
    async ([FromQuery] int id, [FromBody] CarCreateModel obj, ApplicationDbContext db) =>
    {
        var car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);

        if (car == null) return Results.NotFound($"Car with id: {id} is not found");

        car.TeamName = obj.TeamName;
        car.Speed = obj.Speed;
        car.MelfunctionChance = obj.MelfunctionChance;

        await db.SaveChangesAsync();

        return Results.Ok(car);
    })
    .WithName("UpdateCar")
    .WithTags("Cars");

// Delete car
app.MapDelete("api/cars/{id}",
    async (int id, ApplicationDbContext db) =>
    {
        var car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);

        if (car == null) return Results.NotFound($"Car with id: {id} is not found");

        db.Cars.Remove(car);

        await db.SaveChangesAsync();

        return Results.Ok();
    })
    .WithName("DeleteCar")
    .WithTags("Cars");

#endregion

#region endpoints: MOTORBIKES 

app.MapGet("api/motorbikes",
    async (ApplicationDbContext db) =>
    {
        var data = await db.Motorbikes.ToListAsync();

        return Results.Ok(data);
    })
    .WithName("GetMotorbikes")
    .WithTags("Motorbikes");

app.MapGet("api/motorbikes/{id}",
    async (int id, ApplicationDbContext db) =>
    {
        var data = await db.Motorbikes.FirstOrDefaultAsync(x => x.Id == id);

        if (data == null) return Results.NotFound($"Motorbike with Id: {id} is not found");

        return Results.Ok(data);
    })
    .WithName("GetMotorbike")
    .WithTags("Motorbikes");

app.MapPost("api/motorbikes",
    async (MotorbikeCreateModel obj, ApplicationDbContext db) =>
    {
        var motorbike = new Motorbike
        {
            TeamName = obj.TeamName,
            Speed = obj.Speed,
            MelfunctionChance = obj.MelfunctionChance
        };

        db.Motorbikes.Add(motorbike);

        await db.SaveChangesAsync();

        return Results.CreatedAtRoute("GetCar", new { id = motorbike.Id }, motorbike);
    })
    .WithName("CreateMotorbike")
    .WithTags("Motorbikes");

app.MapPut("api/motorbikes/{id}",
    async ([FromQuery] int id, [FromBody] MotorbikeCreateModel obj, ApplicationDbContext db) =>
    {
        var motorbike = await db.Motorbikes.FirstOrDefaultAsync(x => x.Id == id);

        if (motorbike == null) return Results.NotFound($"Motorbike with id: {id} is not found");

        motorbike.TeamName = obj.TeamName;
        motorbike.Speed = obj.Speed;
        motorbike.MelfunctionChance = obj.MelfunctionChance;

        await db.SaveChangesAsync();

        return Results.Ok(motorbike);
    })
    .WithName("UpdateMotorbike")
    .WithTags("Motorbikes");

app.MapDelete("api/motorbikes/{id}",
    async (int id, ApplicationDbContext db) =>
    {
        var motorbike = await db.Motorbikes.FirstOrDefaultAsync(x => x.Id == id);

        if (motorbike == null) return Results.NotFound($"Motorbike with id: {id} is not found");

        db.Motorbikes.Remove(motorbike);

        await db.SaveChangesAsync();

        return Results.Ok();
    })
    .WithName("DeleteMotorbike")
    .WithTags("Motorbikes");

#endregion

#region endpoints: CAR RACES

app.MapGet("api/carraces",
    async (ApplicationDbContext db) =>
    {
        var carRaces = await db.CarRaces.Include(x => x.Cars).ToListAsync();

        return Results.Ok(carRaces);
    })
    .WithName("GetCarRaces")
    .WithTags("Car races");

app.MapGet("api/carraces/{id}",
    async (int id, ApplicationDbContext db) =>
    {
        var carRace = await db.CarRaces
                              .Include(x => x.Cars)
                              .FirstOrDefaultAsync(x => x.Id == id);

        if (carRace == null) return Results.NotFound($"Car race with id: {id} is not found");

        return Results.Ok(carRace);
    })
    .WithName("GetCarRace")
    .WithTags("Car races");

app.MapPost("api/carraces",
    async (CarRaceCreateModel obj, ApplicationDbContext db) =>
    {
        var newCarRace = new CarRace
        {
            Name = obj.Name,
            Location = obj.Location,
            Distance = obj.Distance,
            TimeLimit = obj.TimeLimit,
            Status = "Created"
        };

        db.CarRaces.Add(newCarRace);

        await db.SaveChangesAsync();

        return Results.CreatedAtRoute("GetCarRace", new { id = newCarRace.Id }, newCarRace);
    })
    .WithName("CreateCarRace")
    .WithTags("Car races");

app.MapPut("api/carraces/{id}",
    async ([FromQuery] int id, CarRaceCreateModel obj, ApplicationDbContext db) =>
    {
        var carRace = await db.CarRaces.Include(x => x.Cars).FirstOrDefaultAsync(x => x.Id == id);

        if (carRace == null) return Results.NotFound($"Car race with id: {id} is not found.");

        carRace.Name = obj.Name;
        carRace.Location = obj.Location;
        carRace.Distance = obj.Distance;
        carRace.TimeLimit = obj.TimeLimit;
        carRace.Status = "Updated";

        await db.SaveChangesAsync();

        return Results.Ok(carRace);
    })
    .WithName("UpdateCarRace")
    .WithTags("Car races");

app.MapDelete("api/carraces/{id}",
    async (int id, ApplicationDbContext db) =>
    {
        var carRace = await db.CarRaces.Include(x => x.Cars).FirstOrDefaultAsync(x => x.Id == id);

        if (carRace == null) return Results.NotFound($"Car race with id: {id} is not found.");

        db.CarRaces.Remove(carRace);

        await db.SaveChangesAsync();

        return Results.Ok($"Car race with id: {id} was successfully deleted");
    })
    .WithName("DeleteCarRace")
    .WithTags("Car races");

#endregion

app.Run();
