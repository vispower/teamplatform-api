Tasks
=================

> User can schedule, reorder, group and trigger tasks.

Get Tasks
-------------------

* `GET /workspaces/1/tasks` to get tasks in workspace 1, `GET /tasks` to get all tasks for the current user. Server response will look like this:

```json
[
  {
    "id": 2349,
    "description": "Get the documentation done for API.",
    "details": "in markdown",
    "due": null,
    
    "workspace_id": 1127,
    
    "position": 1,
    "ancestry": null,
    "trigger_id": null,
    
    "state": "created",
    "started_at": null,
    "finished_at": null,
    "change_status": null,
    
    "created_at": "2011-06-14T12:33:30-07:00",
    "updated_at": "2012-08-14T15:39:07-07:00",
    
    "assigner": {
      "id": 1,
      "name": "Randy Jung",
      "email": "randyj@example.com",
      "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png",
      "team_id": 1,
      "team_name": "VispowerTech"
    },
    "assignee": { ...user info }
  },
  {} ...more tasks
]
```

Server will respond `200 Ok` with all tasks in a workspace for `GET /workspaces/1/tasks`. Server returns all accessible tasks when request goes to `GET /tasks`. Tasks will be returned sorted by workspace and then position.

`ancestry` is the slash(`/`) separated list of parent tasks. For example, `ancestry` value of `1/2/3` means the task is sub task of task 3, task 3 is the sub task of task 2, and so on.

`trigger_id` id of the task which can trigger current task to start when trigger task is completed.
Task has three `state`s that are `created`, `started` and `finished`.

`change_status` indicates workspace will be archived when this task is finished if the value was set to `finished`.

More filtering options are available for `GET /tasks` and `GET /workspaces/1/tasks`:

* `GET /tasks?created_since=2012-09-18T18:11:40-07:00` will return tasks which were created after given time.
* `GET /tasks?updated_since=2012-09-18T18:11:40-07:00` will return tasks which were updated after given time.
* `GET /tasks?workspace_id=1` will return tasks in workspace 1.
* `GET /tasks?assigner_ids=1,2,9` will return tasks which was created by user 1 or 2 or 9.
* `GET /tasks?assignee_ids=1,2,9` will return tasks which was assigned to user 1 or 2 or 9.
* `GET /tasks?state=[created|started|finished]` will return tasks in the state.
* `GET /tasks?due_by=2011-06-14T12:33:30-07:00` will return tasks which have due record before given time.
* `GET /tasks?q=rabbit` will search for the tasks which contain `rabbit` keyword.

Get Task
----------------

* `GET /tasks/1` or `GET /workspaces/1/tasks/1` will return single task.

Create Task
------------------

* `POST /workspaces/1/tasks` to create a new task. `POST /tasks` is not valid end point to create a new task. JSON would look like this:

```json
{
  "description": "Finishing API documentation",
  "details": "find out where to explain about pagination",
  "state": "created",
  "assignee_id": 1,
  "due": "2022-08-14T15:39:07-07:00",
  "trigger_id": "",
  "position": 4,
  "change_status": ""
}
```

Server will respond `200 Ok` for successful creation, `403 Forbidden` for in-accessible tasks.

Update Task
-------------------------

* `PUT /workspaces/1/tasks/1` to update a task. `PUT /tasks/1` is not allowed.

```json
{
  "description": "Finishing API documentation",
  "details": "find out where to explain about pagination",
  "state": "finished",
  "assignee_id": 1,
  "due": "2022-08-14T15:39:07-07:00",
  "trigger_id": "",
  "position": 4,
  "change_status": ""
}
```

Above JSON example will change the state to `finished`. Server will respond `200 Ok` with updated JSON.

Delete Task
---------------------

* `DELETE /workspaces/1/tasks/1` will delete the task. `DELETE /tasks/1` is not valid end point.

Server will respond `204 No Content` if successful.