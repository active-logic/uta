#!/bin/bash
# Setup .NET boilerplate; pass any arg to also run tests.
# For local coverage, install this:
# dotnet tool install -g dotnet-reportgenerator-globaltool
rm -rf ../../DotNet && mkdir ../../DotNet
set -euxo pipefail
howl Howl/Editor/Ng ../../DotNet/CLI
cd ../../DotNet
dotnet new solution --name "Main"
dotnet new console --name "CLI" --force  && rm CLI/Program.cs
dotnet sln add "CLI/CLI.csproj"
dotnet build --project CLI/CLI.csproj
