﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace EShoppingProject.Application.Extensions
{
    public static class ClaimsPrincipalExtensions // => buraya açıklama ekle
    {
        public static string GetUserEmail(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.Email);
        
        public static int GetUserId(this ClaimsPrincipal principal) => Convert.ToInt32(principal.FindFirstValue(ClaimTypes.NameIdentifier));

        public static string GetUserName(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.Name);
        
    }
}
