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

    @abstractmethod
    def get_collection(self):
        pass

    @abstractmethod
    def get_default_scheme(self):
        pass

    def get(self, spec=None, limit=0):
        return self.get_collection().find(spec, limit=limit)

    def get_single(self, spec=None):
        return self.get_collection().find_one(spec)

    def insert(self, data):
        final = self.get_default_scheme()

        for index in data:
            final[index] = data[index]

        return self.get_collection().insert(final)

    def update(self, spec, data):
        """ Updates datasets with a given
        :param spec:
        :param data:
        :return:
        """
        final = self.get_default_scheme()

        for index in data:
            final[index] = data[index]

        return self.get_collection().update(spec, final)

    def resolve_object_ids(self, mongo_object):
        if mongo_object is None:
            return None

        if type(mongo_object) is "dict":
            result = {}
            for key in mongo_object:
                result[key] = self.resolve_object_ids(mongo_object[key]) if key is not "_id" else mongo_object[key]
            return result
        elif type(mongo_object) is "list":
            for item in mongo_object:
                yield self.resolve_object_ids(item)
        elif type(mongo_object) is "bson.objectid.ObjectId":
            return self.get_single(mongo_object)
        elif type(mongo_object) is "bson.dbref.DBRef":
            return Database.dereference(mongo_object)
