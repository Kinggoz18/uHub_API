namespace uHubAPI.Extensions.Models
{
    /// <summary>
    /// Object that checks if an operation was Successful.
    /// Success is set to true if Successful, else it is set to false.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperationResult<T>  where T : BaseEntity
	{
        public bool Success { get; set; } = false;
		public required T Entity { get; set; }
	}
    public class OperationResultList<T> where T : BaseEntity
    {
        public bool Success { get; set; } = false;
        public required ICollection<T> EntityList { get; set; }
    }
}

