/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using RewiredController = Rewired.Controller;

namespace Homewreckers.Input.Rewired
{
    /**
     * Rewired controller implementation.
     */
    public class Controller : IController
    {
        /** Used to get the controller key. */
        private RewiredController m_controller;

        /**
         * Gets the unique identifier for the controller.
         */
        public string Key
        {
            get
            {
                return m_controller.hardwareName;
            }
        }

        /**
         * Initialises the controller.
         */
        public Controller(RewiredController controller)
        {
            m_controller = controller;
        }
    }
}
