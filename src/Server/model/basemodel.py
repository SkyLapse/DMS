from bson import DBRef
from pymongo.database import Database

__author__ = 'leobernard'

from abc import ABCMeta, abstractmethod


class BaseModel():
    __metaclass__ = ABCMeta

    def __init__(self, base, config, client, db):
        self.base = base
        self.config = config
        self.client = client
        self.db = db

    def get(self, spec=None, limit=0):
        return self.get_collection().find(spec, limit=limit)

    @abstractmethod
    def get_collection(self):
        pass

    def get_single(self, spec = None):
        return self.get_collection().find_one(spec)

    def insert(self, data):
        return self.get_collection().insert(self._populate(data))

    @abstractmethod
    def _populate(self, item):
        pass

    def update(self, spec, data):
        """ Updates datasets with a given
        :param spec:
        :param data:
        :return:
        """
        return self.get_collection().update(spec, self._populate(data))

    def resolve_object_ids(self, mongo_object):
        if mongo_object is None:
            return None

        if type(mongo_object) is "dict":
            result = { }
            for key in mongo_object:
                result[key] = self.resolve_object_ids(mongo_object[key]) if key is not "_id" else mongo_object[key]
            return result
        elif type(mongo_object) is "list":
            result = []
            for item in mongo_object:
                result.append(self.resolve_object_ids(item))
            return result
        elif type(mongo_object) is "bson.objectid.ObjectId":
            return self.get_single(mongo_object)
        elif type(mongo_object) is "bson.dbref.DBRef":
            return Database.dereference(mongo_object)
