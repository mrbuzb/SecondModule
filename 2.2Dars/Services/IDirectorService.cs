using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2Dars.Services;

public interface  IDirectorService
{
    public bool CheckDitrectorPassword(string login, string password);
    public void ChangeLogin();
}
