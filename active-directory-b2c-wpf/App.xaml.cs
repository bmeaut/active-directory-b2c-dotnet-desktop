using System.Windows;
using Microsoft.Identity.Client;

namespace active_directory_b2c_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string Tenant = "bmedotnet.onmicrosoft.com";
        private static string ClientId = "3dcd6ad2-38c6-4387-a80d-85ed1043b7f0";
        public static string PolicySignUpSignIn = "B2C_1_il207";
        public static string PolicyEditProfile = "b2c_1_edit_profile";
        public static string PolicyResetPassword = "b2c_1_reset";

        public static string[] ApiScopes = { "https://bmedotnet.onmicrosoft.com/labapp/demo.read" };
        public static string ApiEndpoint = "https://localhost:5001/api/values";

        private static string BaseAuthority = "https://bmedotnet.b2clogin.com/tfp/{tenant}/{policy}/oauth2/v2.0/authorize";
        public static string Authority = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicySignUpSignIn);
        public static string AuthorityEditProfile = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicyEditProfile);
        public static string AuthorityResetPassword = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicyResetPassword);

        public static IPublicClientApplication PublicClientApp { get; private set; }

        static App()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
                .WithB2CAuthority(Authority)
                .Build();

            TokenCacheHelper.Bind(PublicClientApp.UserTokenCache);
        }
    }
}