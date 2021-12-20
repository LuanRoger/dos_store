#static
class ErrorHandling:
    @staticmethod
    def ThrowError(message: str):
        print("\033[31m<ERROR> " + message + "\033[m")
    
    @staticmethod
    def ThrowWarning(message: str):
        print("\033[33m<WARNING> " + message + "\033[m")

    @staticmethod
    def ThrowInformation(message: str):
        print("\033[34m<INFORMATION> " + message + "\033[m")