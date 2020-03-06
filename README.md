# Sonic4Ep1-WP7-Decompilation
Decompilation of Sonic 4 Episode 1 for Windows Phone 7

# Issues
## Game is unplayable
The game is unplayable due to collision bugs. I'm assuming these are rounding/truncation errors due to type casts added to fix the build.
Need to review the changes made in the history and port over the fixes.
## AppMain.cs is still way too big
It's so big that it VS to lag pretty badly and sometimes even crashes it outright.
## Touch controls
The game is made for touch controls which makes it hard to play on PC, however I have hacked in mouse controls for the time being so the game logic can be tested further.
