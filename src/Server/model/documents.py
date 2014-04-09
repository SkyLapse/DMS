__author__ = 'leobernard'
from model.basemodel import BaseModel
from datetime import datetime


class Documents(BaseModel):
    def get_collection(self):
        return self.db['documents']

    def get_default_scheme(self):
        return {
            "name": "Unnamed",
            "documentPath": None,
            "thumbnailPath": None,
            "size": 0,
            "mime": None,
            "createInfo": {
                "date": datetime.now(),
                "user": None
            },
            "editInfo": {
                "date": datetime.now(),
                "user": None
            },
            "content": "",
            "category": None,
            "tags": [],
            "buzzwords": [],
            "customFields": []
        }