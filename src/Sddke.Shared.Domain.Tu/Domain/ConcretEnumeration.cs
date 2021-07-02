// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{

    /// <summary>
    /// The status.
    /// </summary>
   public class ConcretEnumeration : Enumeration
    {
        public static ConcretEnumeration Null = new ConcretEnumeration(0, nameof(Null));
        public static ConcretEnumeration Created = new ConcretEnumeration(1, nameof(Created));
        public static ConcretEnumeration Deleted = new ConcretEnumeration(2, nameof(Deleted));
        public static ConcretEnumeration Updated = new ConcretEnumeration(3, nameof(Updated));

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public ConcretEnumeration(int id, string name) : base(id, name)
        {
        }
    }

}
