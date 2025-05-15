using FinanceManagementBlazor.Entities;

/// <summary>
/// Define os servi�os HTTP relacionados �s filiais.
/// Fornece m�todos para obter todas as filiais, criar uma nova filial e excluir uma filial existente.
/// </summary>
public interface IBranchHttpService
{
    /// <summary>
    /// Obt�m a lista de todas as filiais cadastradas.
    /// </summary>
    /// <returns>Uma lista de objetos <see cref="BranchModel"/>.</returns>
    Task<List<BranchModel>> GetAllBranchsAsync();

    /// <summary>
    /// Exclui uma filial a partir do identificador informado.
    /// </summary>
    /// <param name="id">Identificador da filial a ser exclu�da.</param>
    Task DeleteBranchAsync(string id);

    /// <summary>
    /// Cria uma nova filial com as informa��es fornecidas.
    /// </summary>
    /// <param name="model">Objeto contendo os dados da filial.</param>
    Task CreateBranch(BranchModel model);
}
