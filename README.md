# Title
The perils of mockist

# Abstract
Mocking seems to be a popular choice for doing interaction base testing popularized by the GOOS book. In this talk, we're going to expose one of the problems I see using mocking style and we're going to take a look at a different approach.

# Slides
The slides are provided by GitPitch ([show](https://gitpitch.com/matteobaglini/perils-of-mockist/presentation)).

# Code
The problem is demonstrated with an example in C# on .NET Core, but it is ortogonal to the tecnology.
There are five branches that show the problem and the solution in an incremental way:
1. [starting empty projects](https://github.com/matteobaglini/perils-of-mockist/tree/starting-code)
2. [all use cases implemented with flat file as backend](https://github.com/matteobaglini/perils-of-mockist/tree/mockist-solution)
3. [add a different (tcp) backend (introduces a regression)](https://github.com/matteobaglini/perils-of-mockist/tree/add-tcp-repository)
4. [add contract test to respect LSP](https://github.com/matteobaglini/perils-of-mockist/tree/add-contract-tests)
5. [use fake test double in use case (fix the regression)](https://github.com/matteobaglini/perils-of-mockist/tree/add-fake-test-double)