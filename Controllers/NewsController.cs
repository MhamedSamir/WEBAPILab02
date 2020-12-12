using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPILab02.Models;


namespace WEBAPILab02.Controllers
{
    public class NewsController : ApiController
    {
        NewsDtcx Dtcx = new NewsDtcx();


        public IHttpActionResult get()
        {
            List<news> news = Dtcx.news.ToList();
            var lst = news.Select(i => new
            {
                id = i.id,
                Title = i.title,
                desc = i.desc,
                pref = i.pref,
                Photo = i.photo,
               
                Catogery_id=i.catogery_id,
                
                Date = i.date
            });
            return Ok(lst);
        }
       
            public IHttpActionResult GetNews(int id)
            {
                news n = Dtcx.news.Find(id);
                if (n == null)
                {
                    return NotFound();
                }

                return Ok(n);
            }
        public IHttpActionResult Putstudent(int id, news news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news.id)
            {
                return BadRequest();
            }

            Dtcx.Entry(news).State = EntityState.Modified;

            try
            {
                Dtcx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Dtcx.news.Where(i=>i.id==id).Single() is null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        
        public IHttpActionResult Postnews(news news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dtcx.news.Add(news);
            Dtcx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = news.id }, news);
        }
        [ResponseType(typeof(news))]
        public IHttpActionResult Deletenews(int id)
        {
            news news = Dtcx.news.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            Dtcx.news.Remove(news);
            Dtcx.SaveChanges();

            return Ok(news);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dtcx.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
