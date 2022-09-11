using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Threading;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Server.xaml
    /// </summary>
    public partial class Server : Window
    {
        static Semaphore sem;
        Thread myThread;
        FileStream? fstream = null;
        string path = "C:\\lbr\\text.txt";
        //int count = 2;
        public Server()
        {
            InitializeComponent();
            sem = new Semaphore(1, 2);
            myThread = new Thread(Read);
            myThread.Name = "поток 1";
            myThread.Start();
            InputText.Content = "";

        }

        public void Read()
        {
            sem.WaitOne();
            

            try
            {
                fstream = new FileStream(path, FileMode.Open);
                //string[] readText = File.ReadAllLines(path);
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string readText = Encoding.Default.GetString(buffer);
                char[] arr = readText.ToCharArray();
                InputText.Content = "";
                int counter = 0;
                for (int i = 0; i < readText.Length; i++)
                {
                    if (char.IsLetter(arr[i]))
                    {
                        InputText.Content += arr[i].ToString();
                        counter++;
                    }
                    if (counter == 100)
                    {
                        InputText.Content += "\n";
                        counter = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fstream?.Close();
            }
            sem.Release();
        }
    }
}
