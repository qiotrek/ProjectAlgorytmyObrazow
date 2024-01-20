using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Forms
{
    internal class MedianForm : Form
    {
        private Form form;
        private ComboBox masksComboBox;
        private ComboBox frameComboBox;
        private TextBox frameValueTextBox;
        private Button confirmButton;
        private Label masksComboBoxLabel;
        private Label frameComboBoxLabel;
        private Label frameValueLabel;

        public MedianForm()
        {
            form = new Form
            {
                Text = "Multi-Select Form",
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            masksComboBoxLabel = new Label
            {
                Text = "Maski",
                Location = new Point(20, 30)
            };

            masksComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "3x3", "5x5", "7x7","9x9" },
                Location = new Point(175, 30)
            };

            frameComboBoxLabel = new Label
            {
                Text = "Ramka",
                Location = new Point(20, 60)
            };

            frameComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "CONSTANT", "REFLECT", "WRAP" },
                Location = new Point(175, 60)
            };
            frameComboBox.SelectedIndexChanged += FrameComboBoxSelectedIndexChanged;

            frameValueLabel = new Label
            {
                Text = "Wartość",
                Location = new Point(20, 90),
                Visible = false
            };

            frameValueTextBox = new TextBox
            {
                Location = new Point(75, 90),
                Visible = false
            };

            confirmButton = new Button
            {
                Text = "Zatwierdź",
                DialogResult = DialogResult.OK,
                Location = new Point(100, 120),
                Enabled = false
            };
            confirmButton.Click += ConfirmButtonClick;

            form.Controls.Add(masksComboBoxLabel);
            form.Controls.Add(masksComboBox);
            form.Controls.Add(frameComboBoxLabel);
            form.Controls.Add(frameComboBox);
            form.Controls.Add(frameValueLabel);
            form.Controls.Add(frameValueTextBox);
            form.Controls.Add(confirmButton);
        }

        public DialogResult ShowDialog()
        {
            return form.ShowDialog();
        }

        private void FrameComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            bool isConstantSelected = frameComboBox.SelectedItem.ToString() == "CONSTANT";
            frameValueLabel.Visible = frameValueTextBox.Visible = isConstantSelected;
            confirmButton.Enabled = !isConstantSelected || (isConstantSelected && IsValidFrameValue());
        }

        private bool IsValidFrameValue()
        {
            if (int.TryParse(frameValueTextBox.Text, out int value))
            {
                return value >= 0 && value <= 255;
            }
            return false;
        }

        public int GetSelectedMedian()
        {
            int median;

            switch (masksComboBox.SelectedIndex)
            {
                case 0:
                    median = 3;
                    break;
                case 1:
                    median = 5;
                    break;
                case 2:
                    median = 7;
                    break;
                case 3:
                    median = 9;
                    break;
                default:
                    median = 3;
                    break;
            }
            return median;
        }

        public int GetSelectedBorder()
        {
            return frameComboBox.SelectedIndex;
        }

        public int GetFrameValue()
        {
            return IsValidFrameValue() ? int.Parse(frameValueTextBox.Text) : 0;
        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            form.Close();
        }

    }
}
