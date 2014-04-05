__author__ = 'leobernard'
from model.basemodel import BaseModel
from datetime import datetime


class Categories(BaseModel):
    def get_collection(self):
        return self.db['categories']

    def get_default_scheme(self):
        return {
            "name": "Unnamed",
            "description": None,
            "parent": None,
            "createInfo": {
                "date": datetime.now(),
                "user": None
            },
            "editInfo": {
                "date": datetime.now(),
                "user": None
            }
        }