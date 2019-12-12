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
    [RoutePrefix("api/TaiKhoan")]
    public class TaiKhoanController : ApiController
    {
        SoTietKiemDBEntities dbContext = null;
        public TaiKhoanController()
        {
            dbContext = new SoTietKiemDBEntities();
        }


        [ResponseType(typeof(TaiKhoanKhachHang))]
        [HttpPost]
        public HttpResponseMessage SaveTaiKhoanKhachHang(TaiKhoanKhachHang taiKhoanKhachHang)
        {
            int result = 0;
            try
            {
                dbContext.TaiKhoanKhachHangs.Add(taiKhoanKhachHang);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [ResponseType(typeof(TaiKhoanKhachHang))]
        [HttpPut]
        public HttpResponseMessage UpdateTaiKhoanKhachHang(TaiKhoanKhachHang taiKhoanKhachHang)
        {
            int result = 0;
            try
            {
                dbContext.TaiKhoanKhachHangs.Attach(taiKhoanKhachHang);
                dbContext.Entry(taiKhoanKhachHang).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [ResponseType(typeof(TaiKhoanKhachHang))]
        [HttpDelete]
        public HttpResponseMessage DeleteTaiKhoanKhachHang(int id)
        {
            int result = 0;
            try
            {
                var taiKhoanKhachHang = dbContext.TaiKhoanKhachHangs.Where(x => x.ID == id).FirstOrDefault();
                dbContext.TaiKhoanKhachHangs.Attach(taiKhoanKhachHang);
                dbContext.TaiKhoanKhachHangs.Remove(taiKhoanKhachHang);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("GetTaiKhoanKhachHangByID/{ID:int}")]
        [ResponseType(typeof(TaiKhoanKhachHang))]
        [HttpGet]
        public TaiKhoanKhachHang GetTaiKhoanKhachHangByID(int ID)
        {
            TaiKhoanKhachHang aTaiKhoanKhachHang = null;
            try
            {
                aTaiKhoanKhachHang = dbContext.TaiKhoanKhachHangs.Where(x => x.ID == ID).SingleOrDefault();

            }
            catch (Exception e)
            {
                aTaiKhoanKhachHang = null;
            }

            return aTaiKhoanKhachHang;
        }

        [ResponseType(typeof(TaiKhoanKhachHang))]
        [HttpGet]
        public List<TaiKhoanKhachHang> GetTaiKhoans()
        {
            List<TaiKhoanKhachHang> taiKhoanKhachHangs = null;
            try
            {
                taiKhoanKhachHangs = dbContext.TaiKhoanKhachHangs.ToList();

            }
            catch (Exception e)
            {
                taiKhoanKhachHangs = null;
            }

            return taiKhoanKhachHangs;
        }
    }
}
