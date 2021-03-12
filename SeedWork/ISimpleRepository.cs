namespace SeedWork
{
    /// <summary>
    /// Interface to support a simplified repository pattern
    /// </summary>
    /// <typeparam name="TId">Id type of the model</typeparam>
    /// <typeparam name="TEntity">Model to save/load</typeparam>
    public interface ISimpleRepository<TId, TEntity>
    {
        /// <summary>
        /// Create a new <see cref="TEntity"/> in repository
        /// </summary>
        /// <param name="model">Model to save</param>
        /// <returns>Id of the saved model</returns>
        TId Create(TEntity model);

        /// <summary>
        /// Get all <see cref="TEntity"/> with the registered id
        /// </summary>
        /// <param name="id">Reference to expected saved model</param>
        /// <returns>Saved model or <see cref="null"/></returns>
        TEntity GetById(TId id);

        /// <summary>
        /// Update the existing <see cref="TEntity"/> model at the specified Id
        /// </summary>
        /// <param name="id">Reference to expected saved model</param>
        /// <param name="model">Details of updated model</param>
        /// <returns>Updated <see cref="TEntity"/> Id</returns>
        TId Update(TId id, TEntity model);

        /// <summary>
        /// Delete <see cref="TEntity"/> matching the id specified
        /// </summary>
        /// <param name="id">Reference to expected saved model to delete</param>
        void Delete(TId id);
    }
}
