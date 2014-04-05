__author__ = 'leobernard'

from flask import Flask, request
from bson.json_util import dumps
import model.base as modelbase
import workers.base as workersbase
import logging
from logging.handlers import RotatingFileHandler

app = Flask(__name__)

model = modelbase.Base()
workers = workersbase.WorkerManager()

@app.route('/')
def hello_world():
    return dumps(model.documents.get())


if __name__ == '__main__':
    handler = RotatingFileHandler('doculus_server.log')
    handler.setLevel(logging.INFO)
    app.logger.addHandler(handler)

    app.run()

    workers.initialize_workers(app)