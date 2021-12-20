import pickle
from typing import Any

#static
class ObjectSerialization:
    @staticmethod
    def DumpToBin(object: Any, filepath: str):
        fileinfo = open(filepath, 'wb')
        pickle.dump(object, fileinfo)

    @staticmethod
    def LoadFromBin(filepath: str) -> Any:
        fileinfo = open(filepath, 'rb')
        return pickle.load(fileinfo)