__author__ = 'leobernard'
from model.basemodel import BaseModel
from datetime import datetime


class CategoryModel(BaseModel):
    def get_collection(self):
        return self.db['categories']

    def populate(self, item):
        return {
            "name": item["name"],
            "description": item["description"],
            "parent": item["parent"],
            "createInfo": {
                "date": item["createInfo"]["date"],
                "user": item["createInfo"]["user"]
            },
            "editInfo": {
                "date": item["editInfo"]["date"],
                "user": item["editInfo"]["user"]
            },
            "customFields": item["customFields"]
        }