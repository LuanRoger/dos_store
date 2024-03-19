from rw.talker.base_talker import BaseTalker
from rich.console import Console

class Talker(BaseTalker):
    engine: Console

    def __init__(self) -> None:
        self.engine = Console()

    def talk(self, message: object) -> None:
        self.engine.print(message)