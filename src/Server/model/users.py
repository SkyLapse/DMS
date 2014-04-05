__author__ = 'leobernard'
from model.basemodel import BaseModel


class Users(BaseModel):
    def get_default_scheme(self):
        return {
            "username": None,
            "mail": None,
            "password": None,
            "rights": {

            },

        }

    def get_collection(self):
        return self.db['documents']