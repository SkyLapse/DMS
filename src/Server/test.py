__author__ = 'leobernard'

from flask import Flask, request
from bson.json_util import dumps
import model.base as modelbase
import workers.contentextractor
import logging
from logging.handlers import RotatingFileHandler

app = Flask(__name__)

model = modelbase.Base()
content_extractor = workers.contentextractor.ContentExtractor()

@app.route('/')
def hello_world():
    return dumps(model.documents.get())


if __name__ == '__main__':
    handler = RotatingFileHandler('doculus_server.log')
    handler.setLevel(logging.INFO)
    app.logger.addHandler(handler)

    for i in range(1000):
        content_extractor.add_task("bla", "text/plain")

    app.run()

