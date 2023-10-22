using System;
using System.Threading;

namespace NetworkAdapterChecker.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {

        private DelegateCommand? appExitCommand;

        /// <summary>
        /// アプリを閉じる
        /// </summary>
        public DelegateCommand AppExitCommand
        {
            get
            {
                if (appExitCommand == null)
                    appExitCommand = new DelegateCommand
                    {
                        ExecuteHandler = AppExit_Execute,
                        CanExecuteHandler = AppExit_CanExecute,
                    };
                return appExitCommand;
            }
        }

        private void AppExit_Execute(object parameter)
        {
            Environment.Exit(0);
        }


        private bool AppExit_CanExecute(object parameter)
        {
            return true;
        }
    }
}