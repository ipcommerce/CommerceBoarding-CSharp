using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Application = CB.Application;
using ExpiredTokenFault = STS.ExpiredTokenFault;
using InvalidTokenFault = STS.InvalidTokenFault;

namespace CommerceBoarding
{
    public partial class CommerceBoarding : Form
    {
        #region Variable Declarations
        public Helpers Helper = new Helpers();//The following class performs many of the different operations needs for service information and trasaction processing
        private static string _identityToken = "";
        private static string _applicationProfileId;
        private static Application _application;
        private static string _externalApplicationId = Guid.NewGuid().ToString();
        private static IdentityQuestions _identityQuestions;
        private static QualificationResult _qualificationResult;
        private static List<ApplicationSummary> _applicationSummaries = new List<ApplicationSummary>();
        public string DefaultFolder = "C:\\MW_Applications\\";
        public string FileName = "";
        public string Xmldetail = "";
        private string _crXmldetail = "";
        private string _creditReport = "";
        private readonly bool _customerDemoMode = false;
        public Application App = new Application();
        private static string _stsUri;
        private static string _restUri;
        public DateTime DtSessionToken; //Used by CheckTokenExpire() to determine when the session token needs to be updated
        private readonly bool _useRest;
        private readonly bool _useJson;
        private int _searchPage;
        private static  ScrollableMessageBox _scrollableMessageBox = new ScrollableMessageBox();
        #endregion Variable Declarations

