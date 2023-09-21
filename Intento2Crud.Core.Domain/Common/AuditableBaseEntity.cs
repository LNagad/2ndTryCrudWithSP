﻿
namespace Intento2Crud.Core.Domain.Common
{
    public class AuditableBaseEntity
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set;}
    }
}
