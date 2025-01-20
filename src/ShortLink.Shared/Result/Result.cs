using ShortLink.Shared.Result;

namespace ShortLink.Shared
{
    public readonly record struct Result<T>
    {
        private readonly T? _value = default;
        private readonly List<Error>? _errors = [];
        private bool HasErrors => _errors.Count > 0;
        public Result(T value)
        {
            _value = value;           
        }
        public Result(Error error)
        {
            _errors.Add(error);
            _errors = [];
        }
        public T Value { 
            get
            {
                if(HasErrors == true) { throw new Exception(); }
                return _value;
            } 
        }
        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value);
        }
        public static implicit operator Result<T>(Error error)
        {
            return new Result<T>(error);
        }
    }
}