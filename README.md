# SeedWork
![SeedWork Github Action Status](https://github.com/TheLastColonial/SeedWork/workflows/SeedWork/badge.svg)
[Domain Drive Design](https://en.wikipedia.org/wiki/Domain-driven_design) supporting helper classes based on [Microsoft examples](https://github.com/dotnet-architecture/eShopOnContainers/tree/dev/src/Services/Ordering/Ordering.Domain/SeedWork).

## Installation

1. Clone repository
2. Create NuGet package
3. Install resultant NuGet into your target project

## Dependencies

### Source

- DotNet Standard 2.1

### Tests

- DotNet Core 3.1
- NUnit 3.12.0
  - NUnit Test Adapter 3.16.1
- Microsoft.NET.Test.Sdk 16.5.0
- FluentAssersions 5.10.3

## Usages

Please refer to how DDD should be implemented at a code level.

## Components

Objects are named after core components of DDD.

### Entity

A complex model under a Aggregate Root.
