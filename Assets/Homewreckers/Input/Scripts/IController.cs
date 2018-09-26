/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

namespace Homewreckers.Input
{
    /**
     * Interface for controller objects.
     */
    public interface IController
    {
        /** The unique identifier for this controller. */
        string Key { get; }
    }
}
