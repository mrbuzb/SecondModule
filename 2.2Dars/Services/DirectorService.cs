using _2._2Dars.Models;
using System.Text.Json;

namespace _2._2Dars.Services;

public class DirectorService : IDirectorService
{
    private string directorPath = "../../../Data/Director.json";



    private void SaveInform(List<Director> director)
    {
        

        var res = JsonSerializer.Serialize(director);
        File.WriteAllText(directorPath, res);
    }



    private List<Director> GetDirectorInformation()
    {

        var inform = File.ReadAllText(directorPath);
        var res = JsonSerializer.Deserialize<List<Director>>(inform);
        return res;
    }

    public bool CheckDitrectorPassword(string login, string password)
    {
        var resInfile = File.ReadAllText(directorPath);
        var res = JsonSerializer.Deserialize<List<Director>>(resInfile);


        if (login == res[0].Username && res[0].Password == password)
        {
            return true;
        }
        return false;
    }

    public void ChangeLogin()
    {
        var resInfile = File.ReadAllText(directorPath);
        var res = JsonSerializer.Deserialize<List<Director>>(resInfile);

        Console.Write("Enter New Login : ");
        var nLog = Console.ReadLine();
        res[0].Username = nLog;
        Console.Write("Enter New Password : ");
        var pass = Console.ReadLine();
        res[0].Password = pass;

        Console.WriteLine("Login Saved Succesfully!");
        SaveInform(res);
    }
}
