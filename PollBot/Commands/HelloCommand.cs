using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PollBot.Commands
{
    public class HelloCommand : Command
    {
        public override List<string> Name => new List<string>() { "Hello", "hello" };
        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;


            client.SendTextMessageAsync(chatId, "Hello!");
        }
    }
}
