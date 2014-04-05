__author__ = 'leobernard'
from model.basemodel import BaseModel


class Appkeys(BaseModel):
    def get_default_scheme(self):
        pass

    def get_collection(self):
        return self.db['appkeys']