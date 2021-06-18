namespace TrainingProject.Core
{
    public static class ExceptionMessagesHelper
    {
        public const string notFound = "not Found";
        public const string repeatKey = "An entry with this key is already in the database";
        public const string noForeingKey = "There is no foreign key with this value";
        public const string incorrectSize = "The size must be between 1 and 3";
        public const string incorrectSide = "The side must be positive";
        public const string deleteSD = "You can't delete a department because it has dependent stands";
    }
}