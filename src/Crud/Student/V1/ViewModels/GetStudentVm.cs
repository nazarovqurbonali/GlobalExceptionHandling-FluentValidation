using Crud.Student.V1.Enums;

namespace Crud.Student.V1.ViewModels;

public class GetStudentVm
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; } 
    public required string LastName { get; set; } 
    public required string PhoneNumber { get; set; } 
    public required string Email { get; set; } 
    public required string Address { get; set; } 
    public Status Status { get; set; }
    public StudentType Type { get; set; }
}