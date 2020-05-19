using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectMasini_FormsT7
{
    public partial class Modifica : Form
    {
        public Modifica()
        {
            InitializeComponent();
        }

        

        public string getId()
        {
            return idTxt.Text;
        }

        private void Modifica_Load(object sender, EventArgs e)
        {

        }

        

        private void okBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTxt.Text);
            getId();
            this.Close();
        }
    }
}
