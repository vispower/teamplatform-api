The TeamPlatform API V1
====================

> Your Collaboration Portal in Minutes.

The [TeamPlatform.com](https://teamplatform.com) API is now available for all users. TeamPlatform API is a RESTful API that uses JSON for serialization and OAuth 2 for authentication.

Making Requests
----------------

All API requests URLs start with `https://teamplatform.com/api/v1/`. Requests should be SSL. The path is prefixed with the API version. 

To make a request to get all the workspaces on your account, you'd append the workspaces index path to the base url to form something like `https://teamplatform.com/api/v1/workspaces`. Curl example looks like:

```shell
curl -H 'Authorization: OAuth your_access_token' https://teamplatform.com/api/v1/workspaces
```

To create a workspace, you have to POST with `Content-Type` header and the JSON data:

```shell
curl -H 'Content-Type: application/json' \
     -H 'Authorization: OAuth your_access_token' \
     -d '{ "title": "New Workspace", "description": "Cool Project!" }' \
     https://teamplatform.com/api/v1/workspaces
```

To learn more about OAuth access_token, see [Authentication Section](https://github.com/vispower/teamplatform-api/blob/master/authentication.md).

Authentication
--------------

TeamPlatform authenticates end users using OAuth 2 only (No basic auth available). This allows users to authorize your application to use TeamPlatform on their behalf without having to copy/paste API tokens or touch sensitive login info.

JSON Responses
-----------------

We only support JSON for serialization of data. Our format is to have no root element and we use snake\_case to describe attribute keys. This means that you have to send `Content-Type: application/json; charset=utf-8` when you're POSTing or PUTing data into TeamPlatform.

Handling errors
---------------

If TeamPlatform is having trouble, you might see a 5xx error. `500` means that TeamPlatform failed fulfilling the request, but you might also see `502 Bad Gateway`, `503 Service Unavailable`, or `504 Gateway Timeout`. It's your responsibility in all of these cases to retry your request later.

API ready for use
-----------------

* [Authentication](https://github.com/vispower/teamplatform-api/blob/master/authentication.md)
* [Profile](https://github.com/vispower/teamplatform-api/blob/master/profile.md)
* [Workspace](https://github.com/vispower/teamplatform-api/blob/master/workspace.md)
* [Comment](https://github.com/vispower/teamplatform-api/blob/master/comment.md)
* [File](https://github.com/vispower/teamplatform-api/blob/master/file.md)
* [Page](https://github.com/vispower/teamplatform-api/blob/master/page.md)
* [Task](https://github.com/vispower/teamplatform-api/blob/master/task.md)
* [Property](https://github.com/vispower/teamplatform-api/blob/master/property.md)
* [Share](https://github.com/vispower/teamplatform-api/blob/master/share.md)
* [Search](https://github.com/vispower/teamplatform-api/blob/master/search.md)

Help us make it better
----------------------

Please tell us how we can make the API better. If you have a specific feature request or if you found a bug, please use GitHub issues.

This documentation is inspired by 37signals's [bcx-api](https://github.com/37signals/bcx-api)