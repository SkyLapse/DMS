from bson import ObjectId

__author__ = 'leobernard'

from controllers.basecontroller import BaseController


class CategoriesController(BaseController):
    def get(self, id=None):
        if id is None:
            return self.bson_to_json(self.app.models.categories.get())
        else:
            return self.bson_to_json(self.app.models.categories.get_single({"_id": ObjectId(id)}))

    def post(self, id=None):
        return self.bson_to_json(self.app.models.categories.insert({}))

    def put(self, id=None):
        return None