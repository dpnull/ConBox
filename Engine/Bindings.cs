using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConBox
{
    public class Bindings
    {
        public List<Bindings> _bindings = new List<Bindings>();
        public string SID { get; set; }
        public char Keybind { get; set; }
        public string Name { get; set; }
        public bool IsVisible { get; set; }
        public UIManager.FocusableWindows Type { get; set; }

        public void AddBinding(string sid, char keybind, string name, bool isVisible, UIManager.FocusableWindows type)
        {
            Bindings binding = new Bindings();
            binding.SID = sid;
            binding.Keybind = keybind;
            binding.Name = name;
            binding.IsVisible = isVisible;
            binding.Type = type;

            _bindings.Add(binding);
        }

        /// <summary>
        /// Automatically show available keybinds based on the currently focused window.
        /// </summary>
        /// <param name="type">Currently focused window.</param>
        public void AutoShow(UIManager.FocusableWindows type)
        {
            for (int i = 0; i < _bindings.Count; i++)
            {
                if(_bindings[i].Type == type)
                {
                    _bindings[i].IsVisible = true;
                } else
                {
                    _bindings[i].IsVisible = false;
                }
            }
        }

        /// <summary>
        /// Retrieve a keybind from the list.
        /// </summary>
        /// <param name="sid">String id of the keybind.</param>
        /// <returns>Returns an existing keybind from the list.</returns>
        public char GetKeybind(string sid)
        {
            foreach (Bindings binding in _bindings)
            {
                if (sid == binding.SID  && binding.IsVisible)
                {
                    return binding.Keybind;
                }
            }

            return '\0';
        }

        /// <summary>
        /// Retrieve a keybind from the list.
        /// </summary>
        /// <param name="sid">String id of the keybind.</param>
        /// <param name="windowType">Enabled under passed window types.</param>
        /// <returns>Returns an existing keybind from the list based on whether the passed window type is focused.</returns>
        public char GetKeybind(string sid, UIManager.FocusableWindows windowType)
        {
            foreach (Bindings binding in _bindings)
            {
                if (sid == binding.SID && binding.Type == windowType)
                {
                    return binding.Keybind;
                }
            }

            return '\0';
        }

        /// <summary>
        /// Return ready to use string for the bindings window.
        /// </summary>
        /// <returns></returns>
        public string PrintBinding()
        {

            return $"{Keybind}) {Name}";
        }
    }


}
