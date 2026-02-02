using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace yvirata
{
    class Program
    {
        static void Main()
        {
            Evidence evidence = new Evidence();
            KonzoleUI ui = new KonzoleUI(evidence);
            ui.Spustit();
        }
    }

}
