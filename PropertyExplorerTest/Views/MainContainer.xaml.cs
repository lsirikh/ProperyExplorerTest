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

namespace PropertyExplorerTest.Views
{
    /// <summary>
    /// Interaction logic for MainContainer.xaml
    /// </summary>
    public partial class MainContainer : UserControl
    {
        public MainContainer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MVVM 패턴으로 구현하려면 어떻게 접근해야될까요?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is ScrollViewer viewer))
                return;

            CanvasListBox.UnselectAll();
        }
    }
}
