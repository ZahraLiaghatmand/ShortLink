using System.Text.Json.Serialization;

namespace ShortLink.Shared.Result
{
    /// <summary>
    /// Using method factory to
    /// Represents an operation's result with IsSuccess and Error properties.
    /// Uses IsFailure to invert IsSuccess for easier readability.
    /// Static methods Success() and Failure(Error error) create instances with appropriate states.
    /// Generic static methods forward creation to Result<T>, ensuring consistency in handling typed results.
    /// </summary>
    public class Result
    {
        public bool IsSuccess{get; init;}
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;
        public Error Error {get; init;}

        protected Result(bool isSuccess,Error error) 
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<T> Success<T>(T data)
            => Result<T>.Success(data);
        public static Result<T> Failure<T>(Error error) 
            => Result<T>.Failure(error);
    }

    public class Result<T> : Result
    {
        public T Value { get; }
        protected Result(bool isSuccess,T value, Error error) : base(isSuccess, error)
        {
            Value = value;
        }
        public static Result<T> Success(T value) 
            => new(true, value, Error.None);
        public static Result<T> Failure(Error error) 
            => new(false,default!, error);
    }
}