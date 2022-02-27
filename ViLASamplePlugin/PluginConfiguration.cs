// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable MemberCanBePrivate.Global

public class PluginConfiguration
{
    public int DelayMs { get; set; }

    public static PluginConfiguration Default()
    {
        return new() { DelayMs = 500 };
    }
}
