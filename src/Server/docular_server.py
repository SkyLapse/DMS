__author__ = 'leobernard'

# Import Flask and Extensions
from flask import Flask
from flask.ext import restful

# Import Models, Controllers, Workers
import model.base as modelbase
from controllers.documents import DocumentsController, PayloadController
from controllers.categories import CategoriesController
import workers.contentextractor

# Import logging tools
import logging
from logging.handlers import RotatingFileHandler

# Initialize the Flask app and RESTful API
app = Flask(__name__)
api = restful.Api(app)

# Initialize logger
log_formatter = logging.Formatter("[%(asctime)s] [%(filename)s:%(lineno)d] [%(levelname)s] %(message)s")
handler1 = RotatingFileHandler('docular_server.log', maxBytes=10000, backupCount=1)
handler2 = logging.StreamHandler()
handler1.setFormatter(log_formatter)
handler2.setFormatter(log_formatter)
app.logger.addHandler(handler1)
app.logger.addHandler(handler2)
handler1.setLevel(logging.DEBUG)
handler2.setLevel(logging.DEBUG)
app.logger.setLevel(logging.DEBUG)

# Initialize the models and workers
app.logger.info("Loading Models...")
app.models = modelbase.Base(app.logger)
app.logger.info("Loading Content Extractor...")
app.content_extractor = workers.contentextractor.ContentExtractor()

# Set routing for the API
api.add_resource(DocumentsController, "/api/documents", "/api/documents/<string:id>")
api.add_resource(PayloadController, "/api/documents/<string:id>/payload", "/api/documents/<string:id>/thumbnail")
api.add_resource(CategoriesController, "/api/categories", "/api/categories/<string:id>")

# Set the index page
@app.errorhandler(404)
def serve_index(arg):
    return app.send_static_file('index.html')

try:
    # Start the HTTP server
    if __name__ == '__main__':
        app.logger.info("Server is up and running...")
        app.run(debug=True, host='0.0.0.0', port=5002)
except KeyboardInterrupt:
    pass
except Exception as ex:
    app.logger.exception(ex)
