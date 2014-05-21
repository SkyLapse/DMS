import time
from workers.baseworker import BaseWorker

__author__ = 'leobernard'


def run(file_path, file_type):
    print("Hi")
    time.sleep(2)
    print(file_path)
    print(file_type)
    pass


class ContentExtractor(BaseWorker):
    def add_task(self, file_path, file_type):
        self.pool.apply_async(run, [file_path, file_type])