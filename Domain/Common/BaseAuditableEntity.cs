﻿namespace Domain.Common;


public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset? CreatedDate { get;set; }
    public string? CreatedBy { get;set; }
    public string? UpdatedBy { get;set; }
    public DateTimeOffset? UpdatedDate { get;set; }
}
