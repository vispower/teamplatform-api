Properties
=====================

> 5 types of custom properties are `text`, `pulldown`, `multi`, `boolean` or `date`.

Get Properties
--------------

* `GET /workspaces/1/properties` will return all properties defined in the workspace. Response would look like this:

```json
[
  {
    "property": {
      "id": 275,
      "kind": "multi",
      "name": "Select best three things about TeamPlatform",
      "description": "not needed to be just three",
      "selections": "Uniqueness, Fits my needs, Affordable, Support, Easy to use, All of the above",
      "required_for": "create",
      "required": true,
      "team_id": 138,
      "values_count": 2,
      "created_at": "2011-06-14T12:33:51-07:00",
      "updated_at": "2011-06-14T12:34:26-07:00"
    },
    "value": {
      "id": 1868,
      "value": "All of the above",
      "property_id": 275,
      "position": 1,
      "target_type": "Workspace"
      "target_id": 1127,
      "created_at": "2011-06-14T12:33:51-07:00",
      "updated_at": "2011-06-14T12:33:51-07:00"
    }
  },
  {} ...more properties
]
```

* `GET /properties` will return all properties defined for the team. Response will look similar to above case but will not have `value` part. `value` is only available when the property is added to workspaces and requested from `GET /workspaces/1/properties`.

```json
[
  {
    "property": {
      "id": 275,
      "kind": "multi",
      "name": "Select best three things about TeamPlatform",
      "description": "not needed to be just three",
      ...property info
    }
    ...no value info here
  },
  {} ...more properties
]
```

**Property**
`selections` is comma separated list of possible choices for `pulldown` and `multi` type of properties.
`required_for` with `create` means that this property field will be prompted to the user when a new workspace is going to be created from the workspace template which this property belongs to. `required` tells this property is required field to enter when presented to the user.
`team_id` is the id of the team which owns this property.
`values_count` goes up by one whenever this property is added to workspaces.

**Value**
`value` portion of the above example has the actual user input for the property. In the above example, user selected the `All of the above` from the property's selections.
`property_id` points to the property definition which id is `275` in this case.
`position` denotes the position of this property-value pair in the target workspace.
`target_type` and `target_id` tells where this property-value pair exists.

Get Property
------------

* `GET /workspaces/1/properties/1` returns single property-value pair like this:

```json
{
  "property": {
    "id": 275,
    "kind": "multi",
    "name": "Select best three things about TeamPlatform",
    ...more info on property
  },
  "value": {
    "id": 1868,
    "value": "All of the above",
    "property_id": 275,
    ...more info on value
  }
}
```

* `GET /properties/1`

```json
{
  "property": {
    "id": 275,
    "kind": "multi",
    "name": "Select best three things about TeamPlatform",
    ...more info on property
  }
  ...no value here
}
```

Create Property
----------------

* `POST /workspaces/1/properties` with JSON:

```json
{
  "kind": "pulldown",
  "name": "Rate this workspace!",
  "description": "in terms of contents quality",
  "selections": "Super!, A+, A, A-, B+, B, B-, C, D",
  "required_for": "create",
  "required": true,
  "value": "Super!",
  "position": 1
}
```

If workspace is present in the request uri and the workspace is accessible, Property-value pair will be created and will return `200 Ok` with created property-value pair.

* `POST /properties` with JSON:

```json
{
  "kind": "text",
  "name": "What's your name?",
  "description": "just out of curiosity",
  "selections": "",
  "required_for": "",
  "required": false
}
```

If workspace is not present, only new property will be created.

Update Property
---------------

* `PUT /workspaces/1/properties/1` will update the property-value pair.

```json
{
  "value": "D"
}
```

* `PUT /properties/1` will only update the property attributes. Following JSON updates nothing.

```json
{
  "value": "D",
  "position": 2
}
```

Delete Property
----------------

* `DELETE /properties/1` will delete property 1 and all property-value pairs across all the workspaces.
* `DELETE /workspaces/1/properties/1` will remove only the property-value pair in workspace 1, but will not delete property 1 itself.