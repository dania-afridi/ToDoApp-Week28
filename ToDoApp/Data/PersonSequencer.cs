namespace ToDoApp.Data

{
    public static class PersonSequencer
    {
        private static int personId;
        public static int NextPersonId() => ++personId;
        public static void Reset() => personId = 0;
    }
}
