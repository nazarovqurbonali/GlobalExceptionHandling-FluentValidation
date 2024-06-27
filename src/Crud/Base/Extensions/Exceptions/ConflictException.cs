namespace Crud.Base.Extensions.Exceptions;

public class ConflictException(string message, int? code = null) : CustomException(message, code: code);
