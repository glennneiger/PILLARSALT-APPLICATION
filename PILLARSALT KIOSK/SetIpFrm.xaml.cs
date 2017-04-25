using System;
using System.Linq;
using System.Windows;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for SetIpFrm.xaml
    /// </summary>
    public partial class SetIpFrm : Window
    {
        private PilaDbContext _db;

        public SetIpFrm()
        {
            InitializeComponent();
        }

        private void GetDefaultIpConfig(object sender, RoutedEventArgs e)
        {
            try
            {
                _db = new PilaDbContext();
                var profile = _db.ConnectionInfoes.First(c => c.Active == 1);
                txtIpAddress.Text = profile.IPAddress;
                txtPort.Text = profile.SocketPort.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ChangeIpAddress(object sender, RoutedEventArgs e)
        {
            try
            {
                _db = new PilaDbContext();
                var profile = _db.ConnectionInfoes.First(c => c.Active == 1);
                profile.IPAddress = txtIpAddress.Text;
                profile.SocketPort = Convert.ToUInt16(txtPort.Text);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
