# Sunday Unity Integration Developer Test

## Introduction

As a Unity Integration Developer, your task is to address the issues present in the project provided below and to build a functional APK for the imaginary client. The objective is to maintain the existing game without adding new levels or models, focusing solely on resolving the mentioned issues and implementing requested enhancements.

Here are the complaints of the imaginary client below:

## Issues 
### Critical Issues

- **MyEventSystem Class:** MyEventSystem class is unable to find GameAnalytics required to send level start and finish events. Although the GameAnalytics unitypackage containing the script for handling events has been imported, it is not functioning as expected.
- **Performance Issues:** Despite the game having minimal objects and scripts, performance issues persist on mobile devices.
- **Frame Rate Dependency:** Controls behave inconsistently depending on the frames per second (FPS) the game is running at.
- **Git Repository:** There are issues with the git repository as numerous irrelevant files are included in pushes.

 ### Bonus Issues
 
- **Firebase Analytics Integration:** Firebase Analytics integration is missing. I need to send the same events (start, fail, and finish) tracked by Game Analytics to Firebase too. Additional docs: https://firebase.google.com/docs/analytics/unity/start
- **Level Management:** Adding and managing new levels within the project is challenging.

## What Should be Delivered

1. A revised Unity project addressing the mentioned issues including critical issues, and optionally Bonus ones.
2. A functional APK build for Android devices or an iOS build suitable for testing.
3. The project code hosted on a private/public repository on GitHub or GitLab, with the corresponding person invited for review or a public link of repo.
4. Documentation outlining the changes made, troubleshooting steps taken, and any additional improvements implemented.
