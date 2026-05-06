Output docs/demo.gif

Set Shell "bash"
Set FontSize 14
Set Width 1200
Set Height 500
Set TypingSpeed 60ms
Set Theme "Dracula"

# Build quietly, then launch clean
Hide
Type "dotnet build -q"
Enter
Sleep 8s
Show

Type "dotnet run --no-build"
Enter
Sleep 1.5s

# ── Exercise 1: Single Ticket Price — youth price ──
Type "1"
Enter
Sleep 1s
Type "17"
Enter
Sleep 1.8s
Space
Sleep 500ms

# ── Exercise 1 again: senior price ──
Type "1"
Enter
Sleep 1s
Type "70"
Enter
Sleep 1.8s
Space
Sleep 500ms

# ── Exercise 2: Group Ticket Price — 3 people ──
Type "2"
Enter
Sleep 800ms
Type "3"
Enter
Sleep 600ms
Type "4"
Enter
Sleep 600ms
Type "35"
Enter
Sleep 600ms
Type "68"
Enter
Sleep 2s
Space
Sleep 500ms

# ── Exercise 3: Text Repeater ──
Type "3"
Enter
Sleep 800ms
Type "Hello Lexicon"
Enter
Sleep 2s
Space
Sleep 500ms

# ── Exercise 4: Third Word ──
Type "4"
Enter
Sleep 800ms
Type "The quick brown fox jumps"
Enter
Sleep 1.8s
Space
Sleep 500ms

# ── Exit ──
Type "0"
Enter
Sleep 1.2s
