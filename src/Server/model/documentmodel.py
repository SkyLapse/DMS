__author__ = 'SkyLapse'
from model.basemodel import BaseModel
from datetime import datetime


class DocumentModel(BaseModel):
    def get_collection(self):
        return self.db['documents']

    def _populate(self, item):
        return {
            "name": item["name"],
            "documentPath": item["documentPath"],
            "thumbnailPath": item["thumbnailPath"],
            "size": item["size"],
            "mime": item["mime"],
            "createInfo": {
                "date": item["createInfo"]["date"],
                "user": item["createInfo"]["user"]
            },
            "editInfo": {
                "date": item["editInfo"]["date"],
                "user": item["editInfo"]["user"]
            },
            "content": item["content"],
            "category": item["category"],
            "tags": item["tags"],
            "buzzwords": item["buzzwords"],
            "customFields": item["customFields"]
        }