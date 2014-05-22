__author__ = 'SkyLapse'
from model.basemodel import BaseModel


class UserModel(BaseModel):
    def get_collection(self):
        return self.db['documents']

    def _populate(self, item):
        return { }