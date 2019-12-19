using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    List<TiresInfoDto> list = new List<TiresInfoDto>();
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 145", 1996, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 145", 1997, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 145", 1998, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 145", 1999, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 145", 1996, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 145", 1997, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 146", 1996, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 146", 1997, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 146", 1998, 10, 10, 10));
    list.Add(new TiresInfoDto(1, "ALFA ROMEO", "ALFA ROMEO ALFA 146", 1999, 10, 10, 10));

    var result = (from item in list
      group item by item.brand into grp
      select grp.ToList().First()).ToList();
    //var result = list.GroupBy(item => item.brand).Select(grp => grp.ToList().First()).ToList();
    foreach(var res in result) {
      System.Console.WriteLine(res.brand);
      var result2 = list.Where(item => item.brand == res.brand).GroupBy(item => item.year).Select(grp => grp.ToList().First()).ToList();
      foreach(var res1 in result2) {
        System.Console.WriteLine(res1.year);
        var result3 = list.Where(item => item.year == res1.year).GroupBy(item => item.model).Select(grp => grp.ToList().First()).ToList();
        foreach(var res2 in result3) {
          System.Console.WriteLine(res2.model);
        }
      } 
    }

  }
}

public class TiresInfoDto
{
  public double id { get; set; }
  public string brand { get; set; }
  public string model { get; set; }
  public double year { get; set; }
  public double wheel { get; set; }
  public double width { get; set; }
  public double profile { get; set; }

  public TiresInfoDto(double id, string brand, string model, double year, double wheel, double width,  double profile) {
    this.id = id;
    this.brand = brand;
    this.model = model;
    this.year = year;
    this.wheel = wheel;
    this.width = width;
    this.profile = profile;
  }
}