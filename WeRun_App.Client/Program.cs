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


await builder.Build().RunAsync();
