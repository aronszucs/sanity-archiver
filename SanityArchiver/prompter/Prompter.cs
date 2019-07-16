using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanityArchiver.form;

namespace SanityArchiver.prompter
{
    public class Prompter
    {
        public delegate void InputHandler(string input);
        private static Prompter Instance = new Prompter();
        public static Prompter GetInstance()
        {
            return Instance;
        }

        public void HandleInput(string message, InputHandler okButtonClick)
        {
            InputPromptForm inp = new InputPromptForm(message, null, okButtonClick);
            inp.Show();
        }
        public void HandleInput(string message, string defaultValue, InputHandler okButtonClick)
        {
            InputPromptForm inp = new InputPromptForm(message, defaultValue, okButtonClick);
            inp.Show();
        }
        public void HandleError(Exception e)
        {
            HandleError(e.Message);
        }
        public void HandleError(string msg)
        {
            DisplayMessage("Error", msg);
        }
        public void DisplayMessage(string label, string msg)
        {
            MessageForm mf = new MessageForm(label, msg);
        }
    }
}
