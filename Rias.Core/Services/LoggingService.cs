using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Qmmands;
using Rias.Core.Implementation;
using Rias.Core.Services.Commons;
using Serilog.Events;
using Victoria;

namespace Rias.Core.Services
{
    public class LoggingService : RiasService
    {
        public LoggingService(IServiceProvider services) : base(services)
        {
            var client = services.GetRequiredService<DiscordShardedClient>();
            var commandService = services.GetRequiredService<CommandService>();
            var lavalink = services.GetRequiredService<LavaNode<MusicPlayer>>();

            client.Log += DiscordLogAsync;
            commandService.CommandExecuted += CommandExecutedAsync;
            commandService.CommandExecutionFailed += CommandExecutionFailedAsync;
            lavalink.OnLog += DiscordLogAsync;
        }

        private Task DiscordLogAsync(LogMessage msg)
        {
            var logEventLevel = msg.Severity switch
            {
                LogSeverity.Verbose => LogEventLevel.Verbose,
                LogSeverity.Info => LogEventLevel.Information,
                LogSeverity.Debug => LogEventLevel.Debug,
                LogSeverity.Warning => LogEventLevel.Warning,
                LogSeverity.Error => LogEventLevel.Error,
                LogSeverity.Critical => LogEventLevel.Fatal,
                _ => LogEventLevel.Verbose
            };

            Log.Logger.Write(logEventLevel, $"{msg.Source}: {msg.Exception?.ToString() ?? msg.Message}");

            return Task.CompletedTask;
        }

        private Task CommandExecutedAsync(CommandExecutedEventArgs args)
        {
            var context = (RiasCommandContext) args.Context;
            var command = context.Command;

            Log.Logger.Information($"[Command] \"{command.Name}\"\n" +
                            $"\t\t[Arguments] \"{string.Join(" ", context.Arguments)}\"\n" +
                            $"\t\t[User] \"{context.User}\" ({context.User.Id})\n" +
                            $"\t\t[Channel] \"{context.Channel.Name}\" ({context.Channel.Id})\n" +
                            $"\t\t[Guild] \"{context.Guild?.Name ?? "DM"}\" ({context.Guild?.Id ?? 0})");

            return Task.CompletedTask;
        }

        private Task CommandExecutionFailedAsync(CommandExecutionFailedEventArgs args)
        {
            var context = (RiasCommandContext) args.Context;
            var command = context.Command;
            var result = args.Result;

            Log.Error($"[Command] \"{command.Name}\"\n" +
                            $"\t\t[Arguments] \"{context.RawArguments}\"\n" +
                            $"\t\t[User] \"{context.User}\" ({context.User.Id})\n" +
                            $"\t\t[Channel] \"{context.Channel.Name}\" ({context.Channel.Id})\n" +
                            $"\t\t[Guild] \"{context.Guild?.Name ?? "DM"}\" ({context.Guild?.Id ?? 0})\n" +
                            $"\t\t[Error Reason] {result.Reason}\n" +
                            $"\t\t[Error Exception] {result.Exception}");

            return Task.CompletedTask;
        }
    }
}