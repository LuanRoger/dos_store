namespace DosStore.Exceptions;

public class UserNotFoundException() : Exception(MESSAGE)
{
    private const string MESSAGE = "The user was not found.";
}