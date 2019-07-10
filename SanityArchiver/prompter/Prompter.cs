using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanityArchiver.forms;

namespace SanityArchiver.prompter
{
    public class Prompter
    {
        public delegate void InputHandler(string input);


        public static void HandleInput(string message, InputHandler okButtonClick)
        {
            InputPromptForm inp = new InputPromptForm(message, null, okButtonClick);
            inp.Show();
        }
        public static void HandleInput(string message, string defaultValue, InputHandler okButtonClick)
        {
            InputPromptForm inp = new InputPromptForm(message, defaultValue, okButtonClick);
            inp.Show();
        }
        public static void HandleError(string message)
        {

        }
    }
}
