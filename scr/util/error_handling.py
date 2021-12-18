#static
class ErrorHandling:
    def ThrowError(message: str):
        print("\033[31m<ERROR> " + message + "\033[m")
    
    def ThrowWarning(message: str):
        print("\033[33m<WARNING> " + message + "\033[m")

    def ThrowInformation(message: str):
        print("\033[34m<INFORMATION> " + message + "\033[m")