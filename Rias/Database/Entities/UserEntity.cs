﻿using System;

namespace Rias.Database.Entities
{
    public class UserEntity : DbEntity
    {
        public ulong UserId { get; set; }
        
        public int Currency { get; set; }
        
        public int Xp { get; set; }
        
        public DateTime LastMessageDate { get; set; }
        
        public bool IsBanned { get; set; }
        
        public DateTime DailyTaken { get; set; }
    }
}