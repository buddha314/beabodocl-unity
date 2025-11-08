# Quest 3 Local Deployment Guide

This guide covers the complete process of deploying the beabodocl-unity application to a Meta Quest 3 headset for local testing and development.

## Prerequisites

### Hardware Requirements
- Meta Quest 3 headset
- USB-C cable (USB 3.0 or higher recommended for faster deployment)
- Windows/Mac/Linux development machine with Unity installed

### Software Requirements
- Unity Hub with Unity 2021.3 LTS or later
- Android SDK and NDK (installed via Unity Hub)
- Meta Quest Developer Hub (optional but recommended)
- ADB (Android Debug Bridge) - included with Android SDK

### Quest 3 Setup
1. **Enable Developer Mode**
   - Create a Meta Developer account at https://developer.oculus.com
   - Open the Meta Quest mobile app on your phone
   - Connect your Quest 3 to the mobile app
   - Go to Menu → Devices → Select your Quest 3
   - Scroll down to Developer Mode and toggle it ON
   - Restart your Quest 3 headset

2. **Enable USB Debugging**
   - Put on your Quest 3 headset
   - Go to Settings → System → Developer
   - Enable USB Connection Dialog
   - This will prompt you to allow connections when you plug in via USB

## Unity Build Configuration

### 1. Configure Build Settings

1. Open the Unity project in Unity Editor
2. Go to **File → Build Settings**
3. Select **Android** as the platform
4. Click **Switch Platform** if not already on Android
5. Ensure the following scenes are added to "Scenes in Build":
   - Your main VR scene(s)

### 2. Configure Player Settings

1. In Build Settings, click **Player Settings**
2. Configure the following settings:

#### Company and Product Settings
- **Company Name**: Your company/developer name
- **Product Name**: beabodocl-unity
- **Version**: Set your version number (e.g., 0.1.0)

#### Android-Specific Settings
- **Minimum API Level**: Android 10.0 (API Level 29) or higher
- **Target API Level**: Android 12.0 (API Level 31) or higher
- **Install Location**: Automatic
- **Write Permission**: External (SD Card)

#### XR Settings
1. Go to **Project Settings → XR Plug-in Management**
2. Enable **Oculus** (Meta Quest) for Android platform
3. In Oculus settings:
   - Set **Stereo Rendering Mode** to Multiview or Multi Pass
   - Enable **Low Overhead Mode**
   - Set **Target Devices** to include Quest 3

#### Graphics Settings
- **Graphics API**: OpenGLES3 (remove Vulkan if present for initial testing)
- **Color Space**: Linear (recommended for better visuals)
- **Multithreaded Rendering**: Enabled

#### Other Settings
- **Scripting Backend**: IL2CPP (required for ARM64)
- **ARM64**: Enabled (uncheck ARMv7 if present)
- **Target Architectures**: ARM64 only

### 3. Configure Package Identifier

1. In Player Settings → Android tab
2. Set **Package Name** to a unique identifier:
   - Format: `com.yourcompany.beabodocl`
   - Example: `com.beabodocl.unity`
   - Must be lowercase with no special characters except dots

## Building the APK

### Option 1: Build and Run (Direct Deploy)

1. Connect Quest 3 to your PC via USB-C cable
2. Put on the headset and allow USB debugging when prompted
3. In Unity: **File → Build Settings**
4. Verify Quest 3 is detected (should show in Run Device dropdown)
5. Click **Build and Run**
6. Choose a location to save the APK (e.g., `Builds/quest3/`)
7. Unity will build and automatically install to your Quest 3

### Option 2: Build APK Only

1. In Unity: **File → Build Settings**
2. Click **Build**
3. Choose output location and filename (e.g., `beabodocl-quest3-v0.1.0.apk`)
4. Wait for build to complete

## Manual Installation via ADB

If Build and Run doesn't work, or you want to manually install a pre-built APK:

### 1. Verify ADB Connection

```bash
# Navigate to Android SDK platform-tools directory or ensure ADB is in PATH
adb devices
```

You should see your Quest 3 listed. If not:
- Check USB cable connection
- Verify USB debugging is enabled on Quest 3
- Allow the USB debugging prompt in the headset

### 2. Install APK

```bash
# Install the APK
adb install -r path/to/beabodocl-quest3.apk

# The -r flag allows reinstalling and keeping existing data
```

### 3. Launch Application

