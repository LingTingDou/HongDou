using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HongDouWeb.Models;


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
    }
}