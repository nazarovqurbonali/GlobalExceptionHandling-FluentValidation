namespace Crud.Base.Extensions.Exceptions;

public class BadRequestException(string message, int? code = null) : CustomException(message, code: code);

