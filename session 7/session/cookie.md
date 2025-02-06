## 1. Secure Attribute
- **Definition**:  
  The `Secure` attribute ensures that a cookie is only sent over **secure HTTPS connections**. This is important for maintaining the confidentiality and integrity of the data stored in the cookie. If a cookie has the `Secure` flag set, it **won't be sent** over an unencrypted HTTP connection, thus helping prevent **Man-in-the-Middle (MITM)** attacks.

- **Possible Values**:
  - `true` (The cookie is only sent over HTTPS connections).
  - `false` (The cookie can be sent over both HTTP and HTTPS).

- **Example**:
  - When a user logs in on a banking website, cookies like session tokens or authentication tokens should only be sent over HTTPS to prevent attackers from intercepting sensitive information.
  - In the cookie:
    ```txt
    Set-Cookie: session_id=abc123; Secure; HttpOnly
    ```
    This cookie will only be transmitted if the connection is secure (HTTPS).

- **Security Benefit**:  
  It prevents the cookie from being exposed over unencrypted HTTP connections, reducing the risk of it being captured by an attacker.

---

## 2. HttpOnly Attribute
- **Definition**:  
  The `HttpOnly` attribute is used to prevent client-side scripts (like JavaScript) from accessing the cookie. This helps mitigate **Cross-Site Scripting (XSS)** attacks, where malicious scripts try to steal cookies by injecting code into a website.

- **Possible Values**:
  - `true` (The cookie cannot be accessed by JavaScript on the client side).
  - `false` (The cookie is accessible by JavaScript).

- **Example**:
  - A website stores a session cookie like `session_id` to track a user’s logged-in state. If the `HttpOnly` flag is set, JavaScript running on the page cannot access this cookie, even if the page is compromised by an XSS attack.
  - In the cookie:
    ```txt
    Set-Cookie: session_id=abc123; HttpOnly; Secure
    ```
    With this configuration, even if an attacker injects malicious JavaScript into the page, they won’t be able to access the `session_id` cookie.

- **Security Benefit**:  
  This attribute helps protect against XSS attacks by preventing attackers from reading sensitive cookies through JavaScript running in the browser.

---

## 3. SameSite Attribute
- **Definition**:  
  The `SameSite` attribute restricts when cookies are sent with **cross-site requests**, thus helping prevent **Cross-Site Request Forgery (CSRF)** attacks. CSRF attacks trick the user’s browser into making unwanted requests to a different website where the user is authenticated, such as submitting a form to transfer money or change a password.

- **Possible Values**:
  - **Strict**: The cookie is **only sent** if the request originates from the same site that set the cookie. This is the strictest setting and offers the highest level of security against CSRF attacks.
  - **Lax**: The cookie is sent with **same-site requests** and **top-level navigations** (such as clicking a link), but **not** with subresource requests (like loading an image from another site). This is a good balance between usability and security.
  - **None**: The cookie is sent with **cross-site requests**, meaning it’s sent regardless of the origin of the request. However, if this option is used, the cookie **must** also have the `Secure` attribute set (it must be transmitted over HTTPS).

- **Example**:
  - **Strict**: If a user is on `example.com`, and the website sets a `SameSite=Strict` cookie, the cookie will only be sent in requests that originate from `example.com`. If the user clicks a link from `example.com` to `thirdparty.com`, the cookie won’t be sent. However, if the user makes a request to `example.com` directly (or through its own forms), the cookie will be sent.
    ```txt
    Set-Cookie: session_id=abc123; SameSite=Strict
    ```

  - **Lax**: If the `SameSite=Lax` cookie is set on a login session, the cookie will be sent if the user navigates to `example.com` directly (even from another site). However, if a third-party site tries to make a request to `example.com` on behalf of the user (e.g., an embedded image or a form), the cookie will **not** be sent.
    ```txt
    Set-Cookie: session_id=abc123; SameSite=Lax
    ```

  - **None**: If you’re building a site where users may interact across multiple domains (such as a cross-origin authentication flow), you might need to set `SameSite=None`, but **only if the cookie is marked as Secure**. This allows cookies to be sent with cross-origin requests.
    ```txt
    Set-Cookie: session_id=abc123; SameSite=None; Secure
    ```

- **Security Benefit**:
  - **Strict**: It provides the highest level of protection against CSRF because it ensures that cookies are only sent when a request is made from the same origin.
  - **Lax**: It provides a balance between security and user experience. It's useful in cases where top-level navigations should be permitted but subrequests (like iframe or image loading) should be blocked.
  - **None**: This setting should only be used when absolutely necessary because it allows cookies to be sent with cross-site requests. However, it requires HTTPS to ensure the cookie's transmission is secure.

---

## Summary

- **Secure**: Ensures that cookies are only transmitted over HTTPS connections to avoid interception by attackers.
- **HttpOnly**: Makes cookies inaccessible to JavaScript, helping prevent theft through XSS attacks.
- **SameSite**: Restricts how cookies are sent with cross-origin requests, offering protection against CSRF attacks by allowing cookies to only be sent with same-origin requests (Strict, Lax) or all requests (None, but with Secure).
