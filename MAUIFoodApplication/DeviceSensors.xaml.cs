using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;

namespace MAUIFoodApplication;

public partial class DeviceSensors : ContentPage
{
    public DeviceSensors()
    {
        InitializeComponent();
    }

    // --- Accelerometer ---
    void OnStartAccelerometerClicked(object sender, EventArgs e)
    {
        if (!Accelerometer.Default.IsMonitoring)
        {
            Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Default.Start(SensorSpeed.UI);
        }
    }

    void OnStopAccelerometerClicked(object sender, EventArgs e)
    {
        if (Accelerometer.Default.IsMonitoring)
        {
            Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Default.Stop();
        }
    }

    void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        var data = e.Reading;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            AccelerometerLabel.Text = $"X: {data.Acceleration.X:0.00}, Y: {data.Acceleration.Y:0.00}, Z: {data.Acceleration.Z:0.00}";
        });
    }

    // --- Gyroscope ---
    void OnStartGyroscopeClicked(object sender, EventArgs e)
    {
        if (!Gyroscope.Default.IsMonitoring)
        {
            Gyroscope.Default.ReadingChanged += Gyroscope_ReadingChanged;
            Gyroscope.Default.Start(SensorSpeed.UI);
        }
    }

    void OnStopGyroscopeClicked(object sender, EventArgs e)
    {
        if (Gyroscope.Default.IsMonitoring)
        {
            Gyroscope.Default.ReadingChanged -= Gyroscope_ReadingChanged;
            Gyroscope.Default.Stop();
        }
    }

    void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        var data = e.Reading;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            GyroscopeLabel.Text = $"X: {data.AngularVelocity.X:0.00}, Y: {data.AngularVelocity.Y:0.00}, Z: {data.AngularVelocity.Z:0.00}";
        });
    }

    // --- Compass ---
    void OnStartCompassClicked(object sender, EventArgs e)
    {
        if (!Compass.Default.IsMonitoring)
        {
            Compass.Default.ReadingChanged += Compass_ReadingChanged;
            Compass.Default.Start(SensorSpeed.UI);
        }
    }

    void OnStopCompassClicked(object sender, EventArgs e)
    {
        if (Compass.Default.IsMonitoring)
        {
            Compass.Default.ReadingChanged -= Compass_ReadingChanged;
            Compass.Default.Stop();
        }
    }

    void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {
        var data = e.Reading;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            CompassLabel.Text = $"Heading: {data.HeadingMagneticNorth:0.00}°";
        });
    }

    // --- Magnetometer ---
    void OnStartMagnetometerClicked(object sender, EventArgs e)
    {
        if (!Magnetometer.Default.IsMonitoring)
        {
            Magnetometer.Default.ReadingChanged += Magnetometer_ReadingChanged;
            Magnetometer.Default.Start(SensorSpeed.UI);
        }
    }

    void OnStopMagnetometerClicked(object sender, EventArgs e)
    {
        if (Magnetometer.Default.IsMonitoring)
        {
            Magnetometer.Default.ReadingChanged -= Magnetometer_ReadingChanged;
            Magnetometer.Default.Stop();
        }
    }

    void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
    {
        var data = e.Reading;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            MagnetometerLabel.Text = $"X: {data.MagneticField.X:0.00}, Y: {data.MagneticField.Y:0.00}, Z: {data.MagneticField.Z:0.00}";
        });
    }
}
