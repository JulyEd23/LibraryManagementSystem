using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYMANAGEMENTPART2
{
    public static class ViewModelLocator
    {
        private static MainViewModel _mainviewmodel;

        public static MainViewModel MAINVIEWMODEL
        {
            get
            {
                if(_mainviewmodel == null)
                {
                    _mainviewmodel = new MainViewModel();
                }
                return _mainviewmodel;
            }
        }
    }
}
