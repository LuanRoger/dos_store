from controllers.client_controller import ClientController
from controllers.address_controller import AddressController
from util.error_handling import ErrorHandling

# Code page 437
# IBM PCs
# ╔═╗
# ║ ║
# ╚═╝

# Unix Tree
# ├── user
# │
# └─── info

#regin Initial configure ------------------------------------------
ClientController.LoadClientsFromFile()

#endregion

while(True):
    print("╔══════════════ DOS Store ══════════════╗")
    print("║ [ 1 ] - Cadastrar cliente.            ║")
    print("║ [ 2 ] - Adicionar endereço a cliente. ║")
    print("║ [ 3 ] - Mostrar dados do cliente.     ║")
    print("║ [ 4 ] - Mostrar clientes cadastrados. ║")
    print("║ [ 0 ] - Sair.                         ║")
    print("╚═══════════════════════════════════════╝")

    menu_choice = input("> ").strip()

    print(menu_choice)

    if(menu_choice == "1"):
        ClientController.RegisterClient()
    elif(menu_choice == "2"):
        AddressController.RegisterAddressToClient()
    elif(menu_choice == "3"):
        ClientController.ShowRegistredClient()
    elif(menu_choice == "4"):
        ClientController.ShowAllClients()
    elif(menu_choice == "0"):
        ClientController.SaveClientsInFile()
        break
    else:
        ErrorHandling.ThrowWarning("Comando inválido ou inexistente")