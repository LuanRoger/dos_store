#static
from util.error_handling import ErrorHandling


class MenuViews:
    _PREFIX_CHOICE: str = "> "

    def MainMenu(*safeArgs: str) -> str:
        menu_choice: str = None
        while(menu_choice == None):
            print("╔══════════════ DOS Store ══════════════╗")
            print("║ [ 1 ] - Cadastrar cliente.            ║")
            print("║ [ 2 ] - Gerenciar clientes.           ║")
            print("║ [ 3 ] - Mostrar dados do cliente.     ║")
            print("║ [ 4 ] - Mostrar clientes cadastrados. ║")
            print("║ [ 0 ] - Sair.                         ║")
            print("╚═══════════════════════════════════════╝")
            print("[/cls] - Limpar tela")

            menu_choice = input(MenuViews._PREFIX_CHOICE).strip()

            if(menu_choice == "" or not menu_choice in safeArgs):
                ErrorHandling.ThrowWarning("Comando inválido ou inexistente")
                menu_choice = None
        
        return menu_choice

    def ManageClientsMenu(*safeArgs) -> str:
        menu_choice: str = None
        while(menu_choice == None):
            print("╔═════ Gerenciar usuários ════╗")
            print("║ [ 1 ] - Cadastrar endereço. ║")
            print("║ [ 2 ] - Deletar usuário.    ║")
            print("║ [ 0 ] - Voltar.             ║")
            print("╚═════════════════════════════╝")

            menu_choice = input(MenuViews._PREFIX_CHOICE).strip()

            if(menu_choice == "" or not menu_choice in safeArgs):
                ErrorHandling.ThrowWarning("Comando inválido ou inexistente")
                menu_choice = None
        
        return menu_choice

