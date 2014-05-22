__author__ = 'SkyLapse'

# Import Models, Controllers, Workers
import model.base as modelbase
import workers.contentextractor
from controllers import CategoryController, DocumentController, PayloadController, ThumbnailController

# Import Flask and Extensions
from flask import Flask, request
from flask.ext import restful

# Import config
from app_utils import config_util

# Import logging tools
import logging
from logging.handlers import RotatingFileHandler


class DocularServer:
    app = Flask(__name__)
    api = restful.Api(app)

    def __init__(self):
        # Initialize logger
        logging_config = config_util.Config("./config/logging.json")
        log_formatter = logging.Formatter(logging_config["formatting"])
        handler1 = RotatingFileHandler(logging_config["logFileName"], maxBytes=logging_config["maxLogSize"], backupCount=logging_config["rollingLogFileCount"])
        handler2 = logging.StreamHandler()
        handler1.setFormatter(log_formatter)
        handler2.setFormatter(log_formatter)
        self.app.logger.addHandler(handler1)
        self.app.logger.addHandler(handler2)
        handler1.setLevel(logging_config["level"])
        handler2.setLevel(logging_config["level"])
        self.app.logger.setLevel(logging_config["level"])

        # Initialize the models and workers
        self.app.logger.info("Loading Models...")
        self.app.models = modelbase.Base(self.app.logger)
        self.app.logger.info("Loading Content Extractor...")
        self.app.content_extractor = workers.contentextractor.ContentExtractor()

        # Set routing for the API
        self.api.add_resource(DocumentController, "/api/documents", "/api/documents/<string:id>")
        self.api.add_resource(PayloadController, "/api/documents/<string:id>/payload")
        self.api.add_resource(ThumbnailController, "/api/documents/<string:id>/thumbnail")
        self.api.add_resource(CategoryController, "/api/categories", "/api/categories/<string:id>")

    def run(self):
        try:
            self.app.logger.info("Server starting up...")
            self.app.run(debug=True, host='0.0.0.0', port=5002)
            self.app.logger.info("Server started.")
        except (KeyboardInterrupt, SystemExit):
            self.stop()
        except Exception as ex:
            self.app.logger.exception(ex)
            self.stop(1)

    def stop(self, exit_code=0):
        func = request.environ.get('werkzeug.server.shutdown')
        if func is not None:
            func()
        exit(exit_code)

    @app.errorhandler(404)
    def serve_index(self, arg):
        return self.app.send_static_file('index.html')


server = DocularServer()
server.run()