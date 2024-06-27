using System.Net;

namespace Crud.Base.Extensions.Exceptions;

public class CustomException : Exception
{
    public CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, int? code = null) :
        base(message)
    {
        StatusCode = statusCode;
        Code = code;
    }

    public CustomException(
        string message,
        Exception innerException,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        int? code = null) : base(message, innerException)
    {
        StatusCode = statusCode;
        Code = code;
    }

    public CustomException(
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        int? code = null) : base()
    {
        StatusCode = statusCode;
        Code = code;
    }

    public HttpStatusCode StatusCode { get; set; }
    public int? Code { get; set; }
}