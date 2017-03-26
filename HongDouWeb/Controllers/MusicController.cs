using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HongDouWeb.DAL;
using HongDouWeb.Models;

namespace HongDouWeb.Controllers
{
    public class MusicController : CommonController
    {
        MusicService ms = new MusicService();
        // GET: Music
        public ActionResult Index()
        {
            return View(ms.SelectList());
        }

        public ActionResult CreateMusic()
        {
            GetAllType();
            GetAllSinger();
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateMusic(FormCollection form)
        {
            if(ModelState.IsValid==false)
            {
                return Json(new{ success=false});
            }

            Music_List model = new Music_List()
            {
                CreateTime = DateTime.Now
            };

            if (ms.InsertMusic(model) > 0)
            { return Json(new { success = true }); }
            return Json(new { success = false });
        }

        //获取所有音乐类型
        private void GetAllType()
        {
            List<SelectListItem> listType = ms.SelectType()
                .Select(p => new SelectListItem() { Text = p.TypeName, Value = p.TypeID.ToString() }).ToList();

            BindDropDownList("MusicType", listType);
        }

        //获取所有歌手
        private void GetAllSinger()
        {
            List<SelectListItem> listType = ms.SelectSinger()
                .Select(p => new SelectListItem() { Text = p.SingerName, Value = p.SingerID.ToString() }).ToList();
          
            BindDropDownList("MusicSinger", listType);
        }

        
    }
}