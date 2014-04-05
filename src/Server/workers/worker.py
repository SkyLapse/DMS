from threading import Thread

__author__ = 'leobernard'


class Worker(Thread):
    def __init__(self, queue, id, app):
        super(Worker, self).__init__()
        self.queue = queue
        self.app = app
        self.id = id + 1
        self.living = True

    def kill(self):
        self.living = False
        self.app.logger.info("Worker %s will be killed when the task is finished.", self.id)

    def run(self):
        self.app.logger.info("Worker %s started.", self.id)
        print "Worker %s started" % self.id

        while True:
            if not self.living:
                self.app.logger.info("Worker %s will now stop.")
                break

            if not self.queue.empty():
                task = self.queue.get()
                task.run()