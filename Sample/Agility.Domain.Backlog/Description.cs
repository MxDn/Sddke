// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using Sddke.Shared.Domain;

namespace Agility.Domain.Backlog
{
    /// <summary>
    /// The description.
    /// </summary>
    public class Description : ValueObject
    {
        /// <summary>
        /// Gets or Sets the value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="value">The value.</param>
        public Description(string value)
        {
            Value = value.NotNullOrWhiteSpace();
        }

        public static implicit operator
                                        /// <summary>
                                        /// The op_ implicit.
                                        /// </summary>
                                        /// <param name="value">The value.</param>
                                        /// <returns>The result.</returns>
                                        Description(string value)
        {
            return new Description(value);
        }

        public static implicit operator
                                        /// <summary>
                                        /// The op_ implicit.
                                        /// </summary>
                                        /// <param name="description">The description.</param>
                                        /// <returns>The result.</returns>
                                        string(Description description)
        {
            return description.Value;
        }
    }
}
