using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Reflection;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ControlEscolar.Models;
using System.Net.Http;


namespace ControlEscolar.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigation;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigation)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigation = navigation;
        }

        public async Task<string> Register(RegistroRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5071/api/auth/registro", request);
            return response.IsSuccessStatusCode ? "Registro exitoso." : await response.Content.ReadAsStringAsync();
        }

        public async Task<List<Rol>> GetRolesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Rol>>("http://localhost:5071/api/Roles") ?? new List<Rol>();
        }

        public async Task<string?> Login(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5071/api/auth/login", request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    await _localStorage.SetItemAsync("authToken", result.Token);
                    _navigation.NavigateTo("/Inicio");
                    return result.Token;
                }
                return "Error al procesar la respuesta del servidor.";
            }
            return "Credenciales incorrectas.";
        }
    }
}

