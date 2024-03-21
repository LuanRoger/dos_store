using DosStore.Views;
using DosStore.Views.Loader;

SplashLoaderView splashLoaderView = new();
await splashLoaderView.PerformLoading();

MainMenuView mainMenu = new();

while (true)
{
    char option = mainMenu.ShowMenu();
    switch (option)
    {
        case '1':
            CreateClienteMenu clienteMenu = new();
            await clienteMenu.StartFlow();
            break;
        case '2':
            await EnterManageClientsMenu();
            break;
        case '3':
            ShowClientView showClientView = new();
            await showClientView.StartFlow();
            break;
        case '4':
            ShowAllClientsView showAllClientsView = new();
            await showAllClientsView.StartFlow();
            break;
        case '0':
            mainMenu.messages.GoodbayMessage();
            return;
    }
}

async Task EnterManageClientsMenu()
{
    ManageClientsMenu manageClientsMenu = new();
    manageClientsMenu.ShowMenu();

    while (true)
    {
        char option = manageClientsMenu.ShowMenu();
        switch (option)
        {
            case '1':
                AddAdressToClientMenuView addAdressToClientMenuView = new();
                await addAdressToClientMenuView.StartFlow();
                break;
            case '2':
                DeleteClientView clientView = new();
                await clientView.StartFlow();
                break;
            case '0':
                return;
        }
    }
}