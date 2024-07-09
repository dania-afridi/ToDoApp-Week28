using ToDoApp.Models;

namespace ToDo_UnitTesting
{
    public class Todo_Test
    {
        //------------------- Description Initialization TEST ----------------//
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int _id = 2;
            string _description = "This is todo class test.";

            // Act
            Todo list = new Todo(_id, _description);

            // Assert
            Assert.Equal(_id, list.Id);
            Assert.Equal(_description, list.Description);
            Assert.False(list.Done);
            Assert.Null(list.Assignee);
        }

        //------------------- Description Setter Exception TEST ----------------//
        [Fact]
        public void Description_Setter_ShouldThrowArgumentException_WhenNullOrEmpty()
        {
            // Arrange
            int _id = 2;
            string _description = "";

            // Act
            Todo list = new Todo(_id, _description);

            // Assert
            Assert.Throws<ArgumentNullException>(() => list.Description = null);
            Assert.Throws<ArgumentNullException>(() => list.Description = "");
            Assert.Throws<ArgumentNullException>(() => list.Description = " ");
        }

        //------------------- Description Setter Updation TEST ----------------//
        [Fact]
        public void Description_Setter_ShouldUpdateValue()
        {
            // Arrange
            Todo list = new Todo(2, "This is todo class test.");
            string new_description = "Updated test for description.";

            // Act
            list.Description = new_description;

            // Assert
            Assert.Equal(list.Description, new_description);
        }

        //------------------- Done Setter Updation TEST ----------------//
        [Fact]
        public void Done_Setter_ShouldUpdateValue()
        {
            // Arrange
            Todo list = new Todo(2, "This is todo class test.");

            // Act
            list.Done = true;

            // Assert
            Assert.True(list.Done);
        }

        //------------------- Assignee Setter Updation TEST ----------------//
        [Fact]
        public void Assignee_Setter_ShouldUpdateValue()
        {
            // Arrange
            Todo list = new Todo(2, "This is todo class test.");
            Person assignee = new Person(3, "Anabia", "Awaisdotter");
            
            // Act
            list.Assignee = assignee;

            // Assert
            Assert.Equal(list.Assignee, assignee);
        }

    }
}

