namespace SeedWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// An single flag that holds no value other than itself.
    /// Normally used to represet a status or state as an example.
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        /// <param name="id">Reference</param>
        /// <param name="name">Descriptive Name</param>
        protected Enumeration(int id, string name)
        {
            this.Id = id;

            if (string.IsNullOrWhiteSpace(name))
            {
                /// <exception cref="ArgumentNullException">Thrown when name is not given</exception>
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = name;
        }

        /// <returns><see cref="Name"/></returns>
        /// <remarks>Only returns the <see cref="Name"/> as this holds no value other than itself</remarks>
        public override string ToString() => this.Name;

        /// <summary>
        /// Gets all possible permutation of the same type 
        /// </summary>
        /// <typeparam name="T">Enumeration Type</typeparam>
        /// <returns>All permutation of the same type</returns>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }
                
        public override int GetHashCode() => this.Id.GetHashCode();

        /// <summary>
        /// Difference based on the <see cref="Id"/>
        /// </summary>
        /// <returns>Difference between <see cref="Id"/> of the given parameters</returns>
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }

        /// <summary>
        /// Based on the <see cref="Id"/> return the matching <see cref="Enumeration"/>
        /// </summary>
        /// <typeparam name="T"><see cref="Enumeration"/> Type</typeparam>
        /// <param name="value"><see cref="Id"/> referencing the requested <see cref="Enumerable"/></param>
        /// <returns>Matching <see cref="Enumerable"/></returns>
        public static T FromValue<T>(int value) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }

        /// <summary>
        /// Based on <see cref="Name"/> return the matching <see cref="Enumerable"/>
        /// </summary>
        /// <typeparam name="T"><see cref="Enumeration"/> Type</typeparam>
        /// <param name="displayName">Descriptive <see cref="Name"/> of the target</param>
        /// <returns>Matching <see cref="Enumerable"/></returns>
        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }

        /// <summary>
        /// Convert a value into finding a <see cref="Enumerable"/>
        /// </summary>
        /// <typeparam name="T">Type of <see cref="Enumerable"/> being searched</typeparam>
        /// <typeparam name="K">ID </typeparam>
        /// <param name="value">Search value</param>
        /// <param name="description">Descriptive name of the seach criteria</param>
        /// <param name="predicate">Search requirements</param>
        /// <returns>First matching <see cref="Enumerable"/></returns>        
        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                /// <exception cref="InvalidOperationException">Search failed to find matching <see cref="Enumerable"/> which is not a valid state</exception>
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            }

            return matchingItem;
        }

        /// <summary>
        /// Compares the <see cref="Id"/>
        /// </summary>
        /// <param name="other">Alternative <see cref="object"/></param>
        /// <returns>Standard comparison bits</returns>
        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }
}
