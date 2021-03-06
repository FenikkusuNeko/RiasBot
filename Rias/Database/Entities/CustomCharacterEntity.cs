﻿namespace Rias.Database.Entities
{
    public class CustomCharacterEntity : DbEntity, ICharacterEntity
    {
        public int CharacterId { get; set; }
        
        public string? Name { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public string? Description { get; set; }
    }
}