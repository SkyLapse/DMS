__author__ = 'leobernard'

import base64
import calendar
import datetime

from bson.binary import Binary
from bson.code import Code
from bson.dbref import DBRef
from bson.max_key import MaxKey
from bson.min_key import MinKey
from bson.objectid import ObjectId
from bson.timestamp import Timestamp
from bson.py3compat import string_types


def convert_to_json(bson):
    if hasattr(bson, 'iteritems') or hasattr(bson, 'items'):  # PY3 support
        return dict(((k, convert_to_json(v)) for k, v in bson.iteritems()))
    elif hasattr(bson, '__iter__') and not isinstance(bson, string_types):
        return list((convert_to_json(v) for v in bson))
    try:
        return customBSON(bson)
    except TypeError:
        return bson


def customBSON(obj):
    if isinstance(obj, ObjectId):
        return str(obj)
    if isinstance(obj, DBRef):
        return convert_to_json(obj.as_doc())
    if isinstance(obj, datetime.datetime):
        if obj.utcoffset() is not None:
            obj = obj - obj.utcoffset()

        return obj.isoformat()
    if isinstance(obj, MinKey) or isinstance(obj, MaxKey):
        return 1
    if isinstance(obj, Timestamp):
        return {"t": obj.time, "i": obj.inc}
    if isinstance(obj, Code):
        return {'$code': "%s" % obj, '$scope': obj.scope}
    if isinstance(obj, Binary):
        return {'$binary': base64.b64encode(obj).decode(),
                '$type': "%02x" % obj.subtype}
    raise TypeError("%r is not JSON serializable" % obj)