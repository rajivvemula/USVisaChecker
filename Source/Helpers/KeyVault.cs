using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Newtonsoft.Json.Linq;


namespace HitachiQA.Helpers
{
    public class KeyVault
    {
        private readonly string _secretSuffix;
        private readonly Uri _keyVaultUri;

        private KeyVault(string keyVaultUri, string secretSuffix)
        {
            _keyVaultUri = new Uri(keyVaultUri);
            _secretSuffix = secretSuffix;
        }

        public static KeyVault CreateInstance(string keyVaultUri, string secretSuffix)
        {
            return keyVaultUri == null ? null : new KeyVault(keyVaultUri, secretSuffix);
        }

        /// <summary>
        /// Retrieves the secret from the KeyVault based on configured URI
        /// </summary>
        /// <param name="secretName">The key of the secret in KeyVault</param>
        /// <returns>The value of the secret</returns>
        public string GetSecretFromKeyVault(string secretName)
        {
            var client = new SecretClient(_keyVaultUri, new DefaultAzureCredential());
            KeyVaultSecret theSecret = client.GetSecret(secretName);

            return theSecret.Value;
        }

        /// <summary>
        /// Retrieves secret that is stored as an environment variable
        /// </summary>
        /// <param name="envVariableKey">The environment variable holding the secret name</param>
        /// <returns>The value of the secret associated with the environment variable</returns>
        public static string GetStoredEnvironmentSecret(string envVariableKey)
        {
            var secretName = Environment.GetEnvironmentVariable(envVariableKey);
            return Environment.GetEnvironmentVariable(secretName);
        }

        /// <summary>
        /// Retrieves secret from KeyVault then stores it as an environment variable
        /// </summary>
        /// <param name="secretName">The key of the secret in KeyVault</param>
        /// <exception cref="Exception">If method is called multiple times on same secret name</exception>
        public void StoreSecretAsEnvironmentVariable(string secretName)
        {
            var secret = GetSecretFromKeyVault(secretName);

            if (Environment.GetEnvironmentVariable(secretName) != null)
            {
                throw new Exception($"Environment variable '{secretName}' is being set multiple times, please only set it once");
            }

            Environment.SetEnvironmentVariable(secretName, secret);
        }

        /// <summary>
        /// Retrieves secret from KeyVault then stores it as an environment variable
        /// only if variable is a secret and secret needs to be set
        /// </summary>
        /// <param name="variable">JSON variable that may be a secret</param>
        /// <param name="secretSuffix">Suffix for JSON variable key that identifies it as a secret</param>
        public void StoreSecretFromJSONIfNecessary(KeyValuePair<string, JToken?> variable)
        {
            if (ShouldStoreSecretFromJSON(variable))
            {
                var secretName = variable.Value.ToString();
                StoreSecretAsEnvironmentVariable(secretName);
            }
        }

        private bool ShouldStoreSecretFromJSON(KeyValuePair<string, JToken?> variable)
        {
            var variableIsSecret = variable.Key.Contains(_secretSuffix);
            //this will always be false if we are in a pipeline
            var secretNotAlreadySet = Environment.GetEnvironmentVariable(variable.Value.ToString()) == null;

            return variableIsSecret && secretNotAlreadySet;
        }
    }
}