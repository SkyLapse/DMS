__author__ = 'leobernard'

import multiprocessing
import json
import os


class BaseWorker():
    def __init__(self, config_path="../config/workers.json"):
        with open(os.path.join(os.path.dirname(__file__), config_path)) as config_file:
            config = json.load(config_file)

        self.pool = multiprocessing.Pool(multiprocessing.cpu_count() * config['maxWorkersPerCore'])
        self.config = config