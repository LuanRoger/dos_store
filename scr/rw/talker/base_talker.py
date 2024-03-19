from abc import ABC, abstractmethod

class BaseTalker(ABC):

    @abstractmethod
    def talk(self, message: object) -> None:
        pass