namespace SeedWork
{
    using System;

    /// <summary>
    /// Entity within a bounded context
    /// </summary>
    /// <typeparam name="T">Id Type</typeparam>
    /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-domain-model#the-domain-entity-pattern"/>
    public abstract class Entity<T>
    {
        /// <summary>
        /// Key
        /// </summary>
        public T Id { get; }

        /// <summary>
        /// </summary>
        /// <param name="id">Primary key of the <see cref="Entity{T}"/></param>
        public Entity(T id)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