```bash
# Launch the app using package name and main activity
adb shell am start -n com.yourcompany.beabodocl/com.unity3d.player.UnityPlayerActivity
```

## Debugging and Logging

### View Real-time Logs

```bash
# View Unity logs filtered
adb logcat -s Unity

# View all logs
adb logcat

# Clear log buffer
adb logcat -c
```

### Common ADB Commands

```bash
# Uninstall application
adb uninstall com.yourcompany.beabodocl

# Check installed packages
adb shell pm list packages | grep beabodocl

# Take screenshot
adb exec-out screencap -p > screenshot.png

# Record video
adb shell screenrecord /sdcard/recording.mp4
# Stop with Ctrl+C, then pull the file:
adb pull /sdcard/recording.mp4
```

## Troubleshooting

### Quest 3 Not Detected

1. **Check USB Connection**
   - Try a different USB-C cable
   - Use a USB 3.0 port directly on your PC (not a hub)
   - Ensure cable supports data transfer, not just charging

2. **Reinstall Drivers**
   - Install Meta Quest Developer Hub
   - Or manually install Oculus ADB drivers

3. **Restart ADB Server**
   ```bash
   adb kill-server
   adb start-server
   adb devices
   ```

### Build Fails

1. **Check Android SDK/NDK**
   - Unity Hub → Installs → Your Unity Version → Add Modules
   - Ensure Android Build Support with NDK & SDK tools are installed

2. **Clear Build Cache**
   - Delete `Library` folder in project
   - Delete `Temp` folder in project
   - Restart Unity and rebuild

3. **Verify Scripting Backend**
   - Must use IL2CPP for ARM64
   - Ensure ARM64 is selected in Player Settings

### Application Crashes on Launch

1. **Check Logcat Output**
   ```bash
   adb logcat -s Unity ActivityManager
   ```

2. **Common Issues**
   - Missing permissions in AndroidManifest.xml
   - Incorrect minimum API level
   - Missing XR plugin configuration
   - Graphics API incompatibility

### Performance Issues

1. **Enable Developer Overlay**
   - In headset: Settings → System → Developer
   - Enable Performance Overlay
   - Monitor frame rate and thermal throttling

2. **Optimization Settings**
   - Use Fixed Foveated Rendering
   - Reduce texture resolution
   - Optimize draw calls
   - Use occlusion culling

## Wireless Deployment (Advanced)

Once ADB is connected via USB, you can enable wireless debugging:

```bash
# Enable TCP/IP mode on port 5555
adb tcpip 5555

# Find Quest 3 IP address (in headset: Settings → Wi-Fi → Your Network → Advanced)
# Connect wirelessly
adb connect <QUEST_IP_ADDRESS>:5555

# Verify connection
adb devices

# Now you can disconnect USB cable
```

To return to USB mode:
```bash
adb usb
```

## Meta Quest Developer Hub (Optional)

Meta Quest Developer Hub provides a GUI for:
- Device management
- Application installation
- Performance monitoring
- Screen casting to PC
- File management

Download from: https://developer.oculus.com/downloads/package/oculus-developer-hub-win/

## Best Practices

1. **Version Control**
   - Tag APK builds with version numbers
   - Keep build logs for reference
   - Document any custom build configurations

2. **Testing Workflow**
   - Test on Quest 3 frequently during development
   - Use wireless deployment for faster iteration
   - Monitor performance metrics regularly

3. **Distribution**
   - For internal testing, use Meta App Lab
   - For public release, submit to Meta Quest Store
   - Consider SideQuest for community distribution

4. **Security**
   - Don't commit APK files to version control
   - Keep signing keys secure
   - Use release builds for distribution

## Next Steps

After successful deployment:
1. Test all VR interactions and hand tracking features
2. Verify XR Interaction Toolkit integration
3. Test performance and optimize as needed
4. Configure Meta Quest store listing (if planning to publish)

## Additional Resources

- [Meta Quest Developer Documentation](https://developer.oculus.com/documentation/)
- [Unity XR Documentation](https://docs.unity3d.com/Manual/XR.html)
- [Android Debug Bridge (ADB) Guide](https://developer.android.com/studio/command-line/adb)
- [Quest 3 Technical Specifications](https://www.meta.com/quest/quest-3/)

## Support

For issues specific to this project, refer to:
- Project Issues: GitHub repository issues
- Unity XR Forums: https://forum.unity.com/forums/xr.173/
- Meta Quest Developer Forums: https://forums.oculusvr.com/
