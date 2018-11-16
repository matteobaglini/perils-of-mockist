# the @color[IndianRed](perils)
# of @color[GoldenRod](mockist)

---
# Who am I?
<img align="left" src="assets/doubleloop.png">
<img align="right" height="79" src="assets/avanscoperta-bianco.png">
<br /><br />
- declared @color[GoldenRod](developer) ;-)
- enthusiastic technical @color[GoldenRod](trainer/coach)
- wannabe @color[GoldenRod](entrepreneur)

---
## How many of you use mocks and mock library?

---
## How many of you have a satisfing suite of system tests?

---
# Disclaimer

---
## the talk isn't yet another classic vs mockist war

---
## ... and  does not want to demonize mock objects

---
# Relax

---
## My goal is to pinpoint to a problem I see around and how I handle it

---
## It's an opinionated solution
## Some of you might disagree

---
# Sync Testing
# Vocabulary

---
## Architecture
<img src="assets/ports-and-adapters-acceptance-testing.png">

---
## Unit Testing
<img src="assets/ports-and-adapters-unit-testing.png">

---
## Acceptance Testing
<img src="assets/ports-and-adapters-acceptance-testing.png">

---
## Integration Testing
<img src="assets/ports-and-adapters-integration-testing.png">

---
## System Testing
<img src="assets/ports-and-adapters-system-testing.png">

---
# Sync TDD
# Vocabulary

---
## Test-Driven
## Development

---
## Mock in a classic view

---
## Popularized by XP Explained and TDD by Example books

---
## Mockist TDD

---
## Need-Driven
## Design

---
## Impose an outside-in approch

---
## Impose an additional testing lib

---
## Popularized by GOOS book

---
# Example

### Access Control System

---
## Use cases:
- can access
- cannot acces
    - not valid badge
    - unknown badge

---
## Start w/ Happy Path
```csharp
using System.IO.Compression;

#pragma warning disable 414, 3021

namespace MyApplication
{
    [Obsolete("...")]
    class Program : IInterface
    {
        public static List<int> JustDoIt(int count)
        {
            Console.WriteLine($"Hello {Name}!");
            return new List<int>(new int[] { 1, 2, 3 })
        }
    }
}
```

---
# @color[GoldenRod](Thanks)