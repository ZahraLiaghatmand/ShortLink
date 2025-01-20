namespace ShortLink.Shared.Result
{
    public readonly record struct Error
    {
        private readonly string _message { get; }
        private readonly string _description { get; }
        private readonly ErrorType _type { get; }
        private Error(ErrorType type, string message, string description)
        {
            _type = type;
            _message = message;
            _description = description;
        }
        public static Error None(string message, string description)
            => new Error(ErrorType.None, message, description);
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