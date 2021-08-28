using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Discord;

public class Main : MonoBehaviour
{

    public Discord.Discord discord;
    public Text userIdInputText;
    public Text statusText;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 10;
        discord = new Discord.Discord(123, (System.UInt64)Discord.CreateFlags.Default);
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }

    public void buttonStart()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Playing with Gene",
            Details = ":)",

            Timestamps =
            {
                Start = System.DateTimeOffset.Now.ToUnixTimeSeconds()
            },

            Assets =
            {
                LargeImage = "gene",
                LargeText = "It's Gene!",
                SmallImage = "gene",
                SmallText = "It's smol Gene!"
            },

            Party =
            {
                Id = "GeneParty",
                Size =
                {
                    CurrentSize = 1,
                    MaxSize = 42069
                }
            },

            Secrets =
            {
                Match = "aaaaaaaa",
                Join = "bbbbbbbb",
                Spectate = "cccccccc"
            },
            Instance = true
        };

        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                statusText.text = "Button Start success";
            }
            else
            {
                statusText.text = "Button Start failed";
            }
        });
    }

    public void buttonStop()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = ":)",
            Details = "Playing with Gene",

            Assets =
            {
                LargeImage = "gene",
                LargeText = "It's Gene!"
            }
        };

        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                statusText.text = "Button Stop success";
            }
            else
            {
                statusText.text = "Button Stop failed";
            }
        });

    }

    public void buttonQuit()
    {
        var activityManager = discord.GetActivityManager();
        activityManager.ClearActivity((result) =>
        {
            if (result == Discord.Result.Ok)
            {
                statusText.text = "Button Quit success";
            }
            else
            {
                statusText.text = "Button Quit failed";
            }
        });

        Application.Quit();
    }

    public void buttonSendInvite()
    {
        long userid = 0;
        bool success = false;
        try
        {
           userid = long.Parse(userIdInputText.text);
           success = true;
        }
        catch
        {
            statusText.text = "Not a number?";
        }

        if (success)
        {
            var activityManager = discord.GetActivityManager();
            activityManager.SendInvite(userid, Discord.ActivityActionType.Join, "Come play with Gene! :sob:", (result) =>
            {
                if (result == Discord.Result.Ok)
                {
                    statusText.text = "Button Invite success";
                }
                else
                {
                    statusText.text = "Button Invite failed";
                }
            });
        }
        
    }
}
