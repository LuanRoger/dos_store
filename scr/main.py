from controllers.client_controller import ClientController
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

while(True):
    print("╔══════════════ DOS Store ══════════════╗")
    print("║ [ 1 ] - Cadastrar cliente.            ║")
    print("║ [ 2 ] - Adicionar endereço a cliente. ║")
    print("║ [ 4 ] - Mostrar clientes cadastrados. ║")
    print("║ [ 0 ] - Sair.                         ║")
    print("╚═══════════════════════════════════════╝")

    menu_choice = input("> ")

    if(menu_choice == "1"):
        clientController.RegisterClient()
    elif(menu_choice == "0"):
        break
    else:
        ErrorHandling.ThrowWarning("Comando inválido ou inexistente")