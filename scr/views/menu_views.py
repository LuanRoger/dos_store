from typing import Optional
from rw.captor.base_captor import BaseCaptor
from rw.captor.captor import Captor
from rw.talker.base_talker import BaseTalker
from rw.talker.talker import Talker
from util.error_handling import ErrorHandling
from rich.panel import Panel
from rich.text import Text

class MenuViews:
    _PREFIX_CHOICE: str = "> "
    console: BaseTalker
    prompt: BaseCaptor

    def __init__(self, console: Optional[BaseTalker] = None, prompt: Optional[BaseCaptor] = None):
        self.console = Talker() if console is None else console
        self.prompt = Captor(self._PREFIX_CHOICE) if prompt is None else prompt

    def MainMenu(self, *safeArgs: str) -> str:
        menu_choice: str = None
        options = Text()
        options.append("[ 1 ] - Cadastrar cliente.\n")
        options.append("[ 2 ] - Gerenciar clientes.\n")
        options.append("[ 3 ] - Mostrar dados do cliente.\n")
        options.append("[ 4 ] - Mostrar clientes cadastrados.\n")
        options.append("[ 0 ] - Sair.\n")
        panel = Panel.fit(options, title="DOS Store")

        while(menu_choice is None):
            self.console.talk(panel)

            menu_choice = self.prompt.input(safeArgs)

            if(menu_choice == "" or not menu_choice in safeArgs):
                ErrorHandling.ThrowWarning("Comando inválido ou inexistente")
                menu_choice = None
        
        return menu_choice

    def ManageClientsMenu(self, *safeArgs) -> str:
        menu_choice: str = None
        options = Text()
        options.append("[ 1 ] - Cadastrar endereço.\n")
        options.append("[ 2 ] - Deletar usuário.\n")
        options.append("[ 0 ] - Voltar.\n")
        panel = Panel.fit(options, title="Gerenciar clientes")

        while(menu_choice is None):
            self.console.talk(panel)

            menu_choice = self.prompt.input(safeArgs)

            if(menu_choice == "" or not menu_choice in safeArgs):
                ErrorHandling.ThrowWarning("Comando inválido ou inexistente")
                menu_choice = None
        
        return menu_choice

