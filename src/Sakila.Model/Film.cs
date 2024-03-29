﻿using System.ComponentModel.DataAnnotations;

namespace Sakila.Model;

public class Film
{
    public int Id { get; set; }   
    public string Title { get; set; }
    public string Description { get; set; }
    public string ReleaseYear { get; set; }
    public string Rating { get; set; }
    public int RentalDuration {  get; set; }
    public decimal RentalRate { get; set; }
}
