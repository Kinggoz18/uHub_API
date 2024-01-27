using uHubAPI.Extensions.Models;

namespace uHubAPI.Extensions.Services
{
    /// <summary>
    /// Class that generates operation results.
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public static class OperationGenerator<T> where T : BaseEntity
    {
        /// <summary>
        /// Genrates a failed operation result. If false operation failed
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
		public static OperationResult<T> FailedOperationGenerator(T entity)
		{
			return new OperationResult<T>
			{
				Success = false,
				Entity = entity
            };
		}

        /// <summary>
        /// Genrates a successful operation result. If true operation was successful.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static OperationResult<T> SuccessOperationGenerator(T entity)
        {
            return new OperationResult<T>
            {
                Success = true,
                Entity = entity
            };
        }
    }
}

