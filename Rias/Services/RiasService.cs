using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using Rias.Configurations;
using Rias.Extensions;
using Rias.Implementation;
using Serilog;

namespace Rias.Services
{
    public class RiasService
    {
        public readonly RiasBot RiasBot;
        public readonly Configuration Configuration;
        public readonly Localization Localization;

        public RiasService(IServiceProvider serviceProvider)
        {
            RiasBot = serviceProvider.GetRequiredService<RiasBot>();
            Configuration = serviceProvider.GetRequiredService<Configuration>();
            Localization = serviceProvider.GetRequiredService<Localization>();
        }

        /// <summary>
        /// Send a confirmation message with arguments. The form is an embed with the confirm color.<br/>
        /// If the key starts with "#", the first word delimited by "_" is the prefix for the translation.<br/>
        /// If the key doesn't start with "#", the prefix of the translation is the lower module name of this class.
        /// </summary>
        public Task<DiscordMessage> ReplyConfirmationAsync(DiscordChannel channel, ulong guildId, string key, params object[] args)
            => channel.SendConfirmationMessageAsync(Localization.GetText(guildId, key, args));

        /// <summary>
        /// Send an error message with arguments. The form is an embed with the error color.<br/>
        /// If the key starts with "#", the first word delimited by "_" is the prefix for the translation.<br/>
        /// If the key doesn't start with "#", the prefix of the translation is the lower module type of this class.
        /// </summary>
        public Task<DiscordMessage> ReplyErrorAsync(DiscordChannel channel, ulong guildId, string key, params object[] args)
            => channel.SendErrorMessageAsync(Localization.GetText(guildId, key, args));

        /// <summary>
        /// Get a translation text with or without arguments.<br/>
        /// If the key starts with "#", the first word delimited by "_" is the prefix for the translation.<br/>
        /// If the key doesn't start with "#", the prefix of the translation is the lower module type of this class.
        /// </summary>
        public string GetText(ulong? guildId, string key, params object[] args)
            => Localization.GetText(guildId, key, args);

        /// <summary>
        /// Run a task in an async way.
        /// </summary>
        public Task RunTaskAsync(Task task)
            => RunTaskAsync(() => task);
        
        /// <summary>
        /// Run a task in an async way.
        /// </summary>
        public Task RunTaskAsync(Func<Task> func)
        {
            Task.Run(async () =>
            {
                try
                {
                    await func.Invoke();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            });

            return Task.CompletedTask;
        }
    }
}