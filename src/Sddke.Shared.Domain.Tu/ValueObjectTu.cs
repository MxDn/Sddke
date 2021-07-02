// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Sddke.Shared.Tu.Domain;
using Xunit;

namespace Sddke.Shared.Tu
{

    /// <summary>
    /// The value object tu.
    /// </summary>
    public  class ValueObjectTu
    {

        /// <summary>
        /// The two value object with same attribute are equals.
        /// </summary>
        [Fact(DisplayName = "Two ValueObject With Same Attribute Are Equals")]
        public void TwoValueObjectWithSameAttributeAreEquals()
        {
            Assert.Equal(new ConcreteValueObject("max", "dej"), new ConcreteValueObject("max", "dej"));
        }

        /// <summary>
        /// The two value object with same attribute are not equals.
        /// </summary>
        [Fact(DisplayName = "Two ValueObject With different Attribute Are not Equals")]
        public void TwoValueObjectWithDifferentAttributeAreNotEquals()
        {
            Assert.NotEqual(new ConcreteValueObject("max1", "dej"), new ConcreteValueObject("max", "dej"));
        }
    }
}
