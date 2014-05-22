__author__ = 'SkyLapse'

from model.basemodel import BaseModel


class AppKeyModel(BaseModel):
    def get_collection(self):
        return self.db['appkeys']

    def _populate(self, item):
        return {
            "key": item["key"],
            "machineName": item["machineName"],
            "user": item["user"]
        }