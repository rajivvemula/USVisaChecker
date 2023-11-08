using System;

namespace BiBerkLOB.Source.Helpers;

public static class AppSettings
{
    public static string PortalSvcBaseUrl => Environment.GetEnvironmentVariable("PORTAL_SVC_BASE_URL");
    public static string SecuritySvcUrl => Environment.GetEnvironmentVariable("SECURITY_SVC_BASE_URL");
    
    public static string GetAQuoteUrlBaseSegment => Environment.GetEnvironmentVariable("GET_A_QUOTE_URL_BASE_SEGMENT");
    public static string CaUrlBaseSegment => Environment.GetEnvironmentVariable("CA_URL_BASE_SEGMENT");
}