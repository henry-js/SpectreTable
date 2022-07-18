using System.ComponentModel;
using Spectre.Console.Cli;
using SpectreTable.Commands.Validation;

namespace SpectreTable.Commands.Setting
{
    public class ConsoleSettings : CommandSettings
    {
        [CommandArgument(0, "[optional]")]
        [Description("Mandatory argument")]
        public string Mandatory { get; set; } = string.Empty;

        [CommandArgument(1, "[optional]")]
        [Description("Optional argument")]
        public string? Optional { get; set; }

        [CommandOption("--command-option-flag")]
        [Description("Command option flag.")]
        public bool CommandOptionFlag { get; set; }

        [CommandOption("--command-option-value <value>")]
        [Description("Command option value.")]
        [ValidateString]
        public string? CommandOptionValue { get; set; }
    }
}