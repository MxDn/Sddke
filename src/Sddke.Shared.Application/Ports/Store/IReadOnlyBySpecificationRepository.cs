// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

using Sddke.Shared.Application.Specifications;
using Sddke.Shared.Domain;

namespace Sddke.Shared.Application.Ports.Store
{
    public interface IReadOnlyBySpecificationRepository<TEntity>
         where TEntity : Entity, IAggregateRoot
    {
        TEntity GetOneByExpression(Specification<TEntity> expression);
        IEnumerable<TEntity> GetAllByExpression(Specification<TEntity> expression);
    }
}
