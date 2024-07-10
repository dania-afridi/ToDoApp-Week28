using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class TodoService
    {
        //------- Private Fields -----------//
        private static Todo[] TodoItems = new Todo[0];

        //------------- Public Methods --------------//

        //********** TO GET Item Array SIZE ************//
        public int Size() => TodoItems.Length;

        //********** TO GET ALL ToDoItems ************//
        public Todo[] FindAll() => TodoItems;

        //********** TO GET Item BY ID ************//
        public Todo FindById(int todoItemId)
        {
            foreach (Todo item in TodoItems)
            {
                if (item.Id == todoItemId) { return item; }
            }
            return null;
        }

        //********** TO CREATE TodoItem AND ADD IN TodoItems BY RESIZING TodoItems Array ************//
        public Todo Create(int itemId, string description)
        {
            Todo item = new Todo(itemId, description);

            Array.Resize(ref TodoItems, TodoItems.Length + 1); // Expand array to add new item
            TodoItems[^1] = item; // [^1] = [TodoItems.Length - 1]

            return item;
        }

        //********** TO RESET PEOPLE ************//
        public void Clear()
        {
            TodoItems = new Todo[0];
        }
    }
}
