using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver
{
    public class Prompter
    {
        public delegate void InputHandler(string input);


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
    }
}
