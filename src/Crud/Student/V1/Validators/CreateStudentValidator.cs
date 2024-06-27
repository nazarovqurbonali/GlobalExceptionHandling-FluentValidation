using Crud.Student.V1.Requests;
using FluentValidation;

namespace Crud.Student.V1.Validators;

public class CreateStudentValidator:AbstractValidator<CreateStudentRequest>
{
    public CreateStudentValidator()
    {
        RuleFor(x => x.LastName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Please enter a valid LastName");
        RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Please enter a valid FirstName");
        RuleFor(x => x.Email).Cascade(CascadeMode.Stop).Cascade(CascadeMode.Stop).NotEmpty().EmailAddress().WithMessage("Please enter a valid Email");
        RuleFor(x => x.PhoneNumber).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Please enter a valid PhoneNumber");
        RuleFor(x => x.Status).Cascade(CascadeMode.Stop).NotEmpty();
        RuleFor(x => x.Type).Cascade(CascadeMode.Stop).NotEmpty();
        RuleFor(x=>x.Address).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Please enter a valid Address");
    }
}