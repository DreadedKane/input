/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using Homewreckers.Input;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Homewreckers
{
    /**
     * Performs unit tests on the module.
     */
    public sealed class InputTests : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Displays the value of the positive control.")]
        private Text m_positiveText;

        [SerializeField]
        [Tooltip("Displays the value of the negative control.")]
        private Text m_negativeText;

        [SerializeField]
        [Tooltip("Displays the value of the split control.")]
        private Text m_splitText;

        [SerializeField]
        [Tooltip("Displays the value of the head control.")]
        private Text m_headText;

        /** Used to display the value of the positive control. */
        private IControl m_positiveControl;

        /** Used to display the value of the negative control. */
        private IControl m_negativeControl;

        /** Used to display the value of the split control. */
        private IControl m_splitControl;

        /** Used to display the value of the head control. */
        private IControl m_headControl;

        /**
         * Runs the unit tests.
         */
        private void Start()
        {
            Debug.Log("Running unit tests");

            TestControls();
            TestControllers();

            Debug.Log("Unit tests complete");
        }

        /**
         * Verifies the test controls.
         */
        private void TestControls()
        {
            Debug.Log("Testing controls");

            m_positiveControl = TestControl("Positive", "Up Arrow");
            m_negativeControl = TestControl("Negative", "Down Arrow");
            m_splitControl = TestControl("Split", "Left Arrow/Right Arrow");
            m_headControl = TestControl("Head", "Yaw");
        }

        /**
         * Verifies the control is mapped to the input.
         */
        private IControl TestControl(string key, string input)
        {
            IControl control = InputManager.Instance.GetControl(key);

            Assert.IsNotNull(control, "Couldn't get control");

            Assert.AreEqual(control.Input, input, "Invalid input");

            return control;
        }

        /**
         * Checks the headset controller in VR mode.
         */
        private void TestControllers()
        {
            Debug.Log("Testing controllers");

            if (XRSettings.enabled)
            {
                IController headset = InputManager.Instance.GetController("Headset");

                Assert.IsNotNull(headset, "Couldn't get headset controller");
            }
        }

        /**
         * Updates the UI text.
         */
        private void Update()
        {
            m_positiveText.text = m_positiveControl.Value.ToString();
            m_negativeText.text = m_negativeControl.Value.ToString();
            m_splitText.text = m_splitControl.Value.ToString();
            m_headText.text = m_headControl.Value.ToString();
        }
    }
}
