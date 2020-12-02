using System;
using System.Collections.Generic;
using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;

namespace ApolloQA.Source.Helpers
{
    public class KeyVault
    {
        public static String GetSecret(string secretName)
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            String secret = null;

            using (var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback)))
            {
                try
                {
                    var secretBundle = keyVaultClient.GetSecretAsync("https://xbibaoazckv2-qa2.vault.azure.net/", secretName).Result;
                    secret = secretBundle.Value;
                }
                catch(Exception ex)
                {
                    Functions.handleFailure("Error while retrieving secrets from azure KeyVault", ex);
                }
            }

            return secret ?? throw new Exception("Keyvault.GetSecret returned null");
        }
    }
}
