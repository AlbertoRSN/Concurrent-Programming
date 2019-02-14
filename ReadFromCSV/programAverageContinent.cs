using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
//using System.Text;



class CoutriesOfTheWorld
{

    public static void Main()
    {

      IEnumerable<Country> Countries = GetCountries();
        Console.WriteLine("The number of countries: {0}", Countries.Count());  
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine(String.Format("{0, -15} {1, 35} ", "Country", "Average Population"));   
        Console.WriteLine("--------------------------------------------------------------");

        var result2 = from c in Countries
                      orderby c.Continent
                      group c by c.Continent into groups
                      select new{
                        Continent = groups.Key,
                        AveragePopulation = groups.Average(c => c.Population),
                      };

        foreach (var cont in result2)
        {
            Console.WriteLine("");
            Console.WriteLine("{0, -15}  \t  {1, 25:n2}", cont.Continent, cont.AveragePopulation);  
            
        }


        Console.WriteLine("--------------------------------------------------------------");


    }


       public class Country
      {
          public string Name { get; set; }
          public string Continent { get; set; }
          public int Population { get; set; }
          public int Area { get; set; }
          public double Gdp2010 { get; set; } 

      }

   
    public static IEnumerable<Country> GetCountries()
    {
        var countries = System.IO.File.ReadAllLines("data.csv");
 
    
        return (from line in countries
                let fields = line.Split(',')
                
                select new Country()
                {
                    Name = fields[0].Trim(),
                    Continent = fields[1].Trim(),
                    Population = Convert.ToInt32(fields[2]),
                    Area = Convert.ToInt32(fields[3].Trim()), 
                    Gdp2010 = Convert.ToDouble(fields[6].Trim())
                });
               
    }


    
}