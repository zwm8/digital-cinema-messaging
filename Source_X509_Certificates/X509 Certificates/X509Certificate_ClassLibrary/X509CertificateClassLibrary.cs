using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace X509Certificate_ClassLibrary
{
    public class X509CertificateClassLibrary
    {
        static X509Certificate2 GetCertificate(string serialNumber, StoreLocation storeLocation)
        {
            X509Certificate2 x509Certificate2 = null;

            try
            {
                X509Store store = new X509Store(storeLocation);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;

                X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindBySerialNumber, serialNumber, false);
                if (fcollection.Count > 0)
                {
                    x509Certificate2 = fcollection[0];
                }
                else
                {
                    Console.WriteLine("Error: Certificate '" + serialNumber + "' not found.");
                    Console.WriteLine("Number of certificates in store: {0}{1}", collection.Count, Environment.NewLine);
                    foreach (X509Certificate2 x509 in collection)
                    {
                        Console.WriteLine("Certificate Data: ******************************************************************");

                        byte[] rawdata = x509.RawData;

                        Console.WriteLine("Content Type: {0}{1}", X509Certificate2.GetCertContentType(rawdata), Environment.NewLine);
                        Console.WriteLine("Friendly Name: {0}{1}", x509.FriendlyName, Environment.NewLine);
                        Console.WriteLine("Certificate Verified?: {0}{1}", x509.Verify(), Environment.NewLine);
                        Console.WriteLine("Simple Name: {0}{1}", x509.GetNameInfo(X509NameType.SimpleName, true), Environment.NewLine);
                        Console.WriteLine("Signature Algorithm: {0}{1}", x509.SignatureAlgorithm.FriendlyName, Environment.NewLine);
                        Console.WriteLine("Private Key: {0}{1}", x509.PrivateKey.ToXmlString(false), Environment.NewLine);
                        Console.WriteLine("Public Key: {0}{1}", x509.PublicKey.Key.ToXmlString(false), Environment.NewLine);
                        Console.WriteLine("Certificate Archived?: {0}{1}", x509.Archived, Environment.NewLine);
                        Console.WriteLine("Issuer Name: {0}{1}", x509.IssuerName.Name, Environment.NewLine);
                        Console.WriteLine("Subject Name: {0}{1}", x509.SubjectName.Name, Environment.NewLine);
                        Console.WriteLine("Thumb Print: {0}{1}", x509.Thumbprint, Environment.NewLine);
                        Console.WriteLine("Serial Number: {0}{1}", x509.GetSerialNumberString(), Environment.NewLine);

                        Console.WriteLine("Length of Raw Data: {0}{1}", x509.RawData.Length, Environment.NewLine);

                        x509.Reset();
                    }
                }
                store.Close();
            }
            catch (CryptographicException eCrypt)
            {
                Console.WriteLine("Information could not be written out for this certificate: " + eCrypt.Message);
            }

            return x509Certificate2;
        }

        static X509Certificate2 BuildCertificate(byte[] rawData)
        {
            X509Certificate2 x509Certificate2 = new X509Certificate2(rawData);

            return x509Certificate2;
        }

    }
}
