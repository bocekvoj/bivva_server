using bivva_ser.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace bivva_ser.Services
{
    public class CoursesService : ICoursesService
    {
        public courses CreateCourse(courses course)
        {
            using (var db = new AppDbContext())
            {
                db.courses.Add(course);
                db.SaveChanges();
                return course;
            }
        }

        public void DeleteCourse(int id)
        {
            using (var db = new AppDbContext())
            {
                var course = new courses { course_id = id };
                db.courses.Attach(course);
                db.courses.Remove(course);
                db.SaveChanges();
            }
        }

        public List<courses> GetAllCourses()
        {
            using (var db = new AppDbContext())
            {
                var courses = (from c in db.courses select c).ToList();

                return courses;
            }
        }

        public courses GetCourseById(int id)
        {
            using (var db = new AppDbContext())
            {
                var course = (from c in db.courses where c.course_id == id select c).SingleOrDefault();
                return course;
            }
        }

        public courses UpdateCourse(int id, courses requestCourse)
        {
            var course = GetCourseById(id);
            if (course != null)
            {
                using (var db = new AppDbContext())
                {
                   
                        course.course_name = requestCourse.course_name;
                        course.tutor_id = requestCourse.tutor_id;
                        course.course_date = requestCourse.course_date;
                        course.course_description = requestCourse.course_description;

                        db.Entry(course).State = EntityState.Modified;
                        db.SaveChanges();
                   
                }
                return course;
            }
            else
            {
                // log error
                return null;
            }
        }
    }
}