        public CommerceBoarding()
        {
            InitializeComponent();
            qualResultsGrpBox.Visible = false;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CustomerDemoMode"]))
            {
                if (ConfigurationManager.AppSettings["CustomerDemoMode"].Equals("false"))
                    _customerDemoMode = false;
                if (ConfigurationManager.AppSettings["CustomerDemoMode"].Equals("true"))
                    _customerDemoMode = true;
            }
            if (_customerDemoMode)
            {
                tabControl1.TabPages.Remove(Authentication);
                lblCreateApplication.Text =
                    "Please review the sample values below for guidance on data entry for this application.  Where there are multiple choices for an entry please only type/use one of those values.\n\nPlease press \"Create Application\" after all data has been entered.  If there are any errors with the data that you have entered you can press the \"Show Validation Errors\" button to display those errors.  Please correct those errors and then click the \"Save Application\" button.";
                lblQualification.Text =
                    "The Begin Qualification button will submit the application to the backend services for processing. The qualification process may take up to sixty(60) seconds to complete. When the qualification process is complete the \"View Qualification Result\" button will appear.";
                appProfileId.Visible = false;
                appProfileIdLbl.Visible = false;

            }
            // Check to see if Idology is supported, if not hide Idology tab on form
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseIdology"]) &&
                (ConfigurationManager.AppSettings["UseIdology"].Equals("false")))
            {
                tabControl1.TabPages.Remove(IdentityVerification);
            }
            // Check to see if REST is supported
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseREST"]) &&
                (ConfigurationManager.AppSettings["UseREST"].Equals("true")))
            {
                _useRest = true;
                
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EnvironmentLabel"]))
            {
                environmentLbl.Text = ConfigurationManager.AppSettings["EnvironmentLabel"].ToString(CultureInfo.InvariantCulture); 

            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DefaultSaveDirectory"]))
            {
                DefaultFolder = ConfigurationManager.AppSettings["DefaultSaveDirectory"].ToString(CultureInfo.InvariantCulture);

            }
           
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["STSUri"]))
            {
                _stsUri = ConfigurationManager.AppSettings["STSUri"].ToString(CultureInfo.InvariantCulture);
                Helper.STSUri = _stsUri;

            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["RESTUri"]))
            {
                _restUri = ConfigurationManager.AppSettings["RESTUri"].ToString(CultureInfo.InvariantCulture);
                Helper.RESTUri = _restUri;

            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseJson"]) &&
                (ConfigurationManager.AppSettings["UseJson"].Equals("true")))
            {
                _useJson = true;
            }
            if (!string.IsNullOrEmpty((ConfigurationManager.AppSettings["ApplicationProfileId"])))
            {
                _applicationProfileId = (ConfigurationManager.AppSettings["ApplicationProfileId"]);
                appProfileId.Text = _applicationProfileId;
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["KeyValueForFileName"]))
            {
                FileName = ConfigurationManager.AppSettings["KeyValueForFileName"];
            }
            _scrollableMessageBox.Size = new Size(600, 400);
            
            Status.Text = Helper.Status;

        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["IdentityToken"]))
            {
                txtIdentityToken.Text = ConfigurationManager.AppSettings["IdentityToken"];
                _identityToken = ConfigurationManager.AppSettings["IdentityToken"];
                Helper.IdentityToken = _identityToken;
            }
            if (_customerDemoMode)
            {
                tabControl1.TabPages.Remove(Authentication);
                Helper.STSSignOn();
                Status.Text = Helper.Status;
            }

            string[] inputFields = ConfigurationManager.AppSettings["ListOfApplicationFields"].Split('|');
            foreach (string key in inputFields)
            {
                if (key != null) InputFields.Rows.Add(key);
            }
            
            ResetApplication();
        }

        private void ResetApplication()
        {
            qualResultBtn.Visible = false;
            btnSaveAppResultDetail.Visible = false;
            qualResultsGrpBox.Visible = false;
           // viewApplicationBtn.Visible = false;
            createBtn.Enabled = true;
            FileName = "";
            sfdSaveToFile = new SaveFileDialog();
            _externalApplicationId = Guid.NewGuid().ToString();
            _application = null;
            qualBtn.Enabled = true;
            applicationResultTxtBox.Text = "";
            answerQuestions.Enabled = true;
            getIdentityQuestions.Enabled = true;

        }

        private void defaultValues_Click(object sender, EventArgs e)
        {
            Helpers.SetDefaultSampleValues(InputFields);
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Gather the user data from the UI and set in the InputFields[].
            var inputFields = new InputField[InputFields.Rows.Count];
            for (int i = 0; i < InputFields.Rows.Count; i++)
            {
                if (InputFields.Rows[i].Cells[0].Value != null && InputFields.Rows[i].Cells[1].Value != null)
                {
                    inputFields[i] = new InputField
                                         {
                                             Key = InputFields.Rows[i].Cells[0].Value.ToString(),
                                             Value = InputFields.Rows[i].Cells[1].Value.ToString()
                                         };
                }
            }

            try
            {
                //An application has not been created yet for this merchant
                if (_application == null)
                {
                    CreateApplication(inputFields);

                    if (_application.Validation.IsValid)
                    {
                        //The application was created successfully and all data is Valid.  Call SaveApplication to prepare for 
                        //the Qualification process
                        SaveApplication(inputFields);
                    }
                }

                    //An application has already been created.  In this case, we want to update the application data.  
                    //You *must* call SaveApplication with a valid application before starting the Qualification process.
                else
                {
                    SaveApplication(inputFields);
                }

                if (_application != null)
                {
                    Status.Text = "Application created successfully.  Application Guid:  " +
                                  _application.ApplicationGuid;
                    

                    //The application was created/saved successfully, however not all data is valid.  Your application will need to allow the user to 
                    //update information and re-save the application.
                    if (!_application.Validation.IsValid)
                    {
                        showValidationErrors.Visible = true;
                        createBtn.Text = "Save Application";
                        MessageBox.Show("Application is not valid.  Please correct errors and save the application.");
                        Refresh();
                    }
                        //The application has passed data validation and is ready for the Qualification process
                    else
                    {
                        showValidationErrors.Visible = false;
                        createBtn.Enabled = false;
                        appGuidIdent.Text = _application.ApplicationGuid.ToString();
                        appGuidQual.Text = _application.ApplicationGuid.ToString();
                        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseIdology"]) && (ConfigurationManager.AppSettings["UseIdology"].Equals("false")))
                        {
                            Status.Text =
                                "The application has been saved and all data is valid.  You can begin the Qualification process.";
                            MessageBox.Show(Status.Text);
                            tabControl1.SelectedTab = Qualification;
                        }
                        else
                        {
                            Status.Text =
                                   "The application has been saved and all data is valid.  You can begin the Identity Verification process.";
                            MessageBox.Show(Status.Text);
                            tabControl1.SelectedTab = IdentityVerification;   
                        }
                    }
                }

                foreach (InputField inputField in inputFields)
                {
                    if (inputField.Key.ToString() == "BusinessName")
                    {
                        FileName = inputField.Value.ToString();
                        break;
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (FaultException<EmptyArgumentFault> ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:  " + ex.Detail.ErrorMessage, "Application Profile Id not set");
            }
            catch (FaultException<CommerceBoardingServiceUnavailableFault> ex)
            {
                Cursor.Current = Cursors.Default;
                _scrollableMessageBox.Show("Error:  " + ex.Detail.ErrorMessage);
            }
            catch (FaultException<UnknownApplicationProfileIdFault> ex)
            {
                Cursor.Current = Cursors.Default;
                _scrollableMessageBox.Show("Error:  " + ex.Detail.ErrorMessage, "Unknown Application Profile ID");
            }
            catch (FaultException<UnknownInputFieldFault> ex)
            {
                Cursor.Current = Cursors.Default;
                _scrollableMessageBox.Show("Error:  " + ex.Detail.ErrorMessage, "Unknown Input Field");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                _scrollableMessageBox.Show("Error:  " + ex.Message);
            }
        }

        private void CreateApplication(InputField[] inputFields)
        {
            Helper.CheckTokenExpire();
            Status.Text = Helper.Status;
            if (_useRest)
            {
                string body = "";
                string response = "";

                _application = Utilities.CreateJsonApplication(appProfileId.Text, _externalApplicationId, inputFields);
                if (!_useJson)
                {
                    body = Utilities.SerializeObject(_application);
                    response = Utilities.CreateRequest(_restUri + "/Applications", "POST", "xml", body, Helper.SessionToken, null);
                    _application = Utilities.DeserializeObject<Application>(response);
                }
                if (_useJson)
                {
                    body = JsonConvert.SerializeObject(_application);
                    response = Utilities.CreateRequest(_restUri + "/Applications", "POST", "json", body, Helper.SessionToken, null);
                    _application = JsonConvert.DeserializeObject<Application>(response);
                }
            }
            else
                _application = Helper.Cbc.CreateApplication(Helper.SessionToken, appProfileId.Text, _externalApplicationId,
                                                         inputFields);
        }

        private void SaveApplication(InputField[] inputFields)
        {

            Helper.CheckTokenExpire();
            _application.Fields = inputFields;
            
            if (_useRest)
            {
                string body = "";
                string response = "";
                _application.Created = null;
                if (!_useJson)
                {
                    body = Utilities.SerializeObject(_application);
                    response = Utilities.CreateRequest(_restUri + "/Applications/" + _application.ApplicationGuid, "PUT", "xml", body, Helper.SessionToken, null);
                    _application = Utilities.DeserializeObject<Application>(response);
                }
                if (_useJson)
                {
                    body = JsonConvert.SerializeObject(_application);
                    response = Utilities.CreateRequest(_restUri + "/Applications/" + _application.ApplicationGuid, "PUT", "json", body, Helper.SessionToken, null);
                    _application = JsonConvert.DeserializeObject<Application>(response);
                }
               
            }
            else
                _application = Helper.Cbc.SaveApplication(Helper.SessionToken, _application);
        }

        private void showValidationErrors_Click(object sender, EventArgs e)
        {
            string details = "";
            foreach (var detail in _application.Validation.ValidationDetails)
            {
                if (!detail.IsFieldValid)
                    details += detail.Messages.First() + Environment.NewLine;
            }

            MessageBox.Show(details, "Application Validation Error Details");
        }

        private void getIdentityQuestions_Click(object sender, EventArgs e)
        {
            Helper.CheckTokenExpire();
            if (_useRest)
            {
                string response = "";
                if(!_useJson)
                {
                    response = Utilities.CreateRequest(_restUri + "/Applications/" + appGuidIdent.Text + "/IDQuestions", "POST", "xml", null, Helper.SessionToken, null);
                    _identityQuestions = Utilities.DeserializeObject<IdentityQuestions>(response);
                }
                if(_useJson)
                {
                    response = Utilities.CreateRequest(_restUri + "/Applications/" + appGuidIdent.Text + "/IDQuestions", "POST", "json", null, Helper.SessionToken, null);
                    _identityQuestions = JsonConvert.DeserializeObject<IdentityQuestions>(response);
                }

               
            }
            else
                _identityQuestions = Helper.Cbc.GetIdQuestions(Helper.SessionToken, appGuidIdent.Text);

            //Your application should dynamically present the questions and answers to the end user.
            if (_identityQuestions.Questions != null)
            {
                if (_identityQuestions.Questions.Count() >= 3)
                {
                    question1.Text = _identityQuestions.Questions[0].Question;
                    q1ans1.Text = _identityQuestions.Questions[0].Answers[0];
                    q1ans2.Text = _identityQuestions.Questions[0].Answers[1];
                    q1ans3.Text = _identityQuestions.Questions[0].Answers[2];

                    question2.Text = _identityQuestions.Questions[1].Question;
                    q2ans1.Text = _identityQuestions.Questions[1].Answers[0];
                    q2ans2.Text = _identityQuestions.Questions[1].Answers[1];
                    q2ans3.Text = _identityQuestions.Questions[1].Answers[2];

                    question3.Text = _identityQuestions.Questions[2].Question;
                    q3ans1.Text = _identityQuestions.Questions[2].Answers[0];
                    q3ans2.Text = _identityQuestions.Questions[2].Answers[1];
                    q3ans3.Text = _identityQuestions.Questions[2].Answers[2];
                }

                getIdentityQuestions.Enabled = false;
                answerQuestions.Enabled = true;
                questionsPanel.Visible = true;
            }
            else
            {
                Status.Text = "Identity verification questions are not available with your service bundle.";
            }
        }

        private void answerQuestions_Click(object sender, EventArgs e)
        {
            Helper.CheckTokenExpire();
            //Set the user's answers on the IdentityQuestions object

            _identityQuestions.Questions[0].SelectedAnswer = q1ans1.Checked
                                                                 ? 0
                                                                 : q1ans2.Checked ? 1 : q1ans3.Checked ? 2 : -1;
            _identityQuestions.Questions[1].SelectedAnswer = q2ans1.Checked
                                                                 ? 0
                                                                 : q2ans2.Checked ? 1 : q2ans3.Checked ? 2 : -1;
            _identityQuestions.Questions[2].SelectedAnswer = q3ans1.Checked
                                                                 ? 0
                                                                 : q3ans2.Checked ? 1 : q3ans3.Checked ? 2 : -1;


            if (_useRest)
            {
                if (!_useJson)
                {
                    string json = Utilities.SerializeObject(_identityQuestions);
                    string response =
                        Utilities.CreateRequest(
                            _restUri + "/Applications/" + _application.ApplicationGuid + "/IDQuestions/" +
                            _identityQuestions.QuestionsId, "PUT", "xml", json, Helper.SessionToken, null);
                    var result = Utilities.DeserializeObject<bool>(response);
                    Status.Text = result
                  ? "The user has passed Identity Verification"
                  : "The user has failed Identity Verification";
                }
                if (_useJson)
                {
                    string json = JsonConvert.SerializeObject(_identityQuestions);
                    string response =
                        Utilities.CreateRequest(
                            _restUri + "/Applications/" + _application.ApplicationGuid + "/IDQuestions/" +
                            _identityQuestions.QuestionsId, "PUT", "json", json, Helper.SessionToken, null);
                    var result = JsonConvert.DeserializeObject<bool>(response);
                    Status.Text = result
                  ? "The user has passed Identity Verification"
                  : "The user has failed Identity Verification";
                }

            }
            else
            {
                var result = Helper.Cbc.AnswerIdQuestions(Helper.SessionToken, _application.ApplicationGuid.ToString(),
                                                       _identityQuestions);
                Status.Text = result
                  ? "The user has passed Identity Verification"
                  : "The user has failed Identity Verification";
            }

            MessageBox.Show("The user has passed Identity Verification.\n\nYou can begin the Qualification process.");
            tabControl1.SelectedTab = Qualification;
        }

        private void qualBtn_Click(object sender, EventArgs e)
        {
            Helper.CheckTokenExpire();
            bool result;
            Cursor.Current = Cursors.WaitCursor;
            string response = "";
            if (_useRest)
            {
               
                if (_application != null)
                    _application.Created = null;
                if (!_useJson)
                {
                    Utilities.CreateRequest(_restUri + "/Applications/" + appGuidQual.Text + "/Result", "POST", "xml", null, Helper.SessionToken, null);
                    
                }
                if(_useJson)
                {
                    Utilities.CreateRequest(_restUri + "/Applications/" + appGuidQual.Text + "/Result", "POST", "json", null, Helper.SessionToken, null);
                }
                Status.Text = "The Qualification process has been started";
                
            }
            else
                Helper.Cbc.BeginQualification(Helper.SessionToken, appGuidQual.Text);
            Status.Text = "The Qualification process has been started";

            //The Qualification process may take several minutes to complete, based on the number of 
            //qualifiers you have defined in your partner configuration, and the response time of the 
            //external services.  
            Thread.Sleep(30000);
            bool inProgress = true;
            int inProgressCnt = 0;

            while (inProgress)
            {
                inProgressCnt++;
               
                if (_useRest)
                {
                    if (!_useJson)
                    {
                        response = Utilities.CreateRequest(_restUri + "/Applications/" + appGuidQual.Text + "/Result",
                                                           "GET", "xml", null, Helper.SessionToken, null);
                        _qualificationResult = Utilities.DeserializeObject<QualificationResult>(response);
                    }
                    if (_useJson)
                    {
                        response = Utilities.CreateRequest(_restUri + "/Applications/" + appGuidQual.Text + "/Result",
                                                           "GET", "json", null, Helper.SessionToken, null);
                        _qualificationResult = JsonConvert.DeserializeObject<QualificationResult>(response);
                    }
                }
                else
                    _qualificationResult = Helper.Cbc.GetQualificationResult(Helper.SessionToken, appGuidQual.Text);

                if (_qualificationResult.ApplicationStatus == ApplicationStatusEnum.QualificationComplete)
                    inProgress = false;
                if (response.Contains("Qualification is already complete for this application."))
                    inProgress = false;
            }
            
            if (response.Contains("Qualification is already complete for this application."))
                Status.Text = "Qualification is already complete for this application.";
            else
                Status.Text = "The Qualification process has completed successfully ";
            qualBtn.Enabled = false;
            qualResultBtn.Visible = true;
            btnSaveAppResultDetail.Visible = true;
            btnSaveCreditReport.Visible = true;
            //viewApplicationBtn.Visible = true;
            Cursor.Current = Cursors.Default;
            if (inProgressCnt == 20)
            {
                Status.Text = "Qualification could not be started successfully.  Please contact IPC Support Staff.";
                MessageBox.Show(Status.Text);
                inProgress = false;
            }
        }

        private void qualResultBtn_Click(object sender, EventArgs e)
        {
            decisionLbl.Text = "";
            appStatusLbl.Text = "";
            qlfyDecisionLbl.Text = "";
            identityResultLbl.Text = "";
            

            decisionLbl.Text = _qualificationResult.Decision.ToString();
            appStatusLbl.Text = _qualificationResult.ApplicationStatus.ToString();
            qlfyDecisionLbl.Text = _qualificationResult.QualifyDecision.ToString();

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseIdology"]) &&
               (ConfigurationManager.AppSettings["UseIdology"].Equals("false")))
            {
                identResultLabel.Visible = false;
                identityResultLbl.Visible = false;
            }
            else
            {
                identResultLabel.Visible = true;
                identityResultLbl.Visible = true;
                identityResultLbl.Text = _qualificationResult.IdentityResult.ToString();
            }

            qualResultsGrpBox.Visible = true;
            Status.Text = "Application process complete";
            ShowApplicationDetail();
        }

        private ApplicationSummaries searchApps(int page)
        {
            Helper.CheckTokenExpire();
            Cursor = Cursors.WaitCursor;
            ApplicationSummaries appSummaries = new ApplicationSummaries();
            
            try
            {
                SearchParameters searchParameters = new SearchParameters();

                searchParameters.FirstName = searchFirstName.Text;
                searchParameters.LastName = searchLastName.Text;
                searchParameters.EmailAddress = searchEmail.Text;
                searchParameters.PageSize = 50;
                searchParameters.PageNumber = page;

                searchParameters.QualificationStatus =
                    (QualificationStatusEnum)
                    (searchQualificationStatus.Text != "--" &&
                     !string.IsNullOrWhiteSpace(searchQualificationStatus.Text)
                         ? Enum.Parse(typeof(QualificationStatusEnum),
                                      searchQualificationStatus.Text)
                         : QualificationStatusEnum.NotSet);

                searchParameters.ApplicationStatus =
                    (ApplicationStatusEnum)
                    (searchAppStatus.Text != "--" && !string.IsNullOrWhiteSpace(searchAppStatus.Text)
                         ? Enum.Parse(typeof(ApplicationStatusEnum), searchAppStatus.Text)
                         : ApplicationStatusEnum.NotSet);

                searchParameters.IdentityStatus =
                    (IdentityStatusEnum)
                    (searchIdentityStatus.Text != "--" && !string.IsNullOrWhiteSpace(searchIdentityStatus.Text)
                         ? Enum.Parse(typeof(IdentityStatusEnum), searchIdentityStatus.Text)
                         : IdentityStatusEnum.NotSet);

                if (searchDates.Checked)
                {
                    searchParameters.SearchFromDate = searchDateFrom.Value.Date.ToUniversalTime();
                    searchParameters.SearchThroughDate = searchDateThrough.Value.ToUniversalTime();
                }
                if (_useRest)
                {
                    string request = "";
                    JObject sp = null;
                    string queryString = "";
                    queryString = "?";
                    if (_useJson)
                    {
                        request = JsonConvert.SerializeObject(searchParameters);
                        sp = JObject.Parse(request);

                        if ((string)sp["ApplicationProfileId"] != null)
                            queryString = queryString + "appProfileId=" + (string)sp["ApplicationProfileId"];
                        if ((int)sp["ApplicationStatus"] != 0)
                            queryString = queryString + "&appStatus=" + (int)sp["ApplicationStatus"];
                        if ((string)sp["FirstName"] != "")
                            queryString = queryString + "&fName=" + (string)sp["FirstName"];
                        if ((string)sp["LastName"] != "")
                            queryString = queryString + "&lName=" + (string)sp["LastName"];
                        if ((string)sp["EmailAddress"] != "")
                            queryString = queryString + "&email=" + (string)sp["EmailAddress"];
                        if ((int)sp["QualificationStatus"] != 0)
                            queryString = queryString + "&qualStatus=" + (int)sp["QualificationStatus"];
                        if ((int)sp["IdentityStatus"] != 0)
                            queryString = queryString + "&identStatus=" + (int)sp["IdentityStatus"];
                        queryString = queryString + "&pageNum=" + (int)sp["PageNumber"];
                        queryString = queryString + "&pageSize=" + (int)sp["PageSize"];
                    }
                    if (!_useJson)
                    {
                        if (searchParameters.ApplicationProfileId != null)
                            queryString = queryString + "appProfileId=" + searchParameters.ApplicationProfileId;
                        if (searchParameters.ApplicationStatus != null)
                            queryString = queryString + "&appStatus=" + searchParameters.ApplicationStatus;
                        if (searchParameters.FirstName != "")
                            queryString = queryString + "&fName=" + searchParameters.FirstName;
                        if (searchParameters.LastName != "")
                            queryString = queryString + "&lName=" + searchParameters.LastName;
                        if (searchParameters.EmailAddress != "")
                            queryString = queryString + "&email=" + searchParameters.EmailAddress;
                        if (searchParameters.QualificationStatus != null)
                            queryString = queryString + "&qualStatus=" + searchParameters.QualificationStatus;
                        if (searchParameters.IdentityStatus != null)
                            queryString = queryString + "&identStatus=" + searchParameters.IdentityStatus;
                        queryString = queryString + "&pageNum=" + searchParameters.PageNumber;
                        queryString = queryString + "&pageSize=" + searchParameters.PageSize;
                    }



                    if (searchDates.Checked)
                    {
                        queryString = "?fromDate=" + searchParameters.SearchFromDate.Value.ToShortDateString();
                        queryString = queryString + "&throughDate=" +
                                      searchParameters.SearchThroughDate.Value.ToShortDateString();
                    }
                    if (!_useJson)
                    {
                        string response = Utilities.CreateRequest(_restUri + "/Applications"
                                                                  + queryString, "GET", "xml", null, Helper.SessionToken,
                                                                  null);
                        appSummaries = Utilities.DeserializeObject<ApplicationSummaries>(response);
                    }
                    if (_useJson)
                    {
                        string response = Utilities.CreateRequest(_restUri + "/Applications"
                                                                  + queryString, "GET", "json", null, Helper.SessionToken,
                                                                  null);
                        appSummaries = JsonConvert.DeserializeObject<ApplicationSummaries>(response);
                    }
                }
                else
                    appSummaries = Helper.Cbc.ListApplications(Helper.SessionToken, searchParameters);

                return appSummaries;
            }
            catch (FaultException<ExpiredTokenFault>)
            {
                MessageBox.Show("Your session token has expired.  Please authenticate with STS.");
            }
            catch (FaultException<InvalidTokenFault>)
            {
                MessageBox.Show("Your session token is invalid.");
            }
            catch (FaultException<MissingSearchParameterFault>)
            {
                MessageBox.Show("You must search by at least one Search Parameter.");
            }
            Cursor = Cursors.Default;
            return null;

        }
        
        private void addAppSummariesToGrid(ApplicationSummaries applicationSummaries)
        {
            //Display the data 
            for (int i = 0; i < applicationSummaries.Summaries.Count(); i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.Cells.Add(new DataGridViewTextBoxCell());
                newRow.Cells.Add(new DataGridViewTextBoxCell());
                newRow.Cells.Add(new DataGridViewTextBoxCell());
                newRow.Cells.Add(new DataGridViewTextBoxCell());
                newRow.Cells.Add(new DataGridViewButtonCell());
                newRow.Cells.Add(new DataGridViewButtonCell());
                newRow.Cells[0].Value = applicationSummaries.Summaries[i].Created.ToString();
                newRow.Cells[1].Value = applicationSummaries.Summaries[i].ApplicationGuid;
                if (applicationSummaries.Summaries[i].BusinessName != null)
                    newRow.Cells[2].Value = applicationSummaries.Summaries[i].BusinessName;
                else
                {
                    newRow.Cells[2].Value = applicationSummaries.Summaries[i].ApplicantLastName + ", " +
                                            applicationSummaries.Summaries[i].ApplicantFirstName;
                }
                newRow.Cells[3].Value = applicationSummaries.Summaries[i].QualificationStatusEnum.ToString();
                newRow.Cells[4].Value = "View Application Results";
                newRow.Cells[5].Value = "View Application Inputs";
                listApps.Rows.Add(newRow);
            }
        }
        
        private void pageApplications(ApplicationSummaries applicationSummaries)
        {
            foreach (ApplicationSummary summary in applicationSummaries.Summaries)
            {
                _applicationSummaries.Add(summary);
            }
            if (applicationSummaries.Summaries.Count() == 50)
            {
                _searchPage++;
                //applicationSummaries = new ApplicationSummaries();
                applicationSummaries = searchApps(_searchPage);
                addAppSummariesToGrid(applicationSummaries);
                pageApplications(applicationSummaries);
            }

        }
        
        private void listAppsBtn_Click(object sender, EventArgs e)
        {
            Helper.CheckTokenExpire();
            listApps.Rows.Clear();
            _searchPage = 0;
            _applicationSummaries.Clear();
            ApplicationSummaries applicationSummaries = new ApplicationSummaries();
            applicationSummaries = searchApps(_searchPage);
            
            if (applicationSummaries != null)
            {
                if (!applicationSummaries.Summaries.Any())
                    Status.Text = "No applications found with this search criteria";
                else
                {
                    Status.Text = "List Applications completed successfully";
                    addAppSummariesToGrid(applicationSummaries);
                }

                pageApplications(applicationSummaries);
            }

            Cursor = Cursors.Default;
            Status.Text = _applicationSummaries.Count.ToString() + " Applications Returned.";
        }

        private void listApps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckTokenExpire();
            ApplicationDetailResponse appResponse = new ApplicationDetailResponse();
            string detail = "";
            var xmlResult = new ApplicationDetail();
            if (e.ColumnIndex == 5)
            {

                //Call GetApplication to retrieve the application by the ApplicationGuid
                if (_useRest)
                {
                    var result = new ApplicationDetail();
                    if (!_useJson)
                    {

                        string response =
                            Utilities.CreateRequest(
                                _restUri + "/Applications/" +
                                _applicationSummaries[e.RowIndex].ApplicationGuid.ToString(), "GET", "xml",
                                null,
                                Helper.SessionToken, null);

                        result = Utilities.DeserializeObject<ApplicationDetail>(response);
                        xmlResult = result;

                    }
                    if (_useJson)
                    {

                        string response =
                            Utilities.CreateRequest(
                                _restUri + "/Applications/" +
                                _applicationSummaries[e.RowIndex].ApplicationGuid.ToString(), "GET", "json",
                                null,
                                Helper.SessionToken, null);

                        result = JsonConvert.DeserializeObject<ApplicationDetail>(response);
                        xmlResult = result;
                    }

                    detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                             "Application Validation State:  " + result.Validation.IsValid + Environment.NewLine +
                             "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine;
                    if (result.Validation.ValidationDetails.Any())
                    {
                        foreach (var thisValidationDetail in result.Validation.ValidationDetails)
                        {
                            detail += "Validation Field Name: " + thisValidationDetail.FieldName + " - Is Valid? " +
                                      thisValidationDetail.IsFieldValid + Environment.NewLine;
                            if (thisValidationDetail.Messages != null)
                            {
                                detail = thisValidationDetail.Messages.Aggregate(detail,
                                                                                 (current, thisMessage) =>
                                                                                 current +
                                                                                 ("Validation Message: " + thisMessage +
                                                                                  Environment.NewLine));
                            }

                        }
                    }
                }
                else
                {
                    var result = Helper.Cbc.GetApplication(Helper.SessionToken,
                                                        _applicationSummaries[e.RowIndex].ApplicationGuid.
                                                            ToString());
                    
                    detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                             "Application Validation State:  " + result.Validation.IsValid + Environment.NewLine +
                             "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine;
                    if (_applicationSummaries[e.RowIndex].BusinessName != null)
                        FileName = _applicationSummaries[e.RowIndex].BusinessName.ToString();
                    else
                    {
                        FileName = _applicationSummaries[e.RowIndex].ApplicantLastName + "_" +
                                    _applicationSummaries[e.RowIndex].ApplicantFirstName;
                    }
                    //_fileName = _fileName + "_" + _applicationSummaries.Summaries[e.RowIndex].ApplicationGuid.ToString() + ".xml";

                    if (result.Validation.ValidationDetails.Any())
                    {
                        foreach (var thisValidationDetail in result.Validation.ValidationDetails)
                        {
                            detail += "Validation Field Name: " + thisValidationDetail.FieldName + " - Is Valid? " +
                                      thisValidationDetail.IsFieldValid + Environment.NewLine;
                            if (thisValidationDetail.Messages != null)
                            {
                                detail = thisValidationDetail.Messages.Aggregate(detail,
                                                                                 (current, thisMessage) =>
                                                                                 current +
                                                                                 ("Validation Message: " + thisMessage +
                                                                                  Environment.NewLine));
                            }

                        }
                    }
                }
                MemoryStream memoryStream = new MemoryStream();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                XmlSerializer x = new XmlSerializer(xmlResult.GetType());
                x.Serialize(xmlTextWriter, xmlResult);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                UTF8Encoding encoding = new UTF8Encoding();
                Xmldetail = encoding.GetString(memoryStream.ToArray());
                Xmldetail = Xmldetail.Substring(1);
                _scrollableMessageBox.Show(Xmldetail);
            }

            if (e.ColumnIndex == 4)
            {
                //Call GetApplicationDetail for a summary of information on an application
                if (_useRest)
                {
                    var result = new ApplicationDetail();
                    if (!_useJson)
                    {
                        string response =
                            Utilities.CreateRequest(
                                _restUri + "/Applications/" +
                                _applicationSummaries[e.RowIndex].ApplicationGuid.ToString() + "/Detail",
                                "GET", "xml", null, Helper.SessionToken, null);

                        result = Utilities.DeserializeObject<ApplicationDetail>(response);
                        xmlResult = result;
                    }
                    if (_useJson)
                    {
                        string response =
                            Utilities.CreateRequest(
                                _restUri + "/Applications/" +
                                _applicationSummaries[e.RowIndex].ApplicationGuid.ToString() + "/Detail",
                                "GET", "json", null, Helper.SessionToken, null);

                        result = JsonConvert.DeserializeObject<ApplicationDetail>(response);
                        xmlResult = result;
                    }

                    detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                             "Application Status:  " + result.ApplicationStatus + Environment.NewLine +
                             "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine +
                             "Identity Status:  " + result.IdentityStatus + Environment.NewLine +
                             "Qualification Status:  " + result.QualificationStatus + Environment.NewLine;

                    if (result.QualifierResponses.Count() > 0)
                    {
                        foreach (var thisResponse in result.QualifierResponses)
                        {
                            detail += "Qualifier Name: " + thisResponse.QualifierName + " - Key: " +
                                      thisResponse.ResponseKey + " Value:  " + thisResponse.ResponseValue +
                                      Environment.NewLine;
                        }
                    }
                    MemoryStream memoryStream = new MemoryStream();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    XmlSerializer x = new XmlSerializer(xmlResult.GetType());
                    x.Serialize(xmlTextWriter, xmlResult);
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    UTF8Encoding encoding = new UTF8Encoding();
                    Xmldetail = encoding.GetString(memoryStream.ToArray());
                    Xmldetail = Xmldetail.Substring(1);
                    _scrollableMessageBox.Show(Xmldetail);
                }
                else
                {
                    var result = Helper.Cbc.GetApplicationDetail(Helper.SessionToken,
                                                              _applicationSummaries[e.RowIndex].
                                                                  ApplicationGuid.
                                                                  ToString());
                    xmlResult = result;
                    App = result;
                    detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                             "Application Status:  " + result.ApplicationStatus + Environment.NewLine +
                             "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine +
                             "Identity Status:  " + result.IdentityStatus + Environment.NewLine +
                             "Qualification Status:  " + result.QualificationStatus + Environment.NewLine;
                    if (_applicationSummaries[e.RowIndex].BusinessName != null)
                        FileName = _applicationSummaries[e.RowIndex].BusinessName.ToString();
                    else
                    {
                        FileName = _applicationSummaries[e.RowIndex].ApplicantLastName + "_" +
                                    _applicationSummaries[e.RowIndex].ApplicantFirstName;
                    }
                    FileName = FileName + "_" + _applicationSummaries[e.RowIndex].ApplicationGuid.ToString();

                    _creditReport = getResponseValue(result, "CreditReport");

                    appResponse.ApplicationGuid = result.ApplicationGuid.ToString();
                    appResponse.ApplicationStatus = result.ApplicationStatus.ToString();
                    appResponse.CreatedDate = result.Created.ToString();
                    appResponse.ExternalApplicationId = result.ExternalApplicationId;
                    appResponse.IdentityStatus = result.IdentityStatus.ToString();
                    appResponse.InputFields = result.Fields;
                    appResponse.QualifierResponses = result.QualifierResponses;
                    appResponse.QualificationStatus = result.QualificationStatus.ToString();
                    appResponse.SortQualifierResponses();


                    if (result.QualifierResponses.Count() > 0)
                    {
                        foreach (var thisResponse in result.QualifierResponses)
                        {
                            detail += "Qualifier Name: " + thisResponse.QualifierName + " - Key: " +
                                      thisResponse.ResponseKey + " Value:  " + thisResponse.ResponseValue +
                                      Environment.NewLine;
                        }
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(appResponse.BuildApplicationResponseOutput());
                    MemoryStream memoryStream = new MemoryStream();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    XmlSerializer x = new XmlSerializer(doc.GetType());
                    x.Serialize(xmlTextWriter, doc);
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    UTF8Encoding encoding = new UTF8Encoding();
                    Xmldetail = encoding.GetString(memoryStream.ToArray());
                    Xmldetail = Xmldetail.Substring(1);
                    _scrollableMessageBox.Show(Xmldetail);
                    SaveToFile(Xmldetail);

                    MemoryStream crMemoryStream = new MemoryStream();
                    XmlTextWriter crXmlTextWriter = new XmlTextWriter(crMemoryStream, Encoding.UTF8);
                    XmlSerializer crx = new XmlSerializer(_creditReport.GetType());
                    crx.Serialize(crXmlTextWriter, _creditReport);
                    crMemoryStream = (MemoryStream)crXmlTextWriter.BaseStream;
                    UTF8Encoding crEncoding = new UTF8Encoding();
                    _crXmldetail = crEncoding.GetString(crMemoryStream.ToArray());
                    
                    _crXmldetail = _crXmldetail.Replace("&lt;", "<");
                    _crXmldetail = _crXmldetail.Replace("&gt;", ">");
                    _crXmldetail = _crXmldetail.Substring(1);
                    _crXmldetail = _crXmldetail.Replace("<string>", "");
                    _crXmldetail = _crXmldetail.Replace("</string>", "");
                    FileName = FileName + "_CreditReport";
                    SaveToFile(_crXmldetail); 

                    if (checkBox1.Checked)
                    {
                        string log = result.Log.ToString();
                        log = log.Replace("\n", Environment.NewLine);
                        ScrollableMessageBox logBox = new ScrollableMessageBox();
                        logBox.Show(log);
                    }
                    if (saveToLogChkBx.Checked)
                    {
                        FileName = FileName.Replace("_CreditReport", "_LOG");
                        SaveToFile(result.Log.ToString());
                    }
                }
            }
        }

        private void btnViewApplication_Click(object sender, EventArgs e)
        {
            ShowApplication();
        }

        private void btnSaveAppResultDetail_Click(object sender, EventArgs e)
        {
            //Clipboard.SetData(DataFormats.StringFormat, applicationResultTxtBox.Text);
            SaveToFile(applicationResultTxtBox.Text);
        }

        private void btnSaveCreditReport_Click(object sender, EventArgs e)
        {
            MemoryStream crMemoryStream = new MemoryStream();
            XmlTextWriter crXmlTextWriter = new XmlTextWriter(crMemoryStream, Encoding.UTF8);
            XmlSerializer crx = new XmlSerializer(_creditReport.GetType());
            crx.Serialize(crXmlTextWriter, _creditReport);
            crMemoryStream = (MemoryStream)crXmlTextWriter.BaseStream;
            UTF8Encoding crEncoding = new UTF8Encoding();
            _crXmldetail = crEncoding.GetString(crMemoryStream.ToArray());

            _crXmldetail = _crXmldetail.Replace("&lt;", "<");
            _crXmldetail = _crXmldetail.Replace("&gt;", ">");
            _crXmldetail = _crXmldetail.Substring(1);
            _crXmldetail = _crXmldetail.Replace("<string>", "");
            _crXmldetail = _crXmldetail.Replace("</string>", "");
            FileName = FileName + "_CreditReport";
            SaveToFile(_crXmldetail);
        }
       
        private void ShowApplicationDetail()
        {
            applicationResultTxtBox.Text = "";
            Helper.CheckTokenExpire();
            ApplicationDetailResponse appResponse = new ApplicationDetailResponse();
            string detail = "";
            var xmlResult = new ApplicationDetail();
            //Call GetApplicationDetail for a summary of information on an application
            if (_useRest)
            {
                var result = new ApplicationDetail();
                if (!_useJson)
                {
                    string response =
                        Utilities.CreateRequest(
                            _restUri + "/Applications/" +
                            appGuidQual.Text + "/Detail",
                            "GET", "xml", null, Helper.SessionToken, null);

                    result = Utilities.DeserializeObject<ApplicationDetail>(response);
                    xmlResult = result;
                    App = result;
                }
                if (_useJson)
                {
                    string response =
                        Utilities.CreateRequest(
                            _restUri + "/Applications/" +
                            appGuidQual.Text + "/Detail",
                            "GET", "json", null, Helper.SessionToken, null);

                    result = JsonConvert.DeserializeObject<ApplicationDetail>(response);
                    xmlResult = result;
                    App = result;
                }

                detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                         "Application Status:  " + result.ApplicationStatus + Environment.NewLine +
                         "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine +
                         "Identity Status:  " + result.IdentityStatus + Environment.NewLine +
                         "Qualification Status:  " + result.QualificationStatus + Environment.NewLine;

                if (result.QualifierResponses.Count() > 0)
                {
                    foreach (var thisResponse in result.QualifierResponses)
                    {
                        detail += "Qualifier Name: " + thisResponse.QualifierName + " - Key: " +
                                  thisResponse.ResponseKey + " Value:  " + thisResponse.ResponseValue +
                                  Environment.NewLine;
                    }
                }
            }
            else
            {
                var result = Helper.Cbc.GetApplicationDetail(Helper.SessionToken, appGuidQual.Text);
                
                
                App = result;
                detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                         "Application Status:  " + result.ApplicationStatus + Environment.NewLine +
                         "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine +
                         "Identity Status:  " + result.IdentityStatus + Environment.NewLine +
                         "Qualification Status:  " + result.QualificationStatus + Environment.NewLine;
                creditScoreLbl.Text = getResponseValue(result, "CreditScore");
                _creditReport = getResponseValue(result, "CreditReport");

                appResponse.ApplicationGuid = result.ApplicationGuid.ToString();
                appResponse.ApplicationStatus = result.ApplicationStatus.ToString();
                appResponse.CreatedDate = result.Created.ToString();
                appResponse.ExternalApplicationId = result.ExternalApplicationId;
                appResponse.IdentityStatus = result.IdentityStatus.ToString();
                appResponse.InputFields = result.Fields;
                appResponse.QualifierResponses = result.QualifierResponses;
                appResponse.QualificationStatus = result.QualificationStatus.ToString();
				appResponse.SortQualifierResponses();
                if (result.QualifierResponses.Count() > 0)
                {
                    foreach (var thisResponse in result.QualifierResponses)
                    {
                        detail += "Qualifier Name: " + thisResponse.QualifierName + " - Key: " +
                                  thisResponse.ResponseKey + " Value:  " + thisResponse.ResponseValue +
                                  Environment.NewLine;

                    }
                }
                result.Log = null;
                
                //result.LogField = null;
                xmlResult = result;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(appResponse.BuildApplicationResponseOutput());
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            XmlSerializer x = new XmlSerializer(xmlResult.GetType());
            x.Serialize(xmlTextWriter, xmlResult);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            UTF8Encoding encoding = new UTF8Encoding();
            Xmldetail = encoding.GetString(memoryStream.ToArray());
            Xmldetail = Xmldetail.Substring(1);

            applicationResultTxtBox.Text = Xmldetail;
        }
        
        private string getResponseValue(ApplicationDetail detail, string keyValue)
        {
            string responseValue = "";
            foreach (QualifierResponse qr in detail.QualifierResponses)
            {
                if (qr.ResponseKey.ToString() == keyValue)
                {
                    responseValue = qr.ResponseValue.ToString();
                    break;
                }
            }
            return responseValue;
        }
		
        private void ShowApplication()
        {
            applicationResultTxtBox.Text = "";
            Helper.CheckTokenExpire();
            string detail = "";
            var xmlResult = new Application();
            //Call GetApplication to retrieve the application by the ApplicationGuid
            if (_useRest)
            {
                var result = new Application();
                if (!_useJson)
                {

                    string response =
                        Utilities.CreateRequest(
                            _restUri + "/Applications/" +
                            appGuidQual.Text, "GET", "xml",
                            null,
                            Helper.SessionToken, null);

                    result = Utilities.DeserializeObject<Application>(response);
                    xmlResult = result;
                }
                if (_useJson)
                {

                    string response =
                        Utilities.CreateRequest(
                            _restUri + "/Applications/" +
                            appGuidQual.Text, "GET", "json",
                            null,
                            Helper.SessionToken, null);

                    result = JsonConvert.DeserializeObject<Application>(response);
                    xmlResult = result;
                }

                detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                         "Application Validation State:  " + result.Validation.IsValid + Environment.NewLine +
                         "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine;
                if (result.Validation.ValidationDetails.Any())
                {
                    foreach (var thisValidationDetail in result.Validation.ValidationDetails)
                    {
                        detail += "Validation Field Name: " + thisValidationDetail.FieldName + " - Is Valid? " +
                                  thisValidationDetail.IsFieldValid + Environment.NewLine;
                        if (thisValidationDetail.Messages != null)
                        {
                            detail = thisValidationDetail.Messages.Aggregate(detail,
                                                                             (current, thisMessage) =>
                                                                             current +
                                                                             ("Validation Message: " + thisMessage +
                                                                              Environment.NewLine));
                        }

                    }
                }
            }
            else
            {
                var result = Helper.Cbc.GetApplication(Helper.SessionToken, appGuidQual.Text);
                xmlResult = result;
                detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                         "Application Validation State:  " + result.Validation.IsValid + Environment.NewLine +
                         "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine;
                if (result.Validation.ValidationDetails.Any())
                {
                    foreach (var thisValidationDetail in result.Validation.ValidationDetails)
                    {
                        detail += "Validation Field Name: " + thisValidationDetail.FieldName + " - Is Valid? " +
                                  thisValidationDetail.IsFieldValid + Environment.NewLine;
                        if (thisValidationDetail.Messages != null)
                        {
                            detail = thisValidationDetail.Messages.Aggregate(detail,
                                                                             (current, thisMessage) =>
                                                                             current +
                                                                             ("Validation Message: " + thisMessage +
                                                                              Environment.NewLine));
                        }

                    }
                }
            }

            
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            XmlSerializer x = new XmlSerializer(xmlResult.GetType());
            x.Serialize(xmlTextWriter, xmlResult);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            UTF8Encoding encoding = new UTF8Encoding();
            Xmldetail = encoding.GetString(memoryStream.ToArray());
            Xmldetail = Xmldetail.Substring(1);

            applicationResultTxtBox.Text = Xmldetail;
        }

        private void resetApplicationBtn_Click(object sender, EventArgs e)
        {
            ResetApplication();
            Helpers.ResetApplicationFields(InputFields);
        }

        public void SaveToFile(string appToSave)
        {

            if (MessageBox.Show(
                "NOTE: The following \"Save\" function will save Personally Identifiable Information(PII) to your local disk.  Please ensure the security of your system and securely destroy these files when you are finished.  Click \"OK\" to proceed with saving this data.",
                "WARNING!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    if (!Directory.Exists(DefaultFolder))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(DefaultFolder);
                    }
                }
                catch (Exception e)
                {

                }

                //Save the Project Summary
                if (DefaultFolder.Length > 0)
                    sfdSaveToFile.InitialDirectory = DefaultFolder;
                if (appGuidQual.Text != "")
                    sfdSaveToFile.FileName = FileName + "_" + appGuidQual.Text.ToString() + ".xml";
                else
                    sfdSaveToFile.FileName = FileName + ".xml";
               

                if (sfdSaveToFile.FileName.Contains("_LOG"))
                    sfdSaveToFile.FileName = sfdSaveToFile.FileName.Replace("xml", "txt");
                //_defaultFolder = sfdSaveToFile.InitialDirectory;

                sfdSaveToFile.ShowDialog();

                string filename = "";
                filename = sfdSaveToFile.FileName.ToString();

              


                try
                {
                    if (appToSave != null)
                    {
                        //XmlSerializer xs = new XmlSerializer(appToSave.GetType());

                        #region Write to File

                        File.WriteAllText(filename, appToSave);

                        ////<?xml version="1.0" encoding="utf-8"?>
                        ////Todo-Note : Write to File 
                        //Stream fs = new FileStream(_defaultFolder, FileMode.Create);
                        //XmlWriter writer = new XmlTextWriter(fs, Encoding.UTF8);
                        //xs.Serialize(writer, appToSave);
                        //writer.Close();

                        #endregion Write to file
                    }
                    DefaultFolder = sfdSaveToFile.InitialDirectory;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

                finally
                {
                    sfdSaveToFile.Dispose();
                }
            }
        }

        private void SignOn_Click(object sender, EventArgs e)
        {
            Helper.STSSignOn();
            Status.Text = Helper.Status;
            SignOn.Enabled = false;
        }

        private void getAppBtn_Click(object sender, EventArgs e)
        {
            Helper.CheckTokenExpire();
            ApplicationDetailResponse appResponse = new ApplicationDetailResponse();
            string detail = "";
            var xmlResult = new ApplicationDetail();
            if (adminAppGuidTxt.Text != "")
            {
                //Call GetApplicationDetail for a summary of information on an application
                if (_useRest)
                {
                    var result = new ApplicationDetail();
                    if (!_useJson)
                    {
                        string response =
                            Utilities.CreateRequest(
                                _restUri + "/Applications/" +
                                adminAppGuidTxt.Text + "/Detail",
                                "GET", "xml", null, Helper.SessionToken, null);

                        result = Utilities.DeserializeObject<ApplicationDetail>(response);
                        xmlResult = result;
                    }
                    if (_useJson)
                    {
                        string response =
                            Utilities.CreateRequest(
                                _restUri + "/Applications/" +
                                adminAppGuidTxt.Text + "/Detail",
                                "GET", "json", null, Helper.SessionToken, null);

                        result = JsonConvert.DeserializeObject<ApplicationDetail>(response);
                        xmlResult = result;
                    }

                    detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                             "Application Status:  " + result.ApplicationStatus + Environment.NewLine +
                             "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine +
                             "Identity Status:  " + result.IdentityStatus + Environment.NewLine +
                             "Qualification Status:  " + result.QualificationStatus + Environment.NewLine;

                    if (result.QualifierResponses.Count() > 0)
                    {
                        foreach (var thisResponse in result.QualifierResponses)
                        {
                            detail += "Qualifier Name: " + thisResponse.QualifierName + " - Key: " +
                                      thisResponse.ResponseKey + " Value:  " + thisResponse.ResponseValue +
                                      Environment.NewLine;
                        }
                    }
                    MemoryStream memoryStream = new MemoryStream();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    XmlSerializer x = new XmlSerializer(xmlResult.GetType());
                    x.Serialize(xmlTextWriter, xmlResult);
                    memoryStream = (MemoryStream) xmlTextWriter.BaseStream;
                    UTF8Encoding encoding = new UTF8Encoding();
                    Xmldetail = encoding.GetString(memoryStream.ToArray());
                    Xmldetail = Xmldetail.Substring(1);
                    _scrollableMessageBox.Show(Xmldetail);
                }
                else
                {
                    var result = Helper.Cbc.GetApplicationDetail(Helper.SessionToken, adminAppGuidTxt.Text);
                    xmlResult = result;
                    App = result;
                    detail = "Application Detail for " + result.ApplicationGuid + Environment.NewLine +
                             "Application Status:  " + result.ApplicationStatus + Environment.NewLine +
                             "External Application ID:  " + result.ExternalApplicationId + Environment.NewLine +
                             "Identity Status:  " + result.IdentityStatus + Environment.NewLine +
                             "Qualification Status:  " + result.QualificationStatus + Environment.NewLine;



                    _creditReport = getResponseValue(result, "CreditReport");

                    appResponse.ApplicationGuid = result.ApplicationGuid.ToString();
                    appResponse.ApplicationStatus = result.ApplicationStatus.ToString();
                    appResponse.CreatedDate = result.Created.ToString();
                    appResponse.ExternalApplicationId = result.ExternalApplicationId;
                    appResponse.IdentityStatus = result.IdentityStatus.ToString();
                    appResponse.InputFields = result.Fields;
                    appResponse.QualifierResponses = result.QualifierResponses;
                    appResponse.QualificationStatus = result.QualificationStatus.ToString();
                    appResponse.SortQualifierResponses();

                    FileName = appResponse.BusinessName + "_" + adminAppGuidTxt.Text;

                    if (result.QualifierResponses.Count() > 0)
                    {
                        foreach (var thisResponse in result.QualifierResponses)
                        {
                            detail += "Qualifier Name: " + thisResponse.QualifierName + " - Key: " +
                                      thisResponse.ResponseKey + " Value:  " + thisResponse.ResponseValue +
                                      Environment.NewLine;
                        }
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(appResponse.BuildApplicationResponseOutput());
                    MemoryStream memoryStream = new MemoryStream();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    XmlSerializer x = new XmlSerializer(doc.GetType());
                    x.Serialize(xmlTextWriter, doc);
                    memoryStream = (MemoryStream) xmlTextWriter.BaseStream;
                    UTF8Encoding encoding = new UTF8Encoding();
                    Xmldetail = encoding.GetString(memoryStream.ToArray());
                    Xmldetail = Xmldetail.Substring(1);
                    _scrollableMessageBox.Show(Xmldetail);
                    SaveToFile(Xmldetail);

                    MemoryStream crMemoryStream = new MemoryStream();
                    XmlTextWriter crXmlTextWriter = new XmlTextWriter(crMemoryStream, Encoding.UTF8);
                    XmlSerializer crx = new XmlSerializer(_creditReport.GetType());
                    crx.Serialize(crXmlTextWriter, _creditReport);
                    crMemoryStream = (MemoryStream) crXmlTextWriter.BaseStream;
                    UTF8Encoding crEncoding = new UTF8Encoding();
                    _crXmldetail = crEncoding.GetString(crMemoryStream.ToArray());

                    _crXmldetail = _crXmldetail.Replace("&lt;", "<");
                    _crXmldetail = _crXmldetail.Replace("&gt;", ">");
                    _crXmldetail = _crXmldetail.Substring(1);
                    _crXmldetail = _crXmldetail.Replace("<string>", "");
                    _crXmldetail = _crXmldetail.Replace("</string>", "");
                    FileName = FileName + "_CreditReport";
                    SaveToFile(_crXmldetail);
                }
            }
            else
                MessageBox.Show("You must provide an Application GUID to search by.");
        }
    }
}