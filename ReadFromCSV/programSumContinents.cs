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
        Console.WriteLine("------------------------------------------------------------------------");
        Console.WriteLine(String.Format("{0, -25} {1, 15:n0} {2, 15:n0} {3, 10:n1}", "Country", "Population", "Area", "Density"));   
        Console.WriteLine("------------------------------------------------------------------------");

        long total = 0;

        var result = from c in Countries
            where (c.Continent == "Europe") && (c.Population / c.Area > 50)
            orderby c.Population/c.Area descending
            select c;

        foreach(Country c in result){
            Console.WriteLine(String.Format("{0, -25} {1, 15:n0} {2, 15:n0} {3, 10:n1}", c.Name, c.Population, c.Area, (1.0*c.Population/c.Area)));
        }   



        var result1 = from c in Countries
                      select c;

        foreach(Country c in result1){
            total+= c.Population;
        }

        Console.WriteLine("\n------------------------------------------------------------------------");

        Console.WriteLine(" - TOTAL Population: {0:n2} - ", total);

        Console.WriteLine("------------------------------------------------------------------------\n");

        Console.WriteLine(String.Format("{0, -25} {1, 20:n1}", "Continent", "Avg. Population"));   

        var result2 = from c in Countries
                      orderby c.Name
                      group c by c.Continent into groups
                      select new{
                        Continent = groups.Key,
                        AveragePopulation = groups.Average(c => c.Population),
                        //TotalPopulation = groups.Sum(c => c.Population),
                      };


        foreach (var cont in result2)
        {
            Console.WriteLine("");
            Console.WriteLine("{0, -15}  \t  {1, 25:n2}", cont.Continent, cont.AveragePopulation);
                
        }

        //int totalPopulation = result2.Sum(c => c.Population);


        Console.WriteLine("------------------------------------------------------------------------");

        //ong totalPerContinent = 0;

        var result3 = from c in Countries
                      group c by c.Continent into groups
                      select new{
                        Continent = groups.Key,
                        TotalPopulation = groups.Average(x => x.Population),
                      };

        foreach (var co in result3)
        {
            Console.WriteLine("{0, -15}  \t   {1, 25:n2}", co.Continent, co.TotalPopulation);       
        }
        


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