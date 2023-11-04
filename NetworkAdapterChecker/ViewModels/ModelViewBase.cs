using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace NetworkAdapterChecker.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// プロパティの値を変更したら実行する関数
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// プロパティのsetで実行する関数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// コマンド用のヘルパークラス
        /// https://www.atmarkit.co.jp/ait/articles/1011/09/news102_3.html
        /// </summary>
        public class DelegateCommand : ICommand
        {
            public event EventHandler? CanExecuteChanged;
            [XmlIgnore]
            public Action<object>? ExecuteHandler { get; set; }
            [XmlIgnore]
            public Func<object, bool>? CanExecuteHandler { get; set; }

            /// <summary>
            /// コマンドの実行可否を判定する関数
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public bool CanExecute(object parameter)
            {
                var d = CanExecuteHandler;
                return d == null || d(parameter);

            }

            /// <summary>
            /// コマンドを実行する関数
            /// </summary>
            /// <param name="parameter"></param>
            public void Execute(object parameter)
            {
                ExecuteHandler?.Invoke(parameter);
            }

            /// <summary>
            /// コマンドの実行可否を変更したときに実行する関数
            /// </summary>
            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, null);
            }
        }

        //enum型をコンボボックスへ反映　https://www.atmarkit.co.jp/ait/articles/1711/08/news018.html
        //Enumの列挙　https://webbibouroku.com/Blog/Article/enum-for-each
        /// <summary>
        /// enum型をコンボボックスでバインドできるように変換します。
        /// </summary>
        static public class EnumBinding
        {
            static public Dictionary<TEnum, string?> GenerateEnumDic<TEnum>() where TEnum : struct
            {
                Dictionary<TEnum, string?> dic = new();
                foreach (TEnum val in Enum.GetValues(typeof(TEnum)))
                {
                    dic.Add(val, val.ToString());
                }
                return dic;
            }
        }

    }
}
