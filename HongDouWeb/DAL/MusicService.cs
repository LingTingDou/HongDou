using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

using HongDouWeb.Models;
using HongDouWeb.Pager;

namespace HongDouWeb.DAL
{
    public class MusicService
    {
        MusicEntities db = new MusicEntities();

        /// <summary>
        /// 获取Music集合
        /// </summary>
        /// <returns></returns>
        public IQueryable<Music_List> SelectList()
        {
            return db.Music_List.Where(p=>p.Status==1);
        }

        /// <summary>
        /// 获取Type集合
        /// </summary>
        /// <returns></returns>
        public IQueryable<Music_Type> SelectType() {
            return db.Music_Type.Where(p=>p.Status==1);
        }

        /// <summary>
        /// 获取Singer集合
        /// </summary>
        /// <returns></returns>
        public IQueryable<Music_Singer> SelectSinger()
        {
            return db.Music_Singer.Where(p => p.Status == 1);
        }

        /// <summary>
        /// 插入一条数据到Music_List 
        /// 返回int
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertMusic(Music_List model)
        {
            db.Music_List.Add(model);
            return db.SaveChanges();
        }

        //查询歌曲信息列表
        public PageModel<Music_List> SelectMusicList(int pageIndex, int pageSize, string strWhere)
        {
            string returnField = @"ROW_NUMBER()OVER(ORDER BY list.MusicID DESC)orders,MusicName,TypeName,SingerName";
            string table = @" Music_List list 
                                left join Music_Type mt on mt.TypeID=list.TypeID 
                                left join Music_Singer ms on ms.SingerID=list.SingerID ";

            return PageHelper<Music_List>.SelectData(pageSize, pageIndex, returnField, "*", table, " where 1=1 " + strWhere);
        }

        public List<Music_List> SelectMusicList(int pageIndx, int pageSize, Expression<Func<Music_List, bool>> pred,out int totalPage, out int totalCount)
        {
            //List<Music_List> list = .Skip((pageIndx - 1)); 谓词

            var q = db.Music_List.Where(pred);
            totalCount = q.Count();
            totalPage = 0;
            if (totalCount > 0)
            {
                var remainder = totalCount % pageSize;

                var quotient = totalCount / pageSize;

                totalPage = remainder > 0 ? quotient + 1 : quotient;

                return q.OrderBy(x => x.MusicName)
                    .Skip((pageIndx - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            return new List<Music_List>();


        }

    }
}