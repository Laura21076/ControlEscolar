using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using ControlEscolar.Services; // Aseg�rate de que es el namespace correcto

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registrar servicios de autenticaci�n
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


// Registrar HttpClient para llamadas a la API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
