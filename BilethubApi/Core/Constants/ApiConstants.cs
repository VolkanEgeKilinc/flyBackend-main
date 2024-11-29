namespace BilethubApi.Core.Constants;

public static class ApiConstants{
    public static string hostName = "http://localhost:7179/";

    // URL PATH
    public static string ProfileImageUrlPath = hostName + "Api/Files/UserProfile/";
    public static string CoverImageUrlPath = hostName + "Api/Files/CoverProfile/";


    // FILE PATH
    public static string ProfileImageFilePath = "BilethubApi/Images/Users/Profile/";
    public static string CoverImageFilePath = "BilethubApi/Images/Users/Cover/";
}