using System;

namespace MailSystem.Domain.Models
{
    public class ShipmentSize
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }
        
        public int Height { get; set; }
        
        public int Width { get; set; }
        
        public int Length { get; set; }

    }
}