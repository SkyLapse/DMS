import json
import os

__author__ = 'leobernard'


def loadConfig(file_name):
    with open(os.path.join(os.path.dirname(__file__), file_name)) as config_file:
        data = json.load(config_file)

    return


class Config():
    def __init__(self, data, file_name):
        self.data = data
        self.file_name = file_name
        self.is_locked = False

    def __getitem__(self, item):
        return self.data[item]

    def __setitem__(self, key, value):
        while self.is_locked:
            pass

        self.data[key] = value

        self.is_locked = True
        with open(os.path.join(os.path.dirname(__file__), self.file_name), 'w') as config_file:
            config_file.write(json.dumps(self.data, indent=4))