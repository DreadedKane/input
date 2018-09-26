/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using HomewreckersStudio;
using Rewired;
using UnityEngine;

namespace Homewreckers.Input.Rewired
{
    /**
     * Custom Rewired controller using head yaw as input.
     */
    public sealed class HeadsetController : Controller
    {
        /** Used to set the axis value. */
        private CustomController m_controller;

        /** The maximum yaw angle. */
        private float m_maxAngle;

        /** Used to set the axis value on the controller. */
        private int m_elementID;

        /**
         * Initialises the controller.
         */
        public HeadsetController(CustomController controller, float maxAngle) : base(controller)
        {
            m_controller = controller;
            m_maxAngle = maxAngle;

            foreach (ControllerElementIdentifier element in m_controller.ElementIdentifiers)
            {
                if (String.CompareInsensitive(element.name, "Yaw"))
                {
                    m_elementID = element.id;

                    break;
                }
            }

            ReInput.InputSourceUpdateEvent += OnInputUpdate;
        }

        /**
         * Unsubscribes from input updates.
         */
        ~HeadsetController()
        {
            ReInput.InputSourceUpdateEvent -= OnInputUpdate;
        }

        /**
         * Sets the headset yaw value on the controller.
         */
        private void OnInputUpdate()
        {
            Camera camera = Camera.main;

            if (camera)
            {
                float cameraYaw = Math.ClampAngle(camera.transform.localEulerAngles.y);
                float yaw = Mathf.Clamp(cameraYaw / m_maxAngle, -1f, 1f);

                m_controller.SetAxisValue(m_elementID, yaw);
            }
        }
    }
}
