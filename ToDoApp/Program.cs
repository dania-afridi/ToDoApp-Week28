using ToDoApp.Models;

class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person(1, "Awais", "Khan");
        Console.WriteLine($"{person1.FirstName} {person1.LastName} has id number {person1.Id} ");

        string description = "He is a software engineer.";

        Todo list1 = new Todo(person1.Id, description);
        list1.Assignee = person1 ;
        list1.Done = true ;
        Console.WriteLine($"{list1.Id} contains {list1.Assignee.FirstName}. {list1.Description} and it is {list1.Done} that he is married. "); 
    }
}
