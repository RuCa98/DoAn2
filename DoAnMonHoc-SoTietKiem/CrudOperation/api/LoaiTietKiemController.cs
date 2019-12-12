using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CrudOperation.api
{
    // Route 
    [RoutePrefix("api/LoaiTietKiem")]
    public class LoaiTietKiemController : ApiController
    {
        SoTietKiemDBEntities dbContext = null;
        public LoaiTietKiemController()
        {
            dbContext = new SoTietKiemDBEntities();
        }


        [ResponseType(typeof(LoaiTietKiem))]
        [HttpPost]
        public HttpResponseMessage SaveLoaiTietKiem(LoaiTietKiem loaiTietKiem)
        {
            int result = 0;
            try
            {
                dbContext.LoaiTietKiems.Add(loaiTietKiem);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [ResponseType(typeof(LoaiTietKiem))]
        [HttpPut]
        public HttpResponseMessage UpdateLoaiTietKiem(LoaiTietKiem loaiTietKiem)
        {
            int result = 0;
            try
            {
                dbContext.LoaiTietKiems.Attach(loaiTietKiem);
                dbContext.Entry(loaiTietKiem).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [ResponseType(typeof(LoaiTietKiem))]
        [HttpDelete]
        public HttpResponseMessage DeleteLoaiTietKiem(int id)
        {
            int result = 0;
            try
            {
                var loaiTietKiem = dbContext.LoaiTietKiems.Where(x => x.ID == id).FirstOrDefault();
                dbContext.LoaiTietKiems.Attach(loaiTietKiem);
                dbContext.LoaiTietKiems.Remove(loaiTietKiem);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("GetLoaiTietKiemByID/{ID:int}")]
        [ResponseType(typeof(LoaiTietKiem))]
        [HttpGet]
        public LoaiTietKiem GetLoaiTietKiemByID(int ID)
        {
            LoaiTietKiem astudent = null;
            try
            {
                astudent = dbContext.LoaiTietKiems.Where(x => x.ID == ID).SingleOrDefault();

            }
            catch (Exception e)
            {
                astudent = null;
            }

            return astudent;
        }

        [ResponseType(typeof(LoaiTietKiem))]
        [HttpGet]
        public List<LoaiTietKiem> GetLoaiTietKiems()
        {
            List<LoaiTietKiem> loaiTietKiems = null;
            try
            {
                loaiTietKiems = dbContext.LoaiTietKiems.ToList();

            }
            catch (Exception e)
            {
                loaiTietKiems = null;
            }

            return loaiTietKiems;
        } 
    }
}
