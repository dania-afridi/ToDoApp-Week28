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
        public Todo Create(string description)
        {
            int itemId = TodoSequencer.NextTodo_item_Id();
            Todo item = new Todo(itemId, description);

            Array.Resize(ref TodoItems, TodoItems.Length + 1); // Expand array to add new item
            TodoItems[^1] = item; // [^1] = [TodoItems.Length - 1]

            return item;
        }

        //********** TO RESET TodoItems ************//
        public void Clear()
        {
            TodoItems = new Todo[0];
        }

        //------------- Find methods to return array ------------------//

        //********** TO Find TodoItems have done status true ************//
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            return TodoItems.Where(todo => todo.Done == doneStatus).ToArray();
        }

        //********** TO Find TodoItems By Assignee Id ************//
        public Todo[] FindByAssignee(int personId)
        {
            return TodoItems.Where(todo => todo.Assignee != null && todo.Assignee.Id == personId).ToArray();
        }

        //********** TO Find TodoItems By Assignee ************//
        public Todo[] FindByAssignee(Person assignee)
        {
            return TodoItems.Where(todo => todo.Assignee == assignee).ToArray();
        }

        //********** TO Find TodoItems By Unassigned assignee value  ************//
        public Todo[] FindUnassignedTodoItems()
        {
            return TodoItems.Where(todo => todo.Assignee == null).ToArray();
        }

    }
}
