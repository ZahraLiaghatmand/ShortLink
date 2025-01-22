namespace ShortLink.Shared.Result
{
    /// <summary>
    /// It offers static factory methods to create common types of errors: 
    ///     (NotFound, Exception, Validation) 
    /// and uses ErrorType to define the nature of the error.
    /// The Error constructor is private to enforce the use of static factory methods, 
    ///  which is good for controlled instantiation.
    /// </summary>
    public readonly record struct Error
    {
        public string Message { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        public static Error None = new(ErrorType.None, string.Empty, string.Empty);
        private Error(ErrorType type, string message, string description)
        {
            Type = type;
            Message = message;
            Description = description;
        }

        public static implicit operator Result(Error error) => Result.Failure(error);

        public static Error Failure(string message, string description)
            => new Error(ErrorType.Failure, message, description);
        public static Error Validation(string message, string description)
            => new Error(ErrorType.Validation, message, description);
        public static Error Unauthorized(string message, string description)
            => new Error(ErrorType.Unauthorized, message, description);
        public static Error NotFound(string message, string description)
            => new Error(ErrorType.NotFound, message, description);
    }
}