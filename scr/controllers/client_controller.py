from datetime import date
from typing import Dict
from models.client_model import ClientModel
from util.object_serialization import ObjectSerialization
from util.error_handling import ErrorHandling

#static
class ClientController:
    _client_list: Dict[str, ClientModel] = {}
    _CLIENTS_FILE_PATH = "./clients.uli" #User list info

    def GetClientByLogin(login: str) -> ClientModel:
        try:
            return ClientController._client_list[login]
        except:
            return None
    def GetClientByLoginUi(singleTimeVerify: bool = True) -> ClientModel:
        actualClient: ClientModel = None

        while(actualClient == None):

            print("╔══════════════════╗")
            print("║ Digite seu login ║")
            print("╚══════════════════╝")
            #TODO: Create a command recoganizer
            if(not singleTimeVerify):
                print("[/exit] - Para sair")

            login = input("> ")
            if(login == "/exit" and not singleTimeVerify): #Way to exit
                return None

            actualClient = ClientController.GetClientByLogin(login)

            if(actualClient == None):
                ErrorHandling.ThrowWarning("Este cliente não existe")

                if(singleTimeVerify):
                    return None
                else:
                    actualClient = None
                    continue

            print("╔══════════════════╗")
            print("║ Digite sua senha ║")
            print("╚══════════════════╝")

            password = input("> ")
            
            if(actualClient.senha != password):
                ErrorHandling.ThrowWarning("Senha incorreta")
                actualClient = None
                continue
        
        return actualClient

    #region Client persistence ----------------------------------------------------
    def SaveClientsInFile():
        ObjectSerialization.DumpToBin(ClientController._client_list, ClientController._CLIENTS_FILE_PATH)
    def LoadClientsFromFile():
        try:
            ClientController._client_list = ObjectSerialization.LoadFromBin(ClientController._CLIENTS_FILE_PATH)
        except:
            pass
    #endregion---------------------------------------------------------------------

    def RegisterClient():
        nome: str = None
        login: str = None
        senha: str = None
        email: str = None
        data_nascimento: date = None
        tellNumb: str = None

        while(nome == None or nome == ""):
            print("╔═════════════════╗")
            print("║ Digite seu nome ║")
            print("╚═════════════════╝")

            nome = input("> ").strip()
        
        while(login == None or login == ""):
            print("╔══════════════════╗")
            print("║ Digite seu login ║")
            print("╚══════════════════╝")

            login = input("> ").strip()
            
            if(login in ClientController._client_list):
                ErrorHandling.ThrowWarning("Este login já está cadastrado")
                login = None
        
        while(senha == None or senha == ""):
            print("╔══════════════════╗")
            print("║ Digite sua senha ║")
            print("╚══════════════════╝")

            senha = input("> ").strip()
        
        while(email == None or email == ""):
            print("╔══════════════════╗")
            print("║ Digite seu email ║")
            print("╚══════════════════╝")

            email = input("> ").strip()

            if(not "@" in email or not ".com" in email):
                ErrorHandling.ThrowWarning("Este não é um email válido.")
                email = None
        
        while(data_nascimento == None):
            day: int = None
            month: int = None
            year: int = None

            while(day == None or day < 1 or day > 31):
                print("╔══════════════════════════════╗")
                print("║ Digite seu dia de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    day = int(input("> ").strip())
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
            while(month == None or month < 1 and month > 12):
                print("╔══════════════════════════════╗")
                print("║ Digite seu mês de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    month = int(input("> ").strip())
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
            while(year == None or year > date.today().year):
                print("╔══════════════════════════════╗")
                print("║ Digite seu ano de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    year = int(input("> ").strip())
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
            
            data_nascimento = date(year, month, day)
        
        while(tellNumb == None):
            ddd: str = None
            tellNumbLocalTemp: str = None

            while(ddd == None):
                print("╔══════════════════════════════╗")
                print("║ Digite o DDD do seu telefone ║")
                print("╚══════════════════════════════╝")

                ddd = input("> ").strip()

                if(len(ddd) != 2):
                    ErrorHandling.ThrowWarning("O DDD digitado é inválido")
                    ddd = None
            
            while(tellNumbLocalTemp == None):
                print("╔═══════════════════════════════╗")
                print("║ Digite seu número de telefone ║")
                print("╚═══════════════════════════════╝")

                tellNumbLocalTemp = input("> ").strip()

                if(len(tellNumbLocalTemp) != 9):
                    ErrorHandling.ThrowWarning("O número de telefone digitado é inválido")
                    tellNumbLocalTemp = None
        
            tellNumb = f"({ddd}) {tellNumbLocalTemp}"
        
        ClientController._client_list[login] = ClientModel(nome, login, senha, email,
         data_nascimento, tellNumb, None)

        print("╔════════════════════════════════╗")
        print("║ Cliente cadastrado com sucesso ║")
        print("╚════════════════════════════════╝")
    def ShowRegistredClient():
        actualClient = ClientController.GetClientByLoginUi(False)

        if(actualClient == None):
            return
        
        print("╔═══════════════════════════ Informações ═══════════════════════════╗")
        print(f" Nome completo: " + actualClient.nome)
        print(f" Email: " + actualClient.email)
        print(f" Login: " + actualClient.login)
        print(f" Data de nascimento: " + actualClient.data_nascimento.strftime("%d/%m/%Y"))
        print(f" N° Telefone: " + actualClient.tellNumb)

        if(actualClient.enderecos != None):
            defaultAddress = actualClient.enderecos[0]
            print("  ╔══════════════════════ Endereço (Padrão) ═════════════════════╗")
            print(f"   Rua: " + defaultAddress.rua)
            print(f"   N°: " + defaultAddress.numero)
            print(f"   Complemento: " + defaultAddress.bairro)
            print(f"   Cidade: " + defaultAddress.cidade)
            print(f"   CEP: " + defaultAddress.cep)
            print(f"   Ponto de referência: " + defaultAddress.pontoReferencia)
            print("  ╚══════════════════════════════════════════════════════════════╝")

        print("╚═══════════════════════════════════════════════════════════════════╝")
    
    def ShowAllClients():
        tempClientAuth = ClientController.GetClientByLoginUi()
        if(tempClientAuth == None):
            ErrorHandling.ThrowWarning("Este cliente não existe")
            return

        del tempClientAuth

        print("Clientes cadastrados")
        for login, client in ClientController._client_list.items():
            isLast: bool = list(ClientController._client_list)[-1] == login

            rootIndent = "└── " if isLast else "├── "
            rootIndent2 = "    " if isLast else "│   "
            lastClientCharacterTree = "└── " if client.enderecos == None else "├── "

            print(rootIndent + client.nome)
            print(rootIndent2 + "├── " + client.email)
            print(rootIndent2 + "├── " + client.login)
            print(rootIndent2 + "├── " + client.data_nascimento.strftime("%d/%m/%Y"))
            print(rootIndent2 + lastClientCharacterTree + client.tellNumb)
            if(client.enderecos != None):
                print(rootIndent2 + "└── " + "Endereços")
                listInterator: int = 1
                for enderco in client.enderecos:
                    isLastAddress: bool = enderco == client.enderecos[-1]

                    rootAddressIndent = "└── " if isLastAddress else "├── "
                    rootAddressIndent2 = "    " if isLastAddress else "│   "

                    print(rootIndent2 + "    " + rootAddressIndent + "Endereço " + str(listInterator))
                    print(rootIndent2 + "    " + rootAddressIndent2 + "├── " + enderco.rua)
                    print(rootIndent2 + "    " + rootAddressIndent2 + "├── " + enderco.numero)
                    print(rootIndent2 + "    " + rootAddressIndent2 + "├── " + enderco.complemento)
                    print(rootIndent2 + "    " + rootAddressIndent2 + "├── " + enderco.cidade)
                    print(rootIndent2 + "    " + rootAddressIndent2 + "├── " + enderco.cep)
                    print(rootIndent2 + "    " + rootAddressIndent2 + "└── " + enderco.pontoReferencia)

                    listInterator += 1