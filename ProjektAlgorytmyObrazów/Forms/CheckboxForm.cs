using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektAlgorytmyObrazów.Forms
{
    internal class CheckboxForm:Form
    {
        private Form form;
        private CheckBox checkBox;
        private Button confirmButton;

        public CheckboxForm(string checkboxLabel)
        {
            // Inicjalizacja obiektu Form
            form = new Form
            {
                Text = "Checkbox Form",
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Inicjalizacja obiektu CheckBox
            checkBox = new CheckBox
            {
                Text = checkboxLabel,
                TextAlign = ContentAlignment.MiddleCenter,
                Checked = false,
                Location = new System.Drawing.Point(75, 30)
            };

            // Inicjalizacja obiektu Button
            confirmButton = new Button
            {
                Text = "Zatwierdź",
                DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(100, 70)
            };
            confirmButton.Click += ConfirmButtonClick;

            // Dodanie kontrol do formularza
            form.Controls.Add(checkBox);
            form.Controls.Add(confirmButton);
        }

        // Metoda otwierająca okno
        public DialogResult ShowDialog()
        {
            return form.ShowDialog();
        }

        // Metoda zwracająca stan checkboxa
        public bool GetCheckboxState()
        {
            return checkBox.Checked;
        }

        // Obsługa zdarzenia kliknięcia przycisku "Zatwierdź"
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            form.Close();
        }
    }
}
