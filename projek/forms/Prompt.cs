using System;
using System.Windows.Forms;

namespace ToDoListApp.Forms
{
    public static class Prompt
    {
        public static string ShowDialog(string title, string message, string defaultText = "")
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 10, Top = 10, Text = message, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 260, Text = defaultText };
            Button confirmation = new Button() { Text = "OK", Left = 200, Width = 70, Top = 60 };
            confirmation.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}
