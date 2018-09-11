/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using Rewired;
using System.Collections.Generic;
using UnityEngine;

namespace HomewreckersStudio
{
    public sealed partial class InputManager
    {
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
         * Get's the player's map helper.
         */
        public static Player.ControllerHelper.MapHelper MapHelper
        {
            get
            {
                return Player.controllers.maps;
            }
        }

        /**
         * Gets the control with the given key.
         */
        partial void GetControlPartial(ref Control reference, string key)
        {
            foreach (Control control in m_controls)
            {
                if (String.CompareInsensitive(control.Key, key))
                {
                    reference = control;

                    break;
                }
            }
        }

        /**
         * Subscribes to controller events and creates controls.
         */
        partial void AwakePartial()
        {
            // Subscribes to controller connection events.
            ReInput.ControllerConnectedEvent += OnControllerConnected;
            ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;

            // Creates controls
            m_controls = new List<Control>();

            foreach (InputAction action in ReInput.mapping.Actions)
            {
                RewiredControl control = new RewiredControl(action);

                m_controls.Add(control);
            }
        }

        /**
         * Prints a log statement.
         */
        private void OnControllerConnected(ControllerStatusChangedEventArgs args)
        {
            Debug.Log("Controller connected: " + args.name);
        }

        /**
         * Prints a log statement.
         */
        private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
        {
            Debug.Log("Controller disconnected: " + args.name);
        }
    }
}
