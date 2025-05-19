using Finance.Dtos;

/// <summary>
/// Define o servi�o HTTP respons�vel pelo registro de novos usu�rios.
/// Fornece m�todo para enviar a requisi��o de cadastro utilizando os dados do usu�rio.
/// </summary>
public interface IRegisterHttpService
{
    /// <summary>
    /// Envia uma requisi��o HTTP para registrar um novo usu�rio com as informa��es fornecidas.
    /// </summary>
    /// <param name="authModel">Objeto contendo os dados de registro do usu�rio.</param>
    Task RegisterHttpRequest(RegisterDto authModel);
}
