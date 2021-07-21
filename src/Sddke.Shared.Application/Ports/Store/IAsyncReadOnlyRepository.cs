// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Sddke.Shared.Domain;

namespace Sddke.Shared.Application.Ports.Store
{
    public interface IAsyncReadOnlyRepository<TEntity>
      where TEntity : Entity, IAggregateRoot
    {
        Task<TEntity> GetById(Guid id);

        Task<TEntity> GetOneByExpression(Func<TEntity, bool> expression);
        Task<IEnumerable<TEntity>> GetAllByExpression(Func<TEntity, bool> expression);
    }
}
