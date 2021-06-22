using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement5.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string SID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Student() { }
    }
}
