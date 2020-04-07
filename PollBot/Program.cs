using PollBot.Models;
using System;
using Telegram.Bot;

namespace PollBot
{
	class Program
	{
		private static TelegramBotClient client;

		static void Main(string[] args)
		{
			client = Bot.Get();

			var commands = Bot.Commands;

			try
			{
				int offset = 0;
				while (true)
				{
					// получаем массив обновлений
					var updates = client.GetUpdatesAsync(offset).Result;
					client.SetWebhookAsync("");
					//Перебор полученных обновлений
					foreach (var update in updates)
					{
						foreach (var command in commands)
						{
							//Здесь идет сопоставление пришедших комманд с существующими 
							//Происходит их выполнение
							if (command.Name.Contains(update.Message.Text) || command.Name.Contains(update.CallbackQuery.Data))
							{
								command.Execute(update.Message, client);
								break;
							}
						}
						offset = update.Id + 1;
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
