using System;

namespace MailSystem.Contracts.ShipmentSizes
{
    public class ShipmentSizeContract
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }
        
        public int Height { get; set; }
        
        public int Width { get; set; }
        
        public int Length { get; set; }
    }
}