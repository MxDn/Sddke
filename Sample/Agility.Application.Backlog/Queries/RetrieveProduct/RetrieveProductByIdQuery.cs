// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

namespace Agility.Application.Backlog.Queries.RetrieveProduct
{
    public class RetrieveProductByIdQuery : RetrieveProductQuery
    {
        public Guid ProductId { get; set; }
    }
}
