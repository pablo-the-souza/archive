using System;

namespace Core.Entities
{
    public class File: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PolicyType { get; set; }
        public string PolicyNumber { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public string Comments { get; set; }
        public Box Box { get; set; }
        public Guid BoxId { get; set; }
 
    }
}