namespace DosStore.Exceptions;

public class ClientNotFoundException() : Exception(MESSAGE)
{
    private const string MESSAGE = "Client not found";
}