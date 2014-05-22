__author__ = 'SkyLapse'

from abc import abstractmethod
from flask import current_app
from flask.ext import restful

class BaseController(restful.Resource):
    def __init__(self):
        self.app = current_app
        pass

    @abstractmethod
    def get(self, id=None):
        pass