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
using System.Windows.Navigation;
using System.Windows.Shapes;

using RBMessageManager.ViewModels;


namespace RBMessageManager.Views
{
    /// <summary>
    /// Interaction logic for PrimaryPage.xaml
    /// </summary>
    public partial class PrimaryView : Page
    {
        public PrimaryView()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<Model.Message> msgList = new List<Model.Message>();
            SQLiteHelpers helper = new SQLiteHelpers();

            // for(int i = 0; i < MessageGrid.Items.Count; i++)
            //{
            //    msgList.Add(MessageGrid.Items[i] as Model.Message);
            //}
            // foreach(Model.Message m in msgList)
            //{
            //    helper.UpdateMessage(m);
            //}
        }

        private void NewMessage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown(0);
        }

        private void NewType_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void PopupSubmit_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void PopupCancel_Click(object sender, RoutedEventArgs e)
        //{
            
        //}
    }
}
