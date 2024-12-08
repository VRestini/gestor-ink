using AppGestorInk.MVVM.Models;

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


namespace AppGestorInk.Services
{
    public class UserService : IUserService
    {

        //Método utilizado para fazer login de um usuário.
        public async Task Login(User user)
        {
            //loginData representa o corpo necessário para a requisição de login.
            var loginData = new { Username = user.Name, Password = user.Password }; // Pegue os dados do formulário
            var httpClient = new HttpClient();
            //Serializa o objeto loginData para JSON e o coloca no corpo da requisição.
            var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://seuservidor/api/auth/login", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<JwtResponse>(responseData)?.Token;

                if (!string.IsNullOrEmpty(token))
                {
                    SecureStorage.SetAsync("JwtToken", token); // Salva o token localmente
                }
            }
            else
            {
                throw new Exception("Credenciais inválidas");
            }
        }

        //Método utilizado para obter dados do usuário.
        public async Task<string> GetProtectedData()
        {
            var httpClient = new HttpClient();
            var token = SecureStorage.GetAsync("JwtToken").Result;

            if (!string.IsNullOrEmpty(token))
            {
                //Adicionando o Token no cabeçalho da requisição.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //Qualquer requisição para o servidor que necessite de autenticação deve ser feita com o token no cabeçalho.
                var response = await httpClient.GetAsync("https://seuservidor/api/user");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Acesso negado ou token expirado.";
                }
            }
            return "Token não encontrado.";
        }

        //Método utilizado para deslogar o usuário.
        public async Task Logout()
        {
            SecureStorage.Remove("JwtToken");
        }

        //Método utilizado para verificar se o usuário está logado.
        public async Task<bool> IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(SecureStorage.GetAsync("JwtToken").Result);
        }
    }
}
