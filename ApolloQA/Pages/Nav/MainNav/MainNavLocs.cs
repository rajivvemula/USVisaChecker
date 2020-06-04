﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Nav.MainNav
{
    class MainNavLocs
    {
        public static IDictionary<string, string> MainNavXPaths = new Dictionary<string, string>()
        {
            {"Home", "//fa-icon[contains(@class, 'apollo-icon')]" },
            {"Policy", "//button[contains(@class, 'top-menu-item') and contains(.//span, 'Policy')]" },
            {"Organization", "//button[contains(@class, 'top-menu-item') and contains(.//span, 'Organization')]" }
        };
    }
}
