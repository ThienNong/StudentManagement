using Microsoft.EntityFrameworkCore;
using StudentManagement5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement5.Services.BLL
{
    public class StudentService
    {
        public bool isValid(string SID)
        {
            using (var db = new StudentManagementContext())
            {
                var data = db.Students.Where(x => x.SID == SID).FirstOrDefault();
                return data != null;
            }
        }
        public List<Student> GetAllStudents()
        {
            using (var db = new StudentManagementContext())
            {
                var data = db.Students.ToList();

                if (data.Count() == 0)
                    return null;
                return data; 
            }
        }
        public Student GetStudent(string SID)
        {
            if (!isValid(SID))
                return null;

            using (var db = new StudentManagementContext())
            {
                var data = db.Students.Where(x => x.SID == SID).FirstOrDefault();
                return data;
            }
        }
        public List<Student> GetStudentFilters(Dictionary<string, object> filters = null)
        {
            var where = "";

            if (filters is not null)
            {
                foreach (var filter in filters)
                {
                    if (!String.IsNullOrEmpty(where))
                        where += " AND ";
                    string filterValue = "";
                    if (filter.Value is int) filterValue = $"{filter.Value}";
                    else if (filter.Value is short) filterValue = $"{filter.Value}";
                    else if (filter.Value is Guid) filterValue = $"{filter.Value}";
                    else filterValue = $"N'{filter.Value}'";

                    where += $" {filter.Key} = {filterValue} ";
                }
            }

            string sql = "SELECT * FROM Student ";

            if (!string.IsNullOrEmpty(where))
                sql += " WHERE " + where;

            using (var db = new StudentManagementContext())
            {
                try
                {
                    var data = db.Students.FromSqlRaw(sql).ToList();

                    if (data.Count == 0)
                        return null;
                    return data;
                }
                catch
                {
                    throw;
                }
            }
        }
        public Student AddStudent(Student data)
        {
            if (isValid(data.SID))
                return null;

            using (var db = new StudentManagementContext())
            {
                db.Students.Add(data);
                db.SaveChanges();
                return data;
            }
        }

        public Student UpdateStudent(Student data)
        {
            if (!isValid(data.SID))
                return null;

            using (var db = new StudentManagementContext())
            {
                db.Students.Update(data);
                db.SaveChanges();
                return data;
            }
        }

        public Student RemoveStudent(Student data)
        {
            if (!isValid(data.SID))
                return null;

            using (var db = new StudentManagementContext())
            {
                db.Students.Remove(data);
                db.SaveChanges();
                return data;
            }
        }
    }
}
