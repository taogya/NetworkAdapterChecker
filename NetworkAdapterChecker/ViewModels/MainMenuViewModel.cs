using System;
using System.Threading;

namespace NetworkAdapterChecker.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public MainMenuViewModel(DelegateCommand exportCommand)
        {
            ExportCommand = exportCommand;
        }

        private DelegateCommand? appExitCommand;
        /// <summary>
        /// アプリを閉じる
        /// </summary>
        public DelegateCommand AppExitCommand
        {
            get
            {
                appExitCommand ??= new DelegateCommand
                {
                    ExecuteHandler = (o) => Environment.Exit(0),
                };
                return appExitCommand;
            }
        }

        /// <summary>
        /// エクスポート
        /// </summary>
        public DelegateCommand ExportCommand { get; }
    }
}