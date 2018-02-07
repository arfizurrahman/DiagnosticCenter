using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenter.BLL;
using DiagnosticCenter.DAL.Model;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using Control = System.Web.UI.Control;
using Header = System.Runtime.Remoting.Messaging.Header;

namespace DiagnosticCenter.UI
{
    public partial class TestRquestByPatient : System.Web.UI.Page
    {
        TestManager aTestManager = new TestManager();
        PatientManager aPatientManager = new PatientManager();
        PatientTestManager aPatientTestManager = new PatientTestManager();
        private string Name;
        private string contactNo ;
        private string code ;
        private string date;
        private string billNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                          
                string patientCode = Request.QueryString["PatientCode"];
                codeTextBox.Value = patientCode;

                List<TestVM> Tests = aTestManager.GetAllTest();
                selectTestDropDownList.DataSource = Tests;
                selectTestDropDownList.DataValueField = "Id";
                selectTestDropDownList.DataTextField = "Name";
                selectTestDropDownList.DataBind();

            }
            GetFee();
        }
        private void GetFee()
        {
            TestVM aTest = new TestVM();

            aTest.Name = selectTestDropDownList.SelectedItem.Text;
            double fee = aTestManager.GetSelectedTestFee(aTest);
            feeTextBox.Value = Convert.ToString(fee);
        }

        
        protected void addButton_Click(object sender, EventArgs e)
        {

            List<PatientTestVm> patientTests = AddTests();
            testEntryGridView.DataSource = patientTests;
            testEntryGridView.DataBind();
            double total = 0;
            foreach (PatientTestVm patientTestVm in patientTests)
            {
                total += patientTestVm.Fee;
            }

            totalTextBox.Value = total.ToString();
        }

        protected void selectTestDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFee();
        }
        public List<PatientTestVm> AddTests()
        {

            PatientTestVm aPatientVm = new PatientTestVm();
            aPatientVm.TestName = selectTestDropDownList.SelectedItem.Text;
            aPatientVm.TestId = Convert.ToInt32(selectTestDropDownList.SelectedValue);
            aPatientVm.Fee = Convert.ToDouble(feeTextBox.Value);

            if (ViewState["name"] == null)
            {

                List<PatientTestVm> tests = new List<PatientTestVm>();
                tests.Add(aPatientVm);
                ViewState["name"] = tests;
            }
            else
            {
                List<PatientTestVm> tests = (List<PatientTestVm>)ViewState["name"];
                tests.Add(aPatientVm);
                ViewState["name"] = tests;

            }
            return (List<PatientTestVm>)ViewState["name"];
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            
            
            PatientTestVm aPatientVm = new PatientTestVm();
            aPatientVm.Code = codeTextBox.Value;
            aPatientVm.PatientId = aPatientManager.GetPatientId(aPatientVm);
            int id = aPatientVm.PatientId;
            aPatientVm.EntryDate = DateTime.Now.ToString("yyyy-MM-dd");
            aPatientVm.TotalBill = Convert.ToDouble(totalTextBox.Value);
            string aNum = DateTime.Now.ToString("MMdd");
            aPatientVm.BillNo = "B" + aPatientVm.Code +aNum;
            date = aPatientVm.EntryDate;
             billNo = aPatientVm.BillNo;
            int rowAffected = aPatientTestManager.SaveIntoBill(aPatientVm);
            if (rowAffected > 0)
            {
                List<PatientTestVm> patientTest = (List<PatientTestVm>)ViewState["name"];
                
                foreach (PatientTestVm patientTestVM in patientTest)
                {
                    patientTestVM.PatientId = id;
                    patientTestVM.EntryDate = DateTime.Now.ToString("yyyy-MM-dd");
                    int rowAffected2 = aPatientTestManager.SaveInPatientTest(patientTestVM);

                }
                messageLabel.InnerText = "Saved successfully..";

            }
            else
            {
                messageLabel2.InnerText = "Saving failed";
            }


            Patient aPatient = aPatientManager.GetPatientForPdf(aPatientVm.PatientId);
            Name = aPatient.Name;
            contactNo = aPatient.ContactNo;
             code = aPatient.Code;
            
            GeneratePdf();

            }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        public void GeneratePdf()
        {
            

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Bill.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            
            StringWriter sw = new StringWriter();
            testEntryGridView.GridLines = GridLines.Both;
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            testEntryGridView.RenderControl(hw);
            
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 20f, 40f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            string header = "NS Diagnostic Centre";
            pdfDoc.Add(new Paragraph("                                                                   NS Diagnostic Centre        "));
            pdfDoc.Add(new Paragraph("                                                                --------------------------"));
            pdfDoc.Add(new Paragraph("                                                                       Bill Reciept"));

            pdfDoc.Add(new Paragraph("  Date: " + date));
            pdfDoc.Add(new Paragraph("  Bill NO: " + billNo));
            pdfDoc.Add(new Paragraph("  Name: " + Name));
            pdfDoc.Add(new Paragraph("  Code: "+ code));
            pdfDoc.Add(new Paragraph("  Mobile No: " + contactNo));
            pdfDoc.Add(new Paragraph("  "));
            htmlparser.Parse(sr);
            pdfDoc.Add(new Paragraph("                                                                                                    Total Amount : " + totalTextBox.Value));
            
            pdfDoc.Close();
            Response.Write(pdfDoc);

            Response.Flush();
            Response.End();

        }
    }
}