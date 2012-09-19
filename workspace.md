Workspaces
========

Get workspaces
------------

* `GET /workspaces` will return all workspaces.

```json
[
  {
    "id": 1434,
    "title": "My Workspace",
    "description": "TeamPlatform Rocks!",
    
    "status": "active",
    "is_template": false,
    
    "created_at": "2012-09-18T18:11:40-07:00",
    "updated_at": "2012-09-18T19:41:07-07:00",
    "deleted_at": null,
    
    "comments_count": 0,
    "files_count": 0,
    "pages_count": 0,
    "tasks_count": 0,
    "properties_count": 0,
    "members_count": 123,
    
    "root_folder_id": 9326,
    "labels": [
      {
        "name": "demo project",
        "style": "background-color:rgb(222, 229, 242);color:rgb(90, 105, 134);"
      }
    ],
    "owner": {
      "id": 1,
      "name": "Randy Jung",
      "email": "randyj@vispowertech.com",
      "team_name": "VispowerTech",
      "team_id": 1,
      "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png"
    }
  },
  {
    "id": 1435,
    "title": "Second Workspace",
    ...more info
  },
  {} ...more workspaces
]
```

More filtering options are available for `GET /workspaces`:

* `GET /workspaces?status=active` will return active workspaces.
* `GET /workspaces?status=archived` will return archived workspaces.
* `GET /workspaces?deleted=[true|false]` will return `deleted/not-deleted` workspaces.
* `GET /workspaces?starred=[true|false]` will return workspaces which were `starred/not-starred` by current user.
* `GET /workspaces?template=[true|false]` will return `template/normal` workspaces.
* `GET /workspaces?created_since=2012-09-18T18:11:40-07:00` will return workspaces which were created after given time.
* `GET /workspaces?updated_since=2012-09-18T18:11:40-07:00` will return workspaces which were updated after given time.
* `GET /workspaces?label_name=project` will return workspaces which were labeled as `project`.
* `GET /workspaces?owner_ids=1,2,9` will return workspaces which have owner's id of 1 or 2 or 9.
* `GET /workspaces?team_ids=1,2,3` will return workspaces which have owner's team's id of 1 or 2 or 3.
* `GET /workspaces?synced=true` will return workspaces which have been synced with users's desktop folders.
* `GET /workspaces?q=rabbit` will search for the workspaces which contain `rabbit` keyword. Given `q` parameter, TeamPlatform will perform a full text search on key informations like title, description, owner name, labels and custom properties.

Get Workspace
-----------

* `GET /workspaces/1` will return the specified single workspace with same data structure from `GET /workspaces`

```json
{
  "id": 1,
  "title": "My First Workspace",
  "description": "TeamPlatform Rules!",
  ...more info
}
```

Create Workspace
--------------

* `POST /workspaces` will create a new workspace from the parameters passed.

```json
{
  "title": "New workspace",
  "description": "Let's get to the details",
  "is_template": false
}
```

This will return `200 Ok`, with the current JSON representation of the workspace if the creation was a success.

Update Workspace
---------------

* `PUT /workspaces/1` will update the workspace from the parameters passed.

```json
{
  "title": "Changed workspace title",
  "description": "TeamPlatform.com Rocks!",
  "is_template": false,
  "status": "active"
}
```

This will return `200 OK` if the update was a success along with the current JSON representation of the workspace. If the user does not have access to update the workspace, you'll see `403 Forbidden`.

Archiving/Activating a workspace
------------------------------

* `PUT /workspaces/1` with the following JSON will archive a workspace. Passing "active" will re-activate the workspace.

```json
{
  "status": "archived"
}
```

Delete/Undelete/Purge workspace
-------------

* `DELETE /workspaces/1` will delete the workspace specified and return `200 Ok` if that was successful. If the user does not have access to delete the workspace, you'll see `403 Forbidden`.

* `PUT /workspaces/1` with the following JSON(with blank `deleted_at` parameter) will undelete the workspace and return `200 Ok` if that was successful. If the user does not have access to undelete the workspace, you'll see `403 Forbidden`.

```json
{
  "deleted_at": ""
}
```

* `DELETE /workspaces/1?purge=true` will permanently delete the workspace and return `204 No Content` if that was successful. If the user does not have access to purge the workspace, you'll see `403 Forbidden`.