﻿namespace SkillManagement.DataAccess.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
