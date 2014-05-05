from bson import ObjectId
from flask import request

__author__ = 'leobernard'

from flask import Flask, request
from controllers.basecontroller import BaseController


class DocumentsController(BaseController):
    def get(self, id=None):
        if id is None:
            return self.format_output("documents", self.app.models.documents.get())
        else:
            return self.format_output("document", self.app.models.documents.get_single({"_id": ObjectId(id)}))

    def post(self, id=None):
        self.app.logger.info(request.data)
        res = self.app.models.documents.insert({})
        return self.format_output("status", res)

    def put(self, id=None):
        return None


class PayloadController(BaseController):
    def get(self, id):
        pass

    def post(self, id):
        pass

    def put(self, id):
        pass