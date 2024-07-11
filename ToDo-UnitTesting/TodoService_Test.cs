using ToDoApp.Data;
using ToDoApp.Models;
using Xunit;

namespace ToDo_UnitTesting
{
    public class TodoService_Test
    {
        //--------------- TodoService Size Testing ----------//
        [Fact]
        public void Size_ShouldReturnLengthOfArray()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();
            
            // Act
            int size = service.Size();

            // Assert
            Assert.Equal(0, size);

            // Check Size by adding item
            
            service.Create("First item is cleanser.");
            size = service.Size();
            Assert.Equal(1, size);
        }

        //--------------- TodoService FindAll Method Testing ----------//
        [Fact]
        public void FindAll_ShouldReturnTodoItemsArray()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();

            // Act
            Todo[] allItems = service.FindAll();

            // Assert
            Assert.NotNull(allItems);
            Assert.Empty(service.FindAll());

            // Check array by adding item
            service.Create("This item is very important for health.");
            allItems = service.FindAll();
            Assert.Single(allItems);
        }

        //--------------- TodoService FindById Method Testing ----------//
        [Fact]
        public void FindById_ShouldReturnCorrectItem()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();
            Todo createItem = service.Create("Important item for your health.");

            // Act
            Todo foundItem = service.FindById(createItem.Id);

            // Assert
            Assert.NotNull(foundItem);
            Assert.Equal(createItem.Id, foundItem.Id);

        }

        //--------------- TodoService Create Method Testing ----------//
        [Fact]
        public void Create_ShouldAddItemToArray()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();

            // Act
            Todo newItem = service.Create("Important Skin food.");

            // Assert
            Assert.NotNull(newItem);
            Assert.Equal(TodoSequencer.NextTodo_item_Id()-1, newItem.Id);
            Assert.Equal("Important Skin food.", newItem.Description);
            Assert.Equal(1, service.Size());

        }

                                                                                                            //--------------- TodoService Clear Method Testing ----------//
        [Fact]
        public void Clear_ShouldRemoveAllItems()
        {
            // Arrange
            TodoService service = new TodoService();
            Todo newItem1 = service.Create("Important Skin food.");
            Todo newItem2 = service.Create("Important hair food.");

            // Act
            service.Clear();

            // Assert
            Assert.Equal(0, service.Size());
            Assert.Empty(service.FindAll());
        }

        //------------- Test Cases for Find methods ------------------//

        //--------------- TodoService FindByDoneStatus Method Testing ----------//
        [Fact]
        public void FindByDoneStatus_shouldReturnTodoItemsWithDoneStatus()
        {
            // Arrange
            TodoService service = new TodoService(); 
            service.Clear();
            Todo item1 = service.Create("This is item1.");
            item1.Done = true;
            Todo item2 = service.Create("This is item2.");
            item2.Done = false;

            // Act 
            Todo[] todoitemWithDone = service.FindByDoneStatus(true);
            Todo[] todoitemWithNotDone = service.FindByDoneStatus(false);

            // Assert
            Assert.Single(todoitemWithDone);
            Assert.Equal(item1 , todoitemWithDone[0]);
            Assert.Single(todoitemWithNotDone);
            Assert.Equal(item2, todoitemWithNotDone[0]);

        }

        //--------------- TodoService FindByAssignee Method Testing ----------//
        [Fact]
        public void FindByAssignee_shouldReturnTodoItemsWithMatchingAssigneeId()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();
            Person assignee1 = new Person(1, "Awais", "Khan");
            Person assignee2 = new Person(2, "Anabia", "Khan");
            Todo item1 = service.Create("This is item1.");
            item1.Assignee = assignee1;
            Todo item2 = service.Create("This is item2.");
            item2.Assignee = assignee2;

            // Act 
            Todo[] todoitemWithAssignee1 = service.FindByAssignee(1);
            Todo[] todoitemWithAssignee2 = service.FindByAssignee(2);

            // Assert
            Assert.Single(todoitemWithAssignee1);
            Assert.Equal(item1, todoitemWithAssignee1[0]);
            Assert.Single(todoitemWithAssignee2);
            Assert.Equal(item2, todoitemWithAssignee2[0]);

        }

        //--------------- TodoService FindByAssignee Method Testing ----------//
        [Fact]
        public void FindByAssignee_shouldReturnTodoItemsWithMatchingAssignee()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();
            Person assignee1 = new Person(1, "Awais", "Khan");
            Person assignee2 = new Person(2, "Anabia", "Khan");
            Todo item1 = service.Create("This is item1.");
            item1.Assignee = assignee1;
            Todo item2 = service.Create("This is item2.");
            item2.Assignee = assignee2;

            // Act 
            Todo[] todoitemWithAssignee1 = service.FindByAssignee(assignee1);
            Todo[] todoitemWithAssignee2 = service.FindByAssignee(assignee2);

            // Assert
            Assert.Single(todoitemWithAssignee1);
            Assert.Equal(item1, todoitemWithAssignee1[0]);
            Assert.Single(todoitemWithAssignee2);
            Assert.Equal(item2, todoitemWithAssignee2[0]);

        }

        //--------------- TodoService FindUnassignedTodoItems Method Testing ----------//
        [Fact]
        public void FindUnassignedTodoItems_shouldReturnTodoItemsWithoutAssignee()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();
            Person assignee1 = new Person(1, "Awais", "Khan");

            Todo item1 = service.Create("This is item1.");
            Todo item2 = service.Create("This is item2.");
            item2.Assignee = assignee1;

            // Act 
            Todo[] unAssignedItem = service.FindUnassignedTodoItems();

            // Assert
            Assert.Single(unAssignedItem);
            Assert.Equal(item1, unAssignedItem[0]);

        }

        //--------------- TodoService Remove Method Testing ----------//
        [Fact]
        public void RemoveItem_ShouldRemoveItemFromArray()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();
            Todo item1 = service.Create("This is item number one.");
            Todo item2 = service.Create("This is item number two.");

            // Act
            service.RemoveItem(item1.Id);

            // Assert
            Assert.Single(service.FindAll());
            Assert.Null(service.FindById(item1.Id));
            Assert.NotNull(service.FindById(item2.Id));
        }
    }
}
