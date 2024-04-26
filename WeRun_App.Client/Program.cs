using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;
using WeRun_App.Client.Services;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserService, UserService>(); 

builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();



builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

builder.Services.AddSingleton<IToastService, ToastService>();
builder.Services.AddSingleton<IDialogService, DialogService>();
builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddSingleton<ITooltipService, TooltipService>();
builder.Services.AddSingleton<LibraryConfiguration>();
builder.Services.AddSingleton<GlobalState>();

builder.Services.AddApiAuthorization();

//builder.Services.AddOidcAuthentication(options =>
//{
//    // authentication
//    options.ProviderOptions.ClientId = "Your_Client_Id";
//    options.ProviderOptions.Authority = "Your_Authority_Url";
//    options.ProviderOptions.ResponseType = "code";
//});
builder.Logging.SetMinimumLevel(LogLevel.Trace);

await builder.Build().RunAsync();
