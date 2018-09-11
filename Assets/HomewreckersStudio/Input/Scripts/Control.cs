/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

namespace HomewreckersStudio
{
    public abstract class Control
    {
        /** Gets the control key. */
        public abstract string Key { get; }

        /** Gets the assigned input description. */
        public abstract string Input { get; }
    }
}
