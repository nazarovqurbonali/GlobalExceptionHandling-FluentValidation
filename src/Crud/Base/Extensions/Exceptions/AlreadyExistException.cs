namespace Crud.Base.Extensions.Exceptions;

public class AlreadyExistException(string message, int? code = null) : CustomException(message, code: code);