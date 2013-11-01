using System.Windows.Forms;

namespace TestApp
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            var shManager = new ServiceHostManager();
            shManager.Start();
        }
    }
}
