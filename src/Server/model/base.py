import os

__author__ = 'leobernard'

from app_utils import config_util
from model import *
from pymongo import MongoClient, errors


class Base():
    def __init__(self, logger, config_path = "../config/db.json"):
        try:
            self.config = config_util.Config(config_path)
            self.client = MongoClient(self.config['host'], self.config['port'], self.config['maxPoolSize'])
            self.db = self.client[self.config['database']]
        except errors.ConnectionFailure:
            logger.critical("Could not connect to the MongoDB server at %s:%s" % (self.config['host'], self.config['port']))
            exit(1)
        else:
            self.documents = DocumentModel(self, self.config, self.client, self.db)
            self.categories = CategoryModel(self, self.config, self.client, self.db)
            self.tags = TagModel(self, self.config, self.client, self.db)
            self.users = UserModel(self, self.config, self.client, self.db)
            self.appkeys = AppKeyModel(self, self.config, self.client, self.db)