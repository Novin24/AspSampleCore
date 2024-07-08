using IdentityServer4.Models;
using IdentityServer4;

namespace IdetntityUserServer
{
    public class Config
    {

        public static IEnumerable<ApiScope> ApiScopes =>
           [
               new ApiScope("MoviesApiApp", "movie api for movies"),
               new ApiScope("CustomerApiApp", "customer api for Customer"),
               new ApiScope("TestScopeApi", "Test"),
           ];

        public static IEnumerable<IdentityResource> IdentityResources =>
            [
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            ];

        public static IEnumerable<Client> Clients =>

            [
                new Client{
                 ClientId = "ConsoleClient",
                 AccessTokenLifetime = 150,
                 AllowedGrantTypes = GrantTypes.ClientCredentials,
                 AllowedScopes = {"MoviesApiApp" , "CustomerApiApp", "TestScopeApi"},
                 ClientSecrets = {
                 new Secret("1q2w3e*".Sha256())}},

                new Client{
                 ClientId = "ConsoleClient2",
                 AllowedGrantTypes = GrantTypes.ClientCredentials,
                 RequirePkce = true,
                 AllowedScopes = {"MoviesApiApp"},//, "TestScopeApi"},
                 ClientSecrets = {
                 new Secret("Secret".Sha256())}},

                new Client
                       {
                           ClientId = "AnqularApi",
                           ClientName = "Movies Web App",
                           AllowedGrantTypes = GrantTypes.Code,
                           AllowOfflineAccess = true,
                           RequirePkce = true,
                           RequireConsent = false,
                           RequireClientSecret = false,
                           AllowAccessTokensViaBrowser = true,
                           AccessTokenLifetime = 1800,
                           AllowedCorsOrigins={"http://localhost:4200"},
                           RedirectUris ={"http://localhost:4200"},
                           PostLogoutRedirectUris = {"http://localhost:4200"},
                           AllowedScopes =
                           [
                                IdentityServerConstants.StandardScopes.OpenId,
                                IdentityServerConstants.StandardScopes.Profile,
                                IdentityServerConstants.StandardScopes.OfflineAccess,
                               "MoviesApiApp",
                           ]}
            ];

    }
}
