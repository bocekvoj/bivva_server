using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using bivva_ser.Core;
using bivaa_server_main.Utils;

namespace bivva_ser.Controllers
{
    public class CoursesController : BaseController

    {
        private ICoursesService coursesService;
        public CoursesController(ICommonService commonService, ICoursesService coursesService) : base(commonService)
        {
            this.coursesService = coursesService;
        }

        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetAll()
        {
            var courses = coursesService.GetAllCourses();
            return commonService.GetResponse(courses.toJson());
        }
        [HttpGet]
        [ActionName("detail")]
        public HttpResponseMessage GetDetail(int id)
        {
            var courses = coursesService.GetCourseById(id);
            return commonService.GetResponse(courses.toJson());
        }
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage Create(HttpRequestMessage req)
        {
            try
            {
                var requestBody = req.Content.ReadAsStringAsync().Result;
                var requestCourse = requestBody.fromJson<courses>();
                var createdCourse = coursesService.CreateCourse(requestCourse);
                return commonService.GetResponse(createdCourse.toJson());
            }
            catch
            {
                return commonService.GetResponse();
            }
            }
        [HttpPut]
        [ActionName("update")]
        public HttpResponseMessage Update(int id, HttpRequestMessage req)
        {
            var requestBody = req.Content.ReadAsStringAsync().Result;
            //var requestCourse = JsonConvert.DeserializeObject<courses>(requestBody);
            var requestCourse = requestBody.fromJson<courses>();
            var updatedCourse = coursesService.UpdateCourse(id, requestCourse);
            return commonService.GetResponse(updatedCourse.toJson());

        }
        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int id)
        {
            coursesService.DeleteCourse(id);
            return commonService.GetResponse();
        }
    }
}