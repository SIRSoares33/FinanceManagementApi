using Finance.Dtos;

using FinanceManagementBlazor.Services.Home;

/// <summary>
/// Define os serviços relacionados à página inicial do sistema de gestão financeira.
/// Fornece métodos para obter dependências da home, salvar, excluir e armazenar informações de filiais.
/// </summary>
public interface IHomeService
{
    /// <summary>
    /// Obtém todas as dependências necessárias para a página inicial, como usuário, filiais e estatísticas.
    /// </summary>
    /// <returns>Um objeto <see cref="HomeDependecies"/> contendo as informações da home.</returns>
    Task<HomeDependecies> GetHomeDependenciesAsync();

    /// <summary>
    /// Exclui uma filial a partir do identificador informado.
    /// </summary>
    /// <param name="branchId">Identificador da filial a ser excluída.</param>
    Task DeleteBranchAsync(string branchId);

    /// <summary>
    /// Salva as informações de uma filial.
    /// </summary>
    /// <param name="branchInfo">Objeto contendo os dados da filial.</param>
    Task SaveBranchAsync(BranchDto branchInfo);

    /// <summary>
    /// Armazena informações de uma filial localmente (ex: no storage do navegador).
    /// </summary>
    /// <param name="branch">Objeto contendo os dados da filial.</param>
    Task SetBranchStorageAsync(BranchDto branch);
}
