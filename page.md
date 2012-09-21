Pages
===============

> Workspace is the central place where things get organized. Page is another place where people can share data, ideas and more in a different way.

Get Pages
----------

`GET /pages` or `GET /workspaces/1/pages` to get all pages for an account or for a workspace. Server will return something that looks like this:

```json
[
  {
    "id": 1174,
    "title": "Collaboration Platform for Engineers.",
    
    "first_image": "https://d3hdmtlhbe6vzi.cloudfront.net/8633/1/thumbnails/6vav5l_s.jpg",
    "abstract": "<p>Even though so many online collaboration tools available out there, ...</p>",
    
    "workspace_id":913,
    "position":2,
    
    "share_mode":"public",
    "published_url":"http://vti.teamplatform.com:3000/p/1174/collaboration-platform-for-engineers",
    "expire_at":null,
    "password":null,
    "downloadable":true,
    
    "owner":{
      "team_name":"VispowerTech",
      "team_id":1,
      "email":"randyj@example.com",
      "name":"Randy Jung",
      "picture":"https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png",
      "id":1
    },
    
    "comments_count":0,
    "created_at":"2012-05-30T18:40:49-07:00",
    "updated_at":"2012-09-07T17:21:59-07:00"
  },
  {} ...more pages
]
```