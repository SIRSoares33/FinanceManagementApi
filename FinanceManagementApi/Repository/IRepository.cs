using System.Linq.Expressions;

namespace FinanceManagementApi.Repository
{
    /// <summary>
    /// Interface genérica para manipulação de entidades no Entity Framework.
    /// Fornece operações CRUD e métodos auxiliares reutilizáveis para qualquer tipo de entidade.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adiciona uma nova entidade ao banco de dados.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <param name="entity">Entidade a ser adicionada.</param>
        Task CreateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Remove uma entidade com base no seu ID.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <param name="id">Identificador da entidade.</param>
        Task DeleteAsync<T>(int id) where T : class;

        /// <summary>
        /// Obtém uma entidade com base no seu ID.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade correspondente ao ID fornecido.</returns>
        Task<T> GetByIdAsync<T>(int id) where T : class;

        /// <summary>
        /// Obtém a primeira entidade que satisfaça o predicado especificado.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <param name="predicate">Expressão de filtro.</param>
        /// <returns>Entidade correspondente ou exceção se não encontrada.</returns>
        Task<T> GetByAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Verifica se existe alguma entidade que satisfaça o predicado especificado.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <param name="predicate">Expressão de filtro.</param>
        /// <returns>True se existir, caso contrário false.</returns>
        Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Obtém todas as entidades do tipo especificado.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <returns>Lista com todas as entidades.</returns>
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;

        /// <summary>
        /// Obtém uma coleção relacionada a uma entidade específica, com base em uma expressão de navegação.
        /// </summary>
        /// <typeparam name="TEntity">Tipo da entidade principal.</typeparam>
        /// <typeparam name="TCollection">Tipo da coleção relacionada.</typeparam>
        /// <param name="entityId">ID da entidade principal.</param>
        /// <param name="includeExpression">Expressão de navegação para a coleção.</param>
        /// <returns>Lista da coleção relacionada.</returns>
        Task<List<TCollection>> GetCollectionFromEntityAsync<TEntity, TCollection>(
            int entityId,
            Expression<Func<TEntity, IEnumerable<TCollection>>> includeExpression)
            where TEntity : class
            where TCollection : class;
    }
}
