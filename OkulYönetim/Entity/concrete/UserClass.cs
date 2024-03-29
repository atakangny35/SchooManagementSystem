﻿using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class UserClass:IEntity
    {
        public int Id { get; set; }

        public bool IsPassed { get; set; }
        public  int UserId { get; set; }
        public User Users { get; set; }

        public int ClassId { get; set; }
        public Class Classes { get; set; }
    }
}
