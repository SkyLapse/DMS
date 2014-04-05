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