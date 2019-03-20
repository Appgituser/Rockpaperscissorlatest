using RockPaperScissor.Business;
using RockPaperScissor.Business.Implementation;
using RockPaperScissor.Business.Interfaces;
using System;
using System.Web;
using Unity;
public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// Page Load.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    ///
    private Gamer gamer;
    protected void Page_Load(object sender, EventArgs e)
    {

        ////Register Unity container
        IUnityContainer unitycontainer = new UnityContainer();

        unitycontainer.RegisterType<IGamer, Gamer>();

        //Resolve dependency
        gamer = unitycontainer.Resolve<Gamer>();

    }


    int userScore = 0;
    int comScore = 0;
   
    /// <summary>
    /// Method will matches with user input request.
    /// </summary>
    public void MatchSelection()
    {
        string input = string.Empty;
        int userinput = 0;
        if (RadioRock.Checked)
        {
            userinput = (int)Helper.UserInput.Rock;
        }
        else if (RadioPaper.Checked)
        {
            userinput = (int)Helper.UserInput.Paper;
        }
        else
        {
            userinput = (int)Helper.UserInput.Scissor;
        }

        var selection = gamer.GameSelection(userinput).Split(':');
        Label2.Text = selection[0];
        Label1.Text = selection[1];

    }

    /// <summary>
    /// Display the Final Result.
    /// </summary>
    public string DisplayResult()
    {
        int userCount = HttpContext.Current.Session["userount"] != null ? Convert.ToInt32(HttpContext.Current.Session["userount"]) : 0;
        int computerCount = HttpContext.Current.Session["Count"] != null ? Convert.ToInt32(HttpContext.Current.Session["Count"]) : 0;
        lblComScoreText.Visible = true;
        lblUserScoreTxt.Visible = true;
        lblComScoreText.Visible = true;
        lblComputer.Visible = true;
        lblUserScore.Visible = true;
        lblUserScore.Text = userCount.ToString();
        lblComputer.Text = computerCount.ToString();
        string result = gamer.DisplayResult(userCount, computerCount);

        if (HttpContext.Current.Session["TotalScore"] != null)
        {
            if (Convert.ToUInt32(HttpContext.Current.Session["TotalScore"]) == 3)
            {

                RadioScissor.Checked = false;
                RadioPaper.Checked = false;
                RadioRock.Checked = false;
                HttpContext.Current.Session["TotalScore"] = 0;
                HttpContext.Current.Session["userount"] = 0;
                HttpContext.Current.Session["Count"] = 0;
            }
        }

        return result;
    }

    /// <summary>
    /// Start Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StartGame_Click(object sender, EventArgs e)
    {
        if (RadioRock.Checked || RadioPaper.Checked || RadioScissor.Checked)
        {
            MatchSelection();
            Label1.Visible = true;
            Label2.Visible = true;
            lblfinalresult.Visible = true;
            lblfinalresult.Text = DisplayResult();
        }
    }
}