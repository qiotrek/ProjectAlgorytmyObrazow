using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Forms
{
    internal class SelectForm : Form
    {
        private Form form;
        private ComboBox comboBox;
        private TextBox additionalTextBox;
        private Button confirmButton;
        private Label comboBoxLabel;
        private Label additionalTextBoxLabel;

        public SelectForm()
        {
            form = new Form
            {
                Text = "Select Form",
                Width = 300,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            comboBoxLabel = new Label
            {
                Text = "Ramka",
                Location = new Point(20, 30)
            };

            comboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Items = { "CONSTANT", "REFLECT", "WRAP" },
                Location = new Point(75, 30)
            };
            comboBox.SelectedIndexChanged += ComboBoxSelectedIndexChanged;

            additionalTextBoxLabel = new Label
            {
                Text = "Wartość",
                Location = new Point(20, 70),
                Visible = false
            };

            additionalTextBox = new TextBox
            {
                Location = new Point(75, 70),
                Visible = false
            };

            confirmButton = new Button
            {
                Text = "Zastosuj",
                DialogResult = DialogResult.OK,
                Location = new Point(100, 120)
            };
            confirmButton.Click += ConfirmButtonClick;

            form.Controls.Add(comboBoxLabel);
            form.Controls.Add(comboBox);
            form.Controls.Add(additionalTextBoxLabel);
            form.Controls.Add(additionalTextBox);
            form.Controls.Add(confirmButton);
        }

        public DialogResult ShowDialog()
        {
            return form.ShowDialog();
        }

        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            additionalTextBox.Visible = additionalTextBoxLabel.Visible = comboBox.SelectedItem.ToString() == "CONSTANT";
        }

        public string GetSelectedOption()
        {
            return comboBox.SelectedItem.ToString();
        }

        public int GetAdditionalValue()
        {
            if (int.TryParse(additionalTextBox.Text, out int value))
            {
                if (value >= 0 && value <= 255)
                {
                    return value;
                }
            }
            return 0;
        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            form.Close();
        }
    }
}
