﻿namespace CleanArchitectureNetCore.Domain.Common
{
  public abstract class BaseDomainModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
  }
}
