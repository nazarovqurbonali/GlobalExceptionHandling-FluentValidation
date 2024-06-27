using Crud.Student.V1.Requests;
using Crud.Student.V1.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers;

public class StudentController(IStudentService studentService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await studentService.GetStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{studentId:Guid}")]
    public async Task<IActionResult> GetStudent(Guid studentId)
    {
        var student = await studentService.GetStudentByIdAsync(studentId);
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request,
        IValidator<CreateStudentRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var res = Results.ValidationProblem(validationResult.ToDictionary(),
                validationResult.Errors.First().ErrorMessage);
            return BadRequest(res);
        }

        var student = await studentService.CreateStudentAsync(request);
        return Ok(student);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest request)
    {
        var student = await studentService.UpdateStudentAsync(request);
        return Ok(student);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(DeleteStudentRequest request)
    {
        var response = await studentService.DeleteStudentAsync(request);
        return Ok(response);
    }
}