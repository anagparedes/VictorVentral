﻿using VictorVentralProduct.Domain.Interfaces;

namespace VictorVentralProduct.Domain.Models
{
    public abstract class BaseEntity : IBase
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
