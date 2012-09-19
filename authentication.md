TeamPlatform API Authentication
============================

All API requests can be authenticated by passing along an OAuth 2 token. Other types of authentications like basic auth are not supported.

OAuth 2
-------

For a full app integration, you wouldn't want to get into the business of asking
customers for their passwords -- or storing them! -- so we offer a simple way to
ask a user for access to his account. You get an API access token back without
ever having to see his password or ask him to copy/paste an API key.

1. [Grab an OAuth 2 library](http://oauth.net/code/).
2. Register your app at [Your account's settings](https://teamplatform.com/settings#tab-api-s). You'll be assigned a `client_id` and `client_secret`. You'll need to provide a `redirect_uri`: a URL where we can send a verification code. Just enter a dummy URL like `http://localhost/oauth` if you're not ready for this yet.
3. Configure your OAuth 2 library with your `client_id`, `client_secret`, and `redirect_uri`. Tell it to use `https://teamplatform.com/api/v1/oauth/authorize` to request authorization and `https://teamplatform.com/api/v1/oauth/access_token` to get access token.
4. Try making an authorized request to `https://teamplatform.com/profile` to get authorized user's profile.

OAuth 2 from scratch
--------------------

If you're going bare-metal and developing your own OAuth 2 client, you have a bit more work to do.

**The typical flow for a web app:**

Request access, receive a verification code, trade it for an access token.

1. Your app requests authorization by redirecting your user to TeamPlatform's authorization end point:

        https://teamplatform.com/api/v1/oauth/authorize?response_type=code&client_id=your-client-id&redirect_uri=your-redirect-uri

2. We authenticate their TeamPlatform ID and ask whether it's ok to give access to your app.

3. We redirect the user back to your app with a time-limited verification code.

        http://your_redirect_uri?code=issued_verification_code

4. Your app makes a backchannel request to trade the verification code for an access token. We authenticate your app and issue an access token:
        
        POST https://teamplatform.com/api/v1/oauth/access_token
        {
          grant_type: "authorization_code",
          code: "verification-code",
          client_secret: "your-client-secret",
          client_id: "your-client-id",
          redirect_uri: "your-redirect-uri"
        }

        Server Response:
        {
          access_token: "83eab44041067740f9f8c777975218bebb91fb9fc8c11367d73ad0c15626ac7a",
          expires_at: "1348076171",
          refresh_token: "e359ae94bd7046b135380d03af265c78556d897416c8c5dafb74a7d3ab1d8445",
          scope: "read write"
        }

5. Your app uses the token to authorize API requests to any of the TeamPlatform accounts. Set the Authorization request header or as a query parameter:
        
        Authorization: OAuth YOUR_OAUTH_TOKEN
        Or
        GET https://teamplatform.com/api/v1/workspaces?access_token=your_access_token

6. To get info about the TeamPlatform ID you authorized and the accounts you have access to, make an authorized request to `https://teamplatform.com/api/v1/profile`.

**Flow for a native app:**

Trade username and password for an access token.
This flow allows your app to get access token directly from user credentials without redirection.
Your app might require an additional verification process to get registered to use this flow.

1. Your app requests an access token at authorization end point with parameters:

        POST https://teamplatform.com/api/v1/oauth/access_token
        {
          "grant_type": "password",
          "username": "your_user_email",
          "password": "your_user_password",
          "client_id": "a005a867611186693e4a",
          "client_secret": "2a28dda51e0e0f1a4ccb23",
          "scope": "read write"
        }

2. We authenticate your app without user consent and issue an access token.

3. Your app access APIs with responded access_token.

**Refreshing access_token

Your fresh new access_token will expire at the time we specified in the response as `expires_at`.
To get a refreshed access_token:
        
        POST https://teamplatform.com/api/v1/oauth/access_token
        {
          "grant_type": "refresh_token",
          "refresh_token": "e359ae94bd7046b135380d03af265c78556d897416c8c5dafb74a7d3ab1d8445",
          "client_id": "a005a867611186693e4a",
          "client_secret": "2a28dda51e0e0f1a4ccb23"
        }
        
Server will respond with refreshed access_token and new expires_at value.

Implementation notes:

* Start by reading the [draft spec](http://tools.ietf.org/html/draft-ietf-oauth-v2)
* We implement draft 10.
* We support the web server and native application flows.
* We issue refresh tokens. Use them to request a new access token when it expires (2 week lifetime, currently).

What's next?
---------

So, you got an access_token, and what's next? You can probably request TeamPlatform to get user information of who authorized your app by `GET https://teamplatform.com/api/v1/profile`. Or, you can grab all the workspaces the user is accessible to by `GET https://teamplatform.com/api/v1/workspaces`

Please look around [what's available](https://github.com/vispower/teamplatform-api#api-ready-for-use) in TeamPlatform APIs.