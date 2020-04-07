using MihaZupan;
using PollBot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace PollBot.Models
{
    public class Bot
    {
        public static IReadOnlyList<Command> Commands => commandsList?.AsReadOnly();

        private static TelegramBotClient client;

        private static List<Command> commandsList;

        public static TelegramBotClient Get()
        {
            var proxy = new HttpToSocks5Proxy("207.97.174.134", 1080);
            client = new TelegramBotClient(AppSettings.Key, proxy);

            commandsList = new List<Command>();
            //Регистрация комманд
            commandsList.Add(new HelloCommand());
            //TODO: Add more commands

            if (client != null)
            {
                return client;
            }

            return client;
        }
    }
}
