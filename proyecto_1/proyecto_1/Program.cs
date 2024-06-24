// LINQ nos sirve para hacer funciones parecidas a SQL

//var names = new List<string>()
var names = new List<string>()
{
    "hector","francisco","ana","hugo","pedro"
};


var namesResult = from n in names
                  // cosas que hacer con LINQ
                  where n.Length > 3 && n.Length < 5
                  orderby n descending
                  //consulta ejecutada
                  //select n).ToList();

                  select n;


var namesResult2 = names.Where(n =>n.Length>3 && n.Length<5)
                        .OrderByDescending(n => n)
                        .Select(d=>d);

foreach (var name in namesResult2)
{
    Console.WriteLine(name);
}