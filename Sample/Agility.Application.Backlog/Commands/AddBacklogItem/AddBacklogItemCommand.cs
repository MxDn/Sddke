// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

namespace Agility.Application.Backlog.Commands.AddBacklogItem
{
    public class AddBacklogItemCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
    }
}
