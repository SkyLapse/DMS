__author__ = 'leobernard'

from flask import Flask, request, make_response, current_app, Response
from flask.ext import restful
from app_utils.bson_utils import convert_to_json


class BaseController(restful.Resource):
    def __init__(self):
        self.app = current_app
        pass

    def bson_to_json(self, bson):
        self.app.logger.debug("Parsing BSON object to JSON...")
        res = convert_to_json(bson)
        self.app.logger.debug("Result: " + str(res))
        return res

    def format_output(self, name, bson, wrap=None):
        obj = self.bson_to_json(bson)

        if wrap is None:
            wrap = True if request.args.get("nowrap") is None else False

        if hasattr(bson, "count"):
            resp = ({name: obj, "status": {"count": bson.count()}} if wrap else obj)
        else:
            resp = ({name: obj} if wrap else obj)

        return resp