Output docs/demo.gif

Set Shell "bash"
Set FontSize 14
Set Width 1200
Set Height 500
Set Theme "Dracula"

# Build quietly, then launch clean
Hide
Type "dotnet build -q"
Enter
Sleep 8s
Show

Type "dotnet run --no-build"
Enter
Sleep 1.6s

# ── Exercise 1: Single Ticket — youth ──
Type@180ms "1"
Enter
Sleep 1.1s
Type@95ms "17"
Enter
Sleep 2s
Space
Sleep 700ms

# ── Exercise 1 again: senior ──
Type@160ms "1"
Enter
Sleep 900ms
Type@110ms "70"
Enter
Sleep 2s
Space
Sleep 650ms

# ── Exercise 2: Group Ticket — 3 people ──
Type@170ms "2"
Enter
Sleep 750ms
Type@130ms "3"
Enter
Sleep 550ms
Type@150ms "4"
Enter
Sleep 500ms
Type@100ms "35"
Enter
Sleep 480ms
Type@90ms "68"
Enter
Sleep 2.2s
Space
Sleep 700ms

# ── Exercise 3: Text Repeater ──
Type@165ms "3"
Enter
Sleep 850ms
Type@75ms "Hello"
Sleep 180ms
Type@70ms " Lexicon"
Enter
Sleep 2.5s
Space
Sleep 700ms

# ── Exercise 4: Third Word ──
Type@170ms "4"
Enter
Sleep 950ms
Type@68ms "The quick"
Sleep 140ms
Type@62ms " brown fox jumps"
Enter
Sleep 2s
Space
Sleep 700ms

# ── Exercise 5: Settings — switch to Swedish ──
Type@180ms "5"
Enter
Sleep 1.3s
Down
Sleep 600ms
Enter
Sleep 1.4s
Space
Sleep 900ms

# ── Exercise 1 in Swedish ──
Type@160ms "1"
Enter
Sleep 1s
Type@100ms "12"
Enter
Sleep 2s
Space
Sleep 700ms

# ── Settings — switch back to English ──
Type@175ms "5"
Enter
Sleep 1.3s
Up
Sleep 600ms
Enter
Sleep 1.4s
Space
Sleep 700ms

# ── Exit ──
Type@200ms "0"
Enter
Sleep 1.5s
