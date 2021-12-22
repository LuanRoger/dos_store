import pickle
from typing import Any

#static
class ObjectSerialization:
    #THIS SERIALIZATION KIND IS NOT SECURE

    @staticmethod
    def DumpToBin(object: Any, filepath: str):
        fileinfo = open(filepath, 'wb')
        pickle.dump(object, fileinfo)

    @staticmethod
    def LoadFromBin(filepath: str) -> Any:
        fileinfo = open(filepath, 'rb')
        return pickle.load(fileinfo)