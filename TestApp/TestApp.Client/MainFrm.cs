using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Windows.Forms;
using TestApp.Common.Entities;
using TestApp.Entity.Service.Interfaces;

namespace TestApp.Client
{
    public partial class MainFrm : Form
    {
        //private 

        public MainFrm()
        {
            InitializeComponent();
            cmdConnect.Click += ConnectClickHandler;
        }

        private void ConnectClickHandler(object sender, EventArgs e)
        {
            var ep = new EndpointAddress("net.tcp://localhost:880/EntityService");
            var c = new ChannelFactory<IEntityService>(new NetTcpBinding(), ep);
            
            var channel = c.CreateChannel();
            if (channel != null)
            {
                txtLog.AppendText(channel.GetId().ToString(CultureInfo.InvariantCulture));

                var entity = channel.GetEntity(Guid.Empty);
                txtLog.AppendText(entity.Name);

                //entity = channel.GetEntity(Guid.Empty);
                //txtLog.AppendText(entity.UniqueKey.ToString());

            }
        }
    }
}
