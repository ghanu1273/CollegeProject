using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiseaseDetector
{
    public partial class Popup : Form
    {
        public Popup(string diseaseName, string diseaseCause, string diseaseSymptoms, string diseaseCure, string plantSurvival, string recoveryTime, string extraTips, double confidence)
        {
            InitializeComponent();
            
            diseaseLabel.Text = diseaseName;
            confidenceLabel.Text = $"{confidence:P2}";
            causeTextBox.Text = diseaseCause;
            symptomTextBox.Text = diseaseSymptoms;
            predictionTextBox.Text = diseaseCure;
            extraStepsTextBox.Text = extraTips;
            plantSurvivalTextBox.Text = plantSurvival;
            recoveryTimeTextBox.Text = recoveryTime;
            predictionResultOKButton.Click += (s, e) => this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void diseaseLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
