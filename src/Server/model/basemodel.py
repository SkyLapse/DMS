__author__ = 'leobernard'

from abc import ABCMeta, abstractmethod
from pymongo import database


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

    def resolve_object_ids(self, object):
        if object is None:
            return None

        if type(object) is "dict":
            result = {}
            for key in object:
                result[key] = self.resolve_object_ids(object[key]) if key is not "_id" else object[key]
            return result
        elif type(object) is "list":
            collection = list()
            for item in object:
                collection.append(self.resolve_object_ids(item))
            return collection
        elif type(object) is "bson.objectid.ObjectId":
            return object.to_mongo()
