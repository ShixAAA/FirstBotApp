using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace ABisitBot
{
    internal class Program
    {
        private static string token { get; set; } = "5591522287:AAELnkQvOO8GfLwAz7RCskuCYBVOhLCAGuE";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Получено сообщение: {msg.Text}");
                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
                //var stic = await client.SendStickerAsync(
                //    chatId: msg.Chat.Id,
                //    sticker: "https://sticker-collection.com/stickers/plain/PukanePack/512/d233add9-90cc-45c6-ba04-bc97531bc5d1file_1313488.webp",
                //    replyToMessageId: msg.MessageId);
                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GetButtons());
                switch (msg.Text) 
                {
                    case "Лицо":
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://sticker-collection.com/stickers/plain/PukanePack/512/d233add9-90cc-45c6-ba04-bc97531bc5d1file_1313488.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    case "Картинка":
                        var pic = await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://avatars.mds.yandex.net/i?id=1593019dc918ac91b3b060d945e067bc-4834925-images-thumbs&n=13",
                            replyMarkup: GetButtons());
                        break;
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду: ", replyMarkup: GetButtons());
                        break;

                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
               {
                   new List<KeyboardButton> { new KeyboardButton { Text = "Лицо" } },
                   new List<KeyboardButton> { new KeyboardButton { Text = "Картинка" } }
               }
            };           
        }
    }
}
