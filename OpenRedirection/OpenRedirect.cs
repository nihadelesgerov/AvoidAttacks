
/*
 Open redirect attacks occur where the next page is passed as a parameter to
an endpoint. The most common example is when you’re logging in to an
app. Typically, apps remember the page a user is on before redirecting them
to a login page by passing the current page as a returnUrl query string
parameter. After the user logs in, the app redirects the user to the
returnUrl to carry on where they left off.
 */
[HttpPost]
public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
{
    // Verify password, and sign user in
    if (Url.IsLocalUrl(returnUrl))
    {
        return Redirect(returnUrl);
    }
    else
    {
        return RedirectToPage("Index");
    }
}