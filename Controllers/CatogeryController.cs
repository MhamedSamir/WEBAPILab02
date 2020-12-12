using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPILab02.Models;

namespace WEBAPILab02.Controllers
{
    public class CatogeryController : ApiController
    {
        NewsDtcx dtcx = new NewsDtcx();
      public IHttpActionResult get()
        {
            return Ok(dtcx.catogeries.ToList());
        }
    }
}
