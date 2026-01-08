using ClassNotes.Api.Data;
using ClassNotes.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotesDbContext>(options => options.UseSqlite("Data Source= ./Data/notes.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        //policy.WithOrigins("https://diwiatschool.github.io")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowReactApp");

// Get all notes
app.MapGet("/notes", async (NotesDbContext db) =>
{
    return await db.Notes.OrderBy(n => n.Id).ToListAsync();
});

app.MapGet("/notes1", GetAllNotes);

List<Note> GetAllNotes(NotesDbContext db)
{
    return db.Notes.ToList();
}

// Get note by ID
app.MapGet("/notes/{id}", async (int id, NotesDbContext db) =>
{
    return await db.Notes.FindAsync(id) is Note note
        ? Results.Ok(note)
        : Results.NotFound();
});

// New note
app.MapPost("/notes", async (Note note, NotesDbContext db) =>
{
    db.Notes.Add(note);
    await db.SaveChangesAsync();
    return Results.Created($"/notes/{note.Id}", note);
});

// Delete note
app.MapDelete("/notes/{id}", async (int id, NotesDbContext db) =>
{
    var note = await db.Notes.FindAsync(id);
    if (note is null) return Results.NotFound();
    db.Notes.Remove(note);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
