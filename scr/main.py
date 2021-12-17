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

clientController = ClientController()
addreeController = AddressController()

while(True):
    print("╔══════════════ DOS Store ══════════════╗")
    print("║ [ 1 ] - Cadastrar cliente.            ║")
    print("║ [ 2 ] - Adicionar endereço a cliente. ║")
    print("║ [ 3 ] - Mostrar dados do cliente.     ║")
    print("║ [ 4 ] - Mostrar clientes cadastrados. ║")
    print("║ [ 0 ] - Sair.                         ║")
    print("╚═══════════════════════════════════════╝")

    menu_choice = input("> ")

    if(menu_choice == "1"):
        clientController.RegisterClient()
    elif(menu_choice == "2"):
        addreeController.RegisterAddressToClient(clientController)
    elif(menu_choice == "3"):
        clientController.ShowRegistredClients()
    elif(menu_choice == "0"):
        break
    else:
        ErrorHandling.ThrowWarning("Comando inválido ou inexistente")