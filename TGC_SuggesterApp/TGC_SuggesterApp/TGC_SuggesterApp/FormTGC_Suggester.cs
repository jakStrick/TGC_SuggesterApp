using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TGC_ConjectureSuggesterApp
{
    public partial class FormCosmicSuggester : Form
    {
        private bool inited = false;

        public FormCosmicSuggester()
        {
            InitializeComponent();
            SetHeadings();
            CmbBoxHeight(23);
            AddListItems();
        }

        private void SetHeadings()
        {
            comboBox1.Items.Add("Select Your Intensity");
            comboBox2.Items.Add("Select Your Happiness");
            comboBox3.Items.Add("When Was Your Universal Awakening");
            comboBox4.Items.Add("Select Intensity Of Your Laughter");
            comboBox5.Items.Add("Select How World Influences You");
            comboBox6.Items.Add("Select Weight Of God On Your Soul");
            comboBox7.Items.Add("Select A Person To Deliver Your Response");
            textBox1.Text = "Select All Of Your Choices Then Press 'SEE SUGGESTION'";
            textBox2.Text = "Enter your Unique Traits";
        }

        private void AddListItems()
        {
            for (int i = 1; i < 11; i++)
            {
                comboBox1.Items.Add($"{i}");

                if (i < 6)
                    comboBox2.Items.Add($"{i}");

                comboBox3.Items.Add($"{i}");
                comboBox4.Items.Add($"{i}");
                comboBox5.Items.Add($"{i}");
                comboBox6.Items.Add($"{i}");
            }

            //comboBox6.Items.Add("When Was Your Universal Awakening");
            comboBox7.Items.Add("Snoop Dogg");
            comboBox7.Items.Add("A Stoner");
            comboBox7.Items.Add("Michael Jackson");
            comboBox7.Items.Add("Steven Hawkin");
            comboBox7.Items.Add("Carl Sagan");

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;

            inited = true;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            CosmicSuggester cosmicSuggester = SetUserEntries();
            //SetAllListsHeadings();
            DoTask(cosmicSuggester);
        }

        private CosmicSuggester SetUserEntries()
        {
            textBox1.Text = "Hang on a sec or two while I gather up advice from the great cosmic cloud.";

            CosmicSuggester cosmicSuggester = new CosmicSuggester()
            {
                Intensity = comboBox1.SelectedItem.ToString(),
                Happiness = comboBox2.SelectedItem.ToString(),
                Awakening = comboBox3.SelectedItem.ToString(),
                Laughter = comboBox4.SelectedItem.ToString(),
                Influences = comboBox5.SelectedItem.ToString(),
                Realizations = comboBox6.SelectedItem.ToString(),
                VoiceOf = comboBox7.SelectedItem.ToString(),
                Pfactors = textBox2.Text
            };

            return cosmicSuggester;
        }

        private async Task DoTask(CosmicSuggester csg)
        {
            textBox1.Text = await csg.RenderResults(csg);
            //label2.Text = csg.SocialScore.ToString("F2");
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

        private void CmbBoxHeight(int h)
        {
            // do stuff to the combo items
            SetComboBoxHeight(comboBox1.Handle, h);
            SetComboBoxHeight(comboBox2.Handle, h);
            SetComboBoxHeight(comboBox3.Handle, h);
            SetComboBoxHeight(comboBox4.Handle, h);
            SetComboBoxHeight(comboBox5.Handle, h);
            SetComboBoxHeight(comboBox6.Handle, h);
            SetComboBoxHeight(comboBox7.Handle, h);
            SetComboBoxHeight(comboBox8.Handle, h);

            comboBox1.Refresh();
            comboBox2.Refresh();
            comboBox3.Refresh();
            comboBox4.Refresh();
            comboBox5.Refresh();
            comboBox6.Refresh();
            comboBox7.Refresh();
            comboBox8.Refresh();
        }
    }
}