using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HongDouWeb.DAL;

namespace HongDouWeb.Pager
{
    class PageHelper<T> where T : new()
    {
        public static PageModel<T> SelectData(int pageSize, int pageIndex, string returnField, string returnFieldA, string tableName, string strWhere)
        {
            PageModel<T> page = new PageModel<T>();

            string reField = returnFieldA == "" ? returnField : returnFieldA;

            string sql = "select " + reField + " from(select " + returnField + " from " + tableName + strWhere + ")t"
            + " where orders between " + (pageSize * (pageIndex - 1) + 1) + " and " + (pageSize * pageIndex) + "";

            page.list = ConvertHelper<T>.ConvertToList(SQLHelper.SelectData(sql, null));

            page.currentPage = pageIndex;

            page.totalRecords = Convert.ToInt32(SQLHelper.SelectData(getCountQL(sql), null).Rows[0][0]);

            page.totalPages = page.totalRecords % pageSize == 0 ? page.totalRecords / pageSize : page.totalRecords / pageSize + 1;

            return page;
        }

        public static string getCountQL(string ql)
        {
            string sql = "select count (*) from(";
            //if (!string.IsNullOrEmpty(ql) && ql.Length > 0)
            //{
            //    ql = ql.Substring(ql.IndexOf(" from "));
            //    int d = 0;//ql.lastIndexOf("=");
            //    int s = ql.LastIndexOf(" where ");
            //    if (s > d) ql = ql.Substring(0, s);
            //    int o = ql.LastIndexOf(" order by ");
            //    if (o > d) ql = ql.Substring(0, o);
            //    sql += "from ( select 1 as functionByGetCount " + ql + " ";
            //}
            sql += ql.Substring(0,ql.LastIndexOf("where"));
            sql += ")A";
            return sql;
        }
    }
}