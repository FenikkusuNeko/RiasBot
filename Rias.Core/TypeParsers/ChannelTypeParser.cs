﻿using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using Qmmands;
using Rias.Core.Attributes;
using Rias.Core.Extensions;
using Rias.Core.Implementation;

namespace Rias.Core.TypeParsers
{
    public class ChannelTypeParser : RiasTypeParser<DiscordChannel>
    {
        public override ValueTask<TypeParserResult<DiscordChannel>> ParseAsync(Parameter parameter, string value, RiasCommandContext context)
        {
            var channelType = ChannelType.Unknown;
            foreach (var attribute in parameter.Attributes)
            {
                channelType = attribute switch
                {
                    TextChannelAttribute => ChannelType.Text,
                    VoiceChannelAttribute => ChannelType.Voice,
                    CategoryChannelAttribute => ChannelType.Category,
                    _ => channelType
                };

                if (channelType != ChannelType.Unknown)
                    break;
            }
            
            if (channelType == ChannelType.Unknown)
                return TypeParserResult<DiscordChannel>.Unsuccessful("The channel doesn't have an attribute type specified!");
            
            var localization = context.ServiceProvider.GetRequiredService<Localization>();
            if (context.Guild is null)
                return TypeParserResult<DiscordChannel>.Unsuccessful(localization.GetText(context.Guild?.Id, Localization.TypeParserCachedTextChannelNotGuild));

            DiscordChannel? channel;
            if (!RiasUtilities.TryParseChannelMention(value, out var channelId))
                ulong.TryParse(value, out channelId);

            if (channelId != 0)
            {
                channel = context.Guild.GetChannel(channelId);
                var channelTypeBool = channelType == ChannelType.Text
                    ? channel.Type == ChannelType.Text || channel.Type == ChannelType.News || channel.Type == ChannelType.Store
                    : channel.Type == channelType;
                
                if (channel != null && channelTypeBool)
                    return TypeParserResult<DiscordChannel>.Successful(channel);
            }

#pragma warning disable 8509
            channel = channelType switch
            {
                ChannelType.Category => context.Guild.GetCategoryChannel(value),
                ChannelType.Text => context.Guild.GetTextChannel(value),
                ChannelType.Voice => context.Guild.GetVoiceChannel(value)
            };
            
            if (channel != null)
                return TypeParserResult<DiscordChannel>.Successful(channel);

            return channelType switch
            {
                ChannelType.Category => TypeParserResult<DiscordChannel>.Unsuccessful(localization.GetText(context.Guild.Id, Localization.AdministrationCategoryChannelNotFound)),
                ChannelType.Text => TypeParserResult<DiscordChannel>.Unsuccessful(localization.GetText(context.Guild.Id, Localization.AdministrationTextChannelNotFound)),
                ChannelType.Voice => TypeParserResult<DiscordChannel>.Unsuccessful(localization.GetText(context.Guild.Id, Localization.AdministrationVoiceChannelNotFound))
            };
#pragma warning restore 8509
        }
    }
}