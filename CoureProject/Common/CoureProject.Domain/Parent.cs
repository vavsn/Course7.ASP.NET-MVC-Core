﻿using System.ComponentModel.DataAnnotations;

namespace CoureProject.Domain;

public class Parent
{
	public string title { get; set; }
	public string location_type { get; set; }
	public string  latt_long { get; set; }
	[Key]
	public int woeid { get; set; }

}
