﻿using Unosquare.RaspberryIO.Resources;

namespace Unosquare.RaspberryIO
{
    using Camera;
    using Computer;
    using Gpio;
    using Native;
    using Bluetooth;

    /// <summary>
    /// Our main character. Provides access to the Raspberry Pi's GPIO, system and board information and Camera
    /// </summary>
    public static class Pi
    {
        private static readonly object SyncLock = new object();

        internal static string LoggerSource = typeof(Pi).Namespace;

        /// <summary>
        /// Initializes the <see cref="Pi"/> class.
        /// </summary>
        static Pi()
        {
            lock (SyncLock)
            {
                // Extraction of embedded resources
                EmbeddedResources.ExtractAll();

                // Instance assignments
                Gpio = GpioController.Instance;
                Info = SystemInfo.Instance;
                Timing = Timing.Instance;
                Spi = SpiBus.Instance;
                I2C = I2CBus.Instance;
                Camera = CameraController.Instance;
                PiDisplay = DsiDisplay.Instance;
                BT = BluetoothController.Instance;
            }
        }

        #region Components

        /// <summary>
        /// Provides access to the Raspberry Pi's GPIO as a collection of GPIO Pins.
        /// </summary>
        public static GpioController Gpio { get; }

        /// <summary>
        /// Provides information on this Raspberry Pi's CPU and form factor.
        /// </summary>
        public static SystemInfo Info { get; }

        /// <summary>
        /// Provides access to The PI's Timing and threading API
        /// </summary>
        public static Timing Timing { get; }

        /// <summary>
        /// Provides access to the 2-channel SPI bus
        /// </summary>
        public static SpiBus Spi { get; }

        /// <summary>
        /// Provides access to the functionality of the i2c bus.
        /// </summary>
        public static I2CBus I2C { get; }

        /// <summary>
        /// Provides access to the official Raspberry Pi Camera
        /// </summary>
        public static CameraController Camera { get; }

        /// <summary>
        /// Provides access to the official Raspberry Pi 7-inch DSI Display
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        public static DsiDisplay PiDisplay { get; }

        /// <summary>
        /// Provides access to the official Raspberry Bluetooth
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        public static BluetoothController BT { get; }
        #endregion

    }
}