using System;
using Core.Entities;

namespace API.DTOs
{
    public class PolicyToReturnDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PolicyType { get; set; }
        public string PolicyNumber { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public string Comments { get; set; }
        public Guid Box { get; set; }
    }
}