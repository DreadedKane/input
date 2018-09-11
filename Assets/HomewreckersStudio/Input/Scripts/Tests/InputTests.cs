/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.Assertions;

namespace HomewreckersStudio
{
    public sealed class InputTests : MonoBehaviour
    {
        /**
         * Runs the unit tests.
         */
        private void Start()
        {
            Debug.Log("Running unit tests");

            TestControls();

            Debug.Log("Unit tests complete");
        }

        /**
         * Verifies the test controls.
         */
        private void TestControls()
        {
            Debug.Log("Testing controls");

            TestControl("Positive", "Up Arrow");
            TestControl("Negative", "Down Arrow");
            TestControl("Split", "Left Arrow/Right Arrow");
        }

        /**
         * Verifies the control is mapped to the input.
         */
        private void TestControl(string key, string input)
        {
            Control control = InputManager.Instance.GetControl(key);

            Assert.IsNotNull(control, "Couldn't get control");

            Assert.AreEqual(control.Input, input, "Invalid input");
        }
    }
}
