using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void create_btn_Click(object sender, EventArgs e)
    {
        alert_lbl.Text = ProduceCorrectMessage(message_box.Text);
    }

    private string ProduceCorrectMessage(string messageBodyText)
    {
        string correct_message = "";

        try
        {
            string txt = messageBodyText.Replace(" ", "");
            string user_msisdn = Regex.Match(txt, @"5[0-9]{2}[0-9]{7}").Value;

            string step1 = messageBodyText.Replace(user_msisdn, "");
            string user_text = Regex.Match(messageBodyText, @"[A-z^şŞıİçÇöÖüÜĞğ\s]*").Value;

            string step2 = step1.Replace(user_text, "");
            string user_age = ExtractAge(step2);
            
            string formatted_msisdn = FormatMsisdn(user_msisdn);
            string formatted_user_text = DeleteRepeatedSpaces(user_text);
            correct_message = formatted_user_text + user_age + " " + formatted_msisdn;

        }
        catch
        {
            //Log.Error( ex1.Message, ex1);
        }

        return correct_message;
    }
    private string ExtractAge(string user_age)
    {
        string CorrectAge = "";

        try
        {
            user_age = user_age.Replace(" ", "");
            CorrectAge = user_age.Substring(0, 2);

            if (user_age.StartsWith("+") || user_age.StartsWith("0") || user_age.StartsWith("9"))
                CorrectAge = user_age.Substring(user_age.Length - 2, 2);
        }
        catch
        {
            //Log.Error(ex1.Message, ex1);
        }

        return CorrectAge;
    }
    private string DeleteRepeatedSpaces(string text)
    {
        string FormattedText = "";
        try
        {
            FormattedText = Regex.Replace(text, @"\s+", " ");
        }
        catch
        {

        }
        return FormattedText;
    }

    private string FormatMsisdn(string msisdn)
    {
        string FormattedMsisdn = "";

        try
        {
            string m1 = msisdn.Substring(0, 3);
            string m2 = msisdn.Substring(3, 3);
            string m3 = msisdn.Substring(6, 2);
            string m4 = msisdn.Substring(8, 2);

            FormattedMsisdn = "0" + m1 + " " + m2 + " " + m3 + " " + m4;

        }
        catch
        {
            //Log.Error(ex1.Message, ex1);
        }

        return FormattedMsisdn;
    }
}