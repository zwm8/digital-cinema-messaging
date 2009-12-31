using X509Certificate_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Text;

namespace X509Certificate_ClassLibrary_TestProject
{
    
    
    /// <summary>
    ///This is a test class for X509CertificateClassLibraryTest and is intended
    ///to contain all X509CertificateClassLibraryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class X509CertificateClassLibraryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetCertificate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("X509Certificate_ClassLibrary.dll")]
        public void GetCertificateTest()
        {
            string serialNumber = "990B25F50DC7E2B548BE75AFED579448";
            StoreLocation storeLocation = StoreLocation.CurrentUser;
            //string serialNumber = "23B0B092F414B89745B443F2B3700039";
            //StoreLocation storeLocation = StoreLocation.LocalMachine;
            X509Certificate2 actual = null;

            try
            {
                actual = X509CertificateClassLibrary_Accessor.GetCertificate(serialNumber, storeLocation);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception thrown getting certificate: " + e.Message);
            }
            finally
            {
                if (null != actual)
                {
                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("Certificate Data: ******************************************************************");

                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("Basic Certificate Information");
                    //System.Diagnostics.Debug.WriteLine("\t Content Type: " + X509Certificate2.GetCertContentType(actual.RawData));
                    System.Diagnostics.Debug.WriteLine("\t Format: " + actual.GetFormat());
                    System.Diagnostics.Debug.WriteLine("\t Version: " + actual.Version.ToString());
                    System.Diagnostics.Debug.WriteLine("\t Hash String: " + actual.GetCertHashString());
                    System.Diagnostics.Debug.WriteLine("\t Issuer Name: " + actual.IssuerName.Name);
                    System.Diagnostics.Debug.WriteLine("\t Issuer Name OID: " + actual.IssuerName.Oid.Value);
                    System.Diagnostics.Debug.WriteLine("\t Subject Name: " + actual.SubjectName.Name);
                    System.Diagnostics.Debug.WriteLine("\t Serial Number: " + actual.GetSerialNumberString());
                    System.Diagnostics.Debug.WriteLine("\t Thumb Print: " + actual.Thumbprint);
                    System.Diagnostics.Debug.WriteLine("\t Friendly Name: " + actual.FriendlyName);
                    System.Diagnostics.Debug.WriteLine("\t Signature Algorithm: " + actual.SignatureAlgorithm.FriendlyName);
                    System.Diagnostics.Debug.WriteLine("\t Signature Key Exchange Algorithm: " + actual.PrivateKey.KeyExchangeAlgorithm);
                    System.Diagnostics.Debug.WriteLine("\t Key Algorithm Parameters: " + actual.GetKeyAlgorithmParametersString());
                    System.Diagnostics.Debug.WriteLine("\t Not Valid Before: " + actual.NotBefore.ToString());
                    System.Diagnostics.Debug.WriteLine("\t Not Valid After: " + actual.NotAfter.ToString());
                    System.Diagnostics.Debug.WriteLine("\t Can Be Verified: " + actual.Verify());
                    System.Diagnostics.Debug.WriteLine("\t Is Archived: " + actual.Archived);

                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("X509 Name Elements");
                    System.Diagnostics.Debug.WriteLine("\t X509 Simple Name: " + actual.GetNameInfo(X509NameType.SimpleName, false));
                    System.Diagnostics.Debug.WriteLine("\t X509 DNS From Alternative Name: " + actual.GetNameInfo(X509NameType.DnsFromAlternativeName, false));
                    System.Diagnostics.Debug.WriteLine("\t X509 DNS Name: " + actual.GetNameInfo(X509NameType.DnsName, false));
                    System.Diagnostics.Debug.WriteLine("\t X509 Email Name: " + actual.GetNameInfo(X509NameType.EmailName, false));
                    System.Diagnostics.Debug.WriteLine("\t X509 UPN Name: " + actual.GetNameInfo(X509NameType.UpnName, false));
                    System.Diagnostics.Debug.WriteLine("\t X509 URL Name: " + actual.GetNameInfo(X509NameType.UrlName, false));

                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("X509 Name Elements for Issuer");
                    System.Diagnostics.Debug.WriteLine("\t X509 Simple Name: " + actual.GetNameInfo(X509NameType.SimpleName, true));
                    System.Diagnostics.Debug.WriteLine("\t X509 DNS From Alternative Name: " + actual.GetNameInfo(X509NameType.DnsFromAlternativeName, true));
                    System.Diagnostics.Debug.WriteLine("\t X509 DNS Name: " + actual.GetNameInfo(X509NameType.DnsName, true));
                    System.Diagnostics.Debug.WriteLine("\t X509 Email Name: " + actual.GetNameInfo(X509NameType.EmailName, true));
                    System.Diagnostics.Debug.WriteLine("\t X509 UPN Name: " + actual.GetNameInfo(X509NameType.UpnName, true));
                    System.Diagnostics.Debug.WriteLine("\t X509 URL Name: " + actual.GetNameInfo(X509NameType.UrlName, true));

                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("Keys");
                    System.Diagnostics.Debug.WriteLine("\t Private Key: " + actual.PrivateKey.ToXmlString(false));
                    System.Diagnostics.Debug.WriteLine("\t Public Key: " + actual.PublicKey.Key.ToXmlString(false));

                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("Raw Cert");
                    System.Diagnostics.Debug.WriteLine("\t " + actual.GetRawCertDataString());                    

                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("************************************************************************************");
                    System.Diagnostics.Debug.WriteLine("");
                }
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(serialNumber, actual.GetSerialNumberString());
        }

        private void OutputCertificate(X509Certificate2 x509Certificate)
        {
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("Certificate Data: ******************************************************************");

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("Basic Certificate Information");
            //System.Diagnostics.Debug.WriteLine("\t Content Type: " + X509Certificate2.GetCertContentType(x509Certificate.RawData));
            System.Diagnostics.Debug.WriteLine("\t Format: " + x509Certificate.GetFormat());
            System.Diagnostics.Debug.WriteLine("\t Version: " + x509Certificate.Version.ToString());
            System.Diagnostics.Debug.WriteLine("\t Hash String: " + x509Certificate.GetCertHashString());
            System.Diagnostics.Debug.WriteLine("\t Issuer Name: " + x509Certificate.IssuerName.Name);
            System.Diagnostics.Debug.WriteLine("\t Issuer Name OID: " + x509Certificate.IssuerName.Oid.Value);
            System.Diagnostics.Debug.WriteLine("\t Subject Name: " + x509Certificate.SubjectName.Name);
            System.Diagnostics.Debug.WriteLine("\t Serial Number: " + x509Certificate.GetSerialNumberString());
            System.Diagnostics.Debug.WriteLine("\t Thumb Print: " + x509Certificate.Thumbprint);
            System.Diagnostics.Debug.WriteLine("\t Friendly Name: " + x509Certificate.FriendlyName);
            System.Diagnostics.Debug.WriteLine("\t Signature Algorithm: " + x509Certificate.SignatureAlgorithm.FriendlyName);
            if (null != x509Certificate.PrivateKey)
                System.Diagnostics.Debug.WriteLine("\t Signature Key Exchange Algorithm: " + x509Certificate.PrivateKey.KeyExchangeAlgorithm);
            else
                System.Diagnostics.Debug.WriteLine("\t Signature Key Exchange Algorithm: ");
            System.Diagnostics.Debug.WriteLine("\t Key Algorithm Parameters: " + x509Certificate.GetKeyAlgorithmParametersString());
            System.Diagnostics.Debug.WriteLine("\t Not Valid Before: " + x509Certificate.NotBefore.ToString());
            System.Diagnostics.Debug.WriteLine("\t Not Valid After: " + x509Certificate.NotAfter.ToString());
            System.Diagnostics.Debug.WriteLine("\t Can Be Verified: " + x509Certificate.Verify());
            System.Diagnostics.Debug.WriteLine("\t Is Archived: " + x509Certificate.Archived);

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("X509 Name Elements");
            System.Diagnostics.Debug.WriteLine("\t X509 Simple Name: " + x509Certificate.GetNameInfo(X509NameType.SimpleName, false));
            System.Diagnostics.Debug.WriteLine("\t X509 DNS From Alternative Name: " + x509Certificate.GetNameInfo(X509NameType.DnsFromAlternativeName, false));
            System.Diagnostics.Debug.WriteLine("\t X509 DNS Name: " + x509Certificate.GetNameInfo(X509NameType.DnsName, false));
            System.Diagnostics.Debug.WriteLine("\t X509 Email Name: " + x509Certificate.GetNameInfo(X509NameType.EmailName, false));
            System.Diagnostics.Debug.WriteLine("\t X509 UPN Name: " + x509Certificate.GetNameInfo(X509NameType.UpnName, false));
            System.Diagnostics.Debug.WriteLine("\t X509 URL Name: " + x509Certificate.GetNameInfo(X509NameType.UrlName, false));

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("X509 Name Elements for Issuer");
            System.Diagnostics.Debug.WriteLine("\t X509 Simple Name: " + x509Certificate.GetNameInfo(X509NameType.SimpleName, true));
            System.Diagnostics.Debug.WriteLine("\t X509 DNS From Alternative Name: " + x509Certificate.GetNameInfo(X509NameType.DnsFromAlternativeName, true));
            System.Diagnostics.Debug.WriteLine("\t X509 DNS Name: " + x509Certificate.GetNameInfo(X509NameType.DnsName, true));
            System.Diagnostics.Debug.WriteLine("\t X509 Email Name: " + x509Certificate.GetNameInfo(X509NameType.EmailName, true));
            System.Diagnostics.Debug.WriteLine("\t X509 UPN Name: " + x509Certificate.GetNameInfo(X509NameType.UpnName, true));
            System.Diagnostics.Debug.WriteLine("\t X509 URL Name: " + x509Certificate.GetNameInfo(X509NameType.UrlName, true));

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("Keys");
            System.Diagnostics.Debug.WriteLine("\t Public Key: " + x509Certificate.PublicKey.Key.ToXmlString(false));
            if (null != x509Certificate.PrivateKey)
                System.Diagnostics.Debug.WriteLine("\t Private Key: " + x509Certificate.PrivateKey.ToXmlString(false));
            else
                System.Diagnostics.Debug.WriteLine("\t Private Key: ");

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("Raw Cert");
            System.Diagnostics.Debug.WriteLine("\t " + x509Certificate.GetRawCertDataString());

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("************************************************************************************");
            System.Diagnostics.Debug.WriteLine("");
        }

        /// <summary>
        ///A test for BuildCertificate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("X509Certificate_ClassLibrary.dll")]
        public void BuildCertificateTest()
        {
            string serialNumber = "990B25F50DC7E2B548BE75AFED579448";
            StoreLocation storeLocation = StoreLocation.CurrentUser;

            X509Certificate2 expected = X509CertificateClassLibrary_Accessor.GetCertificate(serialNumber, storeLocation);

            byte[] rawData = expected.RawData;
            X509Certificate2 actual;
            actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            Assert.AreEqual(expected, actual);

            rawData = Convert.FromBase64String("MIIERTCCAy2gAwIBAgIIU3Ra85A72X8wDQYJKoZIhvcNAQELBQAwbDEcMBoGA1UEAxMTLlNvbnkuRENJc3N1ZXJDQS52MTEMMAoGA1UECxMDUFJPMRcwFQYDVQQKEw5EQy5DQS5Tb255LkNvbTElMCMGA1UELhMcc2RjMCtoMEdIZ1U3RkFhUHFjMXFyZkZiRzNzPTAeFw0wODEyMTEwNDE5MjBaFw0zODEyMDQwNDI5MjBaMHsxKzApBgNVBAMMIlNNLlNvbnkuU1NQLTI3X0NPTVBMLjQ1MlpLOEMzXzAwMjYxDDAKBgNVBAsTA1BSTzEXMBUGA1UEChMOREMuQ0EuU29ueS5Db20xJTAjBgNVBC4THGtpc3h5MGVHSGhQYnk1NkdhSjRWSWM4bVdIRT0wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCgYX2WqkzhgGAQCIUzjZKeA2+l8svHs5B7gPzrdXZ5V9pQ2LA2//Gg/Nh04ZIZ2OrI7aOeKA67QTBlokmyfa+RU7+td04P0O1KaLj2e7d0TMNI6oplTweuYdl2LEXLW8sYPRG8q5+spuZK63QrZv0Bug4dBw/VZ1Xkw1s9E2tG9pouas8qKHQR85AAh3WY5JBQsU+6wYNpCli9beBf3XxCvgyxKu5rlnF8wMXe0ZwkP1ZnIZR6mFR3bd848hYqoRqC1iEkvUNLfvn5UpuOiAR7zmTilE6ZTi5LRSFohXpJqNtHPBNPQJnOheyGeYL1x3HKVj3jmcsavT5kRTe8cjMDAgMBAAGjgdswgdgwCQYDVR0TBAIwADAOBgNVHQ8BAf8EBAMCBaAwHQYDVR0OBBYEFJIrMctHhh4T28uehmieFSHPJlhxMIGbBgNVHSMEgZMwgZCAFLHXNPodBh4FOxQGj6nNaq3xWxt7oW6kbDBqMRowGAYDVQQDExEuU29ueS5EQ1Jvb3RDQS52MTEMMAoGA1UECxMDUFJPMRcwFQYDVQQKEw5EQy5DQS5Tb255LkNvbTElMCMGA1UELgwcaTFvUTVaWk04L0hLM01GR2o5Q0I2dkExSlA0PYIIFFF3Mun2BycwDQYJKoZIhvcNAQELBQADggEBAFIrplgyL5zCuOqSEf7QexLofkyL8Il1uaSnwFuqo4kxhaIHJRfsFLqzbyXvmYE+CyG4tyi+xtD3xpihNR2dw2zaeSbna6mJzxPPRYG+1ettuvPNpbwud2+aQzXPjsusCYhAjN9+b+yEzArSbXo+bPWGk+ptmOAyEcUvt71qkYIV8rU0NpIsPO2IRZel3jphCNCPz9XKqn+13EWlo9pvOEoZQvOKrwX8+jPkvwK6WW84zixQr6Q8VXnf1eQjKHEO3YlXdS1rCMJDQoW5XFvwzGRGHzXFr+b8GoTZKjsCQjc7mBCqRqVU4g8QcHNvEZ0UfsMyXbYE1Tee+b6zEeBESlA=");
            actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            OutputCertificate(actual);
            
            rawData = Convert.FromBase64String("MIIEPzCCAyegAwIBAgIIFFF3Mun2BycwDQYJKoZIhvcNAQELBQAwajEaMBgGA1UEAxMRLlNvbnkuRENSb290Q0EudjExDDAKBgNVBAsTA1BSTzEXMBUGA1UEChMOREMuQ0EuU29ueS5Db20xJTAjBgNVBC4MHGkxb1E1WlpNOC9ISzNNRkdqOUNCNnZBMUpQND0wIBcNMDYwNDEwMTAwOTI1WhgPMjA1NjAzMjgxMDE5MjVaMGwxHDAaBgNVBAMTEy5Tb255LkRDSXNzdWVyQ0EudjExDDAKBgNVBAsTA1BSTzEXMBUGA1UEChMOREMuQ0EuU29ueS5Db20xJTAjBgNVBC4THHNkYzAraDBHSGdVN0ZBYVBxYzFxcmZGYkczcz0wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCdDApAclnBGakNxDLorVFO5kFcZ6jn0QA4qqDkObEfqeV/uhknf831yVSkIxtJ7f6wOS3y0lMu6ScT+tJu0LSuvpA9ddOmWjUl1/gA00dHuEl6iM9R9/ZRI1IClomuB9uAu3ZNR762cJyp5S9OiqSO4ATy4uiJmY5Sk3hk+ZEgYlZTp1ii9spXvLtm8NXwHeW7okPF5zp95ry2nDIkhfYR9USOG6dQPJfh6OIRj/ko2vtT1VTK10YFGkvdfFGv8HxF9XFpY4D+4nte53i2ZEZJKSgGNxyWPB89D66eHJh3gnegy4irUfXQF8fixgxfInT6mAAVazzfFV52oAs6CnpXAgMBAAGjgeQwgeEwEgYDVR0TAQH/BAgwBgEB/wIBADAOBgNVHQ8BAf8EBAMCAgQwHQYDVR0OBBYEFLHXNPodBh4FOxQGj6nNaq3xWxt7MIGbBgNVHSMEgZMwgZCAFItaEOWWTPPxytzBRo/QgerwNST+oW6kbDBqMRowGAYDVQQDExEuU29ueS5EQ1Jvb3RDQS52MTEMMAoGA1UECxMDUFJPMRcwFQYDVQQKEw5EQy5DQS5Tb255LkNvbTElMCMGA1UELgwcaTFvUTVaWk04L0hLM01GR2o5Q0I2dkExSlA0PYIIaad4vVyDqfkwDQYJKoZIhvcNAQELBQADggEBADhKgqxe5jJ1H6I4Pk0zVNmguxjdkXlfAsyuabWS5MKuGVuGrB82meXPPRPpX3pPC3U7SZMZBOx/nmup/lliTQYJ0gUSQj3+snW9GqIQIrHpxlq/cUtlkGpFz/yv7nBwalTWCL6uhTuGiAKHmy2wtzfXo9TX3VBsMdaRAX/cVJCDvnMuuSvg1hchRoZShD8IwN0Vu4nagoRxpXgAW9LpXSRk4It7THAqFJjhs2IqwJ27ZiBF8TEKwnT4g94Y3najBizxuY6v6rgA4LrY1CLKX3W/wXsPEDzrzbOyz3aeJO35gT4E9phHe4AIff9MtZCddqCzoA3XWcz5OQcTARphARw=");
            actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            OutputCertificate(actual);

            rawData = Convert.FromBase64String("MIIEPTCCAyWgAwIBAgIIaad4vVyDqfkwDQYJKoZIhvcNAQELBQAwajEaMBgGA1UEAxMRLlNvbnkuRENSb290Q0EudjExDDAKBgNVBAsTA1BSTzEXMBUGA1UEChMOREMuQ0EuU29ueS5Db20xJTAjBgNVBC4MHGkxb1E1WlpNOC9ISzNNRkdqOUNCNnZBMUpQND0wIBcNMDYwNDA3MTEyODQ3WhgPMjA2NjAzMjMxMTM4NDdaMGoxGjAYBgNVBAMTES5Tb255LkRDUm9vdENBLnYxMQwwCgYDVQQLEwNQUk8xFzAVBgNVBAoTDkRDLkNBLlNvbnkuQ29tMSUwIwYDVQQuDBxpMW9RNVpaTTgvSEszTUZHajlDQjZ2QTFKUDQ9MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnbwFp5Tt7YOTViw4xDKe1zqqNobMWQMRLJu5q6dKX6pAk5B2a9Rf3XNRAbQQnzt5U13uiGIMbHSVjszjCUtv5O+4i7dMpsVjFkncG7ADd5ZOGS7bduLaw+gm7/tryQ0qOkCm75/OSq/7LmxsaxQK4uHiKip/M1E0a2bORyxPs5XXevOVSNvKO13TYfqcIkUbCYpeH92ZIjm8GxSRCk1/gN8JM3EcpvYesOxKlJsDwCOpnDXFyXnKK5ksJkH+6fYlyKaBWu5awZXpc1Cala9h6u72fGck1OMODzwM3P5pvAqA+aUbQsZ4S6/p2Rs0lEjWK49UB5PfO4+WO51mSwYc8wIDAQABo4HkMIHhMBIGA1UdEwEB/wQIMAYBAf8CAQEwDgYDVR0PAQH/BAQDAgIEMB0GA1UdDgQWBBSLWhDllkzz8crcwUaP0IHq8DUk/jCBmwYDVR0jBIGTMIGQgBSLWhDllkzz8crcwUaP0IHq8DUk/qFupGwwajEaMBgGA1UEAxMRLlNvbnkuRENSb290Q0EudjExDDAKBgNVBAsTA1BSTzEXMBUGA1UEChMOREMuQ0EuU29ueS5Db20xJTAjBgNVBC4MHGkxb1E1WlpNOC9ISzNNRkdqOUNCNnZBMUpQND2CCGmneL1cg6n5MA0GCSqGSIb3DQEBCwUAA4IBAQBsAIKhp50WRJCrs56js+KJzLky9VKNncWszUq86mULis3znRYIZkkoHhbMxJiCHim9l8eP0WAqEQDT7PBvulEhiIfPt886fOHGqgTRm53ryT2kOHImqktdqf3Hv+MwGgld3z5iki8mNn2pkX20ymunQpk2AszX+GnH/rtu/AJaFTRE0gjd825NmXOg+57XerY5hwwbDl4Sd2mQu2As1bM2r20V/6OE+Kx4t6lZRLANr4KGThbkEJb5VUshXQfMqLzf5BiwvYJ/iArPWypeMLsNo98P99OQm+Ch3rFa6BHiHQBK+t55v46VcV+fv/dNtf1W/Ueh0v44x4komOGgkk6k");
            actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            OutputCertificate(actual);

            //rawData = Convert.FromBase64String("MMAoGA1UECxMDUFJPMRcwFQYDVQQKEw5EQy5DQS5Tb255LkNvbTElMCMGA1UELgwcaTFvUTVaWk04L0hLM01GR2o5Q0I2dkExSlA0PYIIaad4vVyDqfkwDQYJKoZIhvcNAQELBQADggEBADhKgqxe5jJ1H6I4Pk0zVNmguxjdkXlfAsyuabWS5MKuGVuGrB82meXPPRPpX3pPC3U7SZMZBOx/nmup/lliTQYJ0gUSQj3+snW9GqIQIrHpxlq/cUtlkGpFz/yv7nBwalTWCL6uhTuGiAKHmy2wtzfXo9TX3VBsMdaRAX/cVJCDvnMuuSvg1hchRoZShD8IwN0Vu4nagoRxpXgAW9LpXSRk4It7THAqFJjhs2IqwJ27ZiBF8TEKwnT4g94Y3najBizxuY6v6rgA4LrY1CLKX3W/wXsPEDzrzbOyz3aeJO35gT4E9phHe4AIff9MtZCddqCzoA3XWcz5OQcTARphARw=");
            //actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            //OutputCertificate(actual);

            //rawData = Convert.FromBase64String("MIIEPTCCAyWgAwIBAgIIaad4vVyDqfkwDQYJKoZIhvcNAQELBQAwajEaMBgGA1UEAxMRLlNvbnkuRENSb290Q0EudjExDDAKBgNVBAsTA1BSTzEXMBUGA1UEChMOREMuQ0EuU29ueS5Db20xJTAjBgNVBC4MHGkxb1E1WlpNOC9ISzNNRkdqOUNCNnZBMUpQND0wIBcNMDYwNDA3MTEyODQ3WhgPMjA2NjAzMjMxMTM4NDdaMGoxGjAYBgNVBAMTES5Tb255LkRDUm9vdENBLnYxMQwwCgYDVQQLEwNQUk8xFzAVBgNVBAoTDkRDLkNBLlNvbnkuQ29tMSUwIwYDVQQuDBxpMW9RNVpaTTgvSEszTUZHajlDQjZ2QTFKUDQ9MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnbwFp5Tt7YOTViw4xDKe1zqqNobMWQMRLJu5q6dKX6pAk5B2a9Rf3XNRAbQQnzt5U13uiGIMbHSVjszjCUtv5O+4i7dMpsVjFkncG7ADd5ZOGS7bduLaw+gm7/tryQ0qOkCm75/OSq/7LmxsaxQK4uHiKip/M1E0a2bORyxPs5XXevOVSNvKO13TYfqcIkUbCYpeH92ZIjm8GxSRCk1/gN8JM3EcpvYesOxKlJsDwCOpnDXFyXnKK5ksJkH+6fYlyKaBWu5awZXpc1Cala9h6u72fGck1OMODzwM3P5pvAqA+aUbQsZ4S6/p2Rs0lEjWK49UB5PfO4+WO51mSwYc8wIDAQABo4HkMIHhMBIGA1UdEwEB/wQIMAYBAf8CAQEwDgYDVR0PAQH/BAQDAgIEMB0GA1UdDgQWBBSLWhDllkzz8crcwUaP0IHq8DUk/jCBmwYDVR0jBIGTMIGQgBSLWhDllkzz8crcwUaP0IHq8DUk/qFupGwwajEaMBgGA1UEAxMRLlNvbnkuRENSb290Q0EudjExDDAKBgNVBAs");
            //actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            //OutputCertificate(actual);

            rawData = Convert.FromBase64String("MIIERTCCAy2gAwIBAgIIfqkgc3lcHwQwDQYJKoZIhvcNAQELBQAwbDEcMBoGA1UEAxMTLlNvbnkuRENJc3N1ZXJDQS52MTEMMAoGA1UECxMDUFJPMRcwFQYDVQQKEw5EQy5DQS5Tb255LkNvbTElMCMGA1UELhMcc2RjMCtoMEdIZ1U3RkFhUHFjMXFyZkZiRzNzPTAeFw0wODA0MjEwNTU1MzNaFw0zODA0MTQwNjA1MzNaMHsxKzApBgNVBAMMIlNNLlNvbnkuU1NQLTI3X0NPTVBMLjQ1MlpLODQ0XzAwMDExDDAKBgNVBAsTA1BSTzEXMBUGA1UEChMOREMuQ0EuU29ueS5Db20xJTAjBgNVBC4THElEbmFUdGVzQXpRbzdROFc4ckpuN09vUjJsND0wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDhvvQCyyUUMjNcWyPOOKUkN7rzEEM3XhxApzDMcmSqzCEvRYa6H4l7jd+Dgk0J9foUkpxeTR8ZYTOuV/AE7enm9lNR9RSUcIHxCVg1XWtmubHjlG8vX7IM88zyyrcCPGl6T6vU38mN4DkKG2C9D4QLeaWjrkf32w96JdjmdrmYZlBwZOOSBpBwYwJZoFi9/+b58BbW91B56965PNc58WiVJb+nUjDgEaBa1iiFMO/NHsS7RRH/YXfHhIw4jzltRBYrCzrCgJlIC0YXiq9ti13lgI7Rv01ItWslFbPmyOn603CX3amL5W3pfkYYFUe8YaWx0a3rR/Vj8h6NMoSkPZMZAgMBAAGjgdswgdgwCQYDVR0TBAIwADAOBgNVHQ8BAf8EBAMCBaAwHQYDVR0OBBYEFCA52k7XrAM0KO0PFvKyZ+zqEdpeMIGbBgNVHSMEgZMwgZCAFLHXNPodBh4FOxQGj6nNaq3xWxt7oW6kbDBqMRowGAYDVQQDExEuU29ueS5EQ1Jvb3RDQS52MTEMMAoGA1UECxMDUFJPMRcwFQYDVQQKEw5EQy5DQS5Tb255LkNvbTElMCMGA1UELgwcaTFvUTVaWk04L0hLM01GR2o5Q0I2dkExSlA0PYIIFFF3Mun2BycwDQYJKoZIhvcNAQELBQADggEBAB4jxAPKksqGuCCuRwZdfMC4VYXrpi4U/Qo9QGZRqHeVOO7uuO/mXCJz+ooSY6SUBDIdrf1MIN4wHC7CNEWHqnAwuLkdMZ79JOC5ne7oRQOtPKDR73/7iAgIbSK6g0zinDXUVI30XuvgOrusve9PzeFbQnao97+lnffTo2e1vZ4SQGeWFVqZeZ+6NtQ82/WWqS3mAYiJ1X9sAosTQw72dUsm3J6gvzhRm9Lly/fePs+WpIdd251w6DKm6lrdpASLmoNz496BOCzto1xqLoifN/nkIrPUGBj2dZeLVpe3UNBhtxY0r4STL+V8hslIs1262bD9hxwyMVuL/kWbs3Q9Qus=");
            actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            OutputCertificate(actual);

            // Sony.LMT-100.A00-000102
            rawData = Convert.FromBase64String("MIIESzCCAzOgAwIBAgIIPyw4qeM/RtYwDQYJKoZIhvcNAQEFBQAwcTEdMBsGA1UEAxMULlNvbnkuRENJSXNzdWVyQ0EudjExEDAOBgNVBAsTB1NvbnlEQ0kxFzAVBgNVBAoTDkRDLkNBLlNvbnkuQ29tMSUwIwYDVQQuDBxMOTFuT0pMMTd2VzAvdllnU3hrQUg0SFZ3ZDg9MB4XDTA1MTIyNzA0MzA1OVoXDTM1MTIyMDA0NDA1OVowdzEjMCEGA1UEAxMaU00uU29ueS5MTVQtMTAwLkEwMC0wMDAxMDIxEDAOBgNVBAsTB1NvbnlEQ0kxFzAVBgNVBAoTDkRDLkNBLlNvbnkuQ29tMSUwIwYDVQQuDBx1c3pLL2lJdjlGcWVsd0pJeEtHYUdmRHJMYWM9MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1AzKuRaUi7ZSYWO/D64j/f8Bv8qvNFeMT9I8D1zPz+6gIcaR+6f5jsm65RY7cF+Onh/YSp6vz1QzKnhMkaDC2LsoBh2MbHmUQxnNPsYu4mJK3P1XQkZDJixM/RLa07LA3YozTUnpitD1p4v91sfRvC8vxBDmmWKO2P1Neb3vWfJ7EMRdHD7MdPsf5bVJBlR+kiu9Qv3QT2lontrUbcKHFOz+7kGZS85aTG1kSR27UKTNq7Cl1eFmBAWpIPHHH+TLYwKEQ0SdZJgI6fz+aSwsyaKpBEz791pETZkFlNoJ+6AJECHyoQ+BMiSPJViATmmebXXQhf4q1U4nUcdn+nhylQIDAQABo4HgMIHdMAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgWgMB0GA1UdDgQWBBS6zMr+Ii/0Wp6XAkjEoZoZ8OstpzCBoAYDVR0jBIGYMIGVgBQv3Wc4kvXu9bT+9iBLGQAfgdXB36FzpHEwbzEbMBkGA1UEAxMSLlNvbnkuRENJUm9vdENBLnYxMRAwDgYDVQQLEwdTb255RENJMRcwFQYDVQQKEw5EQy5DQS5Tb255LkNvbTElMCMGA1UELgwcTnZQUjZzQXBpbENCeW53WWdvb0MvMHZyTzdjPYIIcjFftkdVjzwwDQYJKoZIhvcNAQEFBQADggEBAGu7Z7fn+Tj2ioBmHlqWVOKgvD7/+NVJFmGRU45uSaz2u8XJ7xF1d58cytCnAWP7K454gDj+2f7Y1n4qv6d5gLWPD/usiYVFgq4xquMgIb1CTb4RVNfusboTjyElYhO+brwPr9v4qz+3aGP3l+w1e6gQPs/tuIt4/npg0S+piM05eBB/D7CGIN4UMvndgPA8QkT2IcF9QvKmedV0I3qEIl2Tt454rfs3oJ5kA5dfLjtDwIjmtJoth0Bg1NiovRCQaUjDrD5VbLDcOlVlYNYvv0+14yY+SlHuY/xGbW35h33UHfU5yQg6B1NHjqV2mQl3e2NI3iXvwWeMqoz3XsDuJKg=");
            actual = X509CertificateClassLibrary_Accessor.BuildCertificate(rawData);
            OutputCertificate(actual);
        }
    }
}
