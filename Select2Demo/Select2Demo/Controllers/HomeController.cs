using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Select2Demo.Models;

namespace Select2Demo.Controllers
{


    public class HomeController : Controller
    {

        public IEnumerable<string> areaList = new List<string>()
        { 
            "北京市", 
            "天津市",
            "重庆市",
            "上海市",
            "广州市", 
            "长沙", 
            "哈尔滨", 
            "长春",
            "杭州市", 
            "南京市",
            "福建市",
            "河北省", 
            "山西省", 
            "辽宁省", 
            "吉林省", 
            "黑龙江省",
            "江苏省",
            "浙江省", 
            "安徽省", 
            "福建省", 
            "江西省", 
            "山东省", 
            "河南省",
            "湖北省", 
            "湖南省",
            "广东省", 
            "海南省", 
            "四川省",
            "贵州省", 
            "云南省", 
            "陕西省", 
            "甘肃省",
            "青海省",
            "台湾省",
            "内蒙古自治区", 
            "广西壮族自治区", 
            "西藏自治区", 
            "宁夏回族自治区",
            "新疆维吾尔自治区", 
            "香港特别行政区", 
            "澳门特别行政区" 
        };

        public JsonResult GetArea(string q, string page)
        {
            var area = new { id = 1, name = "" };
            var lstRes = areaList.Select((t, i) => new Area
            {
                id = i,
                text = t,
                element = "element" + i
            });
            if (!string.IsNullOrEmpty(q.Trim()))
            {
                lstRes = lstRes.Where(x => x.text.Contains(q));
            }
            var lstCurPageRes = string.IsNullOrEmpty(page) ? lstRes.Take(10) : lstRes.Skip(Convert.ToInt32(page) * 10 - 10).Take(10);
            return Json(new { items = lstCurPageRes, total_count = lstRes.Count() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }



    }
}
