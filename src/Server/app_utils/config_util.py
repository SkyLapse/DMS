import json
import os
import threading

__author__ = 'SkyLapse'


class Config():
    def __init__(self, file_name, data=None):
        self.file_name = file_name
        self.lock = threading.RLock()
        if data is None:
            with open(os.path.join(os.path.dirname(__file__), file_name)) as config_file:
                self.data = json.load(config_file)
        else:
            self.data = data

    def get(self, item):
        return self.__getitem__(item)

    def set(self, key, value):
        return self.__setitem__(key, value)

    def __getitem__(self, item):
        return self.data[item]

    def __setitem__(self, key, value):
        with self.lock:
            self.data[key] = value
            with open(os.path.join(os.path.dirname(__file__), self.file_name), 'w') as config_file:
                config_file.write(json.dumps(self.data, indent=4))