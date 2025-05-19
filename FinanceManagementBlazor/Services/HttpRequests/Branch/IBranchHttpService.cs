using Finance.Dtos;

/// <summary>
/// Define os serviços HTTP relacionados às filiais.
/// Fornece métodos para obter todas as filiais, criar uma nova filial e excluir uma filial existente.
/// </summary>
public interface IBranchHttpService
{
    /// <summary>
    /// Obtém a lista de todas as filiais cadastradas.
    /// </summary>
    /// <returns>Uma lista de objetos <see cref="BranchDto"/>.</returns>
    Task<List<BranchDto>> GetAllBranchsAsync();

    /// <summary>
    /// Exclui uma filial a partir do identificador informado.
    /// </summary>
    /// <param name="id">Identificador da filial a ser excluída.</param>
    Task DeleteBranchAsync(string id);

    /// <summary>
    /// Cria uma nova filial com as informações fornecidas.
    /// </summary>
    /// <param name="model">Objeto contendo os dados da filial.</param>
    Task CreateBranch(BranchDto model);
}
