__author__ = 'leobernard'

import multiprocessing
import json
import os


class BaseWorker():
    def __init__(self, config_path="../config/workers.json"):
        with open(os.path.dirname(__file__) + "/" + config_path) as data_file:
            data = json.load(data_file)

        self.pool = multiprocessing.Pool(multiprocessing.cpu_count() * data['maxWorkersPerCore'])
        self.config = data