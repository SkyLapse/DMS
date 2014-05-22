from bson import ObjectId

__author__ = 'SkyLapse'

from controllers.basecontroller import BaseController
from app_utils.bson_utils import convert_to_json

class CategoryController(BaseController):
    def get(self, id=None):
        if id is None:
            return convert_to_json(self.app.models.categories.get())
        else:
            return convert_to_json(self.app.models.categories.get_single({"_id": ObjectId(id)}))

    def post(self, id=None):
        return convert_to_json(self.app.models.categories.insert({}))

    def put(self, id=None):
        return None