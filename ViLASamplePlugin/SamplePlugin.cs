using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ViLA.PluginBase;

namespace ViLASamplePlugin
{
    public class SamplePlugin : PluginBase
    {
        private Task _thread;

        public override async Task<bool> Start()
        {
            var log = LoggerFactory.CreateLogger<SamplePlugin>();
            log.LogInformation("Starting sample plugin...");

            _thread = Task.Run(() => RunMethod(default), default);
            return true;
        }

        private void RunMethod(CancellationToken ct)
        {
            var r = new Random();
            while (!ct.IsCancellationRequested)
            {
                for (var i = 0; i < 12*17*6; i++)
                {
                    if (ct.IsCancellationRequested) break;

                    var newColor = r.Next(1, 8);
                    SendData($"cp1led{i % 12 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cp2led{i % 17 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cm1led{i % 6 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cm2led{i % 6 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cm3led{i % 6 + 1}", newColor);

                    newColor = r.Next(1, 8);
                    SendData($"cp1sled{i % 20 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cp2sled{i % 20 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cm1sled{i % 20 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cm2sled{i % 20 + 1}", newColor);
                    newColor = r.Next(1, 8);
                    SendData($"cm3sled{i % 20 + 1}", newColor);

                    Thread.Sleep(500);
                    SendData($"cp1led{i % 12 + 1}", 0);
                    SendData($"cp2led{i % 17 + 1}", 0);
                    SendData($"cm1led{i % 6 + 1}", 0);
                    SendData($"cm2led{i % 6 + 1}", 0);
                    SendData($"cm3led{i % 6 + 1}", 0);
                    SendData($"cp1sled{i % 20 + 1}", 0);
                    SendData($"cp2sled{i % 20 + 1}", 0);
                    SendData($"cm1sled{i % 20 + 1}", 0);
                    SendData($"cm2sled{i % 20 + 1}", 0);
                    SendData($"cm3sled{i % 20 + 1}", 0);
                }
            }
        }
    }
}