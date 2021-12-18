import pickle
from typing import Any

#static
class ObjectSerialization:
    def DumpToBin(object: Any, filepath: str):
        fileinfo = open(filepath, 'wb')
        pickle.dump(object, fileinfo)

    def LoadFromBin(filepath: str) -> Any:
        fileinfo = open(filepath, 'rb')
        return pickle.load(fileinfo)