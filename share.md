Share
========

Get shares
------------

* `GET /workspaces/1/shares` will return all the share holders with access to the workspace.

```json
[
  {
    "id": 6210,
    "type": "User",
    "is_owner": true,
    "created_at": "2012-09-18T18:11:40-07:00",
    "info":
    {
      "id": 1,
      "name": "Randy Jung",
      "email": "randyj@vispowertech.com",
      "team_id": 1,
      "team_name": "VispowerTech",
      "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png"
    }
  },
  {
    "id": 6213,
    "type": "Group",
    "is_owner": false,
    "created_at": "2012-09-18T19:08:53-07:00",
    "info":
    {
      "name": "abc group",
      "users_count": 3,
      "team_id": 1,
      "users":
      [
        {
          "id": 1,
          "name": "Randy Jung",
          "email": "randyj@vispowertech.com",
          "team_id": 1,
          "team_name": "VispowerTech",
          "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png"
        }
      ]
    }
  },
  {
    "id": 6214,
    "type": "Team",
    "is_owner": false,
    "created_at": "2012-09-18T19:08:58-07:00",
    "info":
    {
      "id": 1,
      "name": "VispowerTech",
      "host": "vti.teamplatform.com"
    }
  }
]
```

Above example returns 3 share objects which are the workspace's owner, one group with one user in it and a whole team.

A TeamPlatform's workspace can have many users and groups invited but can have only one invited team which should be workspace owner's team.

Create share
------------

* `POST /workspaces/1/shares` will grant access to the workspace for people via `emails`, `group_names` or `team_share`.

```json
{
  "emails": [ 'joe@example.com', 'john@example.com' ],
  "group_names": [ "marketing group", "engineering group" ],
  "team_share": true
}
```

This will return `200 Ok` with newly created shares if the share was created successfully. If the authenticated user does not have access to this workspace, `401 Not Authorized` will be returned.


Delete share
-------------

* `DELETE /workspaces/1/shares/1` will revoke the access of the share object which id is mentioned in the URL.

This will return `204 Ok` if the request was a success and the access was revoked. If the user does not have access to revoke access from the workspace or doesn't have access to the workspace, `403 Forbidden` will be returned.