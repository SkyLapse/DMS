__author__ = 'leobernard'

from model.basemodel import BaseModel


class AppKeyModel(BaseModel):
    def get_collection(self):
        return self.db['appkeys']

    def populate(self, item):
        return { }