using Crud.Base;
using Crud.Base.Extensions.Exceptions;
using Crud.Student.V1.Requests;
using Crud.Student.V1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Crud.Student.V1.Service;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<List<GetStudentVm>> GetStudentsAsync()
    {
        var students = await context.Students.Where(x => !x.IsDeleted).Select(x => new GetStudentVm()
        {
            Address = x.Address,
            Email = x.Email,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
            Id = x.Id,
            Status = x.Status,
            Type = x.Type
        }).ToListAsync();
        return students;
    }

    public async Task<GetStudentVm> GetStudentByIdAsync(Guid id)
    {
        var existing = await context.Students.Where(x => !x.IsDeleted)
            .Select(x => new GetStudentVm()
            {
                Address = x.Address,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Id = x.Id,
                Status = x.Status,
                Type = x.Type
            }).FirstOrDefaultAsync(x => x.Id == id);
        return existing ?? throw new NotFoundException("Data not found", 404);
    }

    public async Task<string> CreateStudentAsync(CreateStudentRequest student)
    {
        var existing = await context.Students.FirstOrDefaultAsync(x => x.Email == student.Email);
        if (existing is not null)
            throw new BadRequestException("Student already exists", 400);
        var newStudent = Entities.Student.Create(student);
        await context.Students.AddAsync(newStudent);
        var res = await context.SaveChangesAsync();

        return res > 0
            ? $"Created by Id:{newStudent.Id}"
            : throw new InternalServerException("Data not saved", 500);
    }

    public async Task<string> UpdateStudentAsync(UpdateStudentRequest student)
    {
        var existing = await context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
        if (existing is null)
            throw new NotFoundException("Data not found", 404);

        var res = await context.Students.Where(x => x.Id == student.Id).ExecuteUpdateAsync(x =>
            x.SetProperty(p => p.FirstName, student.FirstName)
                .SetProperty(p => p.LastName, student.LastName)
                .SetProperty(p => p.PhoneNumber, student.PhoneNumber)
                .SetProperty(p => p.Email, student.Email)
                .SetProperty(p => p.Address, student.Address)
                .SetProperty(p => p.Status, student.Status)
                .SetProperty(p => p.Type, student.Type)
        );

        return res > 0
            ? $"Updated by Id:{student.Id}"
            : throw new InternalServerException("Data not updated", 500);
    }

    public async Task<bool> DeleteStudentAsync(DeleteStudentRequest request)
    {
        var existing = await context.Students.Where(x => x.Id == request.StudentId && !x.IsDeleted).ExecuteUpdateAsync(x =>
            x.SetProperty(p => p.IsDeleted, true));
        return existing > 0
            ? true
            : throw new NotFoundException("Data not found", 404);
    }
}