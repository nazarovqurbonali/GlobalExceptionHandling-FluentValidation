namespace Crud.Base.Extensions.Exceptions;

public class ValidationException(string message, int? code = null) : CustomException(message, code: code);
