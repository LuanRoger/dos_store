from datetime import date
from models.address_model import AddressModel
from models.client_model import ClientModel
from util.error_handling import ErrorHandling


class ClientController:
    client_list = {} #<ClientModel>

    def RegisterClient(self):
        nome: str = None
        login: str = None
        senha: str = None
        email: str = None
        data_nascimento: date = None
        tellNumb: str = None
        endereco: AddressModel = None

        while(nome == None or nome == ""):
            print("╔═════════════════╗")
            print("║ Digite seu nome ║")
            print("╚═════════════════╝")

            nome = input("> ")
        
        while(login == None or login == ""):
            print("╔══════════════════╗")
            print("║ Digite seu login ║")
            print("╚══════════════════╝")

            login = input("> ")
            #TODO: Verificar se já existe
        
        while(senha == None or senha == ""):
            print("╔══════════════════╗")
            print("║ Digite sua senha ║")
            print("╚══════════════════╝")

            senha = input("> ")
        
        while(email == None or email == ""):
            print("╔══════════════════╗")
            print("║ Digite seu email ║")
            print("╚══════════════════╝")

            email = input("> ")

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
                    day = int(input("> "))
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
                    continue
            while(month == None or month < 1 and month > 12):
                print("╔══════════════════════════════╗")
                print("║ Digite seu mês de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    month = int(input("> "))
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
                    continue
            while(year == None or year > date.today().year):
                print("╔══════════════════════════════╗")
                print("║ Digite seu ano de nascimento ║")
                print("╚══════════════════════════════╝")

                try:
                    year = int(input("> "))
                except:
                    ErrorHandling.ThrowError("O caracter digitado é inválido")
                    continue
            
            data_nascimento = date(year, month, day)
        
        while(tellNumb == None):
            ddd: str = None
            tellNumbLocalTemp: str = None

            while(ddd == None):
                print("╔══════════════════════════════╗")
                print("║ Digite o DDD do seu telefone ║")
                print("╚══════════════════════════════╝")

                ddd = input("> ")

                if(len(ddd) != 2):
                    ErrorHandling.ThrowWarning("O DDD digitado é inválido")
                    ddd = None
            
            while(tellNumbLocalTemp == None):
                print("╔═══════════════════════════════╗")
                print("║ Digite seu número de telefone ║")
                print("╚═══════════════════════════════╝")

                tellNumbLocalTemp = input("> ")

                if(len(tellNumbLocalTemp) != 9):
                    ErrorHandling.ThrowWarning("O número de telefone digitado é inválido")
                    tellNumbLocalTemp = None
        
            tellNumb = f"({ddd}) {tellNumbLocalTemp}"
        
        self.client_list[login] = ClientModel(nome, login, senha, email,
         data_nascimento, tellNumb, endereco)

        print("╔════════════════════════════════╗")
        print("║ Cliente cadastrado com sucesso ║")
        print("╚════════════════════════════════╝")
        #TODO: Perguntar se quer cadastrar um endereço para o login atual
