using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int YearOfGraduating { get; set; }
        public string DateOfJoining { get; set; }
        public string Language { get; set; }
        public bool IsActive { get; set; }

        // Foreign Key
        public int CollegeId { get; set; }
        // Navigation property
        public College College { get; set; }
        // Foreign Key
        public int StreamId { get; set; }
        // Navigation property
        public Stream Stream { get; set; }
        // Foreign Key
        public int BranchId { get; set; }
        // Navigation property
        public Branch Branch { get; set; }
        // Foreign Key
        public int QualificationId { get; set; }
        // Navigation property
        public Qualification Qualification { get; set; }

    }
}