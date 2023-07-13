using System.ComponentModel.DataAnnotations;

namespace PharmacyWebApp.Models.Tables
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Идектитифкатор
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
    }
}
