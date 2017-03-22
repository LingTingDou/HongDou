using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace HongDouWeb.DAL
{
    public class MusicService
    {
        MusicEntities db = new MusicEntities();
        public IQueryable<Music_List> SelectList()
        {
            return db.Music_List.Where(p=>p.Status==1);
        }
    }
}