namespace VideoP
{
    public partial class FORM : Form
    {
        private Configs Configs;
        private Player Player;

        public FORM()
        {
            InitializeComponent();
            Configs = new Configs();
            Player = new Player(Configs);

            textBox1.Text = Configs.VideoFolderPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player.PlayRandomVideo(richTextBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}