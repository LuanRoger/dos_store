using DosStore.Controller;
using DosStore.Models;
using DosStore.Views.ElementsFactory;
using DosStore.Views.ElementsFactory.Base;
using DosStore.Views.Messages;
using Spectre.Console;

namespace DosStore.Views;

public class AddAdressToClientMenuViewView(IRuleFactory? ruleFactory = null) : ICommandMenuView
{
    private readonly AdressController _adressController = new(); 
    private IRuleFactory ruleFactory { get; } = ruleFactory ?? new RuleFactory();
    private readonly AddAdressToClientMenuMessages _messages = new();
    private readonly PickClientWLoginView _pickClientWLogin = new();
    
    public async Task StartFlow()
    {
        var userClientInfo = await _pickClientWLogin.StartFlow();
        if(!userClientInfo.HasValue && userClientInfo is null)
        {
            return;
        }

        (UserModel _, int clientId) = userClientInfo.Value;
        
        string rua = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite sua rua: "));
        string numero = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o numero da sua casa: ")
                .ValidationErrorMessage("Digite um número válido")
                .Validate(_adressController.ValidateNumber));
        string complemento = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o complemento: "));
        string bairro = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o nome do bairro: "));
        string cidade = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o nome da cidade: "));
        string cep = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o CEP: ")
                .ValidationErrorMessage("Digite um CEP válido")
                .Validate(_adressController.ValidateCep));
        string pontoReferencia = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o ponto de referência: "));

        AdressModel clientAdress = new()
        {
            rua = rua,
            numero = numero,
            complemento = complemento,
            bairro = bairro,
            cidade = cidade,
            cep = cep,
            pontoReferencia = pontoReferencia
        };
        await _adressController.RegisterAdressForUser(clientAdress, clientId);
        _messages.AdressAdded();
    }
}