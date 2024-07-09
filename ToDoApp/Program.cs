using ToDoApp.Models;

class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person(1, "Awais", "Khan");
        Console.WriteLine(person1.FirstName); 
    }
}
