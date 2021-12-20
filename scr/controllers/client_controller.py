from datetime import date
from typing import Dict
from models.client_model import ClientModel
from util.object_serialization import ObjectSerialization
from util.error_handling import ErrorHandling

# static
class ClientController:
    _client_list: Dict[str, ClientModel] = {}
    _CLIENTS_FILE_PATH = "./clients.uli" #User list info

    #region GetClient --------------------------------------------------------------
    @staticmethod
    def GetClientByLogin(login: str) -> ClientModel:
        try:
            return ClientController._client_list[login]
        except:
            return None
    @staticmethod
    def GetClientByLoginUi(singleTimeVerify: bool = True) -> ClientModel:
        actualClient: ClientModel = None

        while(actualClient is None):
            print("╔══════════════════╗")
            print("║ Digite seu login ║")
            print("╚══════════════════╝")
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
    #endregion

    #region Client persistence ----------------------------------------------------
    @staticmethod
    def SaveClientsInFile():
        ObjectSerialization.DumpToBin(ClientController._client_list, ClientController._CLIENTS_FILE_PATH)
    @staticmethod
    def LoadClientsFromFile():
        try:
            ClientController._client_list = ObjectSerialization.LoadFromBin(ClientController._CLIENTS_FILE_PATH)
        except:
            pass
    #endregion---------------------------------------------------------------------

    #region Manage Client ---------------------------------------------------------
    @staticmethod
    def RegisterClient():
        nome: str = None
        login: str = None
        senha: str = None
        email: str = None
        data_nascimento: date = None
        tellNumb: str = None

        while(nome is None or nome == ""):
            print("╔═════════════════╗")
            print("║ Digite seu nome ║")
            print("╚═════════════════╝")

            nome = input("> ").strip()
        
        while(login is None or login == ""):
            print("╔══════════════════╗")
            print("║ Digite seu login ║")
            print("╚══════════════════╝")

            login = input("> ").strip()
            
            if(login in ClientController._client_list):
                ErrorHandling.ThrowWarning("Este login já está cadastrado")
                login = None
        
        while(senha is None):
            print("╔══════════════════╗")
            print("║ Digite sua senha ║")
            print("╚══════════════════╝")

            senha = input("> ").strip()

            if(senha == ""):
                ErrorHandling.ThrowWarning("Senha não pode estar vazia")
                senha = None
        
        while(email is None):
            print("╔══════════════════╗")
            print("║ Digite seu email ║")
            print("╚══════════════════╝")

            email = input("> ").strip()

            if(not "@" in email or not ".com" in email or email == ""):
                ErrorHandling.ThrowWarning("Este não é um email válido.")
                email = None
        
        while(data_nascimento is None):
            day: int = None
            month: int = None
            year: int = None

            while(day is None):
                print("╔══════════════════════════════╗")
                print("║ Digite seu dia de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    day = int(input("> ").strip())
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
                    continue

                if(1 > day > 31):
                    ErrorHandling.ThrowWarning("Dia inválido")
                    ErrorHandling.ThrowInformation("O dia digitado deve estar entre 1 e 31")
                    day = None
            while(month is None):
                print("╔══════════════════════════════╗")
                print("║ Digite seu mês de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    month = int(input("> ").strip())
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
                    continue
                
                if(1 > month > 12):
                    ErrorHandling.ThrowWarning("Mês inválido")
                    ErrorHandling.ThrowInformation("O mês digitado deve estar entre 1 e 12")
                    month = None
            while(year is None):
                print("╔══════════════════════════════╗")
                print("║ Digite seu ano de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    year = int(input("> ").strip())
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
                    continue

                if(year > date.today().year):
                    ErrorHandling.ThrowWarning("Ano inválido")
                    ErrorHandling.ThrowInformation("O ano digitado deve estar entre 1 e " + date.today().year)
                    year = None
            
            data_nascimento = date(year, month, day)
        
        while(tellNumb is None):
            ddd: str = None
            tellNumbLocalTemp: str = None

            while(ddd is None):
                print("╔══════════════════════════════╗")
                print("║ Digite o DDD do seu telefone ║")
                print("╚══════════════════════════════╝")

                ddd = input("> ").strip()

                if(len(ddd) != 2):
                    ErrorHandling.ThrowWarning("O DDD digitado é inválido")
                    ddd = None
                
                if(ddd == ""):
                    ErrorHandling.ThrowWarning("O DDD não pode estar vazio")
                    ddd = None
            
            while(tellNumbLocalTemp is None):
                print("╔═══════════════════════════════╗")
                print("║ Digite seu número de telefone ║")
                print("╚═══════════════════════════════╝")

                tellNumbLocalTemp = input("> ").strip()

                if(len(tellNumbLocalTemp) != 9):
                    ErrorHandling.ThrowWarning("O número de telefone digitado é inválido")
                    tellNumbLocalTemp = None
                
                if(tellNumbLocalTemp == ""):
                    ErrorHandling.ThrowWarning("O número de telefone não pode estar vazio")
                    tellNumbLocalTemp = None
        
            tellNumb = f"({ddd}) {tellNumbLocalTemp}"
        
        ClientController._client_list[login] = ClientModel(nome, login, senha, email,
         data_nascimento, tellNumb, None)

        print("╔════════════════════════════════╗")
        print("║ Cliente cadastrado com sucesso ║")
        print("╚════════════════════════════════╝")
    @staticmethod
    def DeleteClient():
        tempClientAuth = ClientController.GetClientByLoginUi(False)
        if(tempClientAuth == None):
            ErrorHandling.ThrowWarning("Este cliente não existe")
            return

        del tempClientAuth

        loginClientToDelete: str = None
        while(loginClientToDelete == None):
            print("╔══════════════════════════════════════════════╗")
            print("║ Digite o login do cliente que deseja deletar ║")
            print("╚══════════════════════════════════════════════╝")
            print("[/exit] - Para sair")

            loginClientToDelete = input("> ").strip()

            if(loginClientToDelete == "/exit"):
                return

            userVerify = ClientController.GetClientByLogin(loginClientToDelete)
            if(userVerify == None):
                ErrorHandling.ThrowError("Este cliente não existe")
                return
        
        print("╔════════════════════════════════════════════════╗")
        print("║ Deseja realmente deleta o usuário selecionado? ║")
        print("║ [ 1 ] - Sim.                      [ 2 ] - Não. ║")
        print("╚════════════════════════════════════════════════╝")

        deleteUserChoice = input("> ").strip()

        if(deleteUserChoice != "1"):
            return

        del ClientController._client_list[loginClientToDelete]

        print("╔══════════════════════════════╗")
        print("║ Cliente deletado com sucesso ║")
        print("╚══════════════════════════════╝")
    #endregion --------------------------------------------------------------------

    #region Show Clients ----------------------------------------------------------
    @staticmethod
    def ShowRegistredClient():
        actualClient = ClientController.GetClientByLoginUi()
        if(actualClient is None):
            return
        
        print("╔═══════════════════════ Informações ════════════════════════╗")
        print(f" Nome completo: " + actualClient.nome)
        print(f" Email: " + actualClient.email)
        print(f" Login: " + actualClient.login)
        print(f" Data de nascimento: " + actualClient.data_nascimento.strftime("%d/%m/%Y"))
        print(f" N° Telefone: " + actualClient.tellNumb)

        if(actualClient.enderecos is not None):
            defaultAddress = actualClient.enderecos[0]
            print("  ╔═══════════════════ Endereço (Padrão) ═══════════════════╗")
            print(f"   Rua: " + defaultAddress.rua)
            print(f"   N°: " + defaultAddress.numero)
            print(f"   Complemento: " + defaultAddress.bairro)
            print(f"   Cidade: " + defaultAddress.cidade)
            print(f"   CEP: " + defaultAddress.cep)
            print(f"   Ponto de referência: " + defaultAddress.pontoReferencia)
            print("  ╚═════════════════════════════════════════════════════════╝")

        print("╚════════════════════════════════════════════════════════════╝")
    @staticmethod
    def ShowAllClients():
        tempClientAuth = ClientController.GetClientByLoginUi()
        if(tempClientAuth == None):
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
    #endregion ---------------------------------------------------------------------