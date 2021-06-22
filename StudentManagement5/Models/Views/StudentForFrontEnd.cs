using System.Collections.Generic;

namespace StudentManagement5.Models.Views
{
    public class StudentForFrontEnd
    {
        public string SID { get; set; }
        public string FullName { get; set; }
        public string BirthDay { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public StudentForFrontEnd(Student student)
        {
            SID = student.SID;
            FullName = student.FullName;
            BirthDay = student.BirthDay.ToShortDateString();
            Address = student.Address;
            PhoneNumber = student.PhoneNumber;
        }
        public static List<StudentForFrontEnd> ToList(List<Student> list)
        {
            List<StudentForFrontEnd> students = new List<StudentForFrontEnd>();

            foreach (Student ex in list)
                students.Add(new StudentForFrontEnd(ex));

            return students;

        }
    }
}
