using DosStore.Exceptions;
using DosStore.Models;
using DosStore.Repository;

namespace DosStore.Controller;

public class UserController
{
    private readonly UserRepository _userRepository = new();
    
    public async Task<UserModel> GetClientByLoginPassword(string login, string password)
    {
        UserModel? clienteModel = await _userRepository
            .GetClientByLoginPassword(login, password);

        if(clienteModel is null)
            throw new UserNotFoundException();

        return clienteModel;
    }
}