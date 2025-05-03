namespace FinanceManagementApi.Models.User
{
    /// <summary>
    /// Representa um contrato para objetos que possuem email e senha.
    /// Pode ser utilizado em operações de autenticação e verificação de credenciais.
    /// </summary>
    public interface IUserEmailAndPassword
    {
        /// <summary>
        /// Endereço de email do usuário.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário (em texto puro ou já criptografada, dependendo do contexto).
        /// </summary>
        public string Password { get; set; }
    }

}