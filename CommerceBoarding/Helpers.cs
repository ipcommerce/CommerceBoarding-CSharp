using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CB;
using STS;
using Application = CB.Application;
using ApplicationDetail = CB.ApplicationDetail;

namespace CommerceBoarding
{
    public class Helpers
    {
        private static CommerceBoardingClient _client = new CommerceBoardingClient();
        private static TokenCredSignOnServiceClient _stsClient = new TokenCredSignOnServiceClient();
        private static string _sessionToken = ""; //The sessionToken lives for only 30 minutes. The CheckTokenExpire() method below rotates this value after 25 minutes as elapsed. 
        private static string _identityToken = "Please contact IP Commerce http://www.ipcommerce.com"; //The identity token is the primary token used to gain access to CWS. This value expires every 3 year or if a security breach is detected. You application need to have a way to update this value at any time. 
        public static DateTime DtSessionToken; //Used by CheckTokenExpire() to determine when the session token needs to be updated
        private static bool _useREST = false;
        private static bool _useJSON = false;
        private static string _STSUri;
        private static string _RESTUri;
        private static bool failed;
        private static string code;
        private static string description;
        private static string _status;
        private static string _businessName;

        public static DataGridView SetDefaultSampleValues(DataGridView dataGrid)
        {
            DataGridView dataGridView = dataGrid;
            //This helper method will set test data in the grid for testing purposes      
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    switch (row.Cells[0].Value.ToString())
                    {
                        case "ApplicantEmailAddress":
                            row.Cells[1].Value = "test@ipcommerce.com";
                            break;
                        case "IpAddress":
                            row.Cells[1].Value = "72.1.99.52";
                            break;
                        case "ApplicationType":
                            row.Cells[1].Value = "Loan";
                            break;
                        case "BusinessName":
                            row.Cells[1].Value = "IP Commerce, Inc";
                            break;
                        case "BusinessLegalName":
                            row.Cells[1].Value = "Test Legal Business Name";
                            break;
                        case "BusinessDBAName":
                            row.Cells[1].Value = "IP Commerce";
                            break;
                        case "OwnershipType":
                            row.Cells[1].Value = "Choices Are: Sole Proprietorship, Corporation, LLC, Non-Profit, Other";
                            break;
                        case "BusinessType":
                            row.Cells[1].Value = "What type of business?";
                            break;
                        case "Aba":
                            row.Cells[1].Value = "123123123";
                            break;
                        case "Dda":
                            row.Cells[1].Value = "111111111";
                            break;
                        case "URL":
                            row.Cells[1].Value = "www.ipcommerce.com";
                            break;
                        case "BusinessEstablishmentDate":
                            row.Cells[1].Value = new DateTime(1999, 12, 31).ToString();
                            break;
                        case "FedTaxID":
                            row.Cells[1].Value = "111222333";
                            break;
                        case "BusinessAddress1":
                            row.Cells[1].Value = "1001 17th Street";
                            break;
                        case "BusinessAddress2":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessCity":
                            row.Cells[1].Value = "Denver";
                            break;
                        case "BusinessState":
                            row.Cells[1].Value = "CO";
                            break;
                        case "BusinessZip":
                            row.Cells[1].Value = "80202";
                            break;
                        case "BusinessPhone":
                            row.Cells[1].Value = "3035555013";
                            break;
                        case "BusinessUrl":
                            row.Cells[1].Value = "ipcommerce.com";
                            break;
                        case "HomeAddress1":
                            row.Cells[1].Value = "5581 Vermont";
                            break;
                        case "HomeAddress2":
                            row.Cells[1].Value = null;
                            break;
                        case "HomeCity":
                            row.Cells[1].Value = "Melbourne";
                            break;
                        case "HomeState":
                            row.Cells[1].Value = "FL";
                            break;
                        case "HomeZip":
                            row.Cells[1].Value = "32904";
                            break;
                        case "HomePhone":
                            row.Cells[1].Value = "3214445555";
                            break;
                        case "ApplicantFirstName":
                            row.Cells[1].Value = "Rowena";
                            break;
                        case "ApplicantLastName":
                            row.Cells[1].Value = "Ranger";
                            break;
                        case "DateOfBirth":
                            row.Cells[1].Value = "10/31/1971";
                            break;
                        case "SocialSecurityNumber":
                            row.Cells[1].Value = "666988162";
                            break;
                        case "EstimatedCreditCardIncome":
                            row.Cells[1].Value = "1-5000/month, 5001-10000/month, Over 10000/month";
                            break;

                    }
                }
            }
            return dataGridView;
        }

        public static DataGridView ResetApplicationFields(DataGridView dataGrid)
        {
            DataGridView dataGridView = dataGrid;
            //This helper method will set test data in the grid for testing purposes      
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    switch (row.Cells[0].Value.ToString())
                    {
                        case "ApplicantEmailAddress":
                            row.Cells[1].Value = "";
                            break;
                        case "IpAddress":
                            row.Cells[1].Value = "";
                            break;
                        case "ApplicationType":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessName":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessLegalName":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessDBAName":
                            row.Cells[1].Value = "";
                            break;
                        case "OwnershipType":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessType":
                            row.Cells[1].Value = "";
                            break;
                        case "Aba":
                            row.Cells[1].Value = "";
                            break;
                        case "Dda":
                            row.Cells[1].Value = "";
                            break;
                        case "URL":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessEstablishmentDate":
                            row.Cells[1].Value = "";
                            break;
                        case "FedTaxID":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessAddress1":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessAddress2":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessCity":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessState":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessZip":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessPhone":
                            row.Cells[1].Value = "";
                            break;
                        case "BusinessUrl":
                            row.Cells[1].Value = "";
                            break;
                        case "HomeAddress1":
                            row.Cells[1].Value = "";
                            break;
                        case "HomeAddress2":
                            row.Cells[1].Value = "";
                            break;
                        case "HomeCity":
                            row.Cells[1].Value = "";
                            break;
                        case "HomeState":
                            row.Cells[1].Value = "";
                            break;
                        case "HomeZip":
                            row.Cells[1].Value = "";
                            break;
                        case "HomePhone":
                            row.Cells[1].Value = "";
                            break;
                        case "ApplicantFirstName":
                            row.Cells[1].Value = "";
                            break;
                        case "ApplicantLastName":
                            row.Cells[1].Value = "";
                            break;
                        case "DateOfBirth":
                            row.Cells[1].Value = "";
                            break;
                        case "SocialSecurityNumber":
                            row.Cells[1].Value = "";
                            break;
                        case "EstimatedCreditCardIncome":
                            row.Cells[1].Value = "";
                            break;

                    }
                }
            }
            return dataGridView;
        }

        public void CheckTokenExpire()
        {
            if (DateTime.UtcNow.Subtract(DtSessionToken).TotalMinutes > 25)//Use 25 as the baseline for renewing session tokens
            {
                try
                {
                    STSSignOn();
                    DtSessionToken = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    string strErrorId;
                    string strErrorMessage;
                    Exception e = new Exception("Unable to Refresh a new Token");
                    throw e;
                }
            }
        }

        public void STSSignOn()
        {
            if (_useREST)
            {
                try
                {
                    _status = "Calling STS SignOn";
                    HttpWebRequest request = Utilities.CreateRequest(STSUri + "/token", "GET", _identityToken);
                    if (_useJSON)
                        request.ContentType = "application/json";
                    if (!_useJSON)
                        request.ContentType = "application/xml";

                    _sessionToken = Utilities.GetResponse(request, "", out failed, out code, out description);

                    char[] MyChar = {'"'};
                    if (_useJSON)
                    {
                        _sessionToken = _sessionToken.TrimStart(MyChar);
                        _sessionToken = _sessionToken.TrimEnd(MyChar);
                    }
                    if(!_useJSON)
                    {
                        _sessionToken = Utilities.DeserializeObject<string>(_sessionToken);
                    }
                    if (!failed)
                    {
                        _status = "You have successfully signed on to the IP Commerce Platform";
                        //SignOn.Enabled = false;
                    }
                    else
                    {
                        _status = "An error occurred when signing on - HTTP Code: " + code.ToString() +
                                      " - Description: " + description;
                        //SignOn.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("An error occurred when signing on:  {0}", ex.Message));
                }
            }
            else
            {


                try
                {
                    _status = "Calling STS SignOn";
                    _sessionToken = _stsClient.SignOn(_identityToken);
                    _status = "You have successfully signed on to the IP Commerce Platform";
                    //SignOn.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("An error occurred when signing on:  {0}", ex.Message));
                }
            }
        }



        #region Class Properties

        public string SessionToken
        {
            get { return _sessionToken; }
            set { _sessionToken = value; }
        }
        public string IdentityToken
        {
            get { return _identityToken; }
            set { _identityToken = value.Trim(); }
        }
       
        public CommerceBoardingClient Cbc
        {
            get { return _client; }
            set { _client = value; }
        }
        public TokenCredSignOnServiceClient Tcssc
        {
            get { return _stsClient; }
            set { _stsClient = value; }
        }
        public bool UseREST
        {
            get { return _useREST; }
            set { _useREST = value; }
        }
        public string STSUri
        {
            get { return _STSUri; }
            set { _STSUri = value; }
        }
        public string RESTUri
        {
            get { return _RESTUri; }
            set { _RESTUri = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion END Class Properties
    }



    public class ApplicationDetailResponse
    {
        private static QualifierResponse[] _qualifierResponses;
        private static InputField[] _inputFields;
        private static string _applicationGuid = "";
        private static string _applicationStatus = "";
        private static string _identityStatus = "";
        private static string _qualificationStatus = "";
        private static string _createdDate = "";
        private static string _externalApplicationId = "";
        private static string _businessName;

        public string BuildApplicationResponseOutput()
        {
            string appResponse = "";
            appResponse = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ApplicationResponseDetail xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
            appResponse = appResponse + "<Details>";
            appResponse = appResponse + "<InputField><InputKey>ApplicationGuid</InputKey><InputValue>" + _applicationGuid + "</InputValue></InputField>";
            appResponse = appResponse + "<InputField><InputKey>ApplicationStatus</InputKey><InputValue>" + _applicationStatus + "</InputValue></InputField>";
            appResponse = appResponse + "<InputField><InputKey>IdentityStatus</InputKey><InputValue>" + _identityStatus + "</InputValue></InputField>";
            appResponse = appResponse + "<InputField><InputKey>QualificationStatus</InputKey><InputValue>" + _qualificationStatus + "</InputValue></InputField>";
            appResponse = appResponse + "<InputField><InputKey>ApplicationCreated</InputKey><InputValue>" + _createdDate + "</InputValue></InputField>";
            appResponse = appResponse + "<InputField><InputKey>ExternalApplicationId</InputKey><InputValue>" + _externalApplicationId + "</InputValue></InputField>";

            int i = _inputFields.Count();
            for (int j = 0; j < i; j++ )
            {
                appResponse = appResponse + "<InputField><InputKey>" + _inputFields[j].Key + "</InputKey><InputValue>" +
                              (_inputFields[j].Value != null ? _inputFields[j].Value.Replace("&", "&amp;") : null) +
                              "</InputValue></InputField>";
                if (_inputFields[j].Key == "BusinessName")
                    _businessName = _inputFields[j].Value;
            }
            int q = _qualifierResponses.Count();
            for (int l = 0; l < q; l++)
            {
                if (_qualifierResponses[l].ResponseKey != "CreditReport")
                {
                    _qualifierResponses[l].ResponseValue = _qualifierResponses[l].ResponseValue.Replace("<", "&lt;");
                    _qualifierResponses[l].ResponseValue = _qualifierResponses[l].ResponseValue.Replace(">", "&gt;");
                    appResponse = appResponse + "<QualifierResponse><QualifierName>" +
                                  _qualifierResponses[l].QualifierName + "</QualifierName><ResponseKey>" +
                                  _qualifierResponses[l].ResponseKey + "</ResponseKey><ResponseValue>" +
                                  _qualifierResponses[l].ResponseValue + "</ResponseValue></QualifierResponse>";
                }
            }

            appResponse = appResponse + "</Details></ApplicationResponseDetail>";

            appResponse = appResponse.Replace(" & ", " &amp; ");
            return appResponse;
        }
         
        public void SortQualifierResponses()
        {
            foreach (QualifierResponse qualifierResponse in _qualifierResponses)
            {
                if(qualifierResponse.QualifierName == "Consistency")
                {
                    qualifierResponse.QualifierName = "Personal Info Check";
                }
            }
            var sorted = _qualifierResponses.OrderBy(QualifierResponses => QualifierResponses.QualifierName);
            var sortedArray = sorted.ToArray();
            _qualifierResponses = sortedArray;

        }
        public QualifierResponse[] QualifierResponses
        {
            get { return _qualifierResponses; }
            set { _qualifierResponses = value; }
        }
        public InputField[] InputFields
        {
            get { return _inputFields; }
            set { _inputFields = value; }
        }
        public string ApplicationGuid
        {
            get { return _applicationGuid; }
            set { _applicationGuid = value; }
        }
        public string ApplicationStatus
        {
            get { return _applicationStatus; }
            set { _applicationStatus = value; }
        }
        public string IdentityStatus
        {
            get { return _identityStatus; }
            set { _identityStatus = value; }
        }
        public string QualificationStatus
        {
            get { return _qualificationStatus; }
            set { _qualificationStatus = value; }
        }
        public string CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }

        public string ExternalApplicationId
        {
            get { return _externalApplicationId; }
            set { _externalApplicationId = value; }
        }
    }

    internal static class Utilities
    {
        internal static Application CreateXMLApplication(string applicationProfileId, string externalApplicationId, InputField[] inputFields)
        {
            Application app = new Application();
            app.ApplicationProfileId = applicationProfileId;
            app.ExternalApplicationId = externalApplicationId;
            app.Fields = inputFields;
            return app;
        }
        internal static Application CreateJsonApplication(string applicationProfileId, string externalApplicationId, InputField[] inputFields)
        {
            Application app = new Application();
            app.ApplicationProfileId = applicationProfileId;
            app.ExternalApplicationId = externalApplicationId;
            app.Fields = inputFields;
            return app;
        }

        public static string CreateRequest(string _url, string _method, string _contentType, string _body, string _UserName, string _UserPassword)
        {
            //http://msdn.microsoft.com/en-us/library/bb969540(office.12).aspx
            //http://www.daniweb.com/forums/thread241233.html
            //http://stackoverflow.com/questions/897782/how-to-add-custom-http-header-for-c-web-service-client-consuming-axis-1-4-web-se

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = _method; //Valid values are "GET", "POST", "PUT" and "DELETE"
                request.UserAgent =
                    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50215)";
                request.ContentType = "application/" + _contentType;
                string ContentLength = "";
                if (_body != null)
                {
                    if (_body.Length > 0)
                        ContentLength = "\r\nContent-Length: " + request.ContentLength;
                    if (_body.Length <= 0)
                        request.ContentLength = 0;
                }
                else if (_body == null)
                    request.ContentLength = 0;
                request.Timeout = 1000 * 60;
                //Authorization is made up of UserName and Password in the format [UserName]:[Password]. In this case the identity token is the only value set and is the [UserName]
                String _Authorization = "Basic " +
                                        Convert.ToBase64String(Encoding.ASCII.GetBytes(_UserName + ":" + _UserPassword));
                request.Headers.Add(HttpRequestHeader.Authorization, _Authorization);

                //Capture the basical header information. Using a proxy sniffer would be prefered however this helps to capture most information.

                string _HeaderInformation = _method + " " + ContentLength + request.Address.AbsolutePath + request.Address.Query +
                                            "\r\n" + request.Headers.ToString().Trim() + "\r\nHost: " +
                                            request.Address.Host + "\r\n\r\n";

                if (_body != null)
                {
                    if (_body.Length > 0)
                    {
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(_body);
                        writer.Close();
                    }
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream data = response.GetResponseStream())
                {
                    try
                    {
                        string text = new StreamReader(data).ReadToEnd();

                        return text;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        data.Close();
                    }
                }
            }
            catch (System.Net.WebException ex2)
            {
                //Lets get the webException returned in the response
                using (Stream data2 = ex2.Response.GetResponseStream())
                {
                    try
                    {
                        string text = new StreamReader(data2).ReadToEnd();
                        return text;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        data2.Close();
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


        public static string GetResponse(HttpWebRequest request, string content, out bool failed, out string code, out string description)
        {
            code = "";
            description = "";
            failed = false;
            string responseStr = string.Empty;

            try
            {
                Console.WriteLine("Request Uri: " + request.RequestUri);
                Console.WriteLine("Request Method: " + request.Method);
                Console.WriteLine("Request Header 'Authorization': Basic " + request.Headers["Authorization"]);
                Console.WriteLine("Content Type: " + request.ContentType);
                Console.WriteLine("Request Body: " + content);
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    Console.WriteLine("Status:  " + response.StatusDescription);
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    responseStr = reader.ReadToEnd();
                    Console.WriteLine("Response:  " + responseStr);
                    Console.WriteLine("Location:  " + response.Headers["Location"]);
                    reader.Close();
                    response.Close();
                }
            }
            catch (WebException we)
            {
                failed = true;
                if (we.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse r = (HttpWebResponse)we.Response;

                    code = r.StatusCode.ToString();
                    description = r.StatusDescription;

                    StreamReader reader = new StreamReader(r.GetResponseStream());
                    responseStr = reader.ReadToEnd();

                    reader.Close();
                    r.Close();
                }
                else
                    Console.WriteLine(we.Message + " " + we.Status);
            }


            catch (Exception ex)
            {
                failed = true;
                Console.WriteLine("Error:" + ex.Message);
            }

            return responseStr;
        }


        internal static HttpWebRequest CreateRequest(string uri, string method, string secret)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = method;

            if (!string.IsNullOrEmpty(secret))
                request.Headers.Add("Authorization", secret);

            return request;
        }

        internal static string AddXmlAttribute(string xml, string attribute)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader("@" + xml).ToString());
            XmlElement root = doc.DocumentElement;
            root.SetAttribute("xmlns", attribute);
            return doc.InnerXml;
        }
        /// <summary>
        /// Serialize an object into an XML string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string SerializeObject<T>(T obj)
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                XmlWriter xmlWriter = XmlWriter.Create(sb, settings);

                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                ser.WriteObject(xmlWriter, obj);
                xmlWriter.Flush();

                string xml = sb.ToString();
                return xml;
            }
            catch
            {
                return string.Empty;
            }

        }
        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        internal static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }
        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        internal static Byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
        /// <summary>
        /// Reconstruct an object from an XML string
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        internal static T DeserializeObject<T>(string xml)
        {
            xml = xml.Replace(" xmlns=\"http://schemas.ipcommerce.com/CommerceBoarding/v1.0\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            xml = xml.Replace(" i:nil=\"true\"", "");
            xml = xml.Replace(" xmlns:a=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\"", "");
            xml = xml.Replace("a:", "");
            xml = xml.Replace(" xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\"", "");
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)xs.Deserialize(memoryStream);
        }

    }
}
