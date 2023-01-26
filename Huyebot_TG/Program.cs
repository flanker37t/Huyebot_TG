using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Text.RegularExpressions;
using System.Net;
using System.Runtime.InteropServices;

namespace Huyebot_TG
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    static void Main(string[] args)
        {
            const int SW_HIDE = 0;
            const int SW_SHOW = 5;
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE); // To hide
            var botClient = new TelegramBotClient("5912999949:AAEVtRYJmgTa0ajSIEKDLuTw7mqfag5XkZs");
            botClient.StartReceiving(Update, Error);
            Console.ReadLine();
            return;
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            Console.WriteLine(arg2.ToString());
            arg1.DeleteWebhookAsync(true, arg3);
            throw new NotImplementedException();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var message = update.Message;
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (update.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    //Regex reg0 = new Regex(@"\b(да+\S)\b[.?:;!]*?$");
                    Regex reg1 = new Regex(@"\b(звезда)[.?:;!]*?$\z");
                    Regex reg2 = new Regex(@"\A(пизда)[.?:;!]*?$\z");
                    Regex reg3 = new Regex(@"\b(пиздец)\b[.?:;!]*?$");
                    Regex reg4 = new Regex(@"\b(триста)\b[.?:;!]*?$");
                    Regex reg5 = new Regex(@"\A(хуй)[.?:;!]*?$\z");
                    Regex reg6 = new Regex(@"\A(ого|огого|ого-го)[.?:;!]*?$\z");
                    //MatchCollection matches0 = reg0.Matches(message.Text.ToLower());
                    MatchCollection matches1 = reg1.Matches(message.Text.ToLower());
                    MatchCollection matches2 = reg2.Matches(message.Text.ToLower());
                    MatchCollection matches3 = reg3.Matches(message.Text.ToLower());
                    MatchCollection matches4 = reg4.Matches(message.Text.ToLower());
                    MatchCollection matches5 = reg5.Matches(message.Text.ToLower());
                    MatchCollection matches6 = reg6.Matches(message.Text.ToLower());
                    if (matches1.Count > 0)
                    {
                        Console.WriteLine(matches1[0]);
                        await botClient.SendTextMessageAsync(message.Chat.Id, message.Text.Remove(message.Text.Length- matches1[0].Length) + "пизда!",Telegram.Bot.Types.Enums.ParseMode.Markdown,null,false,true,false,message.MessageId,true);
                        return;
                    }
                    else if (matches2.Count > 0)
                    {
                        Console.WriteLine(matches2[0]);
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Джигурда!", Telegram.Bot.Types.Enums.ParseMode.Markdown, null, false, true, false, message.MessageId, true);
                        return;
                    }
                    else if (matches3.Count > 0)
                    {
                        Console.WriteLine(matches3[0]);
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Сосни хуец!", Telegram.Bot.Types.Enums.ParseMode.Markdown, null, false, true, false, message.MessageId, true);
                        return;
                    }
                    else if (matches4.Count > 0)
                    {
                        Console.WriteLine(matches4[0]);
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Отсоси у тракториста!", Telegram.Bot.Types.Enums.ParseMode.Markdown, null, false, true, false, message.MessageId, true);
                        return;
                    }
                    else if (matches5.Count > 0)
                    {
                        Console.WriteLine(matches5[0]);
                        await botClient.SendTextMessageAsync(message.Chat.Id, "В жопу себе суй!", Telegram.Bot.Types.Enums.ParseMode.Markdown, null, false, true, false, message.MessageId, true);
                        return;
                    }
                    else if (matches6.Count > 0)
                    {
                        Console.WriteLine(matches6[0]);
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Ко-ко-ко!", Telegram.Bot.Types.Enums.ParseMode.Markdown, null, false, true, false, message.MessageId, true);
                        return;
                    }
                    /*else if (matches0.Count > 0)
                    {
                        Console.WriteLine(matches0[0]);
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Пизда!", Telegram.Bot.Types.Enums.ParseMode.Markdown, null, false, true, false, message.MessageId, true);
                        return;
                    }*/
                }
            }
        }
    }
}
