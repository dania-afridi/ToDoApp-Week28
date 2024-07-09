namespace ToDoApp.Data
{
    public static class TodoSequencer
    {
        private static int Todo_item_Id;
        public static int NextTodo_item_Id() => ++Todo_item_Id;
        public static void Reset() => Todo_item_Id = 0;
    }
}
