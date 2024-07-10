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

            //Size by adding item
            service.Create(1, "First item is cleanser.");
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

            //Size by adding item
            service.Create(1, "This item is very important for health.");
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
            Todo createItem = service.Create(1, "Important item for your health.");

            // Act
            Todo foundItem = service.FindById(createItem.Id);

            // Assert
            Assert.NotNull(service.FindById(createItem.Id));
            Assert.Equal(createItem.Id, foundItem.Id);

            //Size by adding item
            Todo item2 = service.Create(2, "This is second important item.");
            Todo foundItem2 = service.FindById(item2.Id);
            Assert.NotNull(foundItem2);
            Assert.Equal(item2.Id, foundItem2.Id);
        }

        //--------------- TodoService Create Method Testing ----------//
        [Fact]
        public void Create_ShouldAddItemToArray()
        {
            // Arrange
            TodoService service = new TodoService();
            service.Clear();

            // Act
            Todo newItem = service.Create(1, "Important Skin food.");
            int size = service.Size();

            // Assert
            Assert.NotNull(newItem);
            Assert.Equal(1, newItem.Id);
            Assert.Equal("Important Skin food.", newItem.Description);
            Assert.Equal(1, size);

        }

        //--------------- TodoService Clear Method Testing ----------//
        [Fact]
        public void Clear_ShouldRemoveAllItems()
        {
            // Arrange
            TodoService service = new TodoService();
            Todo newItem1 = service.Create(1, "Important Skin food.");
            Todo newItem2 = service.Create(2, "Important hair food.");

            // Act
            service.Clear();

            // Assert
            Assert.Equal(0, service.Size());
            Assert.Empty(service.FindAll());
        }
    }
}
