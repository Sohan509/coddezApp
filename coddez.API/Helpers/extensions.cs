using System;
using Microsoft.AspNetCore.Http;

namespace coddez.API.Helpers
{
    public static class extensions
    {
        public static void AddApplicationError(this HttpResponse response, 
            string message)
        {
            response.Headers.Add("Appilcation-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers","Appilcation-Error");
            response.Headers.Add("Access-Control-Allow-Origin","*");
        }

        public static int CalculateAge(this DateTime theDateTime) {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today )
                age --;

            return age;
        }
    }
}