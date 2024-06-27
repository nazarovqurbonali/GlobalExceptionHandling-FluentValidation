using Crud.Student.V1.Enums;
using Crud.Student.V1.Requests;

namespace Crud.Student.V1.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public Status Status { get; set; }
        public StudentType Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
        
        public static  Student  Create(CreateStudentRequest request)
        {
            return new Student
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                Status = Status.Active,
                Type = request.Type,
                CreatedAt = DateTime.UtcNow
            };
        }
        
        public void Update(UpdateStudentRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            PhoneNumber = request.PhoneNumber;
            Email = request.Email;
            Address = request.Address;
            Status = request.Status;
            Type = request.Type;
        }
    }
}