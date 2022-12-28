using System.Collections;
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
            try
            {
                NaifuClient naifuClient = new NaifuClient("http://127.0.0.1:6969/", true);
                byte[]? imageBytes = await naifuClient.PostAsync(txbTags.Text);
                if (imageBytes != null)
                    pictureBox1.Image = Image.FromStream(new MemoryStream(imageBytes));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "´íÎó");
            }
        }

        private async void WebUI()
        {
            try
            {
                WebUIClient webUIClient = new WebUIClient(13, "http://127.0.0.1:7860/");
                byte[]? imageBytes = await webUIClient.PostAsync(txbTags.Text);
                if (imageBytes != null)
                    pictureBox1.Image = new Bitmap(new MemoryStream(imageBytes));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "´íÎó");
            }
        }

        private void btnWebUI_Click(object sender, EventArgs e)
        {
            WebUI();
        }

        private void btnNaifu_Click(object sender, EventArgs e)
        {
            Naifu();
        }

        private void btnCustomWebUI_Click(object sender, EventArgs e)
        {
            CustomWebUI();
        }

        private async void CustomWebUI()
        {
            try
            {
                int fn_index =  Convert.ToInt32(txbCustomWebUIFnIndex.Text);
                CustomWebUIClient webUIClient = new CustomWebUIClient(fn_index, "http://127.0.0.1:7860/");
                byte[]? imageBytes = await webUIClient.PostAsync(txbCustomWebUIData.Text);
                if (imageBytes != null)
                    pictureBox1.Image = new Bitmap(new MemoryStream(imageBytes));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "´íÎó");
            }
        }
    }
}