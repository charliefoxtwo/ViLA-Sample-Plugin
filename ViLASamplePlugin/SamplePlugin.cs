using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ViLA.PluginBase;

public class SamplePlugin : PluginBase, IDisposable
{
    /// <summary>
    /// ConfigPath is relative to ViLA, *not* to this dll
    /// </summary>
    public const string ConfigPath = "Plugins/ViLASamplePlugin/config.json";

    private Task _thread = null!;

    public override async Task<bool> Start()
    {
        var log = LoggerFactory.CreateLogger<SamplePlugin>();
        log.LogInformation("Starting sample plugin...");

        var cfg = await GetConfiguration();

        _thread = Task.Run(() => RunMethod(cfg.DelayMs, default), default);
        return true;
    }

    public override Task Stop()
    {
        Dispose();
        return Task.CompletedTask;
    }

    private static async Task<PluginConfiguration> GetConfiguration()
    {
        PluginConfiguration? pluginConfig = null;
        var getAndWriteDefaultConfig = true;

        if (File.Exists(ConfigPath))
        {
            getAndWriteDefaultConfig = false;

            var configString = await File.ReadAllTextAsync(ConfigPath);
            pluginConfig = JsonConvert.DeserializeObject<PluginConfiguration>(configString);

            if (pluginConfig is null)
            {
                getAndWriteDefaultConfig = true;
            }
        }

        if (getAndWriteDefaultConfig)
        {
            pluginConfig = PluginConfiguration.Default();
            await File.WriteAllTextAsync(ConfigPath, JsonConvert.SerializeObject(pluginConfig));
        }

        return pluginConfig!;
    }

    private void RunMethod(int delay, CancellationToken ct)
    {
        var r = new Random();
        while (!ct.IsCancellationRequested)
        {
            for (var i = 0; i < 12*17*6 && !ct.IsCancellationRequested; i++)
            {
                var newColor = r.Next(1, 8);
                Send($"cp1led{i % 12 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cp2led{i % 17 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cm1led{i % 6 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cm2led{i % 6 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cm3led{i % 6 + 1}", newColor);

                newColor = r.Next(1, 8);
                Send($"cp1sled{i % 20 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cp2sled{i % 20 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cm1sled{i % 20 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cm2sled{i % 20 + 1}", newColor);
                newColor = r.Next(1, 8);
                Send($"cm3sled{i % 20 + 1}", newColor);

                Thread.Sleep(delay);
                Send($"cp1led{i % 12 + 1}", 0);
                Send($"cp2led{i % 17 + 1}", 0);
                Send($"cm1led{i % 6 + 1}", 0);
                Send($"cm2led{i % 6 + 1}", 0);
                Send($"cm3led{i % 6 + 1}", 0);
                Send($"cp1sled{i % 20 + 1}", 0);
                Send($"cp2sled{i % 20 + 1}", 0);
                Send($"cm1sled{i % 20 + 1}", 0);
                Send($"cm2sled{i % 20 + 1}", 0);
                Send($"cm3sled{i % 20 + 1}", 0);
            }
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _thread.Dispose();
    }
}
