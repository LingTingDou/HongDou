using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HongDouWeb.DAL;
using HongDouWeb.Models;
using HongDouWeb.Pager;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace HongDouWeb.Controllers
{
    public class MusicController : CommonController
    {
        MusicService ms = new MusicService();
        // GET: Music
        public ActionResult Index()
        {
            // return View(ms.SelectList());
            return View();
        }

        //后台查看申请
        [HttpPost]
        public JsonResult SelectMusic_List()
        {

            PageModel<Music_List> page = new PageModel<Music_List>();

            int pageSize = Convert.ToInt32(Request.QueryString["maxResults"]);

            int pageIndex = Convert.ToInt32(Request.QueryString["page"]);

            int totalCount, totalPage;

            //Expression<Func<Music_List, bool>> pred = x => true;// x.MusicName== "C6FC6EEB-D3CF-479D-8DB5-F5CD73320EB3"
            // Expression<Func<Music_List, bool>> pred = x => "rere".Equals(x.MusicName);
            Expression<Func<Music_List, bool>> pred = x => true;
           

            var list = ms.SelectMusicList(pageIndex, pageSize, pred, out totalPage, out totalCount);

            page.list = list;

            page.totalRecords = totalCount;

            page.totalPages = totalPage;

            JsonResult jr = Json(page, JsonRequestBehavior.AllowGet);

            return jr;


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
            if (ModelState.IsValid == false)
            {
                return Json(new { success = false });
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