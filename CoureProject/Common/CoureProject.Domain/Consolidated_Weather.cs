﻿namespace CoureProject.Domain;

public class Consolidated_Weather
{
	public List<Weather> weathers { get; set; }
	public DateTime	time { get; set; }

	public DateTime sun_rise { get; set; }
	public DateTime sun_set { get; set; }

	public string timezone_name {get; set; }

	public Parent parent { get; set; }

	public List<Source> sources { get; set; }
	public string title { get; set; }
	public string location_type { get; set; }
	public int woeid { get; set; }
	public string latt_long { get; set; }
	public string timezone { get; set; }
}
