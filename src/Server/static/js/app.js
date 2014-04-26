App = Ember.Application.create();

App.Router.map(function() {
    this.route("search");
    this.resource("documents", function(){
        this.resource("document", {path: ":id"});
    });
    this.route("categories");
    this.route("tags");
    this.route("settings");
});

App.IndexRoute = Ember.Route.extend({
  model: function() {
    return ['red', 'yellow', 'blue'];
  }
});

App.DocumentsRoute = Ember.Route.extend({
    model: function(){
        return documents;
    }
});

var documents = new Array(50);

for(var i = 0; i < documents.length; i++){
    documents[i] = {
        id: i+1,
        name: "Super long Document title that's hard to read " + (i+1),
        date: "8 days ago",
        type: "PDF",
        preview: "http://lorempixel.com/120/120/city/" + (i+1),
        image: "http://lorempixel.com/1200/1200/city/" + (i+1) + "/Document" + (i+1)
    }
}