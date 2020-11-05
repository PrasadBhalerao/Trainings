using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.PeerToPeer;

namespace PeerToPeerSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NodeNameLabel.Text = Guid.NewGuid().ToString("n").Substring(0, 8);
            Task.Run(() =>
            {
                
            });
        }

        private void StartCalculatingButton_Click(object sender, EventArgs e)
        {
            var peerName = new PeerName(NodeNameLabel.Text);
            var peerNameRegistration = new PeerNameRegistration(peerName, 80);
            peerNameRegistration.Start();
            var fullPeerName = peerName.ToString();
            BroadcastFullPeerName(fullPeerName);
        }

        private void BroadcastFullPeerName(string fullPeerName)
        {

        }

        private void StartCalculating()
        {
            for (var i = 0; i < int.MaxValue; i++)
            {
                var j = i / 2;
            }
        }
    }
}
