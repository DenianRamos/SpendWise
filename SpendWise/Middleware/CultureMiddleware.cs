using System.Globalization;

namespace SpendWise.Api.Middleware
{
    public class CultureMiddleware
    {

        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var supportedLanguage = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

            var RequestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
            var cultureInfo = new CultureInfo("en");

            if (string.IsNullOrEmpty(RequestCulture) == false && supportedLanguage.Exists(l => l.Name.Equals(RequestCulture)))
            {

               cultureInfo = new CultureInfo(RequestCulture);

            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

                await _next(context);

            
            
                
        }
    }
}
