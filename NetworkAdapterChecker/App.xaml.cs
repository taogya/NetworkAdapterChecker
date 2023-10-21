using NetworkAdapterChecker.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkAdapterChecker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// コマンド引数解析を行う
        /// ライセンスに問題なければ、MIT LicenseのCommandLineParserを使うことを推奨
        /// </summary>
        public class CommandOptions
        {
            public bool Help { get; private set; } = false;

            public void PrintHelp()
            {
                Console.WriteLine($"Description of {Name}");
                Console.WriteLine($"    {Name} [-h]");
                Console.WriteLine($"        -h: show help.");
            }

            public CommandOptions() : this(new string[0]) { }
            public CommandOptions(string[] args)
            {
                Help = args.Contains("-h");
            }
        }

#if DEBUG
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
#endif
        public static string Name { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public static Mutex Mutex = new(false, App.Name);
        public static CommandOptions Options = new();

        public static void GetArgument(string[] args)
        {

        }

        /// <summary>
        /// 重複起動しているか
        /// </summary>
        /// <returns>true: 重複起動</returns>
        public static bool IsDuplicateRunning()
        {
            bool ret =　!App.Mutex.WaitOne(0, false);
            // 重複起動時はMutexを閉じる
            if (ret) App.Mutex.Close();

            Console.WriteLine($"AppName: {App.Name}");
            Console.WriteLine($"Duplicate: {ret}");

            return ret;
        }

        /// <summary>
        /// 表示する言語の取得
        /// </summary>
        /// <returns>表示する言語のResourceDictionary</returns>
        public static ResourceDictionary GetLanguage()
        {
            var cultureCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            return GetLanguage(cultureCode);
        }

        /// <summary>
        /// 表示する言語の取得
        /// </summary>
        /// <param name="cultureCode"></param>
        /// <returns>表示する言語のResourceDictionary</returns>
        public static ResourceDictionary GetLanguage(string cultureCode)
        {
            var dictionary = new ResourceDictionary();
            try
            {
                var uri = GlobalSettings.GetLanguagePath(cultureCode);
                dictionary.Source = new Uri(uri, UriKind.Relative);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Language Uri Error: {ex}");
                Console.WriteLine($"Used default {GlobalSettings.DefaultCultureCode}.");
                var uri = GlobalSettings.GetLanguagePath();
                dictionary.Source = new Uri(uri, UriKind.Relative);
            }

            return dictionary;
        }

        /// <summary>
        /// アプリ開始時に処理する関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {

#if DEBUG
            // デバッグ用コンソールの表示
            AllocConsole();
            //Console.SetWindowSize(30, 10);
#endif

            // 引数の解析
            Options = new CommandOptions(e.Args);
            if (Options.Help)
            {
                Options.PrintHelp();
                Console.ReadKey();
                Environment.Exit(0);
            }

            // 想定外の例外を処理するイベントハンドラを登録
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

#if PRIVATEDEBUG
            //throw new Exception("CurrentDomain_UnhandledException");
#endif

            // 重複起動の確認
            if (IsDuplicateRunning())
            {
                MessageBox.Show("This application is already running.", "Infomation", MessageBoxButton.OK, MessageBoxImage.Information);
                Environment.Exit(1);
            }


            // 言語設定
#if PRIVATEDEBUG
            var language = GetLanguage("ja");
#else
            var language = GetLanguage();
#endif
            Resources.MergedDictionaries.Add(language);
            // 動的に変えたいときは、変えたいところに以下コード挿入
            //Application.Current.Resources.MergedDictionaries[0] = dictionary;

            // 初めに表示するウィンドウの開始
            //Application.Run(new WindowSizeCheckerForm());
        }

        /// <summary>
        /// アプリ終了時に処理する関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            // Mutexを解放してからアプリを閉じる
            App.Mutex.ReleaseMutex();
        }

        /// <summary>
        /// 想定外の例外を処理する関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            Exception exObj = (Exception)ex.ExceptionObject;
            MessageBox.Show(exObj.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Environment.Exit(1);
        }
    }
}
