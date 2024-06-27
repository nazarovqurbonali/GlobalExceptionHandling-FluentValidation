using Crud.Student.V1.Requests;
using Crud.Student.V1.ViewModels;

namespace Crud.Student.V1.Service;

public interface IStudentService
{
     Task<List<GetStudentVm>> GetStudentsAsync();
     Task<GetStudentVm> GetStudentByIdAsync(Guid id);
     Task<string> CreateStudentAsync(CreateStudentRequest student);
     Task<string> UpdateStudentAsync(UpdateStudentRequest student);
     Task<bool> DeleteStudentAsync(DeleteStudentRequest request);
}