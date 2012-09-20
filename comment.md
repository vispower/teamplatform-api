Comments
========

Get Comments and Replies
------------------------

Comments API has a few different kinds of end point such as `GET /comments` or `GET /<commentable>/<commentable_id>/comments`.
Commenting can be made for workspaces, files and pages. Complete set of end points are:
        
        GET /comments to get all accessible comments.
        GET /workspaces/1/comments to get comments for the workspace 1.
        GET /workspaces/1/files/1/comments to get comments for the file 1 under the workspace 1.
        GET /workspaces/1/pages/1/comments to get comments for the page 1 under the workspace 1.
        GET /files/1/comments to get comments for the file 1 without knowing the workspace id.
        GET /pages/1/comments to get comments for the page 1 without knowing the workspace id.

* `GET /comments`

To get all the comments accessible by you, call `GET /comments` and resulting JSON response will look like this:

```json
[
  {
    "id": 1748,
    "commented_on": "workspace_1",
    "created_at": "2012-09-17T18:33:47-07:00",
    "comment": "This comment is left on workspace_1!",
    "owner": {
      "id": 1,
      "name": "Randy Jung",
      "email": "randyj@example.com@vispowertech.com",
      "team_id": 1,
      "team_name": "VispowerTech",
      "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png"
    }
  },
  ...more comments
]
```

This call returns all the comments and replies in JSON array.
Each comment has the `commented_on` key pointing to the resource which the comment was written for.
`workspace_1` means that this comment was written for the workspace which id is 1.

* `GET /workspaces/1/comments`

Instead of requesting all the comments and replies, you can see all comments for a given workspace. You'd call `GET /workspaces/1/comments` and response will look like this:

```json
[
  {
    "id": 1748,
    "commented_on": "workspace_1",
    "created_at": "2012-09-17T18:33:47-07:00",
    "comment": "This comment is left on workspace_1!",
    "owner": {
      ...owner info
    },
    "comments": [
      {
        "id": 1750,
        "commented_on": "comment_1748",
        "created_at": "2012-09-19T17:02:34-07:00",
        "comment": "This is reply left on comment_1748 !",
        "owner": {
          ...owner info
        },
      }
    ]
  }
]
```

Call to `GET /workspaces/1/comments` will return all the comments written for the workspace, files and pages in the workspace.
Each comment will have `comments` which contains all the replies written for the comment( different from `GET /comments` ).

More filtering options are available:

* `GET /comments?commented_on_type=Workspace` will return comments written for a workspace. Other parameters can be `File`, `Page` or `Comment` to get replies only.
* `GET /comments?commented_on_type=File&commented_on_ids=1,2,3` will return comments written for files which id is 1, 2 or 3. `commented_on_ids` parameter will only work with `commented_on_type` parameter present.
* `GET /comments?created_since=2012-09-18T18:11:40-07:00` will return comments which were created after given time.
* `GET /comments?updated_since=2012-09-18T18:11:40-07:00` will return comments which were updated after given time.
* `GET /comments?owner_ids=1,2,9` will return comments which have owner's id of 1 or 2 or 9.
* `GET /comments?q=rabbit` will search for the comments which contain `rabbit` as a keyword. Given `q` parameter, TeamPlatform will perform a full text search on comment.

Create Comment
--------------

* `POST /<commentable>/<commentable_id>/comments` will create a new comment from the parameters passed for the `<commentable>` which id is `<commentable_id>`. More elaborate examples are:
  
        POST /workspaces/1/comments to create comment for the workspace 1.
        POST /workspaces/1/files/1/comments to create comment for the file 1 under the workspace 1.
        POST /workspaces/1/pages/1/comments to create comment for the page 1 under the workspace 1.
        POST /files/1/comments to create comment for the file 1 without knowing the workspace id.
        POST /pages/1/comments to create comment for the page 1 without knowing the workspace id.
        
```json
{
  "comment": "I'm trying to explain how to create a comment for a workspace...but"
}
```

This will return `200 Ok`, with a representation of the comment just created in the response body if the creation was a success.
`<commentable>` can not be comments itself. So, `POST /comments` is not allowed and will return `400 Bad Request`.
If the commentable is not editable by you, server will respond with `403 Forbidden`
  
Create Reply
--------------

* `POST /workspaces/1/comments` will create a new reply from the parameters passed. Set `reply_to` to the id of the comment which the reply would be attached to. The same API end points rule will also apply to this case.

```json
{
  "reply_to": 1023,
  "comment": "I'm trying to explain how to create a reply for a workspace comment...but"
}
```

Delete Comment
-------------

* `DELETE /workspaces/1/comments/1` will delete the comment specified and return `204 No Content` if that was successful. If the user does not have access to delete the comment, you'll see `403 Forbidden`. The same API end points rule will also apply to this case, so `DELETE /comments/1` is not allowed.