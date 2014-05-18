__author__ = 'leobernard'

from abc import abstractmethod
from app_utils.bson_utils import convert_to_json
from flask import Flask, request, make_response, current_app, Response
from flask.ext import restful

class BaseController(restful.Resource):
    def __init__(self):
        self.app = current_app
        pass

    def bson_to_json(self, bson):
        return convert_to_json(bson)

    @abstractmethod
    def get(self, id=None):
        pass