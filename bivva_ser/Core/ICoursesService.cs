using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bivva_ser.Core
{
    public interface ICoursesService
    {
        List<courses> GetAllCourses();
        courses GetCourseById(int id);
        courses CreateCourse(courses course);
        courses UpdateCourse(int id, courses course);
        void DeleteCourse(int id);
    }
}
