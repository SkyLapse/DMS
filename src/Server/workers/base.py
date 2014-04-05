from Queue import Queue
import json
import os

from workers.worker import Worker

__author__ = 'leobernard'


class WorkerManager():
    def __init__(self, config_path="../config/workers.json"):
        with open(os.path.dirname(__file__) + "/" + config_path) as data_file:
            data = json.load(data_file)

        self.config = data
        self.queue = Queue()
        self.workers = []

    def initialize_workers(self, app):
        for i in range(0, self.config['maxWorkers']):
            worker = Worker(self.queue, i, app)
            worker.start()
            self.workers.append(worker)

    def add_task(self, task):
        """
        Adds a task to the worker's queue
        :param task: The task that will be added to the queue
        :return:None
        """
        self.queue.put(task)