using _Client2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client2
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            TaskCompletionSource<object> tcs1 = new TaskCompletionSource<object>();
            TaskCompletionSource<object> tcs2 = new TaskCompletionSource<object>();
            try
            {
                ConnectWithServer _server = new ConnectWithServer();
                await _server.Start();
                await _server.ReadMessage();
                tcs1.SetResult(null);
                tcs2.SetResult(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await Task.WhenAll(tcs1.Task, tcs2.Task);
        }
    }
}
