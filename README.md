# RiasBot
Rias is a general multi purpose bot with a lot of commands, anime, music, waifu, and administration. Written in C#, library Discord.Net.

# Commands

## 1. Administration
| Command | Description | Example |
| :---: | :---: | :---: |
| `ban` or `b` | Ban an user. If you provide a reson message the bot will DM the user with the reason. | `r!ban @User` or `r!b @User You've violated many rules!`
| `bye` | Togle announcements on the current channel when someone leaves the server. | `r!bye` |
| `byemsg` | Set the announcement message when someone leaves the server.<br>Placeholders:<br>`%user%` will mention the user who leaves<br>`%server%` or `%guild%` - will put the name of the server<br>Embeds are supported, json form: soon a site for it. | `r!byemsg %user% left...` |
| `greet` | Togle announcements on the current channel when someone joins the server. | `r!greet` |
| `greetmsg` | Set the announcement message when someone joins the server.<br>Placeholders:<br>`%user%` - will mention the user who joins<br>`%server%` or `%guild%` - will put the name of the server<br>Embeds are supported, json form: soon a site for it. | `r!greetmsg Welcome %user% to...` |
| `kick` or `k` | Kick an user. If you provide a reson message the bot will DM the user with the reason. | `r!k @User` or `r!k @User Your behavior is bad!` |
| `modlog` | Set the current channel as "mod-log" channel where the bot will post notifications about mute, unmute, kick, ban, softban. Provide no parameters to disable it from the current channel. | `r!modlog` |
| `mute` | Mute an user from text and voice channels. | `r!mute @User` |
| `prune` or `purge` | `r!prune x` removes last x number of messages from the channel (up to 100).<br>`r!prune @User` removes all User's messages in the last 100 messages.<br>`r!prune @Someone x` removes last x number of User's messages in the channel. | `r!prune x` or `r!prune @User` or `r!prune @User x` |
| `pruneban` or `pb` | Ban an user, remove his messages from last 7 days. Different from "softban" where the user is unbanned. | `r!pb` or `r!pb @User` or `r!pb @User DO NOT SPAM HERE!` |
| `setmute` | Set the mute role. If the role doesn't exists it will be created. | `r!setmute rias-mute` |
| `softban` or `sb` | Ban an user, remove his messages from last 7 days, and then unban it. | `r!sb @User` or `r!sb @User Don't spam here!` |
| `unmute` | Unmute an user from text and voice channels. | `r!unmute @User` |

### Channels
| Command | Description | Example |
| :---: | :---: | :---: |
| `channeltopic` or `ct` | Show the current channel's topic. | `r!ct` |
| `createcategory` or `ccat` | Create a category. | `r!ccat MEDIA` |
| `createchannel` or `cch` | Create a text or a voice channel. The type of the channel must be specified: `text` or `voice`. |
| `deletecategory` or `dcat` | Delete a category. | `r!dcat MEDIA` |
| `renamecategory` or `rncat` | Rename a category. You need to separate the old name by the new name with '->' | `r!rncat MEDIA -> MUSIC` |
| `renamechannel` or `rnch` | Rename a channel. You need to separate the old name by the new name with '->'. The name is case-sensitive. The type of the channel must be specified: `text` or `voice`. | `r!rnch text media -> music` or `r!rnch voice Media -> Music` |
| `setchanneltopic` or `sct` | Set this channel's topic | `r!sct topic` |