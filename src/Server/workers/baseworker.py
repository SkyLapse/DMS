__author__ = 'SkyLapse'

from app_utils import config_util
import multiprocessing

class BaseWorker():
    def __init__(self, config_path = "../config/workers.json"):
        self.config = config_util.Config(config_path)
        self.pool = multiprocessing.Pool(multiprocessing.cpu_count() * self.config['maxWorkersPerCore'])