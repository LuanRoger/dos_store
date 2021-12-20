from controllers.client_controller import ClientController
from models.client_model import ClientModel
from models.address_model import AddressModel
from util.error_handling import ErrorHandling

#static
class AddressController:
    @staticmethod
    def RegisterAddressToClient():
        actualClient: ClientModel = ClientController.GetClientByLoginUi()

        if(actualClient is None):
            return
        
        AddressController._RegisterClientAddress(actualClient)

    @staticmethod
    def _RegisterClientAddress(client: ClientModel):
        rua: str = None
        numero: str = None
        complemento: str = None
        bairro: str = None
        cidade: str = None
        cep: str = None
        pontoReferencia: str = None

        while(rua is None):
            print("╔════════════════╗")
            print("║ Digite sua rua ║")
            print("╚════════════════╝")

            rua = input("> ")

            if(rua == ""):
                ErrorHandling.ThrowWarning("Rua não pode estar vazia")
                rua = None
        
        while(numero is None):
            print("╔═════════════════════════════╗")
            print("║ Digite o numero da sua casa ║")
            print("╚═════════════════════════════╝")

            try:
                numero = int(input("> ")) # Verify if is number
                numero = str(numero)
            except:
                ErrorHandling.ThrowWarning("Digite um valor válido.")
                continue

            if(len(numero) != 4):
                numero = None
        
        while(complemento is None):
            print("╔══════════════════════╗")
            print("║ Digite o complemento ║")
            print("╚══════════════════════╝")

            complemento = input("> ")

            if(complemento == ""):
                ErrorHandling.ThrowWarning("Complemento não pode estar vazio")
                complemento = None
        
        while(bairro is None):
            print("╔═════════════════════════╗")
            print("║ Digite o nome do bairro ║")
            print("╚═════════════════════════╝")

            bairro = input("> ")

            if(bairro == ""):
                ErrorHandling.ThrowWarning("Bairro não pode estar vazio")
                bairro = None
        
        while(cidade is None):
            print("╔═════════════════════════╗")
            print("║ Digite o nome da cidade ║")
            print("╚═════════════════════════╝")

            cidade = input("> ")

            if(cidade == ""):
                ErrorHandling.ThrowWarning("Cidade não pode estar vazio")
                cidade = None
        
        while(cep is None):
            print("╔══════════════╗")
            print("║ Digite o CEP ║")
            print("╚══════════════╝")

            cep = input("> ")

            if(8 >= len(cep) >= 9):
                ErrorHandling.ThrowWarning("O valor digitado é inválido")

            if(cep == ""):
                ErrorHandling.ThrowWarning("CEP não pode estar vazio")
                cep = None
        
        while(pontoReferencia is None):
            print("╔══════════════════════════════╗")
            print("║ Digite o ponto de referência ║")
            print("╚══════════════════════════════╝")

            pontoReferencia = input("> ")

            if(pontoReferencia == ""):
                ErrorHandling.ThrowWarning("Ponto de referência não pode estar vazio")
                pontoReferencia = None
        
        # If the address is not been initialize yet
        if(client.enderecos is None):
            client.enderecos = []

        client.enderecos.append(AddressModel(rua, numero, complemento, bairro, cidade, cep, pontoReferencia))

        print("╔═════════════════════════════════╗")
        print("║ Endereço cadastrado com sucesso ║")
        print("╚═════════════════════════════════╝")