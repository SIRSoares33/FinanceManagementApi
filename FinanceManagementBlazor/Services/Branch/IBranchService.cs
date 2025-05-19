using Finance.Dtos;

using FinanceManagementBlazor.Services.Branch;

/// <summary>
/// Define os serviços relacionados à gestão de filiais.
/// Fornece métodos para obter as dependências da visualização da filial, salvar e excluir transações.
/// </summary>
public interface IBranchService
{
    /// <summary>
    /// Obtém as dependências necessárias para a visualização da filial, incluindo informações da filial, transações e estatísticas.
    /// </summary>
    /// <returns>Um objeto <see cref="BranchViewDependencies"/> contendo os dados da filial, lista de transações e estatísticas.</returns>
    Task<BranchViewDependencies> GetBranchViewDependenciesAsync();

    /// <summary>
    /// Salva uma transação para a filial.
    /// </summary>
    /// <param name="model">Objeto contendo os dados da transação.</param>
    Task SaveTransactionAsync(TransactionDto model);

    /// <summary>
    /// Exclui uma transação a partir do identificador informado.
    /// </summary>
    /// <param name="id">Identificador da transação a ser excluída.</param>
    Task DeleteTransactionAsync(int id);
}
