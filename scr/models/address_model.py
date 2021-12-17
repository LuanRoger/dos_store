class AddressModel:
    rua: str
    numero: str
    complemento: str
    bairro: str
    cidade: str
    cep: str
    pontoReferencia: str

    def __init__(self, rua, numero, complemento, bairro, cidade, cep, pontoReferencia):
        self.rua = rua
        self.numero = numero
        self.complemento = complemento
        self.bairro = bairro
        self.cidade = cidade
        self.cep = cep
        self.pontoReferencia = pontoReferencia