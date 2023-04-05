using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PYS.Application.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PYS.Security.TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PYSSecurity.Encrypt(TxtCleanText.Text, "AGARAMUDHALA", "EZHUTHELLAM", "SHA1", 3, "1B2c3D4e5F6g7H8", 256);
            //encryptedstring = cryptObj.Encrypt(username, "AGARAMUDHALA", "EZHUTHELLAM", "SHA1", 3, "@1B2c3D4e5F6g7H8", 256);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PYSSecurity.Decrypt(TxtEncyriptText.Text, "AGARAMUDHALA", "EZHUTHELLAM", "SHA1", 3, "1B2c3D4e5F6g7H8", 256);
        }
    }
}
