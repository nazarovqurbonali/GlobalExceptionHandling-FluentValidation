using Crud.Student.V1.Requests;
using FluentValidation;

namespace Crud.Student.V1.Validators;

public class DeleteStudentValidator:AbstractValidator<DeleteStudentRequest>
{
    public DeleteStudentValidator()
    {
        RuleFor(x => x.StudentId).NotEmpty().NotEqual(Guid.Empty).WithMessage("Id must be provided and not empty.");
    }
}