using NovelAIClient;

namespace NovelAi_Test
{
    public partial class FrmClientTest : Form
    {
        public FrmClientTest()
        {
            InitializeComponent();
        }

        private async void Naifu()
        {
            NaifuClient naifuClient = new NaifuClient("http://127.0.0.1:6969/", true);
            byte[]? imageBytes = await naifuClient.PostAsync(txbTags.Text);
            if (imageBytes != null)
                pictureBox1.Image = Image.FromStream(new MemoryStream(imageBytes));
        }

        private async void WebUI()
        {
            WebUIClient webUIClient = new WebUIClient("http://127.0.0.1:7860/");
            byte[]? imageBytes = await webUIClient.PostAsync(txbTags.Text);
            if (imageBytes != null)
                pictureBox1.Image = new Bitmap(new MemoryStream(imageBytes));
        }

        private void btnWebUI_Click(object sender, EventArgs e)
        {
            WebUI();
        }

        private void btnNaifu_Click(object sender, EventArgs e)
        {
            Naifu();
        }
    }
}