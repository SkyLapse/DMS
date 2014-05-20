__author__ = 'leobernard'
from model.basemodel import BaseModel


class Users(BaseModel):
    def get_collection(self):
        return self.db['documents']

    def populate(self, item):
        return {}