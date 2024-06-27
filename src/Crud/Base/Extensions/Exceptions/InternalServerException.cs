using System.Net;

namespace Crud.Base.Extensions.Exceptions;

public class InternalServerException(string message, int? code)
    : CustomException(message, HttpStatusCode.InternalServerError, code: code);
