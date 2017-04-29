using System.Threading.Tasks;
using System.Windows;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for DialogScreen.xaml
    /// </summary>
    public partial class DialogScreen : Window
    {
        public DialogScreen()
        {
            InitializeComponent();
        }

        private void ModalDialogOk(object sender, RoutedEventArgs e)
        {
            
                Screen004 screen004 = new Screen004();
                screen004.Show();
                screen004.Topmost = true;
                Close();
           
        }
    }
}
