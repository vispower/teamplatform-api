Pages
===============

> Workspace is the central place where things get organized. Page is another place where people can share data, ideas and more in a different way.

Get Pages
----------

* `GET /pages` or `GET /workspaces/1/pages` to get all pages for an account or for a workspace. Server will return something that looks like this:

```json
[
  {
    "id": 1174,
    "title": "Collaboration Platform for Engineers.",
    "first_image": "https://d3hdmtlhbe6vzi.cloudfront.net/8633/1/thumbnails/6vav5l_s.jpg",
    "abstract": "<p>Even though so many online collaboration tools available out there, ...</p>",
    
    "workspace_id": 913,
    "position": 2,
    
    "share_mode": "public",
    "published_url": "http://vti.teamplatform.com:3000/p/1174/collaboration-platform-for-engineers",
    "expire_at": null,
    "password": null,
    "downloadable": true,
    
    "owner":{
      "team_name": "VispowerTech",
      "team_id": 1,
      "email": "randyj@example.com",
      "name": "Randy Jung",
      "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png",
      "id": 1
    },
    
    "comments_count": 0,
    "created_at": "2012-05-30T18:40:49-07:00",
    "updated_at": "2012-09-07T17:21:59-07:00"
  },
  {} ...more pages
]
```

Server will respond `200 Ok` with JSON representation of the pages which user has access to.

`first_image` is the url of the first image thumbnail in small size appearing in the page. It can be a image inserted in Note or File widget. `abstract` is the first paragraph that appears in the page from page item's content.

`share_mode` denotes the page's share status that can be:
* `private` - not shared. only workspace members can access,
* `anyone` - anyone who has the link can access without login
* `public` - public page that anyone can access and be indexed by search engine.

If a page has share_mode of `anyone` and `public`, `published_url` tells the url.
If a page has share_mode of `anyone`, `expire_at` and `password` options will be available if set.

More filtering options are available for `GET /pages`:

* `GET /pages?page=2` to get the page two of results. The result will be paginated 30 items per page.
* `GET /pages?order_by=updated_at+desc` will return sorted results by `updated_at` field.
* `GET /pages?order_by=created_at+desc` will return sorted results by `created_at` field.
* `GET /pages?created_since=2012-09-18T18:11:40-07:00` will return pages which were created after given time.
* `GET /pages?updated_since=2012-09-18T18:11:40-07:00` will return pages which were updated after given time.
* `GET /pages?owner_ids=1,2,9` will return pages which have owner's id of 1 or 2 or 9.
* `GET /pages?share_mode=[private|anyone|public]` will return pages based on the share status.
* `GET /pages?workspace_id=1` will return pages in workspace 1.
* `GET /pages?q=rabbit` will search for the pages which contain `rabbit` keyword. Given `q` parameter, TeamPlatform will perform a search on informations like title and content.

Get Page
--------------

* `GET /pages/1` or `GET /workspaces/1/pages/1` to get a page. Server will respond `200 Ok` along with JSON if you have access to the page. User has to have access to the workspace which the page belongs to (User should have the access to the workspace even if it's public page. Public API is not available yet.)

```json
{
  "id": 1999,
  "title": "More useful page",
  ...more info
}
```

Create Page
-----------------

* `POST /pages` or `POST /workspaces/1/pages` to create a page with JSON like this:

```json
{
  "title": "How to create a page in TeamPlatform",
  "position": 1
}
```

Server will respond `200 Ok` with new page's data if successful. Specifying `position` will create a new page in that position inside the workspace. If you omit the `position` or the value is blank, a new page will be created at last position.

Update Page
-----------------

* `PUT /pages/1` or `PUT /workspaces/1/pages/1` to update a page. Parameters would look like this:

```json
{
  "title": "Now, how to share a page with people",
  "position": 2,
  "share_mode": "anyone",
  "expire_at": "",
  "password": "pwpasthn"
  "downloadable": true
}
```

Server will respond `200 Ok` if the operation was successful. Update call has 4 more parameters available to use. Set `position` to reorder pages in workspace. `share_mode` controls the share status of the page with optional `expire_at` and `password`. `downloadable` shows/hides the file download link in shared state.

Delete Page
------------------

* `DELETE /pages/1` or `DELETE /workspaces/1/pages/1` to delete a page. Server will return `204 No Content` if the deletion is successful. You will see `403 Forbidden`, if the user doesn't have access to delete the page.