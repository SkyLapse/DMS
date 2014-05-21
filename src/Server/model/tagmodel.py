__author__ = 'leobernard'
from model.basemodel import BaseModel


class TagModel(BaseModel):
    def get_collection(self):
        return self.db['tags']

    def _populate(self, item):
        return {
            "name": item["name"],
            "description": item["description"],
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