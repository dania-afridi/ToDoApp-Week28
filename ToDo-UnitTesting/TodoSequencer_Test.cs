using ToDoApp.Data;

namespace ToDo_UnitTesting
{
    public class TodoSequencer_Test
    {

        //--------------- Next_Todo_ItemId Testing ----------//
        [Fact]
        public void NextTodoItemId_ShouldIncrementAndReturnNextValue()
        {
            // Arrange
            TodoSequencer.Reset();

            // Act
            int firstTodoItemId = TodoSequencer.NextTodo_item_Id();
            int secondTodoItemId = TodoSequencer.NextTodo_item_Id();

            // Assert
            Assert.Equal(1, firstTodoItemId);
            Assert.Equal(2, secondTodoItemId);
        }

        //--------------- Reset Method Testing ----------//
        [Fact]
        public void Reset_ShouldSet_Todo_Item_Id_ToZero()
        {
            // Arrange
            int firstTodoItemId = TodoSequencer.NextTodo_item_Id();
            int secondTodoItemId = TodoSequencer.NextTodo_item_Id();

            // Act
            TodoSequencer.Reset();
            int Todo_ItemId_AfterReset = TodoSequencer.NextTodo_item_Id();

            // Assert
            Assert.Equal(1, Todo_ItemId_AfterReset);
        }
    }
}
