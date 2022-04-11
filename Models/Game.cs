using System.ComponentModel.DataAnnotations;

namespace csharp.Models;

public class Game{
    public int Id { get; set; }

    [MaxLength(30)]
    public string? City { get; set; }

    [MaxLength(30)]
    public string? Country { get; set; } 

    [MaxLength(30)]
    public string? Continent { get; set; } 

    [MaxLength(30)]
    public string? Season { get; set; } 
    public short Year { get; set; }
    public DateTime Opening { get; set; } 
    public DateTime Closing { get; set; }
}