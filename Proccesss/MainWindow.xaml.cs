using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO.Enumeration;
using System.IO;

namespace Proccesss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private Process _selectedtItem;

        public Process SelectedItem
        {
            get { return _selectedtItem; }
            set { _selectedtItem = value; OnPropertyChanged(); }
        }
        public Thread newthr { get; set; }
        public Thread thrblcklist { get; set; }

        private ObservableCollection<String> _blacklstproc;

        public ObservableCollection<String> BlackList
        {
            get { return _blacklstproc; }
            set {   _blacklstproc = value; OnPropertyChanged(); }
        }


        private string _selectedtItemblck;

        public string SelectedItemblck
        {
            get { return _selectedtItemblck; }
            set { _selectedtItemblck = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Process> _proc;

        public ObservableCollection<Process> Proc
        {
            get { return _proc; }
            set
            {
                _proc = value;
                OnPropertyChanged();
            }
        }


        public MainWindow()
        {


            BlackList=new ObservableCollection<String>();

          
            Proc = new ObservableCollection<Process>(Process.GetProcesses().ToList());
            DataContext = this;

            LoadDataFromFile();
            thrblcklist = new Thread(new ThreadStart(blcklst));
            thrblcklist.IsBackground = true;
            thrblcklist.Start();

            newthr = new Thread(new ThreadStart(thr));
            newthr.IsBackground = true;
            newthr.Start();

            InitializeComponent();

        }


        public void blcklst()
        {
            while (true)
            {
                if (BlackList != null)
                {
                    var pr = Proc.Where(p => BlackList.Any(b => b == p.ProcessName)).ToList();
                    Thread.Sleep(1000);
                    foreach (Process p in pr)
                    {
                        p.Kill();
                    }
                }
            }
        }
   

        private void thr(){

            while (true) {
                Thread.Sleep(2000);
                
                Proc = new ObservableCollection<Process>(Process.GetProcesses().ToList()); }

            }





        private void SaveDataToFile()
        {
            try
            {
                
                using (StreamWriter sw = new StreamWriter("../../../blacklist.txt", true))
                {
                    sw.WriteLine(blckTextbox.Text);
                    BlackList.Add(blckTextbox.Text);
                }

                MessageBox.Show("Blackliste add olundu");
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
        }



        private void LoadDataFromFile()
        {
            if (!File.Exists("../../blacklist.txt"))
            {
                MessageBox.Show("File tapilmadi");
                return;
            }

            try
            {
                
                using (StreamReader sr = new StreamReader("../../../blacklist.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                       if(!string.IsNullOrEmpty(line))
                        BlackList.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void EndClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedItem.Kill();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
         
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Textbox.Text)) MessageBox.Show("Textbox empty");
            else
            {var pr = new Process();
                try
                {
                   pr = Process.Start(Textbox.Text);
                }
                catch (Exception ex)
                {

                   MessageBox.Show(ex.ToString());
                }
               Proc.Add(pr);
               
            }
        }

        private void ClearFile()
        {
            
            File.WriteAllText("../../../blacklist.txt", string.Empty);
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            SaveDataToFile();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedItemblck) )
            {
                try
                {
                    BlackList.Remove(SelectedItemblck);
                    ClearFile();
                    foreach (var item in BlackList)
                    { 
                        using (StreamWriter sw = new StreamWriter("../../../blacklist.txt", true))
                        {
                            sw.WriteLine(item);
                          
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                

           

            }

        }
    }
}