namespace uHubAPI.Models
{
    /*======================================================================
    | Entity Base class
    |
    | Name: EntityBaseClass.cs
    |
    | Written by: Chigozie Muonagolu - January 2023
    |      
    | Purpose: Base class for an entity.
    |
    | Usage: Inherited by all other enitity classes.   
    |
    |------------------------------------------------------------------ 
    */

    /// <summary>
    /// Base class from which all entity class inherits from.
    /// </summary>
    public abstract class EntityBaseClass
    {
        /// <summary>
        /// Unique identifier of an entity.
        /// </summary>
        public virtual long Id { get; set; }

    }
}

