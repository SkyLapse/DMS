import multiprocessing
import json
import os

__author__ = 'leobernard'


class BaseWorker():
    def __init__(self, config_path="../config/workers.json"):
        with open(os.path.dirname(__file__) + "/" + config_path) as data_file:
            data = json.load(data_file)

        self.pool = multiprocessing.Pool(data['maxWorkers'])
        self.config = data