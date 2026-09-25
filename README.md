# Maro282-Assignment-4

Assignment repo for assignment/1-4 (Assignment 4)

# Academy Schedule Analyzer

Student Name: Marwan Abdelhamied Hassan
Cohort: Advanced .NET Engineering Diploma
Assignment : 4

## Project

# Schedule Academy Analyzer

A C# console application built to manage, explore, and analyze an academy schedule while practicing different C# programming concepts.

The application provides an interactive console menu with multiple options for working with sessions, their dates, times, durations, and details.

## Features

- Display all academy sessions
- Display session dates, start times, and durations
- Find the next upcoming session
- Find previous/past sessions
- Search for a specific session
- Display detailed session information
- Check for upcoming sessions
- Calculate total and average session duration
- Find the shortest and longest session
- Generate a schedule report using `string`
- Generate the same report using `StringBuilder`
- Interactive console menu with multiple operations

## Data Structure

The schedule is represented using three fixed arrays:

```text
sessionNames
startTimes
durations
```

The same index in all three arrays represents the same session.

For example:

```text
sessionNames[0]
startTimes[0]
durations[0]
      ↓
   Session 1
```

## C# Concepts Practiced

This project was also used to practice and apply several C# concepts, including:

- Methods and return values
- `ref` and `out` parameters
- `params`
- Tuples
- Arrays and array operations
- Searching and sorting
- `DateTime` and `TimeSpan`
- User input and validation
- `string` and `StringBuilder`
- `StringBuilder` capacity and mutability
- Building reusable functions
- Performance and memory considerations

## String vs StringBuilder

The project includes two implementations for generating the schedule report:

- Using `string` concatenation
- Using `StringBuilder`

The goal is to understand how both approaches work, when each one is appropriate, and how repeated string modifications can affect allocations and performance.

## Benchmarking

`BenchmarkDotNet` is used to compare `string` concatenation and `StringBuilder` performance with different iteration counts.

The benchmarks help demonstrate differences in:

- Execution time
- Memory allocations
- Performance as the amount of string manipulation increases

## Technologies

- C#
- .NET
- Console Application
- BenchmarkDotNet

## Purpose

This project is a practical exercise focused on applying C# fundamentals through a real-world-style console application while exploring performance, memory allocation, and different ways of working with data and strings.

## LeetCode

LeetCode/README.md

## LinkedIn

LinkedIn/README.md

## Benchmark

BENCHMARK.md
