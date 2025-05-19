using Finance.Dtos;

/// <summary>
/// Define o serviço HTTP responsável pelo registro de novos usuários.
/// Fornece método para enviar a requisição de cadastro utilizando os dados do usuário.
/// </summary>
public interface IRegisterHttpService
{
    /// <summary>
    /// Envia uma requisição HTTP para registrar um novo usuário com as informações fornecidas.
    /// </summary>
    /// <param name="authModel">Objeto contendo os dados de registro do usuário.</param>
    Task RegisterHttpRequest(RegisterDto authModel);
}
