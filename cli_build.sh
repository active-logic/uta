#!/bin/bash
# Setup .NET boilerplate; pass any arg to also run tests.
# For local coverage, install this:
# dotnet tool install -g dotnet-reportgenerator-globaltool
rm -rf ../../DotNet && mkdir ../../DotNet
set -euo pipefail
cp -r ~build/Howl/Editor/Ng ../../DotNet/CLI
cd ../../DotNet
dotnet new solution --name "Main"
dotnet new console --name "CLI" --force  && rm CLI/Program.cs
dotnet sln add "CLI/CLI.csproj"
dotnet run --project CLI/CLI.csproj
