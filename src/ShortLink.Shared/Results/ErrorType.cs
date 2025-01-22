using System.ComponentModel;

namespace ShortLink.Shared.Result
{
    public enum ErrorType
    {
        [Description("Informational")]
        None = 100,
        [Description("Server Error")]
        Failure = 500,
        [Description("Wrong Input")]
        Validation = 400,
        [Description("Unauthorized")]
        Unauthorized = 401,
        [Description("Not Found")]
        NotFound = 404,
    }
}