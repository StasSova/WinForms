using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            try
            {
                ConnectWithServer _server = ConnectWithServer.GetInstance();
                // процесс инициалищации
                Task task1 = _server.Start();
                // процесс чтения сообщений от сервера
                Task task2 = _server.ReadMessage();
                await Task.WhenAll(task1, task2);
            }
            catch (Exception ex)
            {
                if (ex.Message != "[EXIT]")
                    Console.WriteLine(ex.Message);
            }
        }
    }
}
