using Crud.Student.V1.Enums;

namespace Crud.Student.V1.Requests;

public record CreateStudentRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    string Address,
    Status Status,
    StudentType Type);