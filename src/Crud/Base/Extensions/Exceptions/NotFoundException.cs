namespace Crud.Base.Extensions.Exceptions;

public class NotFoundException(string message, int? code = null) : CustomException(message,code:code);
