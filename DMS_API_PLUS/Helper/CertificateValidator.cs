using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace SAMPLE_API_PLUS.Helper
{
    public static class CertificateValidator
    {
        // OID for "client authentication" (the certificate is meant for signing in as a client)
        private static readonly Oid ClientAuthOid = new Oid("1.3.6.1.5.5.7.3.2");

        // Returns true only if the client certificate chains to our CA
        // and is valid for client authentication.
        public static bool IsIssuedByTrustedCa(X509Certificate2 clientCert, X509Certificate2 caCert)
        {
            using var chain = new X509Chain();

            // Tell the chain builder about our CA
            chain.ChainPolicy.ExtraStore.Add(caCert);

            // Our CA is not in the public trust store. Allow it as an unknown root,
            // because the root check below is what enforces trust.
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

            // No CRL or OCSP server exists in development, so skip revocation checks
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

            // The certificate must be allowed for client authentication
            chain.ChainPolicy.ApplicationPolicy.Add(ClientAuthOid);

            if (!chain.Build(clientCert))
                return false;

            // The top of the chain must be exactly our CA, not some other root
            var root = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
            return root.Thumbprint == caCert.Thumbprint;
        }
    }
}