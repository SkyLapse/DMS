import os

__author__ = 'leobernard'

from pymongo import MongoClient
import json
from model import *


class Base():
    def __init__(self, config_path="../config/db.json"):

        with open(os.path.dirname(__file__) + "/" + config_path) as data_file:
            data = json.load(data_file)

        self.config = data
        self.client = MongoClient(data['host'], data['port'], data['maxPoolSize'])
        self.db = self.client[data['database']]

        self.documents = Documents(self, self.config, self.client, self.db)
        self.categories = Categories(self, self.config, self.client, self.db)
        self.tags = Tags(self, self.config, self.client, self.db)
        self.users = Users(self, self.config, self.client, self.db)
        self.appkeys = Appkeys(self, self.config, self.client, self.db)