# SeedWork

[Domain Drive Design](https://en.wikipedia.org/wiki/Domain-driven_design) supporting helper classes based on [Microsoft examples](https://github.com/dotnet-architecture/eShopOnContainers/tree/dev/src/Services/Ordering/Ordering.Domain/SeedWork).

[![Build](https://github.com/TheLastColonial/SeedWork/workflows/Build/badge.svg)](https://github.com/TheLastColonial/SeedWork/actions?query=workflow%3ABuild) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TheLastColonial_SeedWork&metric=alert_status)](https://sonarcloud.io/dashboard?id=TheLastColonial_SeedWork) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=TheLastColonial_SeedWork&metric=code_smells)](https://sonarcloud.io/dashboard?id=TheLastColonial_SeedWork) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TheLastColonial_SeedWork&metric=coverage)](https://sonarcloud.io/dashboard?id=TheLastColonial_SeedWork) [![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=TheLastColonial_SeedWork&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=TheLastColonial_SeedWork) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=TheLastColonial_SeedWork&metric=bugs)](https://sonarcloud.io/dashboard?id=TheLastColonial_SeedWork)

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
- coverlet.msbuild 3.0.0
- OpenCover 4.7.922

## Usages

Please refer to how DDD should be implemented at a code level.

## Components

Objects are named after core components of DDD.

### Entity

A complex model under a Aggregate Root.
