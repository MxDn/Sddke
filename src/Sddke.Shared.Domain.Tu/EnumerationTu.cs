// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Sddke.Shared.Tu.Domain;
using Xunit;

namespace Sddke.Shared.Tu
{

    /// <summary>
    /// The enumeration tu.
    /// </summary>
    public partial class EnumerationTu
    {

        /// <summary>
        /// The two enumerationt with same attribute are equals.
        /// </summary>
        [Fact(DisplayName = "Two Entity With Same Attribute Are Equals only if id are same")]
        public void TwoEnumerationtWithSameAttributeAreEquals()
        { 
            Assert.Equal(ConcretEnumeration.Created, ConcretEnumeration.Created);
        }

        /// <summary>
        /// The two enumerationt with different attribute are not equals.
        /// </summary>
        [Fact(DisplayName = "Two Entity With Same Attribute Are Equals only if id are same")]
        public void TwoEnumerationtWithDifferentAttributeAreNotEquals()
        {
            Assert.NotEqual(ConcretEnumeration.Created, ConcretEnumeration.Deleted);
        }
    }
}
