using System;
using System.Linq;
using System.Collections.Generic;

// LINQ Query Syntax examples

public class Program
{
    public static void Main()
    {
        // Create new collection, type STUDENT
        List<Student> students = new List<Student>() {
                new Student() { Country = "Spain", Name = "Zbych", Marks = 13, Faculty = "Informatics"} ,
                new Student() { Country = "Spain", Name = "John", Marks = 11, Faculty = "Informatics"} ,
                new Student() { Country = "Poland", Name = "Ala", Marks = 12, Faculty = "Mathematics" } ,
                new Student() { Country = "Spain", Name = "Ola", Marks = 9, Faculty = "Informatics" } ,
                new Student() { Country = "Poland", Name = "Ela", Marks = 4, Faculty = "Mathematics"} ,
                new Student() { Country = "Spain", Name = "Ula", Marks = 10, Faculty = "Informatics" },
                new Student() { Country = "Spain", Name = "Rick", Marks = 12, Faculty = "Medicine" },
                new Student() { Country = "Spain", Name = "Henek", Marks = 10, Faculty = "Mathematics" },
                new Student() { Country = "Poland", Name = "Basia", Marks = 14, Faculty = "Medicine" },
                new Student() { Country = "Turkey", Name = "Anna", Marks = 11, Faculty = "Mathematics" },
                new Student() { Country = "Turkey", Name = "Fred", Marks = 5, Faculty = "Informatics" },
                new Student() { Country = "Spain", Name = "Beata", Marks = 9, Faculty = "Psychology" }

            };


        Console.WriteLine("----------------------------------------");
        Console.WriteLine("(Ex 4.) Candidates by faculties:");
        //-----------------------------------

        /* LINQ Query where we can acces to the list students with s, 
         * order by Country and Marks (descending) 
         * and then we group the result by Country.
        */
        var result2 = from s in students
                          //where s.Marks > 11
                      orderby s.Country, s.Marks descending
                      group s by s.Country;

        /* 
         * We have grouped the data by something, in this case by country, 
         * so the key holds the country name, we acces the result2 and then,
         * with other foreach we show the students properties (name, faculty and mark).
        */
        
        foreach (var country in result2)
        {
            Console.WriteLine("");
            Console.WriteLine("{0}:", country.Key);  


            foreach (Student s in country) // Each group has inner collection
                Console.WriteLine("{0} \t  {1} \t {2}", s.Name, s.Faculty, s.Marks);
        }


        Console.WriteLine("----------------------------------------");
        Console.WriteLine("(Ex 5.) Average for all faculties:");

        /*
        * This is the query simple sintax where we access the list students and then group
        * the students by country into groups.
        */
        var result3 =
            from s in students
            group s by s.Country into groups
            
            /*
            * Here we create 2 columns, so we save the values in result3
            * As in the previous exercise, we use .KEY , it returns IEnumerable<TKey,T> 
            * in which the TKey is the type of property by which we have applied grouping
            */
            select new
            {
                Country = groups.Key,
                AverageMarks = groups.Max(s => s.Marks),
            };

        /*
        * This foreach is to access the list result3 and show the "result" of our previous query.
        * Country ---- AverageMark 
        */
        foreach (var f in result3)
        {
            Console.WriteLine("{0} \t  {1}", f.Country, f.AverageMarks);
        }

        Console.ReadKey();

    }
}

public class Student
{

    public string Country { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
    public string Faculty { get; set; }

}


