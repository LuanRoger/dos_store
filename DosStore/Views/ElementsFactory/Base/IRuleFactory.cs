using Spectre.Console;

namespace DosStore.Views.ElementsFactory.Base;

public interface IRuleFactory
{
    public Rule CreateRule(string title);
}