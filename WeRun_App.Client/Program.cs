using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IToastService, ToastService>();
builder.Services.AddSingleton<IDialogService, DialogService>();
builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddSingleton<ITooltipService, TooltipService>();
builder.Services.AddSingleton<LibraryConfiguration>();
builder.Services.AddSingleton<GlobalState>();

//authentication
builder.Services.AddApiAuthorization();
builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication options here
    options.ProviderOptions.ClientId = "Your_Client_Id";
    options.ProviderOptions.Authority = "Your_Authority_Url";
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

await builder.Build().RunAsync();
