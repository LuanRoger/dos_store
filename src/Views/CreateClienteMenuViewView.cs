using DosStore.Controller;
using DosStore.Models;
using DosStore.Utils;
using DosStore.Views.ElementsFactory;
using DosStore.Views.ElementsFactory.Base;
using DosStore.Views.Messages;
using Spectre.Console;

namespace DosStore.Views;

public class CreateClienteMenuViewView(IRuleFactory? ruleFactory = null) : IFlowMenuView
{
    private readonly ClientController _clientController = new();
    private IRuleFactory ruleFactory { get; } = ruleFactory ?? new RuleFactory();

    public async Task StartFlow()
    {
        AnsiConsole.Write(ruleFactory.CreateRule("Dados de cadastro"));
        string nome = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite seu nome:"));
        string email = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite seu email:")
                .ValidationErrorMessage("Digite um email válido")
                .Validate(_clientController.ValidateEmail));
        
        AnsiConsole.Write(ruleFactory.CreateRule("Dados do usuário"));
        int dia = AnsiConsole.Prompt(
            new TextPrompt<int>("Digite seu dia de nascimento:")
                .ValidationErrorMessage("Digite um dia válido")
                .Validate(_clientController.ValidateDiaNascimento));
        int mes = AnsiConsole.Prompt(
            new TextPrompt<int>("Digite seu mês de nascimento:")
                .ValidationErrorMessage("Digite um mês válido")
                .Validate(_clientController.ValidateMesNascimento));
        int ano = AnsiConsole.Prompt(
            new TextPrompt<int>("Digite seu ano de nascimento:")
                .ValidationErrorMessage("Digite um ano válido")
                .Validate(_clientController.ValidateAnoNascimento));
        string ddd = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o DDD do seu telefone:")
                .ValidationErrorMessage("Digite um DDD válido")
                .Validate(_clientController.ValidateDdd));
        string telNumb = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite seu número de telefone:")
                .ValidationErrorMessage("Digite um número válido")
                .Validate(_clientController.ValidatePhone));

        CreateClienteMenuMessages messages = new();
        messages.ClienteRegisteredSuccessMessage();
        
        ClienteModel clienteModel = new()
        {
            nome = nome,
            email = email,
            dataNascimento = new(ano, mes, dia),
            tellNumb = PhoneFormater.FormatPhone(ddd, telNumb)
        };
        await _clientController.CreateClient(clienteModel);
    }
}