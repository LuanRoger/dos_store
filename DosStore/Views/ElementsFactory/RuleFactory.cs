using DosStore.Views.ElementsFactory.Base;
using Spectre.Console;

namespace DosStore.Views.ElementsFactory;

public class RuleFactory : IRuleFactory
{
    public Rule CreateRule(string title) =>
        new Rule($"[blue]{title}[/]")
            .LeftJustified();
}