# 🎯 Cyber Behaviour Profiler – TestApp

Welcome to the **TestApp**!  

If you're wondering, *"How do I actually test this profiler without downloading real malware onto my computer?"* — this is your answer. 

The TestApp is a safe, controlled simulator that acts exactly like different types of software. It generates the specific signals, API calls, and behaviors that our main Profiler is designed to catch. It does **not** actually harm your system, steal your data, or break your files. It just "acts the part" so you have something to monitor!

---

## 🛠️ How to Use It

Using the TestApp is super simple. You don't need any complex command-line arguments. 

1. **Start the main Profiler App** (make sure it's running as Administrator so it can see everything!).
2. **Double-click** the `TestApp.exe` (or run `dotnet run` inside the TestApp folder).
3. **Press a number key (1-4)** on your keyboard to trigger a specific behavior profile.

That's it! You can switch modes at absolutely any time. If it's halfway through a fake ransomware attack and you want to switch to the "Safe" mode, just press `2`. The app instantly stops what it's doing, cleans up, and switches gears.

---

## 🎭 The Four Testing Modes

The TestApp gives you four distinct "personalities" to test against the Profiler. 

### [1] 🛑 Malicious Mode
This is the big one. It simulates a full-blown cyber attack from start to finish. When you run this, the app will play the role of a bad actor progressing through the classic stages of an attack:
*   **Reconnaissance:** Looks around to see who is logged in and what's running.
*   **Dropping Payloads:** "Downloads" fake payloads and hides them in system folders.
*   **Persistence:** Tries to make itself start automatically with Windows.
*   **Stealing Credentials:** Searches your browser data and secure Windows storage (DPAPI/LSASS) for passwords.
*   **Exfiltration:** Zips up fake "stolen" data and pretends to send it into the cloud.
*   **Ransomware:** Rapidly creates and "encrypts" dummy files, then deletes backups to prevent recovery.
*   *...and finally tries to delete itself to hide the evidence.*

### [2] 🟢 Safe Mode
What does a regular, boring app look like? Press `2` to find out.
This mode mimics an everyday program just doing normal things. It will browse some common folders (like Documents and Pictures), make a standard connection to Google, and write a few temporary cache files. The Profiler should look at this and see absolutely nothing to worry about.

### [3] 🟡 Suspicious Mode
This mode lives in the gray area. It does things that aren't strictly malicious, but are definitely a bit weird. 
It heavily scans through your `System32` and `ProgramData` folders, rapidly writes a bunch of scratch files, spawns command prompts, and pings several external websites quickly. The Profiler should raise an eyebrow, but maybe not sound the full alarm.

### [4] 🧠 KNN Demo Mode (Machine Learning)
Want to see the AI/Machine Learning detector in action? This mode is custom-built for it!
1. When you start this mode, it behaves very quietly, slowly writing a file every few seconds.
2. **Go to the Profiler** and tell it to start recording a "Baseline" for the TestApp. Let it learn this slow, steady behavior.
3. Once the baseline is saved, go back to the TestApp and **press the Spacebar**.
4. BOOM! The app suddenly starts writing hundreds of files incredibly fast. The Profiler's KNN (K-Nearest Neighbors) algorithm should immediately realize that this sudden spike completely violates the baseline it just learned, and flag it as an anomaly!

---

## 🧹 Cleanup & Safety

Don't worry about this app leaving a mess on your computer. 
* Any "stolen" files are actually just empty text files filled with dummy data (`A`s and `0`s).
* All the temporary files, fake ransomware notes, and staging folders are created inside a dedicated temporary folder (`AppData\Local\Temp\sim_...`).
* The moment you close the app smoothly (by pressing `Q`), it automatically goes in and deletes everything it just created to leave your computer exactly how it found it.