// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;

using Sddke.Shared.Domain;

namespace Sddke.Shared.Application.Ports.Store
{
    /// <summary>
    /// The i read only repository.
    /// </summary>
    public interface IReadOnlyRepository<TEntity>
       where TEntity : Entity, IAggregateRoot
    {
        TEntity GetById(Guid id);

        TEntity GetOneByExpression(Func<TEntity, bool> expression);
        IQueryable<TEntity> GetAllByExpression(Func<TEntity, bool> expression);
    }
}
