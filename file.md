Files
===========

Get Files
---------

* `GET /files` to get all accessible files.
* `GET /workspaces/1/files` to get all files in the workspace 1. Responses will look like:

```json
[
  {
    "id": 9184,
    "key": "Workspace which contains a solidworks assembly/assembly.sldasm",
    "filename": "assembly.sldasm",
    "ftype": "file",
    "filesize": 401011,
    "ancestry": "9183",
    "is_root": false,
    "workspace_id": 1349,
    "version": 3,
    "state": "success",
    "small": "https://d3hdmtlhbe6vzi.cloudfront.net/9184/1/thumbnails/lsqa3l_s.jpg",
    "big": "https://d3hdmtlhbe6vzi.cloudfront.net/9184/1/thumbnails/lsqa3l_b.jpg",
    "comments_count": 0,
    "download_count": 9,
    "created_at": "2012-08-30T16:48:39-07:00",
    "updated_at": "2012-09-13T12:41:35-07:00",
    "deleted_at": null,
    "properties": {
      "Unit-Mult-To-MM": "1.000000",
      "Surface": "318746.69300764",
      "Volume": "198810.870015399",
      "Min-X": "-85.0971033072923"
    },
    "labels": [
      {
        "name": "assembly",
        "style": "background-color:rgb(222, 229, 242);color:rgb(90, 105, 134);"
      }
    ],
    "owner":{
      "id": 1,
      "name": "Randy Jung",
      "email": "randyj@example.com",
      "team_id": 1,
      "team_name": "VispowerTech",
      "picture": "https://d3hdmtlhbe6vzi.cloudfront.net/avatars/1/947fbb3731d5e7b765a3c594be4c47ed.png"
    }
  },
  ...more files
]
```

Get File
--------

Create File
-----------------

TeamPlatform provides chunked file upload to support large file upload and resuming. Uploading files to TeamPlatform is a few step process:

1. `PUT /files/upload` or `PUT /workspaces/1/files/upload` with the first chunk of the file without setting `upload_id`, and receive an upload_id in return.
2. Repeatedly PUT subsequent chunks using the `upload_id` to identify the upload in progress and an `offset` representing the number of bytes transferred so far.
3. After each chunk has been uploaded, the server returns a new offset representing the total amount transferred.
4. After the last chunk, `POST /files` or `POST /workspaces/1/files` to complete the upload.

So, here we have two end points and two key parameters controlling the chunked uploading which are `upload_id` and `offset`.