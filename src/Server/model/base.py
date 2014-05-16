import os

__author__ = 'leobernard'

from pymongo import MongoClient, errors
import json
from model import *


class Base():
    def __init__(self, logger, config_path="../config/db.json"):

        with open(os.path.join(os.path.dirname(__file__), config_path)) as config_file:
            config = json.load(config_file)

        try:
            self.config = config
            self.client = MongoClient(config['host'], config['port'], config['maxPoolSize'])
            self.db = self.client[config['database']]
        except errors.ConnectionFailure:
            logger.critical("Could not connect to the MongoDB server at %s:%s" %
                            (config['host'], config['port']))
            exit(1)
        else:
            self.documents = Documents(self, self.config, self.client, self.db)
            self.categories = Categories(self, self.config, self.client, self.db)
            self.tags = Tags(self, self.config, self.client, self.db)
            self.users = Users(self, self.config, self.client, self.db)
            self.appkeys = Appkeys(self, self.config, self.client, self.db)