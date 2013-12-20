Files
===========

> Each workspace has its own folder structure like your desktop file system.

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
    "kind": "cad",
    "filesize": 401011,
    "ancestry": "9183",
    "is_root": false,
    "workspace_id": 1349,
    "version": 3,
    "state": "success",
    "small": "https://d3hdmtlhbe6vzi.cloudfront.net/9184/3/thumbnails/lsqa3l_s.jpg",
    "big": "https://d3hdmtlhbe6vzi.cloudfront.net/9184/3/thumbnails/lsqa3l_b.jpg",
    "created_at": "2012-08-30T16:48:39-07:00",
    "updated_at": "2012-09-13T12:41:35-07:00",
    "deleted_at": null,
    "comments_count": 0,
    "download_count": 9,
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

If the user has no permission to access the workspace, server will return `403 Forbidden`.

**Notes on attributes**

`key` is the file's unique path which starts from workspace title and is also the path of the file in your synced folder. For example, when you specify TeamPlatform's DWM sync location at `c:\\teamplatform-sync-folder`, the full path of the synced local file will be `c:\\teamplatform-sync-folder\Workspace which contains a solidworks assembly\assembly.sldasm` for the first file of the above example.

`ftype` can be `file` or `folder`. `filesize` is in byte.

`ancestry` is the ids of the parent folders represented in the form of file path notation. For example, `ancestry` value of `1/2/3` means the file is in folder 3(id), folder 3 is in folder 2, folder 2 is in folder 1 which is the workspace's root folder and finally folder 1 is in root sync folder like `c:\\teamplatform-sync-folder`. `is_root` tells whether the file is the workspace's root folder or not(Surely, if this value is true, then `ftype` should also be `folder`). `ancestry` value might be useful to generate tree structure of the entire files under a workspace or create breadcrumbs for navigating folders.

`version` denotes current active-and-last version number of the file.

`state` describes current state of the process which generates on-line preview and extracts meta properties(`properties` in the JSON) for the file. Possible `state` values can be `created`, `uploading`, `uploaded`, `processing`, `success` and `error`. Unsupported files for this process will have value of `error` eventually. `small` and `big` tells the location of the preview thumbnails for the successfully processed files.

`properties` will have different kinds and number of keys and values for different types of files.

More filtering options are available:

* `GET /files?page=2` to get the page two of results. The result will be paginated 30 items per page.
* `GET /files?order_by=updated_at+desc` will return sorted results by `updated_at` field.
* `GET /files?order_by=created_at+desc` will return sorted results by `created_at` field.
* `GET /files?created_since=2012-09-18T18:11:40-07:00` will return files created after given time.
* `GET /files?updated_since=2012-09-18T18:11:40-07:00` will return files updated after given time.
* `GET /files?owner_ids=1,2,9` will return files which have owner 1 or owner 2 or owner 9.
* `GET /files?workspace_id=1` will return files in workspace 1.
* `GET /files?folder_id=1` will return files in folder 1.
* `GET /files?filename=rabbit` will search for files named as `rabbit`.
* `GET /files?extension=prt` will search for files having `.prt` file extension.
* `GET /files?ftype=[file|folder]` will return `files/folders`.
* `GET /files?deleted=[true|false]` will return `deleted/not-deleted` files.
* `GET /files?state=[created|uploading|uploaded|processing|success|error]` will return files in corresponding state.
* `GET /files?q=rabbit` will search for the files which contain `rabbit` as a keyword. Given `q` parameter, TeamPlatform will perform a full text search on filename, label names and properties.

Get File
--------

* `GET /files/1` to get file 1.
* `GET /workspaces/1/files/1` to get file 1 in workspace 1.

Response will look like same as `GET /files` but with single JSON representation.

```json
{
  "id": 1,
  "key": "Another workspace/part.part",
  "filename": "part.prt",
  "ftype": "file",
  "kind": "cad",
  "filesize": 400,
  "ancestry": "9100",
  ...more info
}
```

Upload and Create File
-----------------

TeamPlatform provides chunked file upload to support large file upload and resuming. Uploading files to TeamPlatform is a few step process:

1. `PUT /workspaces/1/files/upload` with the first chunk of the file without setting `upload_id`, and receive an `upload_id` in return.

        PUT /workspaces/1/files/upload?offset=0
        
        // Set "Content-Type" header to "application/binary" or the content type of the file
        // Whole request body should be a chunk of data from the file being uploaded.
        
        Server Returns:
        {
          "upload_id": "7a69476a3dc2cfe12cba9225072d7ec2c0ef8f9a88c9984bcb43eb8ec1cdd926",
          "offset": 1048576
        }

