# Sonic4Ep1-WP7-Decompilation
Decompilation of Sonic 4 Episode 1 for Windows Phone 7

# Issues
## Game is unplayable due to collision bugs. I'm assuming these are rounding/truncation errors due to type casts added to fix the build.
Need to review the changes made in the history and port over the fixes.
## AppMain.cs is still way too big and causes VS to lag pretty badly compared to normal.
## The game is made for touch controls which makes it hard to play on PC, however I have hacked in mouse controls for the time being.
