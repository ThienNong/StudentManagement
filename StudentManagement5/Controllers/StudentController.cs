using Microsoft.AspNetCore.Mvc;
using StudentManagement5.Models;
using StudentManagement5.Models.Views;
using StudentManagement5.Services.BLL;
using System;
using System.Collections.Generic;

namespace StudentManagement5.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ForFrontEnd<List<StudentForFrontEnd>> GetAllStudents()
        {
            var data = StudentForFrontEnd.ToList(new StudentService().GetAllStudents());

            try
            {   
                if (data == null)
                    return ForFrontEnd<List<StudentForFrontEnd>>.False(data, "Không có dữ liệu", null);

                return ForFrontEnd<List<StudentForFrontEnd>>.True(data);
            }
            catch (Exception e)
            {
                return ForFrontEnd<List<StudentForFrontEnd>>.False(data, "Lỗi!", e);
            }
        }

        [HttpGet]
        public ForFrontEnd<StudentForFrontEnd> GetStudent(string SID)
        {
            var data = new StudentForFrontEnd(new StudentService().GetStudent(SID));

            try
            {
                if (data == null)
                    return ForFrontEnd<StudentForFrontEnd>.False(data, "Không có dữ liệu", null);

                return ForFrontEnd<StudentForFrontEnd>.True(data);
            }
            catch (Exception e)
            {
                return ForFrontEnd<StudentForFrontEnd>.False(data, "Lỗi!", e);
            }
        }

        [HttpPost]
        public ForFrontEnd<List<StudentForFrontEnd>> GetStudentFilter([FromBody]Dictionary<string, object> filters)
        {
            //var data = StudentForFrontEnd.ToList(new StudentService().GetStudentFilters(filters));
            var result = new StudentService().GetStudentFilters(filters);

            List<StudentForFrontEnd> data;

            if (result != null)
                data = StudentForFrontEnd.ToList(result);
            else
                data = null;

            try
            {
                if (data == null)
                    return ForFrontEnd<List<StudentForFrontEnd>>.False(data, "Không có dữ liệu", null);

                return ForFrontEnd<List<StudentForFrontEnd>>.True(data);
            }
            catch (Exception e)
            {
                return ForFrontEnd<List<StudentForFrontEnd>>.False(data, "Lỗi!", e);
            }
        }

        [HttpPost]
        public ForFrontEnd<StudentForFrontEnd> AddStudent([FromBody] Student student)
        {
            var result = new StudentService().AddStudent(student);

            StudentForFrontEnd data;

            if (result != null)
                data = new StudentForFrontEnd(result);
            else
                data = null;

            try
            {
                if (data == null)
                    return ForFrontEnd<StudentForFrontEnd>.False(data, "Đã tồn tại học sinh có SID này!", null);

                return ForFrontEnd<StudentForFrontEnd>.True(data);
            }
            catch (Exception e)
            {
                return ForFrontEnd<StudentForFrontEnd>.False(data, "Lỗi!", e);
            }
        }

        [HttpPut]
        public ForFrontEnd<StudentForFrontEnd> UpdateStudent([FromBody] Student student)
        {
            var result = new StudentService().UpdateStudent(student);

            StudentForFrontEnd data;

            if (result != null)
                data = new StudentForFrontEnd(result);
            else
                data = null;

            try
            {
                if (data == null)
                    return ForFrontEnd<StudentForFrontEnd>.False(data, "Không tồn tại!", null);

                return ForFrontEnd<StudentForFrontEnd>.True(data);
            }
            catch (Exception e)
            {
                return ForFrontEnd<StudentForFrontEnd>.False(data, "Lỗi!", e);
            }
        }

        [HttpDelete]
        public ForFrontEnd<StudentForFrontEnd> RemoveStudent([FromBody] Student student)
        {
            var result = new StudentService().RemoveStudent(student);

            StudentForFrontEnd data;

            if (result != null)
                data = new StudentForFrontEnd(result);
            else
                data = null;

            try
            {
                if (data == null)
                    return ForFrontEnd<StudentForFrontEnd>.False(data, "Không tồn tại!", null);

                return ForFrontEnd<StudentForFrontEnd>.True(data);
            }
            catch (Exception e)
            {
                return ForFrontEnd<StudentForFrontEnd>.False(data, "Lỗi!", e);
            }
        }
    }
}
