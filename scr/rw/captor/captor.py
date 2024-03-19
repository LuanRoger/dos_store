from rw.captor.base_captor import BaseCaptor
from rich.prompt import Prompt

class Captor(BaseCaptor):
    def input(self, choices: list[str], message: str = None) -> str:
        custom_message = message if message is not None else self.prefix
        return Prompt.ask(custom_message, choices=choices, show_choices=False)