# Ayra's Dual Apps
Based on adbGUI as adb backend threading, and Hikari Toolkit as GUI.

Most device like Samsung and OnePlus only works for cloning messenger app, idk why but some vendor like Xiaomi can clone all apps.

With this app, you can inject SAI (Split APK Installer) or any APK(s) into dual storage.

## Features
- Install any apk
- Uninstall any apps on dual app space
- Clone installed app into dual app space

## Device Supported
- Any Samsung that running OneUI 3.1

## Known Issues
### Samsung OneUI 3.1
- **NEVER** uninstall any dual apps in your settings storage, it will **Uninstall your main app** than cloned app. After that, you cannot uninstall cloned app since main base.apk are missing, then your system well bugged.
- **HOW TO FIX**: uninstall that bugged apk in this AyraDualApps on PC.
- **Workaround:** uninstall cloned app on your OneUI Launcher, or use AyraDualApps if not possible

## Screenshots
![image](https://user-images.githubusercontent.com/36266025/124391020-a610bb00-dd18-11eb-8fc5-ad16d69e7a99.png)

## Download
- [latest version](https://github.com/AyraHikari/AyraDualApps/releases/latest)

## TODO
- [x] Detect dual storage on OneUI
- [x] Detect apps on dual storage on OneUI
- [x] Can install and uninstall cloned apps on OneUI
- [x] Can clone single apk on OneUI
- [ ] Can clone apks and splitted apk on OneUI
- [ ] Support Oxygen OS 11/Hydrogen OS 11
