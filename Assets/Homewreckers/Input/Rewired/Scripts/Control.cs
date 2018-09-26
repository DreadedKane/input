/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using Rewired;
using System.Collections.Generic;

namespace Homewreckers.Input.Rewired
{
    /**
     * Rewired control implementation.
     */
    public sealed class Control : IControl
    {
        /** Used to get the assigned element map. */
        private InputAction m_action;

        /**
         * Gets the action identifier.
         */
        public string Key
        {
            get
            {
                return m_action.name;
            }
        }

        /**
         * Gets the assigned input description.
         */
        public string Input
        {
            get
            {
                string input = string.Empty;

                foreach (ActionElementMap elementMap in ElementMaps)
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        input += "/";
                    }

                    input += elementMap.elementIdentifierName;
                }

                return input;
            }
        }

        /**
         * Gets the current axis value.
         */
        public float Value
        {
            get
            {
                return InputManager.Player.GetAxis(m_action.id);
            }
        }

        /**
         * Is the button currently being pressed?
         */
        public bool IsDown
        {
            get
            {
                return InputManager.Player.GetButton(m_action.id);
            }
        }

        /**
         * Was the button pressed this frame?
         */
        public bool WasPressed
        {
            get
            {
                return InputManager.Player.GetButtonDown(m_action.id);
            }
        }

        /**
         * Was the button released this frame?
         */
        public bool WasReleased
        {
            get
            {
                return InputManager.Player.GetButtonUp(m_action.id);
            }
        }

        /**
         * Get's the player's map helper.
         */
        private Player.ControllerHelper.MapHelper MapHelper
        {
            get
            {
                return InputManager.ControllerHelper.maps;
            }
        }

        /**
         * Gets the element map for the action.
         */
        private List<ActionElementMap> ElementMaps
        {
            get
            {
                List<ActionElementMap> list = new List<ActionElementMap>();

                MapHelper.GetElementMapsWithAction(m_action.id, true, list);

                return list;
            }
        }

        /**
         * Initialises the control.
         */
        public Control(InputAction action)
        {
            m_action = action;
        }
    }
}
