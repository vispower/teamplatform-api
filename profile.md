Profile
======

> Every user account belongs to one primary team.

Get Profile
----------

* `GET /profile` will return the profile of the current user who authorized your app.

```json
{
  "id": 1,
  "name": "Randy Jung",
  "email": "randyj@example.com@vispowertech.com",
  "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png",
  "team_id": 1,
  "team_name": "VispowerTech"
}
```

Your app can then manage its own user information based on this result. `id` is the user identifier which is unique across the all users of TeamPlatform.com.

Invite new user
-------------

New user can be invited directly to workspaces via the [Share API](https://github.com/vispower/teamplatform-api/blob/master/share.md).