__author__ = 'leobernard'
from model.basemodel import BaseModel


class Tags(BaseModel):
    def get_default_scheme(self):
        return {}

    def get_collection(self):
        return self.db['tags']

