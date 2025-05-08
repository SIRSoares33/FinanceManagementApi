namespace FinanceManagementBlazor.Storage
{
    /// <summary>
    /// Define uma interface genérica para gerenciar operações de armazenamento local.
    /// </summary>
    /// <typeparam name="T">O tipo de dado a ser armazenado.</typeparam>
    public interface ILocalStorageManager<T>
    {
        /// <summary>
        /// Armazena um item no armazenamento local.
        /// </summary>
        /// <param name="value">O valor a ser armazenado.</param>
        Task SetItemAsync(T value);

        /// <summary>
        /// Obtém um item do armazenamento local.
        /// </summary>
        /// <returns>O item armazenado ou <c>null</c> se não existir.</returns>
        Task<T?> GetItemAsync();

        /// <summary>
        /// Remove um item do armazenamento local.
        /// </summary>
        Task RemoveItemAsync();
        /// <summary>
        /// Verifica se um item existe.
        /// </summary>
        /// <returns></returns>
        Task<bool> ItemExistsAsync();
    }
}