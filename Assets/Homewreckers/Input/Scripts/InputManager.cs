/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using HomewreckersStudio;
using System.Collections.Generic;

namespace Homewreckers.Input
{
    /**
     * Gets controls and controllers.
     */
    public sealed partial class InputManager : Singleton<InputManager>
    {
        /** Used to get specific controls. */
        private List<IControl> m_controls;

        /** Used to get specific controllers. */
        private List<IController> m_controllers;

        /**
         * Gets the control for the given key.
         */
        public IControl GetControl(string key)
        {
            foreach (IControl control in m_controls)
            {
                if (String.CompareInsensitive(control.Key, key))
                {
                    return control;
                }
            }

            return null;
        }

        /**
         * Gets the controller for the given key.
         */
        public IController GetController(string key)
        {
            foreach (IController controller in m_controllers)
            {
                if (String.CompareInsensitive(controller.Key, key))
                {
                    return controller;
                }
            }

            return null;
        }

        /**
         * Defers to input module.
         */
        protected override void Awake()
        {
            base.Awake();

            AwakePartial();
        }

        /** Implemented in input module. */
        partial void AwakePartial();

        /**
         * Defers to input module.
         */
        private void Start()
        {
            StartPartial();
        }

        /** Implemented in input module. */
        partial void StartPartial();
    }
}
