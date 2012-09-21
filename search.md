Search
==============

> Search API provides full text search on workspaces, comments, files, pages and tasks.

Resource Scope
--------------

* `GET /search?q=lion` will search for all 5 resources which has keyword `lion`.
* `GET /search?q=lion&resource=Workspace` will search for workspaces only.
* `GET /search?q=lion&resource=Workspace,File` will search for workspaces and files.

Possible values for `resource` are `Workspace`, `Comment`, `File`, `Page` and `Task`.

Response
--------

* Search API response would look like this:

```json
[
  {
    "type": "Workspace",
    "content": { ...workspace info }
  },
  {
    "type": "Page",
    "content": { ...page info }
  },
  {} ...more search results
]
```

`type` denotes the type of the content which can be `Workspace`, `Comment`, `File`, `Page` and `Task`.
`content` will be the exact same JSON representation of each resources described in this documentation.
For detail, see the 'GET' section of each resources.

Common Filter Options
--------------------

* `GET /search?page=2` to get next page of the search results. The search result will be paginated 30 items per page.
* `GET /search?order_by=updated_at+desc` will return sorted results by `updated_at` field of the results.
* `GET /search?order_by=created_at+desc` will return sorted results by `created_at` field of the results.
* `GET /search?updated_since=1997-08-14T15:39:07-07:00` will return resources updated after the given time.
* `GET /search?created_since=1984-08-14T15:39:07-07:00` will return resources created after the given time.

Resource Dependent Filter Options
--------------------

* When you specify the resource parameter as single resource like `GET /search?resource=File`, then more options will be available for a specific resource type. For example, following request will search for archived workspaces.

        GET /search?resource=Workspace&state=archived
        
        Above request is equal to
        
        GET /workspaces?state=archived

See each individual document to get more details on filter options.