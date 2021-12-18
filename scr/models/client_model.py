from datetime import date
from models.address_model import AddressModel
from typing import List

class ClientModel:
    nome: str
    login: str
    senha: str
    email: str
    data_nascimento: date
    tellNumb: str
    enderecos: List[AddressModel]

    def __init__(self, nome, login, senha, email, data_nascimento, tellNumb, endereco):
        self.nome = nome
        self.login = login
        self.senha = senha
        self.email = email
        self.data_nascimento = data_nascimento
        self.tellNumb = tellNumb
        self.enderecos = endereco