/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using Rewired;
using System.Collections.Generic;

namespace HomewreckersStudio
{
    public sealed class RewiredControl : Control
    {
        /** Used to get the assigned element map. */
        private InputAction m_action;

        /**
         * Gets the action identifier.
         */
        public override string Key
        {
            get
            {
                return m_action.name;
            }
        }

        /**
         * Gets the assigned input description.
         */
        public override string Input
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
         * Gets the elements map for the action.
         */
        private List<ActionElementMap> ElementMaps
        {
            get
            {
                List<ActionElementMap> list = new List<ActionElementMap>();

                InputManager.MapHelper.GetElementMapsWithAction(m_action.id, true, list);

                return list;
            }
        }

        /**
         * Caches the action.
         */
        public RewiredControl(InputAction action)
        {
            m_action = action;
        }
    }
}
