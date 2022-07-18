using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Spectre.Console;
using Spectre.Console.Cli;
using SpectreTable.Commands.Setting;

namespace SpectreTable.Commands
{
    public class ConsoleCommand : AsyncCommand<ConsoleSettings>
    {
        private ILogger Logger { get; }

        public override async Task<int> ExecuteAsync(CommandContext context, ConsoleSettings settings)
        {
            Logger.LogInformation("Mandatory: {Mandatory}", settings.Mandatory);
            Logger.LogInformation("Optional: {Optional}", settings.Optional);
            Logger.LogInformation("CommandOptionFlag: {CommandOptionFlag}", settings.CommandOptionFlag);
            Logger.LogInformation("CommandOptionValue: {CommandOptionValue}", settings.CommandOptionValue);

            // var table = new Table();

            // table.AddColumn("Foo");
            // table.AddColumn(new TableColumn("Bar").Centered());
            // // Add some rows
            // table.AddRow("Baz", "[green]Qux[/]");
            // table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

            // // Render the table to the console
            // AnsiConsole.Live(table)
            //     .Start(ctx =>
            //     {
            //         table.Expand();
            //         ctx.Refresh();
            //         Task.Delay(1000);
            //     });

            var table = new Table().Centered();

            AnsiConsole.Live(table)
                .AutoClear(false)   // Do not remove when done
                .Overflow(VerticalOverflow.Ellipsis) // Show ellipsis when overflowing
                .Cropping(VerticalOverflowCropping.Top) // Crop overflow at top
                .Start(ctx =>
                            {
                                table.Width(100);
                                table.AddColumn("Foo");
                                ctx.Refresh();
                                Thread.Sleep(1000);

                                table.AddColumn("Bar");
                                ctx.Refresh();
                                Thread.Sleep(1000);
                            });

            Console.ReadLine();
            return await Task.FromResult(0);
        }

        public ConsoleCommand(ILogger<ConsoleCommand> logger)
        {
            Logger = logger;
        }
    }
}
