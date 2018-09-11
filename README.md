# Discord Rich Presence with Gene

Just followed https://discordapp.com/developers/docs/rich-presence/how-to and the Unity setup section at https://github.com/discordapp/discord-rpc

Using their example DiscordController.cs, all I really did was edit a few lines:

void Start()
    {
        presence.largeImageKey = "gene";

        presence.details = "OwO";
        presence.state = "what's this?";

        DiscordRpc.UpdatePresence(presence);
    }

This is the result https://puu.sh/Bt187/bdb1549713.png