Page Items
==================

> A page has five types of page items. Note, Downloader, Uploader, Divider and Form Fields.

Get Page Items
-----------------

* `GET /pages/1/page_items` to get page item's in page 1. `GET /workspaces/1/pages/1/page_items` is also valid end point, but server will just ignore the workspace part to prevent unnecessary complexity from deep nesting.

```json
[
  {
    "id": 2782,
    "kind": "Note",
    "title": "How TeamPlatform Handles Page Contents",
    "content": "<p>Section 1: Page Item Types ...</p>",
    
    "page_id": 1174,
    "position": 1,
    
    "folder_id": null,
    "upload_url": "",
    "file_ids": "",
    "files": [ ...files ],
    "fields": [ ...properties ],
    "submit_text": null,
    "show_owner": true,
    
    "created_at": "2012-05-31T11:19:20-07:00",
    "updated_at": "2012-09-07T12:19:32-07:00",
    "updater": {
      "team_name":"VispowerTech",
      "team_id":1,
      "email":"randyj@example.com",
      "picture":"https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png",
      "name":"Randy Jung",
      "id":1
    },
    "owner": { ...owner info }
  },
  {} ...more page items
]
```

Server will return `200 Ok` with page items in the page if the user is accessible to the page.

`kind` tells the page item type which can be either `Note`, `Downloader`, `Uploader`m `Divider` and `Fields`.
`folder_id` is the id of the file folder which the page item was mapped to.
`upload_url` tells the url of the uploader where users can upload files if the page is shared and the page item type is `uploader`.
`file_ids` is comma separated list of id of files which the page item has. This field is blank if `folder_id` is present, and vice-versa.
`files` contains array of files in the page item with same JSON representation of files. See [Files Section of the API](https://github.com/vispower/teamplatform-api/blob/master/file.md) for details.
`fields` contains array of properties only for `Fields` type of page item. Look further information properties at [Property](https://github.com/vispower/teamplatform-api/blob/master/property.md).
`submit_text` is for `Fields` type page item to represent custom form submit button text.
`show_owner` flag denotes the file owners will be shown or not in shared page view.
`updater` is the user who updated the page last time.

`GET /pages/1/page_items` doesn't have further filtering options and returns all the page items in the page always.

Get Page Item
------------------

* `GET /pages/1/page_items/1` returns page item 1 with.

```json
{
  "id": 2783,
  "kind": "Downloader",
  "title": "Marketing Materials for API",
  "content": "Total 6 files available to download",
  ...more info
}
```

Create Page Item
-----------------------

* `POST /pages/1/page_items` with JSON like this:

```json
{
  "kind": "Downloader",
  "title": "Useful Files",
  "content": "from useful workspace's folder",
  "position": 1,
  "show_owner": true,
  "folder_id": 1972,
  "file_ids": "",
  "submit_text": ""
}
```

Server will respond `200 Ok` with new data if successful, `403 Forbidden` if the page is not accessible.

Update Page Item
----------------------

* `PUT /pages/1/page_items/1` with JSON:
```json
{
  "kind": "Downloader",
  "title": "More Useful Files",
  "content": "files from many different workspaces",
  "position": 2,
  "show_owner": false,
  "folder_id": "",
  "file_ids": "1024,2048,8",
  "submit_text": ""
}
```

Server will respond `200 Ok` with updated data if successful, `403 Forbidden` if the page is not accessible.

Delete Page Item
-------------------------

* `DELETE /pages/1/page_items/1` to delete a page item.

Server will respond `204 No Content`, `403 Forbidden` if the page is not accessible.