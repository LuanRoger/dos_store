from abc import ABC, abstractmethod
from typing import Optional

class BaseCaptor(ABC):
    prefix: str

    def __init__(self, prefix) -> None:
        self.prefix = prefix

    @abstractmethod
    def input(choices: list[str], message: Optional[str] = None) -> str:
        pass