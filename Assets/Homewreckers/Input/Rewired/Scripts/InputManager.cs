/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using HomewreckersStudio;
using Rewired;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Homewreckers.Input
{
    /**
     * Implements the Rewired-specific part.
     */
    public sealed partial class InputManager
    {
        [Header("Properties")]

        [SerializeField]
        [Tooltip("The maximum angle for headset input.")]
        private float m_maxHeadYaw = 30f;

        /** All the currently connected joystick controllers. */
        private List<Rewired.Controller> m_joysticks;

        /** The VR headset controller. */
        private Rewired.HeadsetController m_headsetController;

        /**
         * Gets the first Rewired player.
         */
        public static Player Player
        {
            get
            {
                return ReInput.players.GetPlayer(0);
            }
        }

        /**
         * Gets the controller helper from the player.
         */
        public static Player.ControllerHelper ControllerHelper
        {
            get
            {
                return Player.controllers;
            }
        }

        /**
         * Subscribes to controller events, creates controls and controllers.
         */
        partial void AwakePartial()
        {
            m_controls = new List<IControl>();
            m_joysticks = new List<Rewired.Controller>();
            m_controllers = new List<IController>();

            ReInput.ControllerConnectedEvent += OnControllerConnected;
            ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;

            // Creates controls
            foreach (InputAction action in ReInput.mapping.Actions)
            {
                Rewired.Control control = new Rewired.Control(action);

                m_controls.Add(control);
            }

            // Initialises controllers
            AddKeyboard();
            UpdateJoysticks();

            if (XRSettings.enabled)
            {
                AddHeadsetController();
            }
        }

        /**
         * Updates the joystick list.
         */
        private void OnControllerConnected(ControllerStatusChangedEventArgs args)
        {
            Debug.Log("Controller connected: " + args.name);

            UpdateJoysticks();
        }

        /**
         * Updates the joystick list.
         */
        private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
        {
            Debug.Log("Controller disconnected: " + args.name);

            UpdateJoysticks();
        }

        /**
         * Adds the keyboard controller to the list.
         */
        private void AddKeyboard()
        {
            Rewired.Controller controller = new Rewired.Controller(ControllerHelper.Keyboard);

            m_controllers.Add(controller);
        }

        /**
         * Refreshes the joystick list.
         */
        private void UpdateJoysticks()
        {
            // Removes all joysticks from the controller list
            foreach (Rewired.Controller joystick in m_joysticks)
            {
                m_controllers.Remove(joystick);
            }

            m_joysticks = new List<Rewired.Controller>();

            // Adds existing joysticks to the controller list
            foreach (Joystick joystick in ControllerHelper.Joysticks)
            {
                Rewired.Controller controller = new Rewired.Controller(joystick);

                m_joysticks.Add(controller);
                m_controllers.Add(controller);
            }
        }

        /**
         * Adds the VR headset controller to the list if it exists.
         */
        public void AddHeadsetController()
        {
            foreach (CustomController customController in ReInput.controllers.CustomControllers)
            {
                if (String.CompareInsensitive(customController.hardwareName, "Headset"))
                {
                    Debug.Log("Adding headset controller");

                    m_headsetController = new Rewired.HeadsetController(customController, m_maxHeadYaw);

                    m_controllers.Add(m_headsetController);

                    break;
                }
            }
        }
    }
}
