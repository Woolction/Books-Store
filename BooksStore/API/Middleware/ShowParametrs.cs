namespace BooksStore.API.Middleware;

public class ShowParametrs
{
    public readonly RequestDelegate next;
    public ShowParametrs(RequestDelegate next)
    {
        this.next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {

        string path = context.Request.Path;

        context.Response.ContentType = "text/html; charset=utf-8";

        if (path == "/postuser")
        {
            var form = context.Request.Form;

            string name = form["name"].ToString();
            string age = form["age"].ToString();

            string[] languages = form["languages"];

            if (languages != null)
            {
                string langList = string.Empty;

                for (int i = 0; i < languages.Length; i++)
                {
                    langList += languages[i];
                }

                await context.Response.WriteAsync($"<div><p>Name: {name}</p>" +
                    $"<p>Age: {age}</p>" +
                    $"<div>Languages:{langList}</div></div>");
            }
        }
        else if (context.Request.Path == "/")
        {
            await context.Response.SendFileAsync("Properties/index.html");
        }

        await next.Invoke(context);
    }
}
