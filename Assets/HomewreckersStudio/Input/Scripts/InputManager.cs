/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;

namespace HomewreckersStudio
{
    public sealed partial class InputManager : MonoBehaviour
    {
        partial void Internal();

        /**
         * Defers to installed InputManager.
         */
        private void Awake()
        {
            Internal();
        }
    }
}