2. Repeatedly PUT subsequent chunks using the `upload_id` to identify the upload in progress and an `offset` representing the number of bytes transferred so far. After each chunk has been uploaded, the server returns a new offset representing the total amount transferred.

        PUT /workspaces/1/files/upload?offset=1048576&upload_id=7a69476a3dc2cfe12cba9225072d7ec2c0ef8f9a88c9984bcb43eb8ec1cdd926
        
        Server returns:
        {
          "upload_id": "7a69476a3dc2cfe12cba9225072d7ec2c0ef8f9a88c9984bcb43eb8ec1cdd926",
          "offset": 2097152
        }

3. After the last chunk, `POST /workspaces/1/files` to complete the upload.

        POST /workspaces/1/files
        {
          "upload_id": "7a69476a3dc2cfe12cba9225072d7ec2c0ef8f9a88c9984bcb43eb8ec1cdd926",
          "key": "To be ignored workspace title but required/will create missing subfolders/myfile.zip",
          "ftype": "file"
        }

"key" should always include workspace's root folder name(which is identical to workspace title and should not start with `/`)
Note that all three steps require workspace identifier(`/workspaces/1`) where the file will reside.

If the workspace isn't accessible by you, server will respond with `403 Forbidden`. If the specified workspace is found but sub folder doesn't exist, server will create missing sub-folders automatically and put the file inside the sub folder. If the key already exists, the version number will bump up by 1.

Chunks can be any size but typical chunk is 1~5 MB. Server will be timed out if the chunk size is too big or connection is too slow. Using large chunks will mean fewer calls to and faster overall throughput. However, whenever a transfer is interrupted, you will have to resume at the beginning of the last chunk, so it is often safer to use smaller chunks.

If the offset you submit does not match the expected offset on the server, the server will ignore the request and respond with a 400 error that includes the current offset. To resume upload, seek to the correct offset (in bytes) within the file and then resume uploading from that point.

Download File
--------

* `GET /workspaces/1/files/1/download` to download file 1 in workspace 1.

Response will be actual file with content-type of `application/octet-stream`.
You can download different versions by specifying version number like `GET /workspaces/1/files/1/download?version=2`

Create Folder
--------------

        POST /workspaces/1/files
        {
          "key": "My workspace Title/New Folder",
          "ftype": "folder"
        }
        
Server will respond with `200 Ok` if the creation was successful. If the key already exists, server will respond with `400 Bad Request`.

Rename File or Folder
---------------------

        PUT /workspaces/1/files/1 OR POST /files/1
        {
          "filename": "Renamed.avi"
        }
        
        PUT /workspaces/1/files/2
        {
          "filename": "Renamed Folder"
        }

`filename` parameter should not contain `/` in it. Server will just ignore the update request if `filename` contains `/`. If you rename the workspace's root folder name, the workspace title will update accordingly. Server will respond `200 Ok` with updated JSON if the renaming was successful.

You can't rename file or folder to existing file or folder name inside the same parent folder like any other file systems (Server will return `400 Bad Request`).

If our server returns `409 Conflict`, it means that current operation cannot be done at this moment because there's other process trying to modify the same resource. The process will usually complete in a few seconds, but can be long as a minute depending on the size of the workspace's folder/file structure (if the workspace has thousands of files).

We currently doesn't support more file operation features like move or copy for the API.

Delete, Undelete and Purge file
-------------

* `DELETE /files/1` will delete the file and return `200 Ok` if that was successful. If the user does not have access to delete the file, you'll see `403 Forbidden`.

* `DELETE /files/1?undelete=true` will undelete the file and return `200 Ok` if that was successful. If the user does not have access to undelete the file, you'll see `403 Forbidden`.

* `DELETE /files/1?purge=true` will permanently delete the file and return `204 No Content` if that was successful. If the user does not have access to purge the file, you'll see `403 Forbidden`.

Custom Properties
--------------

Client can store any custom properties on a file in a form of JSON data. Use `meta` parameter to update user defined custom property. `meta` parameters can be added for both file creation and update operation.

      PUT /workspaces/1/files/1 OR POST /files/1
      {
        "meta": {
          "author": "Superman",
          "last revised at": "2014/1/1"
        }
      }

      PUT /workspaces/1/files/2
      {
        "meta": {
          "author": "Supergirl",
          "last revised at": "2024/1/1"
        }
      }