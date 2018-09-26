/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

namespace Homewreckers.Input
{
    /**
     * Interface for control objects.
     */
    public interface IControl
    {
        /** The unique identifier for this control. */
        string Key { get; }

        /** The assigned input description. */
        string Input { get; }

        /** The current value of the control. */
        float Value { get; }

        /** Is the control currently active? */
        bool IsDown { get; }

        /** Was the control activated this frame? */
        bool WasPressed { get; }

        /** Was the control deactivated this frame? */
        bool WasReleased { get; }
    }
}
