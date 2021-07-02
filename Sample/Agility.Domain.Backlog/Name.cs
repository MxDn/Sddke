﻿// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using Sddke.Shared.Domain;

namespace Agility.Domain.Backlog
{
    /// <summary>
    /// The name.
    /// </summary>
    public class Name : ValueObject
    {
        /// <summary>
        /// Gets or Sets the value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="value">The value.</param>
        public Name(string value)
        {
            Value = value.NotNullOrWhiteSpace();
        }

        public static implicit operator
                                        /// <summary>
                                        /// The op_ implicit.
                                        /// </summary>
                                        /// <param name="value">The value.</param>
                                        /// <returns>The result.</returns>
                                        Name(string value)
        {
            return new Name(value);
        }

        public static implicit operator
                                        /// <summary>
                                        /// The op_ implicit.
                                        /// </summary>
                                        /// <param name="name">The name.</param>
                                        /// <returns>The result.</returns>
                                        string(Name name)
        {
            return name.Value;
        }
    }
}
