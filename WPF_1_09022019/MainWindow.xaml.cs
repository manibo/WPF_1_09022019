using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WPF_1_09022019_xml
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> names =
            new List<string>() {
                "Microsoft",
                "Apple",
                "Oracle",
                "IBM",
                "Яндекс",
                "ТОВ \"ТЕХМЕТМАШ\"",
                "Без имени",
                "Товариство з обмеженою відповідальністю \"Артрікс Трейд\"",
                "Товариство з обмеженою відповідальністю \"Торговий дім \"Тріумф-Агро\""
            };

        ObservableCollection<string> find = new ObservableCollection<string>() { "Здесь будут отображены результаты поиска" };


        public MainWindow()
        {
            InitializeComponent();
            Find.ItemsSource = find;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();



            if (openFile.ShowDialog() == true)
            {
                find.Clear();
                FileName.Text = openFile.FileName;
                List<string> some = new List<string>();
                XDocument xDocument = XDocument.Load(openFile.FileName);

                foreach (var item in xDocument.Element("DATA").Elements("RECORD").Elements("NAME"))
                {
                    if (names.Contains(item.Value))
                    {
                        find.Add(names.Find(x => x == item.Value));
                    }



                }

                if (find.Count == 0)
                {
                    find.Add("Not Found");
                }



            }

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            find.Clear();
            find.Add("Здесь будут отображены результаты поиска");
            FileName.Clear();
        }
    }
}
