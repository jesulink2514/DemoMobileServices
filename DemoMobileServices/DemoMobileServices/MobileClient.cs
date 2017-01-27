using Microsoft.WindowsAzure.MobileServices;

namespace DemoMobileServices
{
    public static class MobileClient
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://tellmebackend.azurewebsites.net");
    }
}
