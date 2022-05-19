using System.ComponentModel.DataAnnotations;

namespace CoureProject.Domain;

public class Source
{ 
    [Key]
    public string title { get; set; }
 	public string slug { get; set; }
 	public string url { get; set; }
 	public int crawl_rate { get; set; }
 }