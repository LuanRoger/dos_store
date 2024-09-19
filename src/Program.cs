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
            ICommandMenuView clienteMenuViewView = new CreateClienteMenuViewView();
            await clienteMenuViewView.StartFlow();
            break;
        case '2':
            await EnterManageClientsMenu();
            break;
        case '3':
            ICommandMenuView showClientView = new ShowClientView();
            await showClientView.StartFlow();
            break;
        case '4':
            ICommandMenuView showAllClientsView = new ShowAllClientsView();
            await showAllClientsView.StartFlow();
            break;
        case '5':
            ICommandMenuView showProductsView = new ShowProductsView();
            await showProductsView.StartFlow();
            break;
        case '6':
            await EnterManageProductsMenu();
            break;
        case '7':
            ICommandMenuView showSalesMenuView = new ShowSalesMenuView();
            await showSalesMenuView.StartFlow();
            break;
        case '8':
            ICommandMenuView createSaleMenuView = new CreateSaleMenuView();
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
                ICommandMenuView createProductMenuView = new CreateProductMenuView();
                await createProductMenuView.StartFlow();
                break;
            case '2':
                ICommandMenuView updateProductAmountView = new UpdateProductAmountView();
                await updateProductAmountView.StartFlow();
                break;
            case '3':
                ICommandMenuView deleteProductViewMenu = new DeleteProductViewMenu();
                await deleteProductViewMenu.StartFlow();
                break;
            case '0':
                return;
        }
    }
}