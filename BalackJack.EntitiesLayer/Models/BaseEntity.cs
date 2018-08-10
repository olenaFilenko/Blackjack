using System;

namespace BlackJack.Entities.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
