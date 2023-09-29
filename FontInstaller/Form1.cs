namespace FontInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> lstFont = new List<string>() { "FNT", "FON", "FOT", "OTF", "TTC", "TTC", "TXF", "TTF", "PFM" };
        string path1, path2;
        void FilesFontByFont(bool MoveFile = false)
        {
            bool move = MoveFile;
            lblStatus.Invoke(new Action(() => { lblStatus.Text = "Status:\nRuning.."; }));
            var Files = (from file in System.IO.Directory.GetFiles(path1, "*.*", System.IO.SearchOption.AllDirectories)
                         where lstFont.Contains(System.IO.Path.GetExtension(file).ToUpper().TrimStart('.'))
                         select file).ToList();
            if (Files.Count > 0)
            {
                Files.ForEach(f =>
                {
                    System.Threading.Thread.Sleep(100);
                    try
                    {
                        string _f = path2 + "\\" + System.IO.Path.GetFileName(f);
                        if (move)
                        {
                            lblStatus.Invoke(new Action(() => { lblStatus.Text = "Status:\nMaving.." + f; }));
                            System.IO.File.Move(f, _f);
                        }
                        else
                        {
                            lblStatus.Invoke(new Action(() => { lblStatus.Text = "Status:\nCopying.." + f; }));
                            System.IO.File.Copy(f, _f);
                        }

                    }
                    catch (Exception e)
                    {
                        lblStatus.Invoke(new Action(() => { lblStatus.Text = "Status:\nError:" + e.Message; }));
                    }
                });
            }
            lblStatus.Invoke(new Action(() => { lblStatus.Text = "Status:\nComplete.."; }));
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(path1) || !System.IO.Directory.Exists(path2)) return;
            Task.Factory.StartNew(() => FilesFontByFont(true));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(path1) || !System.IO.Directory.Exists(path2)) return;
            Task.Factory.StartNew(() => FilesFontByFont(false));
        }

        private void textboxDialog3_TextChanged(object sender, EventArgs e)
        {
            path1 = txtPathS.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void textboxDialog4_TextChanged(object sender, EventArgs e)
        {
            path2 = txtPathT.Text;
        }



    }
}