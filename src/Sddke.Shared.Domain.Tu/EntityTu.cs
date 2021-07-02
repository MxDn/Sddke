using System;
using Sddke.Shared.Tu.Domain;
using Xunit;

namespace Sddke.Shared.Tu
{

    /// <summary>
    /// The entity tu.
    /// </summary>
    public partial class EntityTu
    {

        /// <summary>
        /// The two entityt with same attribute are equals only if id are same.
        /// </summary>
        [Fact(DisplayName = "Two Entity With Same Attribute Are Equals only if id are same")]
        public void TwoEntitytWithSameAttributeAreEqualsOnlyIfIdAreSame()
        {
            var guid = Guid.NewGuid();
            Assert.Equal(new ConcreteEntity(guid, "max", "dej"), new ConcreteEntity(guid, "max", "dej"));
        }

        /// <summary>
        /// The two entityt with différent attribute are equals only if id are same.
        /// </summary>
        [Fact(DisplayName = "Two Entity With Different Attribute Are Equals only if id are same")]
        public void TwoEntitytWithDifférentAttributeAreEqualsOnlyIfIdAreSame()
        {
            var guid = Guid.NewGuid();
            Assert.Equal(new ConcreteEntity(guid, "max", "dej"), new ConcreteEntity(guid, "max", "dej"));
        }

        /// <summary>
        /// The two entityt with différent id are not equals.
        /// </summary>
        [Fact(DisplayName = "Two Entity With Different Id Are Not Equals")]
        public void TwoEntitytWithDifférentIdAreNotEquals()
        {
            Assert.NotEqual(new ConcreteEntity(Guid.NewGuid(), "max", "dej"), new ConcreteEntity(Guid.NewGuid(), "max", "dej"));
        }
    }
}
