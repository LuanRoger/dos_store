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
            CreateClienteMenuViewView clienteMenuViewView = new();
            await clienteMenuViewView.StartFlow();
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
        case '5':
            ShowProductsView showProductsView = new();
            await showProductsView.StartFlow();
            break;
        case '6':
            await EnterManageProductsMenu();
            break;
        case '7':
            CreateSaleMenuView createSaleMenuView = new();
            await createSaleMenuView.StartFlow();
            break;
        case '0':
            mainMenu.messages.GoodbayMessage();
            return;
    }
}

async Task EnterManageClientsMenu()
{
    ManageClientsMenuView manageClientsMenuView = new();

    while (true)
    {
        char option = manageClientsMenuView.ShowMenu();
        switch (option)
        {
            case '1':
                AddAdressToClientMenuViewView addAdressToClientMenuViewView = new();
                await addAdressToClientMenuViewView.StartFlow();
                break;
            case '2':
                DeleteClientViewMenu clientViewMenu = new();
                await clientViewMenu.StartFlow();
                break;
            case '0':
                return;
        }
    }
}

async Task EnterManageProductsMenu()
{
    ManageProductsMenuView manageProductsMenuView = new();
    
    while (true)
    {
        char option = manageProductsMenuView.ShowMenu();
        switch (option)
        {
            case '1':
                CreateProductMenuView createProductMenuView = new();
                await createProductMenuView.StartFlow();
                break;
            case '2':
                UpdateProductAmountView updateProductAmountView = new();
                await updateProductAmountView.StartFlow();
                break;
            case '3':
                DeleteProductViewMenu deleteProductViewMenu = new();
                await deleteProductViewMenu.StartFlow();
                break;
            case '0':
                return;
        }
    }
}