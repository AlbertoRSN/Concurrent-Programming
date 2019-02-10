# LINQ QUERIES IN C#

### Linq query consist of three distinct actions:
	
1. **Obtain the data source**
2. **Create the query**
3. **Execute the query**

![query](linq_query.png)

More information about Linq Queries [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries)



**DATA SOURCE**

```c#
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
```


**QUERY CREATION**

```c#
var result2 = from s in students
              orderby s.Country, s.Marks descending
              group s by s.Country;
````




**QUERY EXECUTION**

```c#
  foreach (var country in result2)
        {
            Console.WriteLine("");
            Console.WriteLine("{0}:", country.Key);  


            foreach (Student s in country) // Each group has inner collection
                Console.WriteLine("{0} \t  {1} \t {2}", s.Name, s.Faculty, s.Marks);
        }
````
	
