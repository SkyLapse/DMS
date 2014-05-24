__author__ = 'SkyLapse'

from model.basemodel import BaseModel


class ApiKeyModel(BaseModel):
    def get_collection(self):
        return self.db['apikeys']

    def _populate(self, item):
        return {
            "key": item["key"],
            "machineName": item["machineName"],
            "user": item["user"]
        }