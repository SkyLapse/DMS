__author__ = 'SkyLapse'

from flask import Flask, request
from controllers.basecontroller import BaseController

from bson import ObjectId
from app_utils.bson_utils import convert_to_json

class DocumentController(BaseController):
    def get(self, id=None):
        return self.app.models.documents.get() if id is None else self.app.models.documents.get_single({"_id": ObjectId(id)})

    def post(self, id=None):
        self.app.logger.info(request.data)
        return self.app.models.documents.insert()

    def put(self, id=None):
        return None

