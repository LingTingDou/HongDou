using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HongDouWeb.Controllers
{
    /// <summary>
    /// 控制器 通用方法
    /// </summary>
    public class CommonController : Controller
    {
        //绑定下拉框通用方法
        protected void BindDropDownList(string vdName, List<SelectListItem> listType)
        {
            listType.Insert(0, new SelectListItem() { Text = "--请选择--", Value = "0" });
            ViewData[vdName] = listType;
        }
    }
}