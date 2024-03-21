using DosStore.Controller;
using Spectre.Console;

namespace DosStore.Views.Loader;

public class SplashLoaderView : ILoaderView
{
    private readonly DatabaseController _databaseController = new();
    
    public async Task PerformLoading()
    {
        await AnsiConsole.Progress()
            .AutoClear(true)
            .StartAsync(async context =>
            {
                ProgressTask databaseCreation = context
                    .AddTask("Criando o banco de dados...");
                databaseCreation.IsIndeterminate = true;

                while (!context.IsFinished)
                {
                    await _databaseController.CreateDatabase();
                    databaseCreation.Increment(100);
                }
            });
    }
}