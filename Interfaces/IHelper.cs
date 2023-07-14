namespace PharmacyWebApp.Interfaces
{
    public interface IHelper <T>
    {
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name=""></param>
        T Add(T obj);

        IEnumerable<T> GetAll(int id);
        /// <summary>
        /// Удаление
        /// </summary>
        void Remove(int id);
    }
}
