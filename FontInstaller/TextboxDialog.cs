using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TORServices.Forms;

namespace TORServices.FormsTor
{
  public  class TextboxDialog : TextBoxButton
    {
       
        void browseButton_Click(object sender, EventArgs e)
        {

           
                  using(  FolderBrowserDialog dialog = new  FolderBrowserDialog())
                  {
                        if (dialog.ShowDialog() == DialogResult.OK )
                        {

                            this.Text = dialog.SelectedPath;
                        }

                  }
        }
        public TextboxDialog()
        {
            this.ButtonClick += browseButton_Click;
        }


    }
}
