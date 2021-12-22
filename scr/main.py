import os
from controllers.client_controller import ClientController
from controllers.address_controller import AddressController
from views_elements.menu_views import MenuViews

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

#endregion --------------------------------------------------------

while(True):
    menu_choice = MenuViews.MainMenu("1", "2", "3", "4", "0", "/cls")

    if(menu_choice == "1"):
        ClientController.RegisterClient()
    elif(menu_choice == "2"):
        manage_client_menu_choice = MenuViews.ManageClientsMenu("1", "2", "0")

        if(manage_client_menu_choice == "1"):
            AddressController.RegisterAddressToClient()
        elif(manage_client_menu_choice == "2"):
            ClientController.DeleteClient()
    elif(menu_choice == "3"):
        ClientController.ShowRegistredClient()
    elif(menu_choice == "4"):
        ClientController.ShowAllClients()
    elif(menu_choice == "0"):
        ClientController.SaveClientsInFile()
        break
    elif(menu_choice == "/cls"):
        os.system("cls" if os.name == "nt" else "clear")