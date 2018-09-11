/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System.Collections.Generic;

namespace HomewreckersStudio
{
    public sealed partial class InputManager : Singleton<InputManager>
    {
        /** Used to get specific controls. */
        private List<Control> m_controls;

        /**
         * Gets the control for the given key.
         */
        public Control GetControl(string key)
        {
            Control control = null;

            GetControlPartial(ref control, key);

            return control;
        }

        /** Implemented in input module. */
        partial void GetControlPartial(ref Control reference, string key);

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
    }
}
