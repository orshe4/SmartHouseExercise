# SmartHouseExercise

Smart house software engineering exercise
In this exercise the goal is to implement a smart house system using high level languages:
C#/Java/Python/Scala/etc.

The exercise will be divided into check points. Please use Github to keep track of changes and progress
from check point to check point, each checkpoint should have a Git tag associated with its commit.
High level description: The smart house system exposes an HTTP API to receive queries &amp; commands to
either retrieve smart devices info &amp; status or submit a command to a device, e.g. turn off/on. 

The smart house has the following devices:
- Bedroom TV
- Microwave
- Computer
- Living room TV
- Air Conditioner

Design your solutions well, there may be more devices and more queries &amp; commands, adding them
should result in minimal changes to existing code.

## Checkpoint 1

Design and Implement a console app that receives one of the following CLI commands, design the
commands syntax as you see fit:
- Query Bedroom TV status on/off
- Query Microwave status on/off
- Query Computer status on/off
- Query Living Room TV status on/off
- Query Air Conditioner status on/off
- Turn on/off Air Conditioner
- Turn on/off Bedroom TV
- Turn on/off Microware
- Turn on/off Computer
- Turn on/off Living room TV
- Turn on/off Air Conditioner
- Query Bedroom TV channel
- Query Living room TV channel
- Switch channel in Bedroom TV
- Switch channel in Living room TV
- Query Microwave degrees
- Query Air Conditioner degrees
- Set degrees and timer to Microwave, no more than 30 degrees
- Set degrees to Air Conditioner, between 10 and 30
The commands should be sent to the appropriate device and trigger the appropriate action, currently
implemented as printing an appropriate console message stating the action executed for simplicity.

Notes:
- Do not concern yourself with concurrency at this point.
- Treat the console app execution as one-time CLI command execution, no session.
