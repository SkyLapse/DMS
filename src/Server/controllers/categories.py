from bson import ObjectId

__author__ = 'leobernard'

from flask import Flask, request
from controllers.basecontroller import BaseController


class CategoriesController(BaseController):
    def get(self, id=None):
        if id is None:
            return self.format_output("categories", self.app.models.categories.get())
        else:
            return self.format_output("category", self.app.models.categories.get_single({"_id": ObjectId(id)}))

    def post(self, id=None):
        res = self.app.models.categories.insert({})
        return self.format_output("status", res)

    def put(self, id=None):
        return None