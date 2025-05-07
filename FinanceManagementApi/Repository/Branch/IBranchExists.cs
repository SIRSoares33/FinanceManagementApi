/// <summary>
/// Interface para verificar a existência de uma branch.
/// </summary>
public interface IBranchExists
{
    /// <summary>
    /// Verifica de forma assíncrona se uma branch com o ID especificado existe.
    /// </summary>
    /// <param name="branchId">O ID da branch a ser verificada.</param>
    /// <returns>Um Task que representa o resultado da operação, lança uma exception caso não exista.</returns>
    Task BranchExistsAsync(int branchId);
}