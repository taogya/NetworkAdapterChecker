using NetworkAdapterChecker.Models;
using NetworkAdapterChecker.Views;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
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
            public CommandOptions() : this(new string[0]) { }
            public CommandOptions(string[] args)
            {
                Help = args.Contains("-h");
            }

            /// <summary>
            /// ヘルプの表示オプション
            /// </summary>
            public bool Help { get; private set; } = false;

            /// <summary>
            /// ヘルプの表示
            /// </summary>
            public void PrintHelp()
            {
                Console.WriteLine($"Description of {Name}");
                Console.WriteLine($"    {Name} [-h]");
                Console.WriteLine($"        -h: show help.");
            }
        }

#if DEBUG
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
#endif
        public static string Name { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public static Mutex Mutex = new(false, App.Name);
        public static CommandOptions Options = new();

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
            // https://ja.wikipedia.org/wiki/ISO_639-1%E3%82%B3%E3%83%BC%E3%83%89%E4%B8%80%E8%A6%A7
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
                var uri = GlobalParameter.GetLanguagePath(cultureCode);
                dictionary.Source = new Uri(uri, UriKind.Relative);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Language Uri Error: {ex}");
                Console.WriteLine($"Used default {GlobalParameter.DefaultCultureCode}.");
                var uri = GlobalParameter.GetLanguagePath();
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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
#else
            // 想定外の例外を処理するイベントハンドラを登録
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif

#if PRIVATEDEBUG
            //throw new Exception("CurrentDomain_UnhandledException");
#endif

            // 引数の解析
            Options = new CommandOptions(e.Args);
            if (Options.Help)
            {
                Options.PrintHelp();
                Console.ReadKey();
                Environment.Exit(0);
            }
#if PRIVATEDEBUG
            Options.PrintHelp();
            Console.WriteLine($"Command Args:");
            foreach(string arg in e.Args) Console.WriteLine($"    {arg}");
#endif

            // 重複起動の確認
            if (IsDuplicateRunning())
            {
                MessageBox.Show("This application is already running.", "Infomation", MessageBoxButton.OK, MessageBoxImage.Information);
                Environment.Exit(1);
            }
#if PRIVATEDEBUG
            //Process.Start(Name);
#endif


            // 言語設定
            var language = GetLanguage();
            Resources.MergedDictionaries[0] = language;
#if PRIVATEDEBUG
            // システムで設定されている言語
            var nowLang = Application.Current.Resources.MergedDictionaries[0];
            Console.WriteLine($"System: {nowLang["network_adapter_checker"]}");
            // 言語切り替え(存在しない言語)
            nowLang = Application.Current.Resources.MergedDictionaries[0] = GetLanguage("xx");
            Console.WriteLine($"Default: {nowLang["network_adapter_checker"]}");
            // 英語に切り替え
            nowLang = Application.Current.Resources.MergedDictionaries[0] = GetLanguage("en");
            Console.WriteLine($"English: {nowLang["network_adapter_checker"]}");
            // 日本語に切り替え
            nowLang = Application.Current.Resources.MergedDictionaries[0] = GetLanguage("ja");
            Console.WriteLine($"Japanese: {nowLang["network_adapter_checker"]}");
#endif

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
