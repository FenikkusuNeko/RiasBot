﻿namespace Rias.Database.Entities
{
    public class CharacterEntity : DbEntity, ICharacterEntity
    {
        public int CharacterId { get; set; }
        
        public string? Name { get; set; }
        
        public string? Url { get; set; }
        
        public string? ImageUrl { get; set; }
    }
}