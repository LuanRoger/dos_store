from controllers.client_controller import ClientController
from models.client_model import ClientModel
from models.address_model import AddressModel
from util.error_handling import ErrorHandling

#static
class AddressController:
    def RegisterAddressToClient(self, clientController: ClientController):
        actualClient: ClientModel = clientController.GetClientByLoginUi()

        if(actualClient == None):
            return
        
        self._RegisterClientAddress(actualClient)

    def _RegisterClientAddress(self, client: ClientModel):
        rua: str = None
        numero: str = None
        complemento: str = None
        bairro: str = None
        cidade: str = None
        cep: str = None
        pontoReferencia: str = None

        while(rua == None):
            print("╔════════════════╗")
            print("║ Digite sua rua ║")
            print("╚════════════════╝")

            rua = input("> ")
        
        while(numero == None):
            print("╔═════════════════════════════╗")
            print("║ Digite o numero da sua casa ║")
            print("╚═════════════════════════════╝")

            numero = input("> ")

            if(len(numero) != 4):
                ErrorHandling.ThrowWarning("Digite um valor válido.")
                numero = None
        
        while(complemento == None):
            print("╔══════════════════════╗")
            print("║ Digite o complemento ║")
            print("╚══════════════════════╝")

            complemento = input("> ")
        
        while(bairro == None):
            print("╔═════════════════════════╗")
            print("║ Digite o nome do bairro ║")
            print("╚═════════════════════════╝")

            bairro = input("> ")
        
        while(cidade == None):
            print("╔═════════════════════════╗")
            print("║ Digite o nome da cidade ║")
            print("╚═════════════════════════╝")

            cidade = input("> ")
        
        while(cep == None):
            print("╔══════════════╗")
            print("║ Digite o CEP ║")
            print("╚══════════════╝")

            cep = input("> ")

            if(len(cep) != 8):
                ErrorHandling.ThrowWarning("O valor digitado é inválido")
        
        while(pontoReferencia == None):
            print("╔══════════════════════════════╗")
            print("║ Digite o ponto de referência ║")
            print("╚══════════════════════════════╝")

            pontoReferencia = input("> ")
        
        client.endereco = AddressModel(rua, numero, complemento, bairro, cidade, cep, pontoReferencia)

        print("╔═════════════════════════════════╗")
        print("║ Endereço cadastrado com sucesso ║")
        print("╚═════════════════════════════════╝